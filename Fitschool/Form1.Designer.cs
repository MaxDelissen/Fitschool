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
            RequestDataButton = new Button();
            IDValue = new NumericUpDown();
            label1 = new Label();
            ShopKnop = new Button();
            panel1 = new Panel();
            leeftijdLabel = new Label();
            LeeftijdSelector = new NumericUpDown();
            NameBox = new TextBox();
            AddUserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)IDValue).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LeeftijdSelector).BeginInit();
            SuspendLayout();
            // 
            // RequestDataButton
            // 
            RequestDataButton.Location = new Point(12, 72);
            RequestDataButton.Name = "RequestDataButton";
            RequestDataButton.Size = new Size(205, 62);
            RequestDataButton.TabIndex = 0;
            RequestDataButton.Text = "Request data";
            RequestDataButton.UseVisualStyleBackColor = true;
            RequestDataButton.Click += RequestDataButton_Click;
            // 
            // IDValue
            // 
            IDValue.Location = new Point(12, 39);
            IDValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            IDValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            IDValue.Name = "IDValue";
            IDValue.Size = new Size(205, 27);
            IDValue.TabIndex = 2;
            IDValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 14);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 3;
            label1.Text = "Tijdelijke input voor ID:";
            // 
            // ShopKnop
            // 
            ShopKnop.Location = new Point(278, 39);
            ShopKnop.Name = "ShopKnop";
            ShopKnop.Size = new Size(94, 29);
            ShopKnop.TabIndex = 4;
            ShopKnop.Text = "Shop";
            ShopKnop.UseVisualStyleBackColor = true;
            ShopKnop.Click += ShopKnop_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(leeftijdLabel);
            panel1.Controls.Add(LeeftijdSelector);
            panel1.Controls.Add(NameBox);
            panel1.Controls.Add(AddUserButton);
            panel1.Location = new Point(13, 258);
            panel1.Name = "panel1";
            panel1.Size = new Size(164, 175);
            panel1.TabIndex = 5;
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
            AddUserButton.Click += AddUserButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 445);
            Controls.Add(panel1);
            Controls.Add(ShopKnop);
            Controls.Add(label1);
            Controls.Add(IDValue);
            Controls.Add(RequestDataButton);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)IDValue).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LeeftijdSelector).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RequestDataButton;
        private NumericUpDown IDValue;
        private Label label1;
        private Button ShopKnop;
        private Panel panel1;
        private Label leeftijdLabel;
        private NumericUpDown LeeftijdSelector;
        private TextBox NameBox;
        private Button AddUserButton;
    }
}