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
using ProjectDLL.Utils;

namespace WindowFormsProject.UI
{
    public partial class CustomerOp1 : Form
    {
        private UserDB userDB;
        public CustomerOp1()
        {
            InitializeComponent();
     
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string newPassword = textBox2.Text;

            try
            {
                // Call the BL method to change the password
                bool passwordChanged = ObjectHandler.getUserDL().ChangePassword(username, newPassword);

                if (passwordChanged)
                {
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
        }
    }
}
