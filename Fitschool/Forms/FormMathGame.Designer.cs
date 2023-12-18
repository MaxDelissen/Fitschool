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
            submitButton = new Button();
            answerBox = new TextBox();
            questionLabel = new Label();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(172, 154);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(104, 27);
            submitButton.TabIndex = 0;
            submitButton.Text = "Controleer";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // answerBox
            // 
            answerBox.Location = new Point(22, 154);
            answerBox.Name = "answerBox";
            answerBox.PlaceholderText = "Antwoord";
            answerBox.Size = new Size(125, 27);
            answerBox.TabIndex = 1;
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.Location = new Point(22, 92);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(89, 20);
            questionLabel.TabIndex = 2;
            questionLabel.Text = "Hello World";
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.FromArgb(255, 192, 192);
            buttonClose.Location = new Point(182, 12);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Stoppen";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormMathGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 233);
            Controls.Add(buttonClose);
            Controls.Add(questionLabel);
            Controls.Add(answerBox);
            Controls.Add(submitButton);
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