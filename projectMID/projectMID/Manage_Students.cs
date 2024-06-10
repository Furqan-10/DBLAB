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
    public partial class Manage_Students : Form
    {
        public Manage_Students()
        {
            InitializeComponent();
            AddItems();
        }
        static ConnectionString connectionString = new ConnectionString();
        static string connection = connectionString.GetConnection();

        private void Manage_Students_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into Student values(@FirstName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)", conn);
                SqlCommand c = new SqlCommand("select LookupId from Lookup where Name=@Name", conn);
                c.Parameters.AddWithValue("@Name", comboBox2.Text);
                c.ExecuteScalar();
                SqlDataReader reader = c.ExecuteReader();
                reader.Read();
                int i = reader.GetInt32(0);
                reader.Close();
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", i);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddItems()
        {
            string query = "SELECT Name FROM Lookup where LookupId > 4";

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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("update Student set FirstName=@FirstName, LastName=@LastName, Email=@Email, Contact=@Contact, RegistrationNumber=@RegistrationNumber" +
                                                " where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Updated!");
            }
            catch
            {
                MessageBox.Show("Not Updated!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete Student where FirstName=@FirstName", conn);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student Deleted!");
            }
            catch
            {
                MessageBox.Show("Not Deleted!");
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Student", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_ClassAttendence manage_ClassAttendence = new Manage_ClassAttendence();
            manage_ClassAttendence.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_StudentAttendence manage = new Manage_StudentAttendence();
            manage.Show();
        }
    }
}
