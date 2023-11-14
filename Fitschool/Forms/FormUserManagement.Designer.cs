namespace Fitschool
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
            panel1.Controls.Add(leeftijdLabel);
            panel1.Controls.Add(AddUserButton);
            panel1.Controls.Add(LeeftijdSelector);
            panel1.Controls.Add(NameBox);
            panel1.Location = new Point(17, 63);
            panel1.Margin = new Padding(9, 8, 9, 8);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(9, 8, 9, 8);
            panel1.Size = new Size(352, 97);
            panel1.TabIndex = 6;
            // 
            // leeftijdLabel
            // 
            leeftijdLabel.AutoSize = true;
            leeftijdLabel.Location = new Point(11, 48);
            leeftijdLabel.Name = "leeftijdLabel";
            leeftijdLabel.Size = new Size(85, 15);
            leeftijdLabel.TabIndex = 3;
            leeftijdLabel.Text = "Voer leeftijd in:";
            // 
            // AddUserButton
            // 
            AddUserButton.Location = new Point(225, 48);
            AddUserButton.Margin = new Padding(3, 2, 3, 2);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(114, 38);
            AddUserButton.TabIndex = 0;
            AddUserButton.Text = "Add User";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_Click;
            // 
            // LeeftijdSelector
            // 
            LeeftijdSelector.Location = new Point(11, 65);
            LeeftijdSelector.Margin = new Padding(3, 2, 3, 2);
            LeeftijdSelector.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            LeeftijdSelector.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            LeeftijdSelector.Name = "LeeftijdSelector";
            LeeftijdSelector.Size = new Size(187, 23);
            LeeftijdSelector.TabIndex = 2;
            LeeftijdSelector.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // NameBox
            // 
            NameBox.Location = new Point(11, 10);
            NameBox.Margin = new Padding(3, 2, 3, 2);
            NameBox.MaxLength = 45;
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Voer naam in";
            NameBox.Size = new Size(328, 23);
            NameBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(17, 7);
            label1.Name = "label1";
            label1.Size = new Size(352, 49);
            label1.TabIndex = 7;
            label1.Text = "Gebruik dit paneel om gebruikers toe te voegen, of te verwijderen";
            // 
            // RemoveUserButton
            // 
            RemoveUserButton.Location = new Point(227, 10);
            RemoveUserButton.Margin = new Padding(3, 2, 3, 2);
            RemoveUserButton.Name = "RemoveUserButton";
            RemoveUserButton.Size = new Size(114, 40);
            RemoveUserButton.TabIndex = 8;
            RemoveUserButton.Text = "Remove User";
            RemoveUserButton.UseVisualStyleBackColor = true;
            RemoveUserButton.Click += RemoveUserButton_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(IdToDelete);
            panel2.Controls.Add(RemoveUserButton);
            panel2.Location = new Point(17, 170);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(9, 8, 9, 8);
            panel2.Size = new Size(352, 59);
            panel2.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 10;
            label2.Text = "Voer ID in";
            // 
            // IdToDelete
            // 
            IdToDelete.Location = new Point(11, 29);
            IdToDelete.Margin = new Padding(3, 2, 3, 2);
            IdToDelete.Name = "IdToDelete";
            IdToDelete.Size = new Size(131, 23);
            IdToDelete.TabIndex = 9;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 256);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
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
    }
}