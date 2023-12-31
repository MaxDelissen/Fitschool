﻿namespace Fitschool
{
    partial class FormUserManagement
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
            panel1 = new Panel();
            label3 = new Label();
            selectStyle = new ComboBox();
            textBoxEmail = new TextBox();
            leeftijdLabel = new Label();
            AddUserButton = new Button();
            LeeftijdSelector = new NumericUpDown();
            NameBox = new TextBox();
            label1 = new Label();
            RemoveUserButton = new Button();
            panel2 = new Panel();
            label2 = new Label();
            IdToDelete = new NumericUpDown();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LeeftijdSelector).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IdToDelete).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(selectStyle);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(leeftijdLabel);
            panel1.Controls.Add(AddUserButton);
            panel1.Controls.Add(LeeftijdSelector);
            panel1.Controls.Add(NameBox);
            panel1.Location = new Point(19, 84);
            panel1.Margin = new Padding(10, 11, 10, 11);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 11, 10, 11);
            panel1.Size = new Size(402, 228);
            panel1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(223, 118);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 6;
            label3.Text = "<= Kies een stijl";
            // 
            // selectStyle
            // 
            selectStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            selectStyle.FormattingEnabled = true;
            selectStyle.Location = new Point(13, 115);
            selectStyle.Name = "selectStyle";
            selectStyle.Size = new Size(187, 28);
            selectStyle.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(13, 61);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Voer Email van ouder/ verzorger in.";
            textBoxEmail.Size = new Size(371, 27);
            textBoxEmail.TabIndex = 2;
            // 
            // leeftijdLabel
            // 
            leeftijdLabel.AutoSize = true;
            leeftijdLabel.Location = new Point(13, 160);
            leeftijdLabel.Name = "leeftijdLabel";
            leeftijdLabel.Size = new Size(87, 20);
            leeftijdLabel.TabIndex = 3;
            leeftijdLabel.Text = "Voer klas in:";
            // 
            // AddUserButton
            // 
            AddUserButton.Location = new Point(223, 170);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(161, 51);
            AddUserButton.TabIndex = 4;
            AddUserButton.Text = "Toevoegen";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_Click;
            // 
            // LeeftijdSelector
            // 
            LeeftijdSelector.Location = new Point(13, 183);
            LeeftijdSelector.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            LeeftijdSelector.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            LeeftijdSelector.Name = "LeeftijdSelector";
            LeeftijdSelector.Size = new Size(187, 27);
            LeeftijdSelector.TabIndex = 3;
            LeeftijdSelector.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NameBox
            // 
            NameBox.Location = new Point(13, 13);
            NameBox.MaxLength = 45;
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Voer naam in";
            NameBox.Size = new Size(374, 27);
            NameBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(19, 9);
            label1.Name = "label1";
            label1.Size = new Size(402, 65);
            label1.TabIndex = 7;
            label1.Text = "Gebruik dit paneel om gebruikers toe te voegen, of te verwijderen";
            // 
            // RemoveUserButton
            // 
            RemoveUserButton.Location = new Point(223, 13);
            RemoveUserButton.Name = "RemoveUserButton";
            RemoveUserButton.Size = new Size(161, 53);
            RemoveUserButton.TabIndex = 6;
            RemoveUserButton.Text = "Verwijder Gebruiker";
            RemoveUserButton.UseVisualStyleBackColor = true;
            RemoveUserButton.Click += RemoveUserButton_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(IdToDelete);
            panel2.Controls.Add(RemoveUserButton);
            panel2.Location = new Point(19, 340);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10, 11, 10, 11);
            panel2.Size = new Size(402, 77);
            panel2.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 16);
            label2.Name = "label2";
            label2.Size = new Size(198, 20);
            label2.TabIndex = 10;
            label2.Text = "Voer ID in om te verwijderen";
            // 
            // IdToDelete
            // 
            IdToDelete.Location = new Point(13, 39);
            IdToDelete.Name = "IdToDelete";
            IdToDelete.Size = new Size(199, 27);
            IdToDelete.TabIndex = 5;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 429);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUserManagement";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "User Management - Fitschool";
            TopMost = true;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LeeftijdSelector).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IdToDelete).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label leeftijdLabel;
        private NumericUpDown LeeftijdSelector;
        private TextBox NameBox;
        private Button AddUserButton;
        private Label label1;
        private Button RemoveUserButton;
        private Panel panel2;
        private Label label2;
        private NumericUpDown IdToDelete;
        private TextBox textBoxEmail;
        private ComboBox selectStyle;
        private Label label3;
    }
}