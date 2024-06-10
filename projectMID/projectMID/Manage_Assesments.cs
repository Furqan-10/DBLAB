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
    public partial class Manage_Assesments : Form
    {
        public Manage_Assesments()
        {
            InitializeComponent();
        }

        static ConnectionString connectionString = new ConnectionString();
        static string connection = connectionString.GetConnection() ;
        private void Manage_Assesments_Load(object sender, EventArgs e)
        {

        }

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
            SqlCommand cmd = new SqlCommand("select * from Assessment", sqlConnection);
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
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("delete Assessment where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Deleted!");
            }
            catch
            {
                MessageBox.Show("Assessment Cannot be Deleted!");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("update Assessment set Title=@Title,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
                cmd.Parameters.AddWithValue("@TotalWeightage", textBox1.Text);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Updated!");
            }
            catch
            {
                MessageBox.Show("Not Updated!");
            }
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("insert into Assessment values(@Title,@DateCreated,@TotalMarks,@TotalWeightage)", sqlConnection);
                cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
                cmd.Parameters.AddWithValue("@TotalWeightage", textBox1.Text);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
            }
        }
    }
}
