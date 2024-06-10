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
    public partial class CustomerOp8 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public CustomerOp8()
        {
            InitializeComponent();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string customerName = textBox3.Text;
            string email = textBox1.Text;
            string feedbackText = textBox5.Text;
            int rating = (int)numericUpDown1.Value;

            // Call the method in ProductBL to add feedback
            bool feedbackAdded = ObjectHandler.getProductDL().AddFeedback(customerName, email, feedbackText, rating);

            // Show appropriate message to the user
            if (feedbackAdded)
            {
                MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the input fields after successful submission
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Failed to submit feedback. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void ClearInputFields()
        {
            textBox3.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
