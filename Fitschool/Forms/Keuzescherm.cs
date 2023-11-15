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
    public partial class Keuzescherm : Form
    {
        public Keuzescherm()
        {
            InitializeComponent();
        }

        private void buttonToShop_Click(object sender, EventArgs e)
        {
            var myForm = new FormShop();
            myForm.Show();
            this.Close();
        }

        private void buttonToActivity_Click(object sender, EventArgs e)
        {
            var myForm = new FormActiviteiten();
            myForm.Show();
            this.Close();
        }

        private void Keuzescherm_Load(object sender, EventArgs e)
        {
            buttonToActivity.FlatStyle = FlatStyle.Flat;
            buttonToActivity.FlatAppearance.BorderColor = BackColor;
            buttonToShop.FlatStyle = FlatStyle.Flat;
            buttonToShop.FlatAppearance.BorderColor = BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form1();
            myForm.Show();
            this.Close();
        }
    }
}
