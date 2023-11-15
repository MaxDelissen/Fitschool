using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitschool.Forms
{
    public partial class FormActiviteiten : Form
    {
        public FormActiviteiten()
        {
            InitializeComponent();
        }

        private void buttonBackActiviteiten_Click(object sender, EventArgs e)
        {
            var myForm = new Keuzescherm();
            myForm.Show();
            this.Close();
        }

        private void FormActiviteiten_Load(object sender, EventArgs e)
        {

        }

        private void buttonPushUps_Click(object sender, EventArgs e)
        {

        }
    }
}
