using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormsProject.UI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 2000000;
            for (int i = 0; i <= 2000000; i = i + 3)
            {
                progressBar1.Value = i;
            }
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
