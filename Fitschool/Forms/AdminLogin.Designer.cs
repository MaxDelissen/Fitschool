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
            passwordBox.Location = new Point(14, 64);
            passwordBox.Margin = new Padding(3, 4, 3, 4);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Wachtwoord";
            passwordBox.Size = new Size(236, 27);
            passwordBox.TabIndex = 0;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(234, 48);
            label1.TabIndex = 1;
            label1.Text = "Voer het Administratie wachtwoord in.";
            // 
            // SubmitPasswordButton
            // 
            SubmitPasswordButton.Location = new Point(145, 103);
            SubmitPasswordButton.Margin = new Padding(3, 4, 3, 4);
            SubmitPasswordButton.Name = "SubmitPasswordButton";
            SubmitPasswordButton.Size = new Size(105, 37);
            SubmitPasswordButton.TabIndex = 2;
            SubmitPasswordButton.Text = "Inloggen";
            SubmitPasswordButton.UseVisualStyleBackColor = true;
            SubmitPasswordButton.Click += SubmitPasswordButton_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 175);
            Controls.Add(SubmitPasswordButton);
            Controls.Add(label1);
            Controls.Add(passwordBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminLogin";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += AdminLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordBox;
        private Label label1;
        private Button SubmitPasswordButton;
    }
}