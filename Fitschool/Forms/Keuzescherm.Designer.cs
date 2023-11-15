namespace Fitschool.Forms
{
    partial class Keuzescherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keuzescherm));
            buttonToActivity = new Button();
            buttonToShop = new Button();
            buttonBackKeuzescherm = new Button();
            SuspendLayout();
            // 
            // buttonToActivity
            // 
            buttonToActivity.BackColor = Color.Transparent;
            buttonToActivity.FlatAppearance.BorderSize = 0;
            buttonToActivity.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonToActivity.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonToActivity.FlatStyle = FlatStyle.Flat;
            buttonToActivity.Location = new Point(124, 400);
            buttonToActivity.Name = "buttonToActivity";
            buttonToActivity.Size = new Size(536, 237);
            buttonToActivity.TabIndex = 0;
            buttonToActivity.UseVisualStyleBackColor = false;
            buttonToActivity.Click += buttonToActivity_Click;
            // 
            // buttonToShop
            // 
            buttonToShop.BackColor = Color.Transparent;
            buttonToShop.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            buttonToShop.FlatAppearance.BorderSize = 0;
            buttonToShop.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonToShop.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonToShop.FlatStyle = FlatStyle.Popup;
            buttonToShop.Location = new Point(1168, 400);
            buttonToShop.Name = "buttonToShop";
            buttonToShop.Size = new Size(559, 237);
            buttonToShop.TabIndex = 1;
            buttonToShop.UseVisualStyleBackColor = false;
            buttonToShop.Click += buttonToShop_Click;
            // 
            // buttonBackKeuzescherm
            // 
            buttonBackKeuzescherm.BackColor = Color.Transparent;
            buttonBackKeuzescherm.FlatAppearance.BorderSize = 0;
            buttonBackKeuzescherm.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonBackKeuzescherm.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonBackKeuzescherm.FlatStyle = FlatStyle.Flat;
            buttonBackKeuzescherm.Location = new Point(61, 31);
            buttonBackKeuzescherm.Name = "buttonBackKeuzescherm";
            buttonBackKeuzescherm.Size = new Size(183, 91);
            buttonBackKeuzescherm.TabIndex = 2;
            buttonBackKeuzescherm.UseVisualStyleBackColor = false;
            buttonBackKeuzescherm.Click += button1_Click;
            // 
            // Keuzescherm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1902, 1033);
            Controls.Add(buttonBackKeuzescherm);
            Controls.Add(buttonToActivity);
            Controls.Add(buttonToShop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Keuzescherm";
            Text = "Keuzescherm";
            WindowState = FormWindowState.Maximized;
            Load += Keuzescherm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonToActivity;
        private Button buttonToShop;
        private Button buttonBackKeuzescherm;
    }
}