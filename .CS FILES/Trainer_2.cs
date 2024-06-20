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
    public partial class Trainer_2 : Form
    {
        public int trainerid;
        public Trainer_2()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            trainerid = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Trainer_1 secondForm = new Trainer_1();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }

        private void Trainer_2_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Bulking");
            comboBox2.Items.Add("Cutting");
            comboBox2.Items.Add("Rehabilition");
            comboBox2.Items.Add("Injury Prevention");
            comboBox2.SelectedItem = "Weight Loss";

            comboBox3.Items.Add("Daily");
            comboBox3.Items.Add("3 times a week");
            comboBox3.Items.Add("5 times a week");
            comboBox3.Items.Add("Weekly");
            comboBox3.SelectedItem = "Daily";

            comboBox4.Items.Add("Begginer");
            comboBox4.Items.Add("Intermediate");
            comboBox4.Items.Add("Advance");
            comboBox4.SelectedItem = "Beginner";

            LoadExerciseData();
        }
        void LoadExerciseData()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            // Check if the workoutplan exists for the given trainer
            int workoutPlanCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryCheck = "SELECT COUNT(*) FROM workoutplan WHERE t_id = @trainerid";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@trainerid", trainerid);
                    workoutPlanCount = (int)commandCheck.ExecuteScalar();
                }
            }

            // If no workoutplan exists for the user, return
            if (workoutPlanCount == 0)
            {
                return;
            }

            // Retrieve workoutplan IDs for the user
            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT w.w_id  ,w.u_id  " +
                               "FROM workoutplan AS w " +
                               "WHERE w.t_id = @trainerid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@trainerid", trainerid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;

            dataGridView1.Columns["W_ID"].Width = 45;
            dataGridView1.Columns["u_id"].Width = 70;

            dataGridView1.Columns["W_ID"].HeaderText = "PLAN ID";
            dataGridView1.Columns["u_ID"].HeaderText = "USER ID";


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_3 secondForm = new User_3('b');
            this.Close();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Trainer_2 second = new Trainer_2();
            second.receive_data(trainerid);
            this.Hide();
            second.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();


            if (((comboBox4.SelectedIndex == -1) || (comboBox2.SelectedIndex == -1) || (comboBox3.SelectedIndex == -1)))
            {
                MessageBox.Show("Please Select form drop down list");
                return;
            }

            string purpose = comboBox2.SelectedItem.ToString();
            string shedule = comboBox3.SelectedItem.ToString();
            string exp = comboBox4.SelectedItem.ToString();
            string userid= textBox1.Text;

            // Check that member and trainer works in same gym
            string querycheck2 = "SELECT count(*) from r_user_gym as r " +
                                  "INNER JOIN gym as g on r.g_id = g.g_id " +
                                  "INNER JOIN r_trainer_gym as t on g.g_id = t.g_id " +
                                  "WHERE r.u_id = @userid AND t.t_id = @trainerid";
            SqlCommand cmdcheck2 = new SqlCommand(querycheck2, conn);
            cmdcheck2.Parameters.AddWithValue("@userid", userid);
            cmdcheck2.Parameters.AddWithValue("@trainerid", trainerid);
            int count_2 = (int)cmdcheck2.ExecuteScalar();

            if (count_2 == 0)
            {
                MessageBox.Show("The trainer does not work at the same gym as the user.");
                return;
            }


            //Insert into workoutplan
            string query1 = "INSERT INTO workoutplan VALUES('" + purpose + "','" + shedule + "', '" + exp + "' ,'" + userid + "','" + trainerid + "' )";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("WORKOUT PLAN SUCCESSFULLY CREATED");
            cmd1.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            User_3 s = new User_3('b');
            s.receive_data2(trainerid);
            this.Hide();
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Trainer_11 second = new Trainer_11();
            second.receive_data(trainerid);
            this.Hide();
            second.Show();
        }
    }
}
