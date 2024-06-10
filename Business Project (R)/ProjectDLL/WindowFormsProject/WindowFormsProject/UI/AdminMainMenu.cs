using ProjectDLL.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectDLL.BL;
using ProjectDLL.DL.DB;

namespace WindowFormsProject.UI
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt1 adminopt1 = new Adminopt1();
            adminopt1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt2 adminopt2 = new Adminopt2();
            adminopt2.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt5 adminopt5 = new Adminopt5();
            adminopt5.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt8 adminopt8 = new Adminopt8();
            adminopt8.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt9 adminopt9 = new Adminopt9();
            adminopt9.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt3 adminopt3 = new Adminopt3();
            adminopt3.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide() ;
            Adminopt4 adminopt4 = new Adminopt4();
            adminopt4.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt6 adminopt6 = new Adminopt6();
            adminopt6.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Adminopt7 adminopt7 = new Adminopt7();
            adminopt7.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
     
        }
    }
}
