/*
 *  The Ultimate Pig Latin Project - 2017 - Daniel Vest
 *  
 * Requirements:
 * .NET 4 and up
 * system.speech added to references
 * speechlib DLL added to references
 * 
 * 
 * Purpose:
 *   Demo of speech recognition, text to speach API's and string manipulation
 * 
 *    Pig Latin Rules:
 *      If the word begins with a consonant put the first letter of the word at the end and add 'ay'
 *      if the word begins with a vowel just add 'ay'
 *      contractions are converted to their full lenght text (i.e. "can't" "can not") I did this 
 *            because I couldn't figure where to put the apostrophe back in.
 *      All possesive S's are kept at the end of the word, after the "ay" (i. e. "Daniel's" "Anielday's"
 *             not "Anielsday"
 *      Consonants that are blends are treated as one letter (i. e. "brush" to "ushbray", "thrush" to "ushthray"
 * 
 * Features:
 * 
 *   Translates entire sentences typed into the textbox 
 *   Listens for dictation and translates on hearing keyword
 *   pronounces both the original and the pig latin translation
 *   allows you to copy the pig latin text to the clipboard
 *   Slider bar to change the speed of the sound output
 *   
 * Not yet implemented:
 *   read and translate from a file
 *   save sound output as .wav file
 * 
 *Known Bugs:
 * 
 * If punctuation does not have a letter on one side and a space on the other side it is not processed right.
 * badly in need of error checking - crashes if the system doesn't have the speech libs installed.
 * double punctuation will confuse it (( for example.
 * not very object oriented - needs re-vamped with some objects
 * 
 * Notes:
 * The preformance of the speech to text routine relies largely on training the Microsoft's speech 
 * recognizer to an individual's voice. You can use the control panel apps to train it:
 * 
 * Windows 8 & 10:
 *  control panel>sound and hardware>Ease of Access>speech recognition
 * 
 *  Other Windows systems:
 *  control panel>sound and hardware>>speech recognition
 *  
 *  Though system.SpeechSynthesizer class os more modern and has a lot more functionality than the speechLib 
 *  methods I've used the latter for backwards compatibility.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;





namespace ProjectA3_2

{

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Sets the output background to be transparent so you can see the cute pig graphic.
            outputLabel.BackColor = Color.Transparent;
        }

        
        //the following needs to be made more object oriented and encapsulated
        //Maybe a PigLatin class?

        private String piggify(string s) // This translates a word to pig latin
        {
            //get the first letter of our string as a char
            char testCapital = Convert.ToChar(s.Substring(0, 1));

            //remember if the first letter was capitalized so we can fix it in the output
            bool wasCapital = false; //assume lower case 
            if (char.IsUpper(testCapital)) wasCapital = true;

            //convert the string to lower case
            s = s.ToLower();

            //get rid of the contractions
            fixContractions();

            //list of punctuation so we can put it back.
            string[] punctuation = { "\'", "\"", "," , "." , ":" , ";" , "?" ,"!" ,"@" ,"#" ,"$" ,"%" ,"^", "&","*",
                                     "(" , ")" , "_" , "-" , "+" , "=" , "\\", "<",">" , "|" , "`" , "~" , "\r" };
            //List of vowels - Pig latin leaves the vowels at the front of words in place
            string[] vowels = { "a", "e", "i", "o", "u" }; //never y in pig latin

            string[] twoLetterSounds =
            {
                "wh" , "ch" , "ps" , "th" , "sh" , "ts" , "ph" , "bl" , "br" , "ci" , "cl" , "cr" , "dr" , "dw" ,
                "fl" , "fr" , "gh" , "gl" , "gr" , "kn" , "pl" , "pr" , "pt" , "rh" , "sc" , "sk" , "sl" , "sm" ,
                "sn" ,"sp" , "st" , "wr" , "sw" ,"tr" , "tw"
            };

            string[] threeLetterSounds = { "shm", "thr", "psy", "sch", "shr", "tch", "str", "spr" };
            
            //strings to save punctuation attached to the word - should remain in place when letters move
            string startPunctuation = "";
            string endPunctuation = "";

            //if there is punctuation at the begining of the word, save it
            if (punctuation.Contains(s.Substring(0, 1)))
            {
                startPunctuation = s.Substring(0, 1);
                //delete the punctuation at start
                s = s.Substring(1, s.Length - 1);
            }

            //if it's at the end of the word save it
            if (s.Length > 1)
            {
                if (punctuation.Contains(s.Substring(s.Length - 1, 1)))
                {
                    endPunctuation = s.Substring(s.Length - 1, 1);
                    //delete the punctuation at end
                    s = s.Substring(0, s.Length - 1);
                }
            }


            

            //Is it a number? put back punctuation and return it unchanged.
            int n;
            if (int.TryParse(s, out n)) return startPunctuation + s + endPunctuation;

            //if it starts with a vowel return it with a "ay" at the end.
            bool wasAnS = false; //used to check for possessive 's'

            // if the word starts with Vowel
            if (vowels.Contains(s.Substring(0, 1)))
            {
                //capitalize the first letter if that's how we got it
                if (wasCapital) s = s.Substring(0, 1).ToUpper() + s.Substring(1, s.Length - 1);
                //check the length so we avoid an error
                if (s.Length > 2)
                {
                    //see if there was a possessive 's
                    if (s.Substring(s.Length - 2, 2) == "'s")
                    {
                        //record there was an 's
                        wasAnS = true;
                        //remove the the 's for the time being
                        s = s.Substring(0, s.Length - 2);
                    }
                }

                if (wasAnS)
                {
                    return startPunctuation + s + "ay's" + endPunctuation;
                }
                else
                {

                    return startPunctuation + s + "ay" + endPunctuation;
                }
                
            }
            
            //Our word must start with a consonant or blend  

            //assume the first sound is only a single letter
            int lengthOfSound = 1;

            //see if our word is 3 characters or longer

            if (s.Length >= 3)
            {
                //check if the first three letters of our word are on the list, adjust the number of characters we move                 

                if (threeLetterSounds.Contains(s.Substring(0, 3))) lengthOfSound = 3;

                //check for possesive 's and strip them
                if (s.Substring(s.Length - 2, 2) == "'s")
                {
                    //remember that we had an 's
                    wasAnS = true;
                    //delete the 's
                    s = s.Substring(0, s.Length - 2);
                }

            }

            //same for first two letters
            if (s.Length >= 2)
            {
                if (twoLetterSounds.Contains(s.Substring(0, 2))) lengthOfSound = 2;
            }

            //get the first sound
            string firstSound = s.Substring(0, lengthOfSound);

            //get what's left over
            string baseWord = s.Substring(lengthOfSound, s.Length - lengthOfSound);
            
            //create a new word and add the first sound to the end plus the -ay            
            string newWord = baseWord + firstSound + "ay";
            
            //Capitalize the first letter and add possesives if that's how we got it
            if (wasCapital) newWord = newWord.Substring(0, 1).ToUpper() + newWord.Substring(1, newWord.Length - 1);
            if (wasAnS) newWord = newWord + "'s";

            //return with punctuation.
            return startPunctuation + newWord + endPunctuation;
        }

        private void fixContractions()//deals with pesky contractions.
        {/*This could be made more elegant by creating an array of the 
          *contractions and their expanded version and doing it all in a loop
          */
            
            //special case "won't" to will not
            inputTextBox.Text = inputTextBox.Text.Replace("won't", "will not");

            //special case "it's" to "it is"
            inputTextBox.Text = inputTextBox.Text.Replace("it's", "it is");

            // "n't" contractions
            inputTextBox.Text = inputTextBox.Text.Replace("n't", " not");

            // "'ve" contractions
            inputTextBox.Text = inputTextBox.Text.Replace("'ve", " have");

            // "'re" contractions
            inputTextBox.Text = inputTextBox.Text.Replace("'re", " are");

            // " 'll" contractions
            inputTextBox.Text = inputTextBox.Text.Replace("'ll", " will");

            // " 'd " is tricky - it could be had or would, most often depending whether it is followed by "have"
            //This works 90% of the time
            inputTextBox.Text = inputTextBox.Text.Replace("'d have", "  would have");
            inputTextBox.Text = inputTextBox.Text.Replace("'d", "  had");

            // "he's" to "he is" -sometimes it can be he has.
            inputTextBox.Text = inputTextBox.Text.Replace("he's", "he is");

            // "she's to she is
            inputTextBox.Text = inputTextBox.Text.Replace("she's", "she is");

            // "there's there is
            inputTextBox.Text = inputTextBox.Text.Replace("there's", "there is");

            // "what's what is
            inputTextBox.Text = inputTextBox.Text.Replace("what's", "what is");

            // "who's who is
            inputTextBox.Text = inputTextBox.Text.Replace("who's", "who is");

            // "how's to how is
            inputTextBox.Text = inputTextBox.Text.Replace("how's", "how is");

            //y'all to you all
            inputTextBox.Text = inputTextBox.Text.Replace("y'all", "you all");

            //"i'm" to I am
            inputTextBox.Text = inputTextBox.Text.Replace("i'm", "i am");
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            //80 characters per line
            int divideLine = 80;

            //list of characters to split the string - spaces, tabs 
            char[] delimiterList = { ' ', '\t' };

            //create an array of strings filled with each word of the input.
            string[] wordsList = inputTextBox.Text.Split(delimiterList, StringSplitOptions.RemoveEmptyEntries);

            //step through each one and piggify it
            foreach (string s in wordsList)
            {
                String newWord = piggify(s);
                //if the output is over linelength
                if (outputLabel.Text.Length + newWord.Length > divideLine)
                {
                    //start a new line
                    outputLabel.Text += Environment.NewLine;
                    //increase the line length before next newline
                    divideLine += 80;
                }

                outputLabel.Text += " " + newWord;
            }
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            //reset the output for new translation.
            outputLabel.Text = "";
        }


        private void speekButton_Click(object sender, EventArgs e)
        {
            try
            {
                //use the windows text to speech API to try and say the words 
                //error checking needs testing

                SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak;
                SpVoice Voice = new SpVoice();

                //set the voice rate and speak the words
                Voice.Rate = voiceRateTrackBar.Value;
                Voice.Speak(outputLabel.Text, Flags);
            }
            catch
            {
                var result = MessageBox.Show("Sound could not be played", "Sound Error", MessageBoxButtons.OK);
            }

        }

        private void speakNormal_Click(object sender, EventArgs e)
        {
            try
            {
                //use the windows text to speech API to try and say the words
                //error checking needs testing 
                SpeechVoiceSpeakFlags flags = SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak;
                SpVoice Voice = new SpVoice();

                //set the voice rate and speak the words
                Voice.Rate = voiceRateTrackBar.Value;
                Voice.Speak(inputTextBox.Text, flags);
            }
            catch
            {
                var result = MessageBox.Show("Sound could not be played", "Sound Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Puts the text in the clipboard if you want ot save it
            Clipboard.SetText(outputLabel.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* Two choices for speech recognition: SpeechRecognizer or SpeechRecognitionEngine*/
            /*Recognizer is just a gui wrapper for RecognitionEngine*/
            try
            {
                SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine(); //new instance of the engine
                _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("piggify"))); //set up command grammar
                _recognizer.LoadGrammar(new DictationGrammar());                    // set up to recognize everything 

                _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;      //enable the event for words in grammar

                _recognizer.SetInputToDefaultAudioDevice();                        //input device 
                _recognizer.RecognizeAsync(RecognizeMode.Single);                  // process one phrase then reset 
            }
            catch
            {
                var result = MessageBox.Show("Speech Error: SpeechRecognitionEngine may not be installed on your system.", "Sound Error", MessageBoxButtons.OK);
            }
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            inputTextBox.Text = e.Result.Text;
            if (e.Result.Text.IndexOf("translate") > -1 )
            {
                //translate and say the translation
                translateButton_Click( sender, e);
                speekButton_Click(sender,  e);
            }
        }

        private void clipPigLatin_Click(object sender, EventArgs e)
        {
            //Puts the text in the clipboard if you want ot save it
            Clipboard.SetText(outputLabel.Text);
    }
    }
}