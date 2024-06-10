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
    public partial class Adminopt8 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public Adminopt8()
        {
            InitializeComponent();
          
            BindDataGrid();
            BindDataGrid2();
        }
        private void BindDataGrid()
        {
            LoadMenu(); 
        }
        private void BindDataGrid2()
        {

            dataGridView2.DataSource = ObjectHandler.getProductDL().ShowAllShirts(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            try
            {
                ObjectHandler.GetSource().DeleteShoe(name);

                MessageBox.Show("Shoe deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete shoe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindDataGrid();
            BindDataGrid2();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int shirtID = int.Parse(textBox2.Text);

            try
            {
                ObjectHandler.getProductDL().DeleteShirt(shirtID);

                MessageBox.Show("Shirt deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete shirt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadMenu()
        {
          
            dataGridView1.Rows.Clear(); 
            dataGridView1.Columns.Clear(); 
                                         
            dataGridView1.AutoGenerateColumns = false; 
            dataGridView1.Columns.Add("Type", "Product Type"); 
            dataGridView1.Columns.Add("Name", "Product Name"); 
            dataGridView1.Columns.Add("Size", "Product Size"); 
            dataGridView1.Columns.Add("Color", "Product Color"); 
            dataGridView1.Columns.Add("Quantity", "Product Quantity"); 
            dataGridView1.Columns.Add("Price", "Product Price"); 

            dataGridView1.Columns["Type"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Type"].DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.Columns["Name"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Name"].DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.Columns["Size"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Size"].DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.Columns["Color"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Color"].DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.Columns["Quantity"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Quantity"].DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.Columns["Price"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Price"].DefaultCellStyle.ForeColor = Color.Black;
            foreach (ShoeBL product in ObjectHandler.GetSource().getAllShoes())
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["Type"].Value = product.getType(); 
                dataGridView1.Rows[rowIndex].Cells["Name"].Value = product.getName(); 
                dataGridView1.Rows[rowIndex].Cells["Size"].Value = product.getSize();
                dataGridView1.Rows[rowIndex].Cells["Color"].Value = product.getColor();
                dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = product.getQuantity();
                dataGridView1.Rows[rowIndex].Cells["Price"].Value = product.getPrice();

            }
        }
    }
}
