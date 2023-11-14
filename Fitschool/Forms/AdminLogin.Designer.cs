namespace Fitschool.Forms
{
    partial class AdminLogin
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
            passwordBox = new TextBox();
            label1 = new Label();
            SubmitPasswordButton = new Button();
            SuspendLayout();
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(12, 48);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Wachtwoord";
            passwordBox.Size = new Size(207, 23);
            passwordBox.TabIndex = 0;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(205, 36);
            label1.TabIndex = 1;
            label1.Text = "Voer het Administratie wachtwoord in.";
            // 
            // SubmitPasswordButton
            // 
            SubmitPasswordButton.Location = new Point(127, 77);
            SubmitPasswordButton.Name = "SubmitPasswordButton";
            SubmitPasswordButton.Size = new Size(92, 28);
            SubmitPasswordButton.TabIndex = 2;
            SubmitPasswordButton.Text = "Inloggen";
            SubmitPasswordButton.UseVisualStyleBackColor = true;
            SubmitPasswordButton.Click += SubmitPasswordButton_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 131);
            Controls.Add(SubmitPasswordButton);
            Controls.Add(label1);
            Controls.Add(passwordBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminLogin";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordBox;
        private Label label1;
        private Button SubmitPasswordButton;
    }
}