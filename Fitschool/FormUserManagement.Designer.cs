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
            LeeftijdSelector = new NumericUpDown();
            NameBox = new TextBox();
            AddUserButton = new Button();
            label1 = new Label();
            RemoveUserButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LeeftijdSelector).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(leeftijdLabel);
            panel1.Controls.Add(LeeftijdSelector);
            panel1.Controls.Add(NameBox);
            panel1.Location = new Point(19, 84);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(25, 10, 50, 10);
            panel1.Size = new Size(402, 129);
            panel1.TabIndex = 6;
            // 
            // leeftijdLabel
            // 
            leeftijdLabel.AutoSize = true;
            leeftijdLabel.Location = new Point(28, 64);
            leeftijdLabel.Name = "leeftijdLabel";
            leeftijdLabel.Size = new Size(109, 20);
            leeftijdLabel.TabIndex = 3;
            leeftijdLabel.Text = "Voer leeftijd in:";
            // 
            // LeeftijdSelector
            // 
            LeeftijdSelector.Location = new Point(28, 87);
            LeeftijdSelector.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            LeeftijdSelector.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            LeeftijdSelector.Name = "LeeftijdSelector";
            LeeftijdSelector.Size = new Size(261, 27);
            LeeftijdSelector.TabIndex = 2;
            LeeftijdSelector.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // NameBox
            // 
            NameBox.Location = new Point(28, 13);
            NameBox.MaxLength = 45;
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Voer naam in";
            NameBox.Size = new Size(261, 27);
            NameBox.TabIndex = 1;
            // 
            // AddUserButton
            // 
            AddUserButton.Location = new Point(49, 247);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(150, 50);
            AddUserButton.TabIndex = 0;
            AddUserButton.Text = "Add User";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_Click;
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
            RemoveUserButton.Location = new Point(241, 247);
            RemoveUserButton.Name = "RemoveUserButton";
            RemoveUserButton.Size = new Size(150, 50);
            RemoveUserButton.TabIndex = 8;
            RemoveUserButton.Text = "Remove User";
            RemoveUserButton.UseVisualStyleBackColor = true;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 342);
            Controls.Add(RemoveUserButton);
            Controls.Add(AddUserButton);
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
    }
}