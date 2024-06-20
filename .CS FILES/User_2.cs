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
    public partial class User_2 : Form
    {
        public int userid;
        public User_2()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            userid=a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_1 s= new User_1();
            s.receive_data(userid);
            this.Hide();
            s.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_3 s= new User_3('a');
            s.receive_data(userid);
            this.Hide();
            s.Show();
        }

        private void User_2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet8.workoutplan' table. You can move, or remove it, as needed.
            this.workoutplanTableAdapter2.Fill(this.flex_Trainer_Management_SystemDataSet8.workoutplan);
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet7.workoutplan' table. You can move, or remove it, as needed.
            this.workoutplanTableAdapter1.Fill(this.flex_Trainer_Management_SystemDataSet7.workoutplan);
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet6.workoutplan' table. You can move, or remove it, as needed.
            this.workoutplanTableAdapter.Fill(this.flex_Trainer_Management_SystemDataSet6.workoutplan);
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet4.exercise' table. You can move, or remove it, as needed.
            this.exerciseTableAdapter.Fill(this.flex_Trainer_Management_SystemDataSet4.exercise);
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

           label9.Text = "User ID: " + userid.ToString();

            LoadExerciseData();
        }
        void LoadExerciseData()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            // Check if the workoutplan exists for the given user
            int workoutPlanCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryCheck = "SELECT COUNT(*) FROM workoutplan WHERE u_id = @userid AND t_id IS NULL";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@userid", userid);
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
                string query = "SELECT w.w_id " +
                               "FROM workoutplan AS w " +
                               "WHERE w.u_id = @userid AND w.t_id IS NULL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
        }
     
        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();


            if (((comboBox4.SelectedIndex == -1) || (comboBox2.SelectedIndex == -1) || (comboBox3.SelectedIndex == -1)))
            {
                MessageBox.Show("Please Select form drop down list");
                return;
            }

            string selectedOption1 = comboBox2.SelectedItem.ToString();
            string selectedOption2 = comboBox3.SelectedItem.ToString();
            string selectedOption3 = comboBox4.SelectedItem.ToString();

            //Insert into workoutplan
            string query1 = "INSERT INTO workoutplan VALUES('" + selectedOption1 + "','" + selectedOption2 + "', '" + selectedOption3 + "' ,'" + userid + "', NULL )";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("WORKOUT PLAN SUCCESSFULLY CREATED");
            cmd1.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User_2 second = new User_2();
            second.receive_data(userid);
            this.Hide();
            second.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_11 second = new User_11();
            second.receive_data(userid);
            this.Hide();
            second.Show();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }
    }
}
