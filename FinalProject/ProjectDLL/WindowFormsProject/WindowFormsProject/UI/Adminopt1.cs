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
    public partial class Adminopt1 : Form
    {
        private UserDB userDB;

        public Adminopt1()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            //userDB = new UserDB(connectionString);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string newPassword = textBox2.Text;

            try
            {
               
                bool passwordChanged = ObjectHandler.getUserDL().ChangePassword(username, newPassword);
                textBox1.Text = "";
                textBox2.Text = "";

                if (passwordChanged)
                {
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to change password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
