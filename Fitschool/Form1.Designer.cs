﻿using MySql.Data.MySqlClient;

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
            buttonFormswitch = new Button();
            ((System.ComponentModel.ISupportInitialize)IDValue).BeginInit();
            SuspendLayout();
            // 
            // RequestDataButton
            // 
            RequestDataButton.Location = new Point(12, 72);
            RequestDataButton.Name = "RequestDataButton";
            RequestDataButton.Size = new Size(376, 176);
            RequestDataButton.TabIndex = 0;
            RequestDataButton.Text = "Request data";
            RequestDataButton.UseVisualStyleBackColor = true;
            RequestDataButton.Click += RequestDataButton_Click;
            // 
            // IDValue
            // 
            IDValue.Location = new Point(12, 39);
            IDValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            IDValue.Name = "IDValue";
            IDValue.Size = new Size(376, 27);
            IDValue.TabIndex = 2;
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
            // buttonFormswitch
            // 
            buttonFormswitch.Location = new Point(474, 72);
            buttonFormswitch.Name = "buttonFormswitch";
            buttonFormswitch.Size = new Size(94, 29);
            buttonFormswitch.TabIndex = 4;
            buttonFormswitch.Text = "button1";
            buttonFormswitch.UseVisualStyleBackColor = true;
            buttonFormswitch.Click += buttonFormswitch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 445);
            Controls.Add(buttonFormswitch);
            Controls.Add(label1);
            Controls.Add(IDValue);
            Controls.Add(RequestDataButton);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)IDValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RequestDataButton;
        private NumericUpDown IDValue;
        private Label label1;
        //private MySqlConnector.MySqlCommandBuilder mySqlCommandBuilder1;
        private Button buttonFormswitch;
    }
}