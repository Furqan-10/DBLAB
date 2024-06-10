using ProjectDLL.DL.DB;
using ProjectDLL.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormsProject.UI
{
    public partial class Report : Form
    {
        string connection = "Data Source=DESKTOP-RRLMQR8\\MSSQLSERVER01;Initial Catalog=ProjectOOP;Integrated Security=True";
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Feedback", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Feedback");
            CrystalReport1 crystalReport1 = new CrystalReport1();
            crystalReport1.SetDataSource(dataSet);
            crystalReportViewer1.ReportSource = crystalReport1;
            crystalReportViewer1.Refresh();
            sqlConnection.Close();
        }
    }
}
