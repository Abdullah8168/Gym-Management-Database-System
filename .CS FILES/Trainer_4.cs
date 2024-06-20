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
    public partial class Trainer_4 : Form
    {
        public int trainerid;
        public Trainer_4()
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
            this.Close();
            secondForm.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_5 secondForm = new User_5('b');
            this.Close();
            secondForm.Show();
        }

        private void Trainer_4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Weight Loss");
            comboBox1.Items.Add("Muscle gain");
            comboBox1.Items.Add("Disease prevention");
            comboBox1.SelectedItem = "Muscle Gain";

            comboBox2.Items.Add("Vegan");
            comboBox2.Items.Add("Vegetarian");
            comboBox2.Items.Add("Organic");
            comboBox2.Items.Add("Dairy free");
            comboBox2.SelectedItem = "Vegan";

            comboBox3.Items.Add("High Carb");
            comboBox3.Items.Add("High Proteins");
            comboBox3.Items.Add("High Fats");
            comboBox3.Items.Add("High Vitamins");
            comboBox3.Items.Add("High Fibers");
            comboBox3.SelectedItem = "High Proteins";
            LoadExerciseData();
        }
        void LoadExerciseData()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            // Check if the dietplan exists for the given trainer
            int DietPlanCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryCheck = "SELECT COUNT(*) FROM dietplan WHERE t_id = @trainerid ";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@trainerid", trainerid);
                    DietPlanCount = (int)commandCheck.ExecuteScalar();
                }
            }

            // If no workoutplan exists for the user, return
            if (DietPlanCount == 0)
            {
                return;
            }

            // Retrieve workoutplan IDs for the user
            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT d.d_id " +
                               "FROM dietplan AS d " +
                               "WHERE d.t_id = @trainerid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@trainerid", trainerid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;



            dataGridView1.Columns["d_id"].HeaderText = "DIET PLAN ID";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            if (((comboBox1.SelectedIndex == -1) || (comboBox2.SelectedIndex == -1) || (comboBox3.SelectedIndex == -1)))
            {
                MessageBox.Show("Please Select form drop down list");
                return;
            }

            string selectedOption2 = comboBox1.SelectedItem.ToString();
            string selectedOption1 = comboBox2.SelectedItem.ToString();
            string selectedOption3 = comboBox3.SelectedItem.ToString();
            string userid = textBox1.Text;
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
            string query1 = "INSERT INTO dietplan VALUES('" + selectedOption1 + "','" + selectedOption2 + "', '" + selectedOption3 + "' ,'" + userid + "','" + trainerid + "' )";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("DIET PLAN SUCCESSFULLY CREATED");
            cmd1.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Trainer_4 secondForm = new Trainer_4();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            User_5 secondForm = new User_5('b');
            secondForm.receivedata2(trainerid);
            this.Hide();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trainer_12 secondForm = new Trainer_12();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }
    }
}
