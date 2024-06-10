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
    public partial class Adminopt7 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public Adminopt7()
        {
            InitializeComponent();
       


            BindDataGrid();
        }
        private void BindDataGrid()
        {
    
            dataGridView1.DataSource = ObjectHandler.getProductDL().ShowAllShirts(); 
        }
        private void Adminopt7_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int shirtID = int.Parse(textBox1.Text);
            int quantity = int.Parse(textBox3.Text);
            decimal price = decimal.Parse(textBox2.Text);
            bool success = ObjectHandler.getProductDL().UpdateShirt(shirtID, quantity, price);
            if (success == true)
            {

                MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            }
            else
            { 

                MessageBox.Show($"Failed to update. An error occurred");
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
