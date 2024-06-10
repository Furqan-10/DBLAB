using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProjectDLL.BL;
using ProjectDLL.DL;
using ProjectDLL.DL.DB;
using ProjectDLL.Utils;

namespace WindowFormsProject.UI
{
    public partial class SignIn : Form
    {
        private UserDB userDB;
        public SignIn()
        {
            InitializeComponent();
 
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox1.Text;

            try
            {
                // Call the SignIn method of User with username and password parameters
                string role = ObjectHandler.getUserDL().SignIn(username, password);

                if (role != null)
                {
                    progressBar1.Show();
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 2000000;
                    for (int i = 0; i <= 2000000; i = i + 3)
                    {
                        progressBar1.Value = i;
                    }
                   

                    // Open corresponding form based on role
                    if ( (role == "Admin" ) || (role == "admin")) 
                    {
                        this.Hide();
                        AdminMainMenu adminMainMenu = new AdminMainMenu();
                        adminMainMenu.Show();
                    }
                    else if ((role == "Customer") || (role == "customer"))
                    {
                        this.Hide();
                        CustomerMainMenu customerMainMenu = new CustomerMainMenu();
                        customerMainMenu.Show();
                    }

                    // Close the current form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sign-in failed: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
