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
using ProjectDLL.DL;
using ProjectDLL.DL.DB;
using ProjectDLL.Utils;

namespace WindowFormsProject.UI
{
    public partial class Adminopt2 : Form
    {
        private ProductDB productDB;

        public Adminopt2()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             
                string type = textBox1.Text;
                string name = textBox2.Text;
                int size = int.Parse(textBox3.Text);
                string color = textBox4.Text;
                int quantity = int.Parse(textBox5.Text);
                decimal price = decimal.Parse(textBox6.Text);

                if (checkForSameName(name))
                {

                    ObjectHandler.GetSource().AddShoe(type, name, size, color, quantity, price);
                    MessageBox.Show("Shoe added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Shoe already exists");
                }

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding shoe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private bool checkForSameName(string name)
        {
            foreach(ShoeBL sho in ObjectHandler.GetSource().getAllShoes())
            {
                if (sho.getName() == name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
