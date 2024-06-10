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
    public partial class Adminopt9 : Form
    {
        private ProductDB productDB;
        private readonly ProductBL productBL;
        public Adminopt9()
        {
            InitializeComponent();
            string connectionString = ConnectionManager.GetConnectionString();
            productDB = new ProductDB(connectionString);
            productBL = new ProductBL(productDB);
            BindDataGrid();
        }
        private void BindDataGrid()
        {
            // Assuming dataGridView1 is the DataGridView control on your form
            dataGridView1.DataSource = ObjectHandler.getProductDL().GetFeedback(); // Assuming ShowAllShoes returns a DataTable
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
            Report report = new Report();
            report.Show();
        }
    }
}
