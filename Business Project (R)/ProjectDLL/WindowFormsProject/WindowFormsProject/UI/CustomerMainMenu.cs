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
    public partial class CustomerMainMenu : Form
    {
        public CustomerMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp1 op1 = new CustomerOp1();
            op1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp2 op2 = new CustomerOp2();
            op2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp3 op3 = new CustomerOp3();
            op3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp8 op8 = new CustomerOp8();
            op8.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp9 op9 = new CustomerOp9();
            op9.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp4 op4 = new CustomerOp4();
            op4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp6 op6 = new CustomerOp6();
            op6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOp7 op7 = new CustomerOp7();
            op7.Show();
        }
    }
}
