using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4_Miracle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showContact sc = new showContact();
            this.Hide();
            sc.ShowDialog();
            this.Close();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addContact ac = new addContact();
            this.Hide();
            ac.ShowDialog();
            this.Close();
        }
    }
}
