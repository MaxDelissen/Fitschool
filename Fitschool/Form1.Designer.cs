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
            RequestDataButton = new Button();
            IDValue = new NumericUpDown();
            label1 = new Label();
            ShopKnop = new Button();
            AddPointsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)IDValue).BeginInit();
            SuspendLayout();
            // 
            // RequestDataButton
            // 
            RequestDataButton.Location = new Point(124, 79);
            RequestDataButton.Name = "RequestDataButton";
            RequestDataButton.Size = new Size(205, 62);
            RequestDataButton.TabIndex = 0;
            RequestDataButton.Text = "Request data";
            RequestDataButton.UseVisualStyleBackColor = true;
            RequestDataButton.Click += RequestDataButton_Click;
            // 
            // IDValue
            // 
            IDValue.Location = new Point(124, 37);
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
            label1.Location = new Point(149, 9);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 3;
            label1.Text = "Tijdelijke input voor ID:";
            // 
            // ShopKnop
            // 
            ShopKnop.Location = new Point(124, 147);
            ShopKnop.Name = "ShopKnop";
            ShopKnop.Size = new Size(205, 71);
            ShopKnop.TabIndex = 4;
            ShopKnop.Text = "Shop";
            ShopKnop.UseVisualStyleBackColor = true;
            ShopKnop.Click += ShopKnop_Click;
            // 
            // AddPointsButton
            // 
            AddPointsButton.Location = new Point(124, 315);
            AddPointsButton.Name = "AddPointsButton";
            AddPointsButton.Size = new Size(205, 81);
            AddPointsButton.TabIndex = 6;
            AddPointsButton.Text = "Add 10 points to current user (temp)";
            AddPointsButton.UseVisualStyleBackColor = true;
            AddPointsButton.Click += AddPointsButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 445);
            Controls.Add(AddPointsButton);
            Controls.Add(ShopKnop);
            Controls.Add(label1);
            Controls.Add(IDValue);
            Controls.Add(RequestDataButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Inloggen - Fitschool";
            ((System.ComponentModel.ISupportInitialize)IDValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RequestDataButton;
        private NumericUpDown IDValue;
        private Label label1;
        private Button ShopKnop;
        private Button AddPointsButton;
    }
}