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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShop));
            labelTotalPoints = new Label();
            buttonShop1 = new Button();
            buttonBackShop = new Button();
            SuspendLayout();
            // 
            // labelTotalPoints
            // 
            labelTotalPoints.AutoSize = true;
            labelTotalPoints.BackColor = Color.Transparent;
            labelTotalPoints.Font = new Font("Segoe UI Semibold", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalPoints.Location = new Point(1612, 43);
            labelTotalPoints.Name = "labelTotalPoints";
            labelTotalPoints.Size = new Size(53, 62);
            labelTotalPoints.TabIndex = 0;
            labelTotalPoints.Text = "0";
            // 
            // buttonShop1
            // 
            buttonShop1.BackColor = Color.Transparent;
            buttonShop1.FlatAppearance.BorderSize = 0;
            buttonShop1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonShop1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonShop1.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            buttonShop1.Location = new Point(232, 477);
            buttonShop1.Name = "buttonShop1";
            buttonShop1.Size = new Size(159, 61);
            buttonShop1.TabIndex = 2;
            buttonShop1.Text = "100 Punten";
            buttonShop1.UseVisualStyleBackColor = false;
            buttonShop1.Click += ButtonShop1_Click;
            // 
            // buttonBackShop
            // 
            buttonBackShop.BackColor = Color.Transparent;
            buttonBackShop.FlatAppearance.BorderSize = 0;
            buttonBackShop.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonBackShop.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonBackShop.FlatStyle = FlatStyle.Flat;
            buttonBackShop.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBackShop.Location = new Point(61, 26);
            buttonBackShop.Name = "buttonBackShop";
            buttonBackShop.Size = new Size(185, 99);
            buttonBackShop.TabIndex = 3;
            buttonBackShop.UseVisualStyleBackColor = false;
            buttonBackShop.Click += buttonBackShop_Click;
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(buttonBackShop);
            Controls.Add(buttonShop1);
            Controls.Add(labelTotalPoints);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormShop";
            Text = "Shop - Fitschool";
            WindowState = FormWindowState.Maximized;
            Load += FormShop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTotalPoints;
        private Button buttonShop1;
        private Button buttonBackShop;
    }
}