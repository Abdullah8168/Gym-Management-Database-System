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
    public partial class User_3 : Form
    {
        public char data_;
        public int userid;
        public int trainid;
        public User_3(char d)
        {
            InitializeComponent();
            data_ = d;
            userid = 0;
            trainid = 0;
        }
        public void receive_data(int a)
        {
            userid = a;
        }
        public void receive_data2(int a)
        {
            trainid = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (data_ == 'a')
            {
                User_2 s = new User_2();
                s.receive_data(userid);
                this.Close();
                s.Show();
            }
            else if (data_ == 'b')
            {
                Trainer_2 s = new Trainer_2();
                this.Close();
                s.receive_data(trainid);
                s.Show();
            }
            else if (data_ == 'c')
            {
                User_10 s = new User_10();
                s.receive_data(userid);
                this.Close();
                s.Show();
            }
        }

        private void User_3_Load(object sender, EventArgs e)
        {
            LoadExerciseData();
           
        }

        void LoadExerciseData()
        {
            string connectionString="Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Create a DataTable to hold the exercise and machine data
            DataTable exerciseTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query = "SELECT e.e_id, e.e_day, e.e_targetmuscle,e.e_reps,e.e_restinterval,e.e_sets, m.m_manufacturer, m.m_discription " +
                               "FROM exercise e " +
                               "INNER JOIN R_EXERCISE_MACHINERY r ON e.e_id = r.e_id " +
                               "INNER JOIN machinery m ON r.m_id = m.m_id " +
                               "ORDER BY e.e_id ASC ";

                // Create a SqlDataAdapter to execute the query and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(exerciseTable);
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
        }

        void LoadExerciseData2()
        {
            string wid = textBox1.Text;
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Check workout plan id should be INT
            if (!int.TryParse(wid, out int number))
            {
                MessageBox.Show("INVALID WORKOUT PLAN ID");
                return;
            }

            DataTable exerciseTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query = "SELECT w.w_id, w.w_purpose, w.w_shedule, w.w_expLevel, e.e_id, e.e_day, e.e_targetmuscle " +
                               "FROM exercise AS e " +
                               "INNER JOIN R_WORKOUTPLAN_EXERCISES AS r ON e.e_id = r.e_id " +
                               "INNER JOIN workoutplan AS w ON w.w_id = r.w_id " +
                               "WHERE w.w_id = @wid";

                // Create a new SqlCommand object
                SqlCommand command = new SqlCommand(query, connection);

                // Add a parameter for @wid
                command.Parameters.AddWithValue("@wid", wid);

                // Create a SqlDataAdapter to execute the query and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(exerciseTable);
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = exerciseTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            User_3 s = new User_3(data_);
            s.receive_data(userid);
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadExerciseData2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();
            string wid = textBox3.Text;
            string eid = textBox2.Text;

            // Check EXERCISE id should be INT
            if (!int.TryParse(eid, out int number))
            {
                MessageBox.Show("INVALID EXERCISE ID");
                return;
            }

            // Check workoutplan id should be INT
            if (!int.TryParse(wid, out int numb))
            {
                MessageBox.Show("INVALID WORKOUTPLAN ID");
                return;
            }

            //check that exercise is available
            string query_check = "SELECT count(*) FROM EXERCISE WHERE e_id=@eid";
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@eid", eid);
            int count1 = (int)cmd_check.ExecuteScalar();

            if (count1 == 0)
            {
                MessageBox.Show("EXERCISE DO NOT EXISTS");
                return;
            }

            //check if workoutplan exists
            string query_check2 = "SELECT count(*) FROM WORKOUTPLAN WHERE w_id=@wid";
            SqlCommand cmd_check2 = new SqlCommand(query_check2, conn);
            cmd_check2.Parameters.AddWithValue("@wid", wid);
            int count2 = (int)cmd_check2.ExecuteScalar();

            if (count2 == 0)
            {
                MessageBox.Show("WORKOUT PLAN DO NOT EXISTS ");
                return;
            }
            if (trainid == 0)
            {  //check if this plan belongs to same user
                string query_check4 = "SELECT count(*) FROM WORKOUTPLAN WHERE w_id=@wid AND u_id=@userid AND t_id IS NULL";
                SqlCommand cmd_check4 = new SqlCommand(query_check4, conn);
                cmd_check4.Parameters.AddWithValue("@wid", wid);
                cmd_check4.Parameters.AddWithValue("@userid", userid);
                int count4 = (int)cmd_check4.ExecuteScalar();

                if (count4 == 0)
                {
                    MessageBox.Show("WORKOUT BELONGS TO OTHER USER");
                    return;
                }
            }
            else
            {

                //check if this plan belongs to same user
                string query_check4 = "SELECT count(*) FROM WORKOUTPLAN WHERE w_id=@wid AND t_id=@trainid";
                SqlCommand cmd_check4 = new SqlCommand(query_check4, conn);
                cmd_check4.Parameters.AddWithValue("@wid", wid);
                cmd_check4.Parameters.AddWithValue("@trainid", trainid);
                int count4 = (int)cmd_check4.ExecuteScalar();

                if (count4 == 0)
                {
                    MessageBox.Show("WORKOUT BELONGS TO OTHER TRAINER");
                    return;
                }
            }
            //check if this plan belongs to same trainer

            //check of  exercise already added
            string query_check3 = "SELECT count(*) FROM R_WORKOUTPLAN_EXERCISES WHERE e_id=@eid AND w_id=@wid";
            SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
            cmd_check3.Parameters.AddWithValue("@eid", eid);
            cmd_check3.Parameters.AddWithValue("@wid", wid);
            int count3 = (int)cmd_check3.ExecuteScalar();

            if (count3 > 0)
            {
                MessageBox.Show("EXERCISE IS ALREADY ADDED");
                return;
            }


            //INSERT INTO R_EXERCISES_WORKOUTPLAN TABLE
            string query2 = "INSERT INTO R_workoutplan_exercises VALUES('" + eid + "','" + wid + "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();



            cmd2.Dispose();
            cmd_check.Dispose();
            cmd_check2.Dispose();
            cmd_check3.Dispose();

            MessageBox.Show("EXERCISE IS SUCCESSFULLY ADDED ");


        }
    }
}
