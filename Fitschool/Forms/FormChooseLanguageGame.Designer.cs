namespace Fitschool.Forms
{
    partial class FormChooseLanguageGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChooseLanguageGame));
            label1 = new Label();
            gameSelector = new ComboBox();
            playButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(281, 28);
            label1.TabIndex = 0;
            label1.Text = "Kies een taal spel om te spelen:";
            // 
            // gameSelector
            // 
            gameSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            gameSelector.FormattingEnabled = true;
            gameSelector.Location = new Point(12, 66);
            gameSelector.Name = "gameSelector";
            gameSelector.Size = new Size(281, 28);
            gameSelector.TabIndex = 1;
            // 
            // playButton
            // 
            playButton.Location = new Point(12, 113);
            playButton.Name = "playButton";
            playButton.Size = new Size(281, 29);
            playButton.TabIndex = 2;
            playButton.Text = "Spelen!";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // FormChooseLanguageGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 159);
            ControlBox = false;
            Controls.Add(playButton);
            Controls.Add(gameSelector);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(332, 177);
            MinimumSize = new Size(332, 177);
            Name = "FormChooseLanguageGame";
            Load += FormChooseLanguageGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox gameSelector;
        private Button playButton;
    }
}