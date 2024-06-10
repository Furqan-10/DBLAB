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
    public partial class CustomerOp7 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public CustomerOp7()
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalAmount = ObjectHandler.getProductDL().CalculateTotalPayableAmount();

            // Display total payable amount to the user
            MessageBox.Show($"Total payable amount: {totalAmount:C}", "Total Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Empty cart tables
            bool emptied = ObjectHandler.getProductDL().EmptyCartTables();
            if (emptied)
            {
                MessageBox.Show("THANKS FOR SHOPPING!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindDataGrid();
            BindDataGrid2();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();

        }
    }
}
