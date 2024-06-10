using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormsProject.UI
{
    public partial class CustomerOp9 : Form
    {
        public CustomerOp9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();

        }
    }
}
