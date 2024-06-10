﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectMID
{
    public partial class ManageAssessmentComponent : Form
    {
        public ManageAssessmentComponent()
        {
            InitializeComponent();
            AddItems1();
            AddItems2();
        }
        static ConnectionString connectionString = new ConnectionString();
        static string connection = connectionString.GetConnection();
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                SqlCommand cmd = new SqlCommand("update AssessmentComponent set Name=@Name,TotalMarks=@TotalMarks,DateUpdated=@Date where Id=@Id", sql);
                cmd.Parameters.AddWithValue("@Id", textBox2.Text);
                cmd.Parameters.AddWithValue("@Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Assessment Component Updated!");
            }
            catch
            {
                MessageBox.Show("Not Updated!");
            }
        }

        private void ManageAssessmentComponent_Load(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("select * from AssessmentComponent", sqlConnection);
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
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                SqlCommand cmd = new SqlCommand("delete AssessmentComponent where Id=@Id", sql);
                cmd.Parameters.AddWithValue("@Id", textBox2.Text);
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Assessment Component Deleted!");
            }
            catch
            {
                MessageBox.Show("Assessment Component cannot be Deleted!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into AssessmentComponent values(@Name,@RubricId,@TotalMarks,@DateCreated,@Date,@AssessmentId)", sqlConnection);

                SqlCommand c = new SqlCommand("select Id from Rubric where Details=@Details", sqlConnection);
                c.Parameters.AddWithValue("@Details", comboBox2.Text);
                SqlDataReader sqlDataReader = c.ExecuteReader();
                sqlDataReader.Read();
                int i = sqlDataReader.GetInt32(0);
                sqlDataReader.Close();
                c.ExecuteScalar();

                SqlCommand cm = new SqlCommand("select Id from Assessment where Title=@Title", sqlConnection);
                cm.Parameters.AddWithValue("@Title", comboBox1.Text);
                SqlDataReader DataReader = cm.ExecuteReader();
                DataReader.Read();
                int j = DataReader.GetInt32(0);
                DataReader.Close();
                cm.ExecuteScalar();


                cmd.Parameters.AddWithValue("@Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                cmd.Parameters.AddWithValue("@RubricId", i);
                cmd.Parameters.AddWithValue("@AssessmentId", j);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Component Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddItems1()
        {
            string query = "SELECT Details FROM Rubric";

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

        private void AddItems2()
        {
            string query = "SELECT Title FROM Assessment";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
