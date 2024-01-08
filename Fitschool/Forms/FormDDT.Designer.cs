namespace Fitschool.Classes.Activiteiten
{
    partial class FormDDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDDT));
            labelQuestion = new Label();
            buttonOption1 = new Button();
            buttonOption2 = new Button();
            buttonOption3 = new Button();
            labelPoints = new Label();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.BackColor = Color.Transparent;
            labelQuestion.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            labelQuestion.Location = new Point(59, 348);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(1172, 81);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "(Beantwoorden) in ieder geval mijn vragen!";
            // 
            // buttonOption1
            // 
            buttonOption1.BackColor = Color.Transparent;
            buttonOption1.FlatAppearance.BorderSize = 0;
            buttonOption1.FlatAppearance.CheckedBackColor = Color.Transparent;
            buttonOption1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonOption1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonOption1.FlatStyle = FlatStyle.Flat;
            buttonOption1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonOption1.Location = new Point(185, 536);
            buttonOption1.Name = "buttonOption1";
            buttonOption1.Size = new Size(355, 123);
            buttonOption1.TabIndex = 1;
            buttonOption1.Text = "geïnteresseerdt";
            buttonOption1.UseVisualStyleBackColor = false;
            buttonOption1.Click += buttonOption_Click;
            // 
            // buttonOption2
            // 
            buttonOption2.BackColor = Color.Transparent;
            buttonOption2.FlatAppearance.BorderSize = 0;
            buttonOption2.FlatAppearance.CheckedBackColor = Color.Transparent;
            buttonOption2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonOption2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonOption2.FlatStyle = FlatStyle.Flat;
            buttonOption2.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonOption2.Location = new Point(795, 536);
            buttonOption2.Name = "buttonOption2";
            buttonOption2.Size = new Size(338, 123);
            buttonOption2.TabIndex = 2;
            buttonOption2.Text = "geïnteresseerdt";
            buttonOption2.UseVisualStyleBackColor = false;
            buttonOption2.Click += buttonOption_Click;
            // 
            // buttonOption3
            // 
            buttonOption3.BackColor = Color.Transparent;
            buttonOption3.FlatAppearance.BorderSize = 0;
            buttonOption3.FlatAppearance.CheckedBackColor = Color.Transparent;
            buttonOption3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonOption3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonOption3.FlatStyle = FlatStyle.Flat;
            buttonOption3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonOption3.Location = new Point(1388, 536);
            buttonOption3.Name = "buttonOption3";
            buttonOption3.Size = new Size(341, 123);
            buttonOption3.TabIndex = 3;
            buttonOption3.Text = "geïnteresseerdt";
            buttonOption3.UseVisualStyleBackColor = false;
            buttonOption3.Click += buttonOption_Click;
            // 
            // labelPoints
            // 
            labelPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPoints.AutoSize = true;
            labelPoints.BackColor = Color.Transparent;
            labelPoints.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            labelPoints.Location = new Point(56, 78);
            labelPoints.Name = "labelPoints";
            labelPoints.Size = new Size(311, 106);
            labelPoints.TabIndex = 4;
            labelPoints.Text = "Punten:";
            labelPoints.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Transparent;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Location = new Point(1768, 22);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(125, 134);
            buttonExit.TabIndex = 5;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // FormDDT
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(buttonExit);
            Controls.Add(labelPoints);
            Controls.Add(buttonOption3);
            Controls.Add(buttonOption2);
            Controls.Add(buttonOption1);
            Controls.Add(labelQuestion);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDDT";
            Padding = new Padding(20, 50, 20, 50);
            Text = "FormDDT";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelQuestion;
        private Button buttonOption1;
        private Button buttonOption2;
        private Button buttonOption3;
        private Label labelPoints;
        private Button buttonExit;
    }
}