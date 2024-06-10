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
    public partial class CustomerOp6 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public CustomerOp6()
        {
            InitializeComponent();
            

            // Call the method to bind the data to the DataGridView
            BindDataGrid();
            BindDataGrid2();
        }
        private void BindDataGrid()
        {
            // Assuming dataGridView1 is the DataGridView control on your form
            dataGridView1.DataSource = ObjectHandler.getProductDL().GetShoeCart(); // Assuming ShowAllShoes returns a DataTable
        }
        private void BindDataGrid2()
        {
            // Assuming dataGridView1 is the DataGridView control on your form
            dataGridView2.DataSource = ObjectHandler.getProductDL().GetShirtCart(); // Assuming ShowAllShoes returns a DataTable
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int shoeID = int.Parse(textBox1.Text);

            // Call the BL function to delete the shoe from the ShoeCart
            bool deleted = ObjectHandler.getProductDL().DeleteFromShoeCart(shoeID);

            if (deleted)
            {
                MessageBox.Show("Shoe deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                // Refresh or update the UI as needed
            }
            else
            {
             
                MessageBox.Show("Failed to delete shoe from cart. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
            BindDataGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int shirtID = int.Parse(textBox4.Text);

            // Call the BL function to delete the shirt from the ShirtCart
            bool deleted = ObjectHandler.getProductDL().DeleteFromShirtCart(shirtID);

            if (deleted)
            {
                MessageBox.Show("Shirt deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Text = "";
                // Refresh or update the UI as needed
            }
            else
            {
                MessageBox.Show("Failed to delete shirt from cart. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = "";
            }
            BindDataGrid2();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
        }
    }
}
