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
    public partial class CustomerOp3 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public CustomerOp3()
        {
            InitializeComponent();
         

            // Call the method to bind the data to the DataGridView
            BindDataGrid();
        }
        private void BindDataGrid()
        {
            // Assuming dataGridView1 is the DataGridView control on your form
            dataGridView1.DataSource = ObjectHandler.getProductDL().ShowAllShirts(); // Assuming ShowAllShoes returns a DataTable
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu   = new CustomerMainMenu();
            customerMainMenu.Show();
        }
    }
}
