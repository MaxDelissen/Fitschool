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
            SuspendLayout();
            // 
            // buttonBackActiviteiten
            // 
            buttonBackActiviteiten.BackColor = Color.Transparent;
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
            buttonPushUps.FlatAppearance.BorderSize = 0;
            buttonPushUps.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonPushUps.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonPushUps.FlatStyle = FlatStyle.Flat;
            buttonPushUps.Location = new Point(124, 158);
            buttonPushUps.Name = "buttonPushUps";
            buttonPushUps.Size = new Size(472, 358);
            buttonPushUps.TabIndex = 1;
            buttonPushUps.UseVisualStyleBackColor = false;
            buttonPushUps.Click += buttonPushUps_Click;
            // 
            // buttonTTT
            // 
            buttonTTT.BackColor = Color.Yellow;
            buttonTTT.FlatAppearance.BorderSize = 0;
            buttonTTT.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonTTT.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonTTT.FlatStyle = FlatStyle.Flat;
            buttonTTT.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTTT.Location = new Point(724, 158);
            buttonTTT.Name = "buttonTTT";
            buttonTTT.Size = new Size(472, 358);
            buttonTTT.TabIndex = 2;
            buttonTTT.Text = "TicTacToe";
            buttonTTT.UseVisualStyleBackColor = false;
            buttonTTT.Click += buttonTTT_Click;
            // 
            // FormActiviteiten
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(buttonTTT);
            Controls.Add(buttonPushUps);
            Controls.Add(buttonBackActiviteiten);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormActiviteiten";
            Text = "FormActiviteiten";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonBackActiviteiten;
        private Button buttonPushUps;
        private Button buttonTTT;
    }
}