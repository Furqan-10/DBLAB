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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowFormsProject.UI
{
    public partial class Adminopt6 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public Adminopt6()
        {
            InitializeComponent();
         

            BindDataGrid();
        }
        private void BindDataGrid()
        {
            LoadMenu(); 
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

        private void button1_Click(object sender, EventArgs e)
        {
            string shoename =textBox1.Text;
            int quantity = int.Parse(textBox3.Text);
            decimal price = decimal.Parse(textBox2.Text);
            bool success = ObjectHandler.GetSource().UpdateShoe(shoename, quantity, price);
            if (success == true)
                {  
       


               
                MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            
            }


            else 
            {
              
                MessageBox.Show("Failed to update. An error occurred!");
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindDataGrid();
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
