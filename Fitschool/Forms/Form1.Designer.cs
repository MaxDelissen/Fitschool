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
            IDValue = new NumericUpDown();
            RequestDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)IDValue).BeginInit();
            SuspendLayout();
            // 
            // IDValue
            // 
            IDValue.Location = new Point(837, 536);
            IDValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            IDValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            IDValue.Name = "IDValue";
            IDValue.Size = new Size(238, 27);
            IDValue.TabIndex = 0;
            IDValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // RequestDataButton
            // 
            RequestDataButton.Location = new Point(900, 569);
            RequestDataButton.Name = "RequestDataButton";
            RequestDataButton.Size = new Size(94, 29);
            RequestDataButton.TabIndex = 1;
            RequestDataButton.Text = "Enter";
            RequestDataButton.UseVisualStyleBackColor = true;
            RequestDataButton.Click += RequestDataButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Frame_1;
            ClientSize = new Size(1902, 1033);
            Controls.Add(RequestDataButton);
            Controls.Add(IDValue);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Padding = new Padding(57, 27, 57, 27);
            Text = "Inloggen - Fitschool";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)IDValue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown IDValue;
        private Button RequestDataButton;
    }
}