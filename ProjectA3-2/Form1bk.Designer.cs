namespace ProjectA3_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.translateButton = new System.Windows.Forms.Button();
            this.speakPigButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.speakNormal = new System.Windows.Forms.Button();
            this.clipPigLatin = new System.Windows.Forms.Button();
            this.voiceRateTrackBar = new System.Windows.Forms.TrackBar();
            this.voiceRateLabel = new System.Windows.Forms.Label();
            this.dictateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadTextFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.voicesListBox = new System.Windows.Forms.ListBox();
            this.voiceLabel = new System.Windows.Forms.Label();
            this.outputBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceRateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.AcceptsReturn = true;
            this.inputTextBox.AllowDrop = true;
            this.inputTextBox.Location = new System.Drawing.Point(12, 25);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(608, 143);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(638, 54);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(75, 23);
            this.translateButton.TabIndex = 2;
            this.translateButton.Text = "Translate";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // speakPigButton
            // 
            this.speakPigButton.Location = new System.Drawing.Point(638, 261);
            this.speakPigButton.Name = "speakPigButton";
            this.speakPigButton.Size = new System.Drawing.Size(75, 23);
            this.speakPigButton.TabIndex = 4;
            this.speakPigButton.Text = "Speak";
            this.speakPigButton.UseVisualStyleBackColor = true;
            this.speakPigButton.Click += new System.EventHandler(this.speakPigButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("outputBox.BackgroundImage")));
            this.outputBox.Controls.Add(this.outputLabel);
            this.outputBox.Location = new System.Drawing.Point(22, 174);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(598, 448);
            this.outputBox.TabIndex = 6;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "Pig Latin ";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.outputLabel.Location = new System.Drawing.Point(14, 25);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(56, 14);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "       ";
            // 
            // speakNormal
            // 
            this.speakNormal.Location = new System.Drawing.Point(638, 25);
            this.speakNormal.Name = "speakNormal";
            this.speakNormal.Size = new System.Drawing.Size(75, 23);
            this.speakNormal.TabIndex = 7;
            this.speakNormal.Text = "Speak";
            this.speakNormal.UseVisualStyleBackColor = true;
            this.speakNormal.Click += new System.EventHandler(this.speakNormal_Click);
            // 
            // clipPigLatin
            // 
            this.clipPigLatin.Location = new System.Drawing.Point(638, 290);
            this.clipPigLatin.Name = "clipPigLatin";
            this.clipPigLatin.Size = new System.Drawing.Size(75, 23);
            this.clipPigLatin.TabIndex = 8;
            this.clipPigLatin.Text = "Clipboard";
            this.clipPigLatin.UseVisualStyleBackColor = true;
            this.clipPigLatin.Click += new System.EventHandler(this.clipPigLatin_Click);
            // 
            // voiceRateTrackBar
            // 
            this.voiceRateTrackBar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.voiceRateTrackBar.Location = new System.Drawing.Point(638, 199);
            this.voiceRateTrackBar.Minimum = -10;
            this.voiceRateTrackBar.Name = "voiceRateTrackBar";
            this.voiceRateTrackBar.Size = new System.Drawing.Size(75, 45);
            this.voiceRateTrackBar.TabIndex = 9;
            // 
            // voiceRateLabel
            // 
            this.voiceRateLabel.AutoSize = true;
            this.voiceRateLabel.Location = new System.Drawing.Point(647, 183);
            this.voiceRateLabel.Name = "voiceRateLabel";
            this.voiceRateLabel.Size = new System.Drawing.Size(66, 13);
            this.voiceRateLabel.TabIndex = 10;
            this.voiceRateLabel.Text = "Voice Rate: ";
            // 
            // dictateButton
            // 
            this.dictateButton.Location = new System.Drawing.Point(638, 83);
            this.dictateButton.Name = "dictateButton";
            this.dictateButton.Size = new System.Drawing.Size(75, 23);
            this.dictateButton.TabIndex = 11;
            this.dictateButton.Text = "Dictate";
            this.dictateButton.UseVisualStyleBackColor = true;
            this.dictateButton.Click += new System.EventHandler(this.dictateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(638, 320);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save Audio";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadTextFile
            // 
            this.loadTextFile.Location = new System.Drawing.Point(638, 113);
            this.loadTextFile.Name = "loadTextFile";
            this.loadTextFile.Size = new System.Drawing.Size(75, 23);
            this.loadTextFile.TabIndex = 13;
            this.loadTextFile.Text = "Load Text";
            this.loadTextFile.UseVisualStyleBackColor = true;
            this.loadTextFile.Click += new System.EventHandler(this.loadTextFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Input Text:";
            // 
            // voicesListBox
            // 
            this.voicesListBox.FormattingEnabled = true;
            this.voicesListBox.HorizontalScrollbar = true;
            this.voicesListBox.Location = new System.Drawing.Point(626, 385);
            this.voicesListBox.Name = "voicesListBox";
            this.voicesListBox.ScrollAlwaysVisible = true;
            this.voicesListBox.Size = new System.Drawing.Size(133, 264);
            this.voicesListBox.TabIndex = 15;
            // 
            // voiceLabel
            // 
            this.voiceLabel.AutoSize = true;
            this.voiceLabel.Location = new System.Drawing.Point(627, 366);
            this.voiceLabel.Name = "voiceLabel";
            this.voiceLabel.Size = new System.Drawing.Size(84, 13);
            this.voiceLabel.TabIndex = 16;
            this.voiceLabel.Text = "Choose a voice:";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 651);
            this.Controls.Add(this.voiceLabel);
            this.Controls.Add(this.voicesListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadTextFile);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dictateButton);
            this.Controls.Add(this.voiceRateLabel);
            this.Controls.Add(this.voiceRateTrackBar);
            this.Controls.Add(this.clipPigLatin);
            this.Controls.Add(this.speakNormal);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.speakPigButton);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.inputTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pig Latin Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.outputBox.ResumeLayout(false);
            this.outputBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceRateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Button speakPigButton;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button speakNormal;
        private System.Windows.Forms.Button clipPigLatin;
        private System.Windows.Forms.TrackBar voiceRateTrackBar;
        private System.Windows.Forms.Label voiceRateLabel;
        private System.Windows.Forms.Button dictateButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadTextFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox voicesListBox;
        private System.Windows.Forms.Label voiceLabel;
    }
}

