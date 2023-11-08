namespace Fitschool
{
    partial class FormShop
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
            labelTotalPoints = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelTotalPoints
            // 
            labelTotalPoints.AutoSize = true;
            labelTotalPoints.Location = new Point(685, 9);
            labelTotalPoints.Name = "labelTotalPoints";
            labelTotalPoints.Size = new Size(102, 20);
            labelTotalPoints.TabIndex = 0;
            labelTotalPoints.Text = "Total points: 0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.RodePanda;
            pictureBox1.Location = new Point(35, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 202);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(35, 246);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(labelTotalPoints);
            Name = "FormShop";
            Text = "FormShop";
            Load += FormShop_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTotalPoints;
        private PictureBox pictureBox1;
        private Button button1;
    }
}