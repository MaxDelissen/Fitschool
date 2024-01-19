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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTicTacToe));
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            labelPlayerX = new Label();
            labelPlayerO = new Label();
            labelPlayerTurn = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(1006, 390);
            button3.Margin = new Padding(20);
            button3.Name = "button3";
            button3.Size = new Size(133, 133);
            button3.TabIndex = 8;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Option_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(844, 390);
            button2.Margin = new Padding(20);
            button2.Name = "button2";
            button2.Size = new Size(140, 133);
            button2.TabIndex = 7;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Option_Click;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(685, 390);
            button1.Margin = new Padding(20);
            button1.Name = "button1";
            button1.Size = new Size(132, 133);
            button1.TabIndex = 6;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Option_Click;
            // 
            // button6
            // 
            button6.Cursor = Cursors.Hand;
            button6.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(1006, 543);
            button6.Margin = new Padding(20);
            button6.Name = "button6";
            button6.Size = new Size(133, 146);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Option_Click;
            // 
            // button5
            // 
            button5.Cursor = Cursors.Hand;
            button5.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(844, 543);
            button5.Margin = new Padding(20);
            button5.Name = "button5";
            button5.Size = new Size(140, 146);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Option_Click;
            // 
            // button4
            // 
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(685, 543);
            button4.Margin = new Padding(20);
            button4.Name = "button4";
            button4.Size = new Size(132, 146);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Option_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(1006, 705);
            button9.Margin = new Padding(20);
            button9.Name = "button9";
            button9.Size = new Size(133, 136);
            button9.TabIndex = 2;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Option_Click;
            // 
            // button8
            // 
            button8.Cursor = Cursors.Hand;
            button8.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(844, 705);
            button8.Margin = new Padding(20);
            button8.Name = "button8";
            button8.Size = new Size(140, 136);
            button8.TabIndex = 1;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Option_Click;
            // 
            // button7
            // 
            button7.Cursor = Cursors.Hand;
            button7.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(685, 705);
            button7.Margin = new Padding(20);
            button7.Name = "button7";
            button7.Size = new Size(132, 136);
            button7.TabIndex = 0;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Option_Click;
            // 
            // labelPlayerX
            // 
            labelPlayerX.AutoSize = true;
            labelPlayerX.BackColor = Color.Transparent;
            labelPlayerX.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayerX.Location = new Point(614, 234);
            labelPlayerX.Name = "labelPlayerX";
            labelPlayerX.Size = new Size(303, 54);
            labelPlayerX.TabIndex = 1;
            labelPlayerX.Text = "X : Timo Jansen";
            // 
            // labelPlayerO
            // 
            labelPlayerO.AutoSize = true;
            labelPlayerO.BackColor = Color.Transparent;
            labelPlayerO.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayerO.Location = new Point(614, 297);
            labelPlayerO.Name = "labelPlayerO";
            labelPlayerO.Size = new Size(308, 54);
            labelPlayerO.TabIndex = 2;
            labelPlayerO.Text = "O : Timo Jansen";
            // 
            // labelPlayerTurn
            // 
            labelPlayerTurn.BackColor = Color.Transparent;
            labelPlayerTurn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayerTurn.ForeColor = SystemColors.ControlDarkDark;
            labelPlayerTurn.Location = new Point(611, 861);
            labelPlayerTurn.Name = "labelPlayerTurn";
            labelPlayerTurn.Size = new Size(602, 55);
            labelPlayerTurn.TabIndex = 3;
            labelPlayerTurn.Text = "Timo Jansen is aan de beurt";
            labelPlayerTurn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormTicTacToe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            ControlBox = false;
            Controls.Add(button9);
            Controls.Add(button6);
            Controls.Add(button8);
            Controls.Add(button1);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(labelPlayerTurn);
            Controls.Add(labelPlayerO);
            Controls.Add(labelPlayerX);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTicTacToe";
            Text = "TicTacToe";
            WindowState = FormWindowState.Maximized;
            Load += FormTicTacToe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button8;
        private Button button7;
        private Label labelPlayerX;
        private Label labelPlayerO;
        private Label labelPlayerTurn;
    }
}