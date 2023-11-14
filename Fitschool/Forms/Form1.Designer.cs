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
            OpenUserManagementButton = new Button();
            ((System.ComponentModel.ISupportInitialize)IDValue).BeginInit();
            SuspendLayout();
            // 
            // RequestDataButton
            // 
            RequestDataButton.Location = new Point(53, 169);
            RequestDataButton.Margin = new Padding(3, 2, 3, 2);
            RequestDataButton.Name = "RequestDataButton";
            RequestDataButton.Size = new Size(296, 66);
            RequestDataButton.TabIndex = 0;
            RequestDataButton.Text = "Inloggen";
            RequestDataButton.UseVisualStyleBackColor = true;
            RequestDataButton.Click += RequestDataButton_Click;
            // 
            // IDValue
            // 
            IDValue.Location = new Point(108, 113);
            IDValue.Margin = new Padding(3, 2, 3, 2);
            IDValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            IDValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            IDValue.Name = "IDValue";
            IDValue.Size = new Size(205, 23);
            IDValue.TabIndex = 2;
            IDValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(192, 255, 192);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(53, 20);
            label1.Name = "label1";
            label1.Padding = new Padding(15);
            label1.Size = new Size(296, 134);
            label1.TabIndex = 3;
            label1.Text = "Scan uw pas";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OpenUserManagementButton
            // 
            OpenUserManagementButton.Location = new Point(9, 253);
            OpenUserManagementButton.Name = "OpenUserManagementButton";
            OpenUserManagementButton.Size = new Size(123, 38);
            OpenUserManagementButton.TabIndex = 4;
            OpenUserManagementButton.Text = "Gebruiker beheer";
            OpenUserManagementButton.UseVisualStyleBackColor = true;
            OpenUserManagementButton.Click += OpenUserManagementButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 298);
            Controls.Add(OpenUserManagementButton);
            Controls.Add(IDValue);
            Controls.Add(label1);
            Controls.Add(RequestDataButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Padding = new Padding(50, 20, 50, 20);
            Text = "Inloggen - Fitschool";
            ((System.ComponentModel.ISupportInitialize)IDValue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button RequestDataButton;
        private NumericUpDown IDValue;
        private Label label1;
        private Button OpenUserManagementButton;
    }
}