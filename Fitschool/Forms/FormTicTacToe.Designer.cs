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
            Panel = new Panel();
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
            Panel.Location = new Point(29, 97);
            Panel.Margin = new Padding(20);
            Panel.Name = "Panel";
            Panel.Padding = new Padding(10);
            Panel.Size = new Size(442, 442);
            Panel.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(310, 30);
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
            button2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(170, 30);
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
            button1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(30, 30);
            button1.Margin = new Padding(20);
            button1.Name = "button1";
            button1.Size = new Size(100, 100);
            button1.TabIndex = 6;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Option_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(310, 170);
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
            button5.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(170, 170);
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
            button4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(30, 170);
            button4.Margin = new Padding(20);
            button4.Name = "button4";
            button4.Size = new Size(100, 100);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Option_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(310, 310);
            button9.Margin = new Padding(20);
            button9.Name = "button9";
            button9.Size = new Size(100, 100);
            button9.TabIndex = 2;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Option_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(170, 310);
            button8.Margin = new Padding(20);
            button8.Name = "button8";
            button8.Size = new Size(100, 100);
            button8.TabIndex = 1;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Option_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(30, 310);
            button7.Margin = new Padding(20);
            button7.Name = "button7";
            button7.Size = new Size(100, 100);
            button7.TabIndex = 0;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Option_Click;
            // 
            // labelPlayerX
            // 
            labelPlayerX.AutoSize = true;
            labelPlayerX.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayerX.Location = new Point(29, 9);
            labelPlayerX.Name = "labelPlayerX";
            labelPlayerX.Size = new Size(207, 37);
            labelPlayerX.TabIndex = 1;
            labelPlayerX.Text = "X : Timo Jansen";
            // 
            // labelPlayerO
            // 
            labelPlayerO.AutoSize = true;
            labelPlayerO.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayerO.Location = new Point(29, 49);
            labelPlayerO.Name = "labelPlayerO";
            labelPlayerO.Size = new Size(210, 37);
            labelPlayerO.TabIndex = 2;
            labelPlayerO.Text = "O : Timo Jansen";
            // 
            // labelPlayerTurn
            // 
            labelPlayerTurn.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayerTurn.ForeColor = SystemColors.ControlDarkDark;
            labelPlayerTurn.Location = new Point(29, 543);
            labelPlayerTurn.Name = "labelPlayerTurn";
            labelPlayerTurn.Size = new Size(442, 39);
            labelPlayerTurn.TabIndex = 3;
            labelPlayerTurn.Text = "Timo Jansen is aan de beurt";
            labelPlayerTurn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormTicTacToe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 589);
            ControlBox = false;
            Controls.Add(labelPlayerTurn);
            Controls.Add(labelPlayerO);
            Controls.Add(labelPlayerX);
            Controls.Add(Panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTicTacToe";
            Text = "TicTacToe";
            Load += FormTicTacToe_Load;
            Panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Label labelPlayerX;
        private Label labelPlayerO;
        private Label labelPlayerTurn;
    }
}