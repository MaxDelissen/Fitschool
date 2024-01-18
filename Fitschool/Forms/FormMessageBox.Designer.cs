namespace Fitschool.Forms
{
    partial class FormMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox));
            MessageLabel = new Label();
            OkButton = new Button();
            SuspendLayout();
            // 
            // MessageLabel
            // 
            MessageLabel.BackColor = Color.Transparent;
            MessageLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            MessageLabel.Location = new Point(25, 18);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(450, 164);
            MessageLabel.TabIndex = 0;
            MessageLabel.Text = "We're trying to reach you about your cars extended warrenty! Would you like to fill in this survey?";
            // 
            // OkButton
            // 
            OkButton.BackColor = Color.FromArgb(219, 220, 255);
            OkButton.FlatAppearance.BorderColor = Color.FromArgb(202, 161, 255);
            OkButton.FlatAppearance.BorderSize = 3;
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            OkButton.Location = new Point(367, 183);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(103, 35);
            OkButton.TabIndex = 1;
            OkButton.Text = "Opnieuw";
            OkButton.UseVisualStyleBackColor = false;
            OkButton.Click += OkButton_Click;
            // 
            // FormMessageBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(500, 251);
            Controls.Add(OkButton);
            Controls.Add(MessageLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMessageBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMessageBox";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Label MessageLabel;
        private Button OkButton;
    }
}