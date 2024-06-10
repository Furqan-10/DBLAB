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
using static System.Collections.Specialized.BitVector32;

namespace projectMID
{
    public partial class Manage_StudentAttendence : Form
    {
        public Manage_StudentAttendence()
        {
            InitializeComponent();
            AddItems1();
            AddItems2();
            AddItems3();
        }
        static ConnectionString connectionString = new ConnectionString();
        static string connection = connectionString.GetConnection();
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("delete StudentAttendance where AttendanceId=@attid", sqlConnection);

                SqlCommand c3 = new SqlCommand("select Id from ClassAttendance where Id=@id", sqlConnection);
                c3.Parameters.AddWithValue("@id", comboBox1.Text);
                SqlDataReader reader2 = c3.ExecuteReader();
                reader2.Read();
                int j2 = reader2.GetInt32(0);
                reader2.Close();
                c3.ExecuteScalar();

                sqlCommand.Parameters.AddWithValue("@attid", j2);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Attendance Deleted!");
            }
            catch
            {
                MessageBox.Show("Student Attendance cannot be Deleted!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from StudentAttendance", sqlConnection);
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
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into StudentAttendance values (@AttendanceId,@StuId,@AttStatus)", sqlConnection);

                SqlCommand c1 = new SqlCommand("select Id from Student where RegistrationNumber=@Regno", sqlConnection);
                c1.Parameters.AddWithValue("@Regno", comboBox3.Text);
                SqlDataReader reader = c1.ExecuteReader();
                reader.Read();
                int i = reader.GetInt32(0);
                reader.Close();
                c1.ExecuteScalar();

                SqlCommand c = new SqlCommand("select LookupId from Lookup where Name=@Name", sqlConnection);
                c.Parameters.AddWithValue("@Name", comboBox2.Text);
                c.ExecuteScalar();
                SqlDataReader reader1 = c.ExecuteReader();
                reader1.Read();
                int j = reader1.GetInt32(0);
                reader1.Close();

                SqlCommand c3 = new SqlCommand("select Id from ClassAttendance where Id=@id", sqlConnection);
                c3.Parameters.AddWithValue("@id", comboBox1.Text);
                SqlDataReader reader2 = c3.ExecuteReader();
                reader2.Read();
                int j2 = reader2.GetInt32(0);
                reader2.Close();
                c3.ExecuteScalar();


                cmd.Parameters.AddWithValue("@AttendanceId", j2);
                cmd.Parameters.AddWithValue("@StuId", i);
                cmd.Parameters.AddWithValue("@AttStatus", j);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddItems1()
        {
            string query = "SELECT RegistrationNumber FROM Student";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox3.Items.Clear();

            while (reader.Read())
            {
                comboBox3.Items.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
        }
        private void AddItems2()
        {
            string query = "SELECT Name FROM Lookup where LookupId < 5";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox2.Items.Clear();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
        }

        private void AddItems3()
        {
            string query = "SELECT Id FROM ClassAttendance";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox1.Items.Clear();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetInt32(0));
            }

            reader.Close();
            con.Close();
        }

    }
}
