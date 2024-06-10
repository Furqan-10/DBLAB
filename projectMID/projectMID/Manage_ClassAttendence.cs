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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectMID
{
    public partial class Manage_ClassAttendence : Form
    {
        public Manage_ClassAttendence()
        {
            InitializeComponent();
        }

        static ConnectionString connectionString = new ConnectionString();
        static string connection = connectionString.GetConnection();
        private void Manage_ClassAttendence_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("delete ClassAttendance where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Class Attendance Deleted!");
            }
            catch
            {
                MessageBox.Show("Class Attendance cannot be Deleted!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from ClassAttendance", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into ClassAttendance values (@AttendanceDate)", con);
                sqlCommand.Parameters.AddWithValue("@AttendanceDate", DateTime.Now);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Class Attendance Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }
    }
}
