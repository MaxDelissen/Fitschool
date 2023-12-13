namespace Fitschool.Forms
{
    partial class FormTicTacToe
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
            Panel = new Panel();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            Panel.SuspendLayout();
            SuspendLayout();
            // 
            // Panel
            // 
            Panel.BorderStyle = BorderStyle.FixedSingle;
            Panel.Controls.Add(button3);
            Panel.Controls.Add(button2);
            Panel.Controls.Add(button1);
            Panel.Controls.Add(button6);
            Panel.Controls.Add(button5);
            Panel.Controls.Add(button4);
            Panel.Controls.Add(button9);
            Panel.Controls.Add(button8);
            Panel.Controls.Add(button7);
            Panel.Location = new Point(12, 12);
            Panel.Margin = new Padding(20);
            Panel.Name = "Panel";
            Panel.Padding = new Padding(10);
            Panel.Size = new Size(476, 476);
            Panel.TabIndex = 0;
            // 
            // button7
            // 
            button7.Location = new Point(13, 361);
            button7.Margin = new Padding(20);
            button7.Name = "button7";
            button7.Size = new Size(100, 100);
            button7.TabIndex = 0;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Option_Click;
            // 
            // button8
            // 
            button8.Location = new Point(153, 358);
            button8.Margin = new Padding(20);
            button8.Name = "button8";
            button8.Size = new Size(100, 100);
            button8.TabIndex = 1;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Option_Click;
            // 
            // button9
            // 
            button9.Location = new Point(293, 358);
            button9.Margin = new Padding(20);
            button9.Name = "button9";
            button9.Size = new Size(100, 100);
            button9.TabIndex = 2;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Option_Click;
            // 
            // button6
            // 
            button6.Location = new Point(293, 218);
            button6.Margin = new Padding(20);
            button6.Name = "button6";
            button6.Size = new Size(100, 100);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Option_Click;
            // 
            // button5
            // 
            button5.Location = new Point(153, 218);
            button5.Margin = new Padding(20);
            button5.Name = "button5";
            button5.Size = new Size(100, 100);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Option_Click;
            // 
            // button4
            // 
            button4.Location = new Point(13, 221);
            button4.Margin = new Padding(20);
            button4.Name = "button4";
            button4.Size = new Size(100, 100);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Option_Click;
            // 
            // button3
            // 
            button3.Location = new Point(293, 78);
            button3.Margin = new Padding(20);
            button3.Name = "button3";
            button3.Size = new Size(100, 100);
            button3.TabIndex = 8;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Option_Click;
            // 
            // button2
            // 
            button2.Location = new Point(153, 78);
            button2.Margin = new Padding(20);
            button2.Name = "button2";
            button2.Size = new Size(100, 100);
            button2.TabIndex = 7;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Option_Click;
            // 
            // button1
            // 
            button1.Location = new Point(13, 81);
            button1.Margin = new Padding(20);
            button1.Name = "button1";
            button1.Size = new Size(100, 100);
            button1.TabIndex = 6;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Option_Click;
            // 
            // FormTicTacToe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 500);
            Controls.Add(Panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTicTacToe";
            Text = "FormTicTacToe";
            Panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button8;
        private Button button7;
    }
}