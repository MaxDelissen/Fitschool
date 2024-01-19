namespace Fitschool.Forms
{
    partial class FormActiviteiten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActiviteiten));
            buttonBackActiviteiten = new Button();
            buttonPushUps = new Button();
            buttonTTT = new Button();
            IdBox = new TextBox();
            buttonMath = new Button();
            buttonLanguage = new Button();
            SuspendLayout();
            // 
            // buttonBackActiviteiten
            // 
            buttonBackActiviteiten.BackColor = Color.Transparent;
            buttonBackActiviteiten.Cursor = Cursors.Hand;
            buttonBackActiviteiten.FlatAppearance.BorderSize = 0;
            buttonBackActiviteiten.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonBackActiviteiten.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonBackActiviteiten.FlatStyle = FlatStyle.Flat;
            buttonBackActiviteiten.Location = new Point(55, 32);
            buttonBackActiviteiten.Name = "buttonBackActiviteiten";
            buttonBackActiviteiten.Size = new Size(194, 90);
            buttonBackActiviteiten.TabIndex = 0;
            buttonBackActiviteiten.UseVisualStyleBackColor = false;
            buttonBackActiviteiten.Click += buttonBackActiviteiten_Click;
            // 
            // buttonPushUps
            // 
            buttonPushUps.BackColor = Color.Transparent;
            buttonPushUps.Cursor = Cursors.Hand;
            buttonPushUps.FlatAppearance.BorderSize = 0;
            buttonPushUps.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonPushUps.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonPushUps.FlatStyle = FlatStyle.Flat;
            buttonPushUps.Location = new Point(333, 158);
            buttonPushUps.Name = "buttonPushUps";
            buttonPushUps.Size = new Size(472, 358);
            buttonPushUps.TabIndex = 1;
            buttonPushUps.UseVisualStyleBackColor = false;
            buttonPushUps.Click += buttonPushUps_Click;
            // 
            // buttonTTT
            // 
            buttonTTT.BackColor = Color.Transparent;
            buttonTTT.Cursor = Cursors.Hand;
            buttonTTT.FlatAppearance.BorderSize = 0;
            buttonTTT.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonTTT.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonTTT.FlatStyle = FlatStyle.Flat;
            buttonTTT.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTTT.Location = new Point(1156, 158);
            buttonTTT.Name = "buttonTTT";
            buttonTTT.Size = new Size(472, 358);
            buttonTTT.TabIndex = 2;
            buttonTTT.UseVisualStyleBackColor = false;
            buttonTTT.Click += buttonTTT_Click;
            // 
            // IdBox
            // 
            IdBox.BackColor = Color.FromArgb(6, 225, 219);
            IdBox.BorderStyle = BorderStyle.None;
            IdBox.Location = new Point(1887, 1009);
            IdBox.MaxLength = 5;
            IdBox.Name = "IdBox";
            IdBox.Size = new Size(19, 20);
            IdBox.TabIndex = 5;
            // 
            // buttonMath
            // 
            buttonMath.BackColor = Color.Transparent;
            buttonMath.Cursor = Cursors.Hand;
            buttonMath.FlatAppearance.BorderSize = 0;
            buttonMath.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonMath.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonMath.FlatStyle = FlatStyle.Flat;
            buttonMath.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMath.Location = new Point(1156, 615);
            buttonMath.Name = "buttonMath";
            buttonMath.Size = new Size(472, 358);
            buttonMath.TabIndex = 6;
            buttonMath.UseVisualStyleBackColor = false;
            buttonMath.Click += buttonMath_Click;
            // 
            // buttonLanguage
            // 
            buttonLanguage.BackColor = Color.Transparent;
            buttonLanguage.Cursor = Cursors.Hand;
            buttonLanguage.FlatAppearance.BorderSize = 0;
            buttonLanguage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonLanguage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonLanguage.FlatStyle = FlatStyle.Flat;
            buttonLanguage.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLanguage.Location = new Point(333, 615);
            buttonLanguage.Name = "buttonLanguage";
            buttonLanguage.Size = new Size(472, 358);
            buttonLanguage.TabIndex = 7;
            buttonLanguage.UseVisualStyleBackColor = false;
            buttonLanguage.Click += buttonLanguage_Click;
            // 
            // FormActiviteiten
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(buttonLanguage);
            Controls.Add(buttonMath);
            Controls.Add(IdBox);
            Controls.Add(buttonTTT);
            Controls.Add(buttonPushUps);
            Controls.Add(buttonBackActiviteiten);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormActiviteiten";
            Text = "FormActiviteiten";
            WindowState = FormWindowState.Maximized;
            Load += FormActiviteiten_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonBackActiviteiten;
        private Button buttonPushUps;
        private Button buttonTTT;
        private TextBox IdBox;
        private Button buttonMath;
        private Button buttonLanguage;
    }
}