using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        public FormShop()
        {
            InitializeComponent();
        }
        
        int TotalPoints = 1000;

        private void FormShop_Load(object sender, EventArgs e)
        {
            labelTotalPoints.Text = TotalPoints.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            TotalPoints = TotalPoints - 10;
            labelTotalPoints.Text = TotalPoints.ToString();
        }
    }
}
