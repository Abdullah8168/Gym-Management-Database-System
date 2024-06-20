using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PROJECT_FRONTEND
{
    public partial class User_6 : Form
    {
        public int userid;
        public User_6()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            userid = a;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_1 secondForm = new User_1();
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_7 secondForm = new User_7('b');
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void User_6_Load(object sender, EventArgs e)
        {
            Loadtable1();
            Loadtable2();
        }
        public void Loadtable1()
        { 
        string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
        // Create a DataTable to hold the exercise and machine data
        DataTable exerciseTable = new DataTable();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query = "SELECT g.g_id, g.g_name  " +
                               "FROM gym g " +
                               "INNER JOIN  R_USER_GYM r ON g.g_id = r.g_id " +
                               "WHERE r.u_id=@userid ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", userid); 
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
    adapter.Fill(exerciseTable);
                }
            }
            dataGridView1.DataSource = exerciseTable;

dataGridView1.Columns["g_id"].Width = 40;
dataGridView1.Columns["g_name"].Width = 100;

dataGridView1.Columns["g_id"].HeaderText = "ID";
dataGridView1.Columns["g_name"].HeaderText = "NAME";

        }

        public void Loadtable2()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Create a DataTable to hold the exercise and machine data
            DataTable exerciseTable = new DataTable();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                   string query = "SELECT r.s_id, r.s_date ,t.t_name " +
                               "FROM Trainingsession  r " +
                               "INNER JOIN trainer t ON t.t_id=r.t_id  " +
                               "WHERE r.u_id=@userid ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", userid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }
            dataGridView2.DataSource = exerciseTable;

            dataGridView2.Columns["s_id"].Width = 40;
            dataGridView2.Columns["s_date"].Width = 50;
            dataGridView2.Columns["t_name"].Width = 50;

            dataGridView2.Columns["s_id"].HeaderText = "ID";
            dataGridView2.Columns["s_date"].HeaderText = "NAME";
            dataGridView2.Columns["t_name"].HeaderText = "TRAINER";

        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox3.Text)))
            {
                MessageBox.Show("Please fill Trainer ID and date ");
                return;
            }
            string trainerid = textBox1.Text;
            string dis = textBox2.Text;
            string sdate = textBox3.Text;
            string gymid = textBox4.Text;

            //check that date is valid
         DateTime dateTime = DateTime.Parse(sdate);
             if (!DateTime.TryParse(sdate, out dateTime))
            {
                MessageBox.Show("Unable to parse the string as a date and time.");
                return;
            }
            //Check gym and trainer id should be INT
            if (!int.TryParse(gymid, out int number))
            {
                MessageBox.Show("INVALID GYM ID");
                return;
            }
            if (!int.TryParse(trainerid, out int numb))
            {
                MessageBox.Show("INVALID TRAINER ID");
                return;
            }
            // no 2 session on same day
            string query_check = "SELECT count(*) FROM trainingsession WHERE s_date=@sdate";
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@sdate", sdate);
            int count1 = (int)cmd_check.ExecuteScalar();

            if (count1 > 0)
            {
                MessageBox.Show("You already have session on this date");
                return;
            }
            // trainer works in this gym
            string query_check2 = "SELECT count(*) FROM R_TRAINER_GYM WHERE t_id=@trainerid AND g_id=@gymid";
            SqlCommand cmd_check2 = new SqlCommand(query_check2, conn);
            cmd_check2.Parameters.AddWithValue("@gymid", gymid);
            cmd_check2.Parameters.AddWithValue("@trainerid", trainerid);
            int count2 = (int)cmd_check2.ExecuteScalar();

            if (count2 == 0)
            {
                MessageBox.Show("Trainer Does Not Work In This Gym");
                return;
            }
            // user is registered in this gym
            string query_check3 = "SELECT count(*) FROM R_USER_GYM WHERE u_id=@userid AND g_id=@gymid";
            SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
            cmd_check3.Parameters.AddWithValue("@gymid", gymid);
            cmd_check3.Parameters.AddWithValue("@userid", userid);
            int count3 = (int)cmd_check3.ExecuteScalar();

            if (count3 == 0)
            {
                MessageBox.Show("User Does Not Have Membership In This Gym");
                return;
            }
            
            //INSERTION
            string query2 = "INSERT INTO trainingsession VALUES('" + dis + "','" + sdate + "','" + userid + "','" + trainerid + "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();

            MessageBox.Show("Your session has been booked");

        }
    }
}
