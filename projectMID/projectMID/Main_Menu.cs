using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectMID
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Show();
            Manage_Assesments manage_Assesments = new Manage_Assesments();
            manage_Assesments.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_CLO manage_CLO = new Manage_CLO();
            manage_CLO.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageRubricLevels level = new ManageRubricLevels();
            level.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Rubrics manage_Rubrics = new Manage_Rubrics();
            manage_Rubrics.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Evaluation manage_Evaluation = new Manage_Evaluation();  
            manage_Evaluation.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Students manage_Students = new Manage_Students();
            manage_Students.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageAssessmentComponent manageAssessmentComponent = new ManageAssessmentComponent();
            manageAssessmentComponent.Show();
        }
    }
}
