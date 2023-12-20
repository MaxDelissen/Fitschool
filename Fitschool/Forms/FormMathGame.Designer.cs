namespace Fitschool.Forms
{
    partial class FormMathGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMathGame));
            submitButton = new Button();
            answerBox = new TextBox();
            questionLabel = new Label();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.Transparent;
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            submitButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Location = new Point(723, 299);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(468, 159);
            submitButton.TabIndex = 0;
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // answerBox
            // 
            answerBox.BorderStyle = BorderStyle.None;
            answerBox.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            answerBox.Location = new Point(1333, 139);
            answerBox.Name = "answerBox";
            answerBox.PlaceholderText = "...";
            answerBox.Size = new Size(335, 80);
            answerBox.TabIndex = 1;
            answerBox.TextAlign = HorizontalAlignment.Center;
            // 
            // questionLabel
            // 
            questionLabel.BackColor = Color.Transparent;
            questionLabel.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            questionLabel.Location = new Point(208, 139);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(940, 90);
            questionLabel.TabIndex = 2;
            questionLabel.Text = "Hello World";
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Transparent;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(1782, 19);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(115, 113);
            buttonClose.TabIndex = 3;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormMathGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1920, 1080);
            Controls.Add(buttonClose);
            Controls.Add(questionLabel);
            Controls.Add(answerBox);
            Controls.Add(submitButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMathGame";
            Text = "FormMathGame";
            Load += FormMathGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitButton;
        private TextBox answerBox;
        private Label questionLabel;
        private Button buttonClose;
    }
}