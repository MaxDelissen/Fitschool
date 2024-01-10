using MySql.Data.MySqlClient;

namespace Fitschool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            OpenUserManagementButton = new Button();
            ExitButton = new Button();
            IdBox = new TextBox();
            SuspendLayout();
            // 
            // OpenUserManagementButton
            // 
            OpenUserManagementButton.Location = new Point(1398, 46);
            OpenUserManagementButton.Name = "OpenUserManagementButton";
            OpenUserManagementButton.Size = new Size(193, 105);
            OpenUserManagementButton.TabIndex = 2;
            OpenUserManagementButton.Text = "Gebruiker beheer";
            OpenUserManagementButton.UseVisualStyleBackColor = true;
            OpenUserManagementButton.Visible = false;
            OpenUserManagementButton.Click += OpenUserManagementButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.Red;
            ExitButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            ExitButton.ForeColor = SystemColors.ControlLightLight;
            ExitButton.Location = new Point(1640, 46);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(170, 97);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Visible = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // IdBox
            // 
            IdBox.BackColor = Color.FromArgb(76, 240, 18);
            IdBox.Location = new Point(1889, 1012);
            IdBox.MaxLength = 5;
            IdBox.Name = "IdBox";
            IdBox.Size = new Size(24, 27);
            IdBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 240, 18);
            BackgroundImage = Properties.Resources.Frame_1;
            ClientSize = new Size(1902, 1033);
            Controls.Add(IdBox);
            Controls.Add(ExitButton);
            Controls.Add(OpenUserManagementButton);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Padding = new Padding(57, 27, 57, 27);
            Text = "Inloggen - Fitschool";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button OpenUserManagementButton;
        private Button ExitButton;
        private TextBox IdBox;
    }
}