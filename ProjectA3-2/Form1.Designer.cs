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
            this.speekButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.speakNormal = new System.Windows.Forms.Button();
            this.clipPigLatin = new System.Windows.Forms.Button();
            this.voiceRateTrackBar = new System.Windows.Forms.TrackBar();
            this.voiceRateLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.inputTextBox.Size = new System.Drawing.Size(608, 87);
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
            // speekButton
            // 
            this.speekButton.Location = new System.Drawing.Point(638, 261);
            this.speekButton.Name = "speekButton";
            this.speekButton.Size = new System.Drawing.Size(75, 23);
            this.speekButton.TabIndex = 4;
            this.speekButton.Text = "Speak";
            this.speekButton.UseVisualStyleBackColor = true;
            this.speekButton.Click += new System.EventHandler(this.speekButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("outputBox.BackgroundImage")));
            this.outputBox.Controls.Add(this.outputLabel);
            this.outputBox.Location = new System.Drawing.Point(22, 174);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(598, 399);
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
            this.voiceRateTrackBar.Location = new System.Drawing.Point(247, 128);
            this.voiceRateTrackBar.Minimum = -10;
            this.voiceRateTrackBar.Name = "voiceRateTrackBar";
            this.voiceRateTrackBar.Size = new System.Drawing.Size(104, 45);
            this.voiceRateTrackBar.TabIndex = 9;
            // 
            // voiceRateLabel
            // 
            this.voiceRateLabel.AutoSize = true;
            this.voiceRateLabel.Location = new System.Drawing.Point(266, 112);
            this.voiceRateLabel.Name = "voiceRateLabel";
            this.voiceRateLabel.Size = new System.Drawing.Size(66, 13);
            this.voiceRateLabel.TabIndex = 10;
            this.voiceRateLabel.Text = "Voice Rate: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(638, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Dictate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 614);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.voiceRateLabel);
            this.Controls.Add(this.voiceRateTrackBar);
            this.Controls.Add(this.clipPigLatin);
            this.Controls.Add(this.speakNormal);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.speekButton);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.inputTextBox);
            this.Name = "Form1";
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
        private System.Windows.Forms.Button speekButton;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button speakNormal;
        private System.Windows.Forms.Button clipPigLatin;
        private System.Windows.Forms.TrackBar voiceRateTrackBar;
        private System.Windows.Forms.Label voiceRateLabel;
        private System.Windows.Forms.Button button2;
    }
}

