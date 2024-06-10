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
    public partial class Adminopt4 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;

        public Adminopt4()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainMenu adminMainMenu = new AdminMainMenu();
            adminMainMenu.Show();
        }
  
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoadMenu()
        {
            // Assuming dataGridView1 is your DataGridView control
            dataGridView1.Rows.Clear(); // Clear all rows
            dataGridView1.Columns.Clear(); // Clear all columns
                                           // Assuming your data grid is called 'dataGridView1'
            dataGridView1.AutoGenerateColumns = false; // Optional: If you want to manually define columns
            dataGridView1.Columns.Add("Type", "Product Type"); // Define 'Price' column
            dataGridView1.Columns.Add("Name", "Product Name"); // Define 'Name' column
            dataGridView1.Columns.Add("Size", "Product Size"); // Define 'Name' column
            dataGridView1.Columns.Add("Color", "Product Color"); // Define 'Name' column
            dataGridView1.Columns.Add("Quantity", "Product Quantity"); // Define 'Name' column
            dataGridView1.Columns.Add("Price", "Product Price"); // Define 'Price' column

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

            // Change the background and foreground colors for the 'Price' column
            dataGridView1.Columns["Price"].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Columns["Price"].DefaultCellStyle.ForeColor = Color.Black;
     
            foreach (ShoeBL product in ObjectHandler.GetSource().getAllShoes())
            {
                int rowIndex = dataGridView1.Rows.Add(); // Add a new row and get its index
                dataGridView1.Rows[rowIndex].Cells["Type"].Value = product.getType(); // Set 'Name' cell value
                dataGridView1.Rows[rowIndex].Cells["Name"].Value = product.getName(); // Set 'Price' cell value
                dataGridView1.Rows[rowIndex].Cells["Size"].Value = product.getSize();
                dataGridView1.Rows[rowIndex].Cells["Color"].Value = product.getColor();
                dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = product.getQuantity();
                dataGridView1.Rows[rowIndex].Cells["Price"].Value = product.getPrice();

            }
        }
    }
}
