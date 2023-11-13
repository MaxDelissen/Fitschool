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
            panel1.Controls.Add(AddUserButton);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 342);
            panel1.TabIndex = 6;
            // 
            // leeftijdLabel
            // 
            leeftijdLabel.AutoSize = true;
            leeftijdLabel.Location = new Point(3, 62);
            leeftijdLabel.Name = "leeftijdLabel";
            leeftijdLabel.Size = new Size(109, 20);
            leeftijdLabel.TabIndex = 3;
            leeftijdLabel.Text = "Voer leeftijd in:";
            // 
            // LeeftijdSelector
            // 
            LeeftijdSelector.Location = new Point(3, 85);
            LeeftijdSelector.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            LeeftijdSelector.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            LeeftijdSelector.Name = "LeeftijdSelector";
            LeeftijdSelector.Size = new Size(156, 27);
            LeeftijdSelector.TabIndex = 2;
            LeeftijdSelector.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // NameBox
            // 
            NameBox.Location = new Point(3, 3);
            NameBox.Name = "NameBox";
            NameBox.PlaceholderText = "Voer naam in";
            NameBox.Size = new Size(156, 27);
            NameBox.TabIndex = 1;
            // 
            // AddUserButton
            // 
            AddUserButton.Location = new Point(3, 133);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(94, 29);
            AddUserButton.TabIndex = 0;
            AddUserButton.Text = "Add User";
            AddUserButton.UseVisualStyleBackColor = true;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 366);
            Controls.Add(panel1);
            Name = "FormUserManagement";
            Text = "FormUserManagement";
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
    }
}