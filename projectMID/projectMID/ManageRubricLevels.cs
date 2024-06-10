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
    public partial class ManageRubricLevels : Form
    {
        public ManageRubricLevels()
        {
            InitializeComponent();
            AddItems();
        }
        static ConnectionString connectionString = new ConnectionString();
        static string connection = connectionString.GetConnection();

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete RubricLevel where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Rubric Level Deleted!");
            }
            catch
            {
                MessageBox.Show("Rubric Level cannot be Deleted!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("update RubricLevel set Details=@Details,MeasurementLevel=@MeasurementLevel where Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", textBox1.Text);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Rubric Level Updated!");
            }
            catch
            {
                MessageBox.Show("Not Updated!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into RubricLevel values(@RubricId,@Details,@MeasurementLevel)", sqlConnection);
                SqlCommand c = new SqlCommand("select Id from Rubric where Details=@Details", sqlConnection);
                c.Parameters.AddWithValue("@Details", comboBox1.Text);
                SqlDataReader sqlDataReader = c.ExecuteReader();
                sqlDataReader.Read();
                int i = sqlDataReader.GetInt32(0);
                sqlDataReader.Close();
                c.ExecuteScalar();
                cmd.Parameters.AddWithValue("Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", textBox1.Text);
                cmd.Parameters.AddWithValue("@RubricId", i);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Rubric Level Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
            }
        }
        private void AddItems()
        {
            string query = "SELECT Details FROM Rubric";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox1.Items.Clear();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
        }
    }
    
}
