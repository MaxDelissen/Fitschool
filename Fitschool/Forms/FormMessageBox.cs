using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Fitschool.Forms
{
    public partial class FormMessageBox : Form
    {
        private System.Windows.Forms.Timer autoCloseTimer;

        /// <summary>
        /// Creates a new instance of the FormMessageBox class.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="title">The optional title of the message box. Default is "Fitschool".</param>
        /// <param name="buttonText">The optional text for the button. Default is "Oké".</param>
        /// <param name="timer">Flag indicating whether to use a timer to close the form automatically. Default is false.</param>
        public FormMessageBox(string message, string title = "Fitschool", string buttonText = "Oké", bool timer = false)
        {
            InitializeComponent();

            string betterTitle = "    " + title;
            MessageLabel.Text = message;
            Text = betterTitle;
            OkButton.Text = buttonText;

            if (timer)
            {
                OkButton.Visible = false;

                autoCloseTimer = new System.Windows.Forms.Timer();
                autoCloseTimer.Interval = 2000; // 2 seconds
                autoCloseTimer.Tick += AutoCloseTimer_Tick;
                autoCloseTimer.Start();
            }

            this.ShowDialog();
        }

        private void FormMessageBox_Load(object? sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void FormMessageBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }

        private void AutoCloseTimer_Tick(object? sender, EventArgs e)
        {
            // Stop the timer
            autoCloseTimer.Stop();

            // Close the form
            Close();
        }

        private void FormMessageBox_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
