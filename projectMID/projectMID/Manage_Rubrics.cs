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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectMID
{
    public partial class Manage_Rubrics : Form
    {
        public Manage_Rubrics()
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete Rubric where Id=@ID", conn);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Rubric Deleted!");
            }
            catch
            {
                MessageBox.Show("Rubric cannot be Deleted!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manage_Rubrics_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("update Rubric set Details=@Details where Id=@Id", con);
                sqlCommand.Parameters.AddWithValue("@Id", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@Details", textBox2.Text);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Rubric Updated!");
            }
            catch
            {
                MessageBox.Show("Not Updated!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from Rubric", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
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
                SqlCommand cmd = new SqlCommand("insert into Rubric(Details,CloId) values(@Details,@CloId)", sqlConnection);
                SqlCommand c = new SqlCommand("select Id from Clo where Name=@Name", sqlConnection);
                c.Parameters.AddWithValue("@Name", comboBox1.Text);
                c.ExecuteScalar();
                SqlDataReader reader = c.ExecuteReader();
                reader.Read();
                int i = reader.GetInt32(0);
                reader.Close();
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@CloId", i);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Rubric Added!");
            }
            catch
            {
                MessageBox.Show("Not Added!");
            }
        }

        private void AddItems()
        {
            string query = "SELECT Name FROM Clo";

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