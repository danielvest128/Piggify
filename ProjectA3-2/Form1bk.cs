/* Daniel Vest
 * Module A3 - The Ultimate Pig Latin Translator - 2017 
 * Needs windows TTS support installed to run, either system.speech or speechLib.DLL.
 * 
 *   Pig Latin Rules:
 *     If the word begins with a consonant put the first letter of the word at the end and add 'ay'
 *     if the word begins with a vowel just add 'ay' (otherwise you can end up with 3 vowels in a row)
 *     contractions are converted to their full lenght text (i.e. "can't" "can not") 
 *     All possesive S's are kept at the end of the word, after the "ay" (i. e. "Daniel's" "Anielday's" not "Anielsday"
 *     Consonants that are blends are treated as one letter (i. e. "brush" to "ushbray", "thrush" to "ushthray"
 
 * Features:
 *   Translates entire sentences typed into the textbox or loaded from a text file
 *   Listens for dictation and translates on hearing keyword "translate"
 *   Pronounces both the original and the pig latin translation
 *   Allows you to copy the pig latin text to the clipboard or save to .wav file
 *   Slider bar to change the speed of the sound output
 *   Can select other voices if installed
 *   
 * 
 *Known Bugs:
 * 
 * If punctuation does not have a letter on one side and a space on the other side it is not processed right.
 * Double punctuation will confuse it (( for example.
 */

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

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
            outputLabel.BackColor = Color.Transparent; // Sets the background to transparent to make graphic visible.
            try // Make a list of voices if installed
            {
                SpeechSynthesizer synthVoice = new SpeechSynthesizer();  // Make a new voice object
                foreach (InstalledVoice voice in synthVoice.GetInstalledVoices()) //Step through each installed voice
                {
                     voicesListBox.Items.Add(voice.VoiceInfo.Name);  // Populate listbox with installled voices
                }
            }
            catch
            {
                voicesListBox.Enabled = false;  // Make the listbox and it's label invisible and disabled
                voicesListBox.Visible = false;
                voiceLabel.Visible = false;
            }
        }

        private String piggify(string s) // This translates a word to pig latin | Called by translateButton_Click()
        {
            char testCapital = Convert.ToChar(s.Substring(0, 1)); // Get the first letter of our string
            bool wasCapital = false; 
            if (char.IsUpper(testCapital)) wasCapital = true;  //  Remember if the first letter was capitalized
            s = s.ToLower();           // Convert the string to lower case for comparisons
            
            // List of punctuation so we can put it back.
            string[] punctuation = { "\'", "\"", "," , "." , ":" , ";" , "?" ,"!" ,"@" ,"#" ,"$" ,"%" ,"^", "&","*",
                                     "(" , ")" , "_" , "-" , "+" , "=" , "\\", "<",">" , "|" , "`" , "~" , "\r" };
            
            // List of vowels - Pig latin leaves the vowels at the front of words in place (otherwise you get 3 or 4 vowels in a row)
            string[] vowels = { "a", "e", "i", "o", "u" }; // Y is special case
            
            string[] twoLetterSounds =   // Two letter blends
            {
                "wh" , "ch" , "ps" , "th" , "sh" , "ts" , "ph" , "bl" , "br" , "ci" , "cl" , "cr" , "dr" , "dw" ,
                "fl" , "fr" , "gh" , "gl" , "gr" , "kn" , "pl" , "pr" , "pt" , "rh" , "sc" , "sk" , "sl" , "sm" ,
                "sn" ,"sp" , "st" , "wr" , "sw" ,"tr" , "tw"
            };

            string[] threeLetterSounds = { "shm", "thr", "psy", "sch", "shr", "tch", "str", "spr" };
            
            // Strings to save punctuation attached to the word - should remain in place when letters move
            string startPunctuation = "";
            string endPunctuation = "";

            // If there is punctuation at the begining of the word, stoe it and remove from string
            if (punctuation.Contains(s.Substring(0, 1)))
            {
                startPunctuation = s.Substring(0, 1); 
                s = s.Substring(1, s.Length - 1); 
            }

            if (s.Length > 1)  // Same process for end of the word.
            {
                if (punctuation.Contains(s.Substring(s.Length - 1, 1)))
                {
                    endPunctuation = s.Substring(s.Length - 1, 1);
                    s = s.Substring(0, s.Length - 1);
                }
            }

            
            int n; // Is it a number? put back punctuation and return it unchanged.
            if (int.TryParse(s, out n)) return startPunctuation + s + endPunctuation;
                        
            bool wasAnS = false; // Var to remember if there is a possessive 's'

            // If it starts with a vowel return it with a "ay" at the end.
            if (vowels.Contains(s.Substring(0, 1)))
            {
                // Capitalize the first letter if that's how we got it
                if (wasCapital) s = s.Substring(0, 1).ToUpper() + s.Substring(1, s.Length - 1);
                if (s.Length > 2)       // Check the length so we avoid an error
                {
                    if (s.Substring(s.Length - 2, 2) == "'s")  // See if there was a possessive 's 
                    {
                        wasAnS = true;  // Record there was an 's
                        s = s.Substring(0, s.Length - 2); // Remove the the 's for the time being
                    }
                }

                if (wasAnS)
                {
                    return startPunctuation + s + "ay's" + endPunctuation;  // Replace 's and punctuation
                }
                else
                {
                    return startPunctuation + s + "ay" + endPunctuation; 
                }
                
            }
            
            // If not a vowel, Our word must start with a consonant or blend  
            
            int lengthOfSound = 1; // Assume the first sound is only a single letter

            // See if our word is 3 characters or longer
            if (s.Length >= 3)
            {
                // Check if the first three letters are on the list of blends
                // Adjust the number of characters we move to the end if true
                if (threeLetterSounds.Contains(s.Substring(0, 3))) lengthOfSound = 3;

                if (s.Substring(s.Length - 2, 2) == "'s")  // Check for possesive 's and strip them
                {
                    wasAnS = true;   // Remember that we had an 's
                    s = s.Substring(0, s.Length - 2); // Delete the 's
                }
            }

            if (s.Length >= 2) // Check list of two letters blends
            {
                if (twoLetterSounds.Contains(s.Substring(0, 2))) lengthOfSound = 2;
            }

            // Get the first sound (1, 2 or 3 char)
            string firstSound = s.Substring(0, lengthOfSound);

            // Get what's left over
            string baseWord = s.Substring(lengthOfSound, s.Length - lengthOfSound);
            
            // Create a new word and add the first sound to the end plus the -ay            
            string newWord = baseWord + firstSound + "ay";
            
            // Capitalize the first letter and add possesives if that's how we got it
            if (wasCapital) newWord = newWord.Substring(0, 1).ToUpper() + newWord.Substring(1, newWord.Length - 1);
            if (wasAnS) newWord = newWord + "'s";

            return startPunctuation + newWord + endPunctuation;     // Return with punctuation.
        }

        private string fixContractions(string s)  //Deals with pesky contractions.| Called by translateButton_Click
        {   string[] contractionsList = {   "won't", "it's", "n't", "'ve", "'re", "'ll", "'d have",
                                            "'d","he's","she's","there's","what's", "who's",
                                            "how's","y'all","i'm" };

            string[] contractionsExpandedList = { "will not", "it is", " not", " have"," are", " will",
                                                " would"," had","he is","she is","there is","what is",
                                                "who is", "how is", "you all","I am"};
            
            // Step through each and replace with the right expansion
            for (int count = 0; count < contractionsList.Length; count++)
            {
                s = s.Replace(contractionsList[count], contractionsExpandedList[count]);
            }
            return s;
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            int divideLine = 80;  // 80 characters per line word wrap for outputLabel 

            char[] delimiterList = { ' ', '\t'};   // List of characters to split the string - spaces, tabs 
            string s = fixContractions(inputTextBox.Text); // Get rid of the contractions for simplicity

            // Create an array of strings filled with each word of the input from inputTextBox
            string[] wordsList = s.Split(delimiterList, StringSplitOptions.RemoveEmptyEntries);
                        
            foreach (string wrd in wordsList) // Step through each word and piggify it
            {
                String newWord = piggify(wrd);    // Translate word
                if (outputLabel.Text.Length + newWord.Length > divideLine)  // If the output is over the allowed line
                {
                    outputLabel.Text += Environment.NewLine;  // Start a new line
                    divideLine += 80;   // Increase the allowed length before next NewLine
                }
                outputLabel.Text += " " + newWord;    // Add the word to the label
            }
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            outputLabel.Text = "";            // Reset the output for new translation.
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) // Triggered when SpeechRecognizer thinks it hears speech
        {
            inputTextBox.Text = e.Result.Text;

            if (e.Result.Text.IndexOf("translate") > -1 ) // If the person says translate then translate it automatically.
            {
                translateButton_Click(sender, e);  // Translate and speak the translation
                speakPigButton_Click(sender,  e);
                speakNormal_Click(sender, e);  // Say the normal phrase
            }
        }

        private void clipPigLatin_Click(object sender, EventArgs e)  // Puts the pig latin text in the clipboard if you want ot save it
        {
            Clipboard.SetText(outputLabel.Text);
            var result = MessageBox.Show("Text copied to clipboard.", "Copy", MessageBoxButtons.OK);
        }

        private void loadTextFile_Click(object sender, EventArgs e)  // Opens a text file and reads it into the inputTextBox control
        {
            OpenFileDialog txtFile = new OpenFileDialog();  // Open a file open dialog
            txtFile.Filter = "*.txt|*.*";                   // List *.txt files or all files
            txtFile.FilterIndex = 1;                        // Use filter 1 first
            

            if (txtFile.ShowDialog() == DialogResult.OK)   // If they didn't press cancel
            {
                string theFile = System.IO.File.ReadAllText(txtFile.FileName);  //Load the whole file in one string
                                
                if (System.Text.RegularExpressions.Regex.IsMatch(theFile, "\u0000-\u0127")) // Test for normal text W/ regular expressions   
                {
                    inputTextBox.Text = theFile;  // Put the text frm the file into inputTextBox
                }
                else // Not a text file
                {
                    var result = MessageBox.Show("I don' think that is a valid text file.", 
                        "File Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);   // Tell off the user
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)  // Saves the audio out to a .WAV file
        {
            SaveFileDialog sFile = new SaveFileDialog();  // Open a file save dialog box
            sFile.Filter = "*.wav|*.*";                   // Show .wav but can show all files
            sFile.FilterIndex = 1;                        // Start with first filename filter  

            if (sFile.ShowDialog() == DialogResult.OK)
            {
                try // Try to use the SpeechSynthesizer methods
                {
                    SpeechSynthesizer synth = new SpeechSynthesizer();

                    // Configure the audio output with a new instance of SpeechAudioFormatInfo and save the file
                    synth.SetOutputToWaveFile(@sFile.FileName,
                      new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Eight, AudioChannel.Mono));
                }
                catch
                {
                    try // Try SpeechLib instead (older version of Windows TTS)
                    {
                        SpVoice voiceOutput = new SpVoice();          // Instance of a new voice object
                        SpFileStream fileStream = new SpFileStream(); // Instance of Stream to a file

                        //Open the file
                        fileStream.Open(sFile.FileName + ".wav", SpeechStreamFileMode.SSFMCreateForWrite, false);
                        voiceOutput.AudioOutputStream = fileStream;  // Re-direct the output to the file
                        voiceOutput.Rate = voiceRateTrackBar.Value;  // Set the voice rate
                        voiceOutput.Speak(outputLabel.Text, SpeechVoiceSpeakFlags.SVSFDefault);  // Speak the words
                        fileStream.Close();  // Close the file
                    }

                    catch //no TTS installed
                    {
                        var result = MessageBox.Show("Sound could not saved.", "File or Sound Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void dictateButton_Click(object sender, EventArgs e)
        {
            {
                /* Two choices for speech recognition: SpeechRecognizer or SpeechRecognitionEngine
                *  SpeechRecognizer is just a GUI wrapper for RecognitionEngine and causes time lag problems on slower machines
                */
                try
                {
                    SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine(); // New instance of the engine
                    _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("translate"))); // Set up command grammar
                    _recognizer.LoadGrammar(new DictationGrammar());                     // Set up to recognize everything 

                    _recognizer.SpeechRecognized += _recognizer_SpeechRecognized; // Enable the event for words in grammar
                    _recognizer.SetInputToDefaultAudioDevice();                   // Input device 
                    _recognizer.RecognizeAsync(RecognizeMode.Single);             // Process one phrase then stop listening
                }
                catch 
                {
                    var result = MessageBox.Show("Speech Error: May not be installed on your system.", "Sound Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Error);  // Tell off user
                }
            }
        }

        private void speakText(string ourText)
        {
            try // Try SpeechSynthesizer first (it has more features)
            {
                SpeechSynthesizer synthVoice = new SpeechSynthesizer(); // New voice object
                synthVoice.SelectVoice(voicesListBox.Text);             // Select the voice to use 
                synthVoice.Rate = voiceRateTrackBar.Value;              // Set the rate
                synthVoice.SetOutputToDefaultAudioDevice();             // Default audio output. 
                synthVoice.Speak(ourText);
            }
            catch
            {
                try // Try SpeechLib instead
                {
                    SpeechVoiceSpeakFlags flags = SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak;
                    SpVoice voiceSpeaking = new SpVoice();

                    //set the voice rate and speak the words
                    voiceSpeaking.Rate = voiceRateTrackBar.Value;
                    voiceSpeaking.Speak(ourText, flags);
                }
                catch // System has niether installed 
                {
                    var result = MessageBox.Show("Sound could not be played", "Sound Error", MessageBoxButtons.OK);
                }
            }
        }

        private void speakNormal_Click(object sender, EventArgs e)  // Speak text in English
        {
            if (inputTextBox.Text.Equals("")) speakText(inputTextBox.Text);
        }

        private void speakPigButton_Click(object sender, EventArgs e)  // Speak translated text
        {
            if (outputLabel.Text.Equals("")) speakText(outputLabel.Text);
        }
    }
}