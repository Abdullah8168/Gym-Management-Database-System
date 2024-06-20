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
    public partial class User_4 : Form
    {
        public int userid;
        public User_4()
        {
            InitializeComponent();
        }
        public void receive_data(int a )
        {
            userid = a;
        }
        private void user_4_Load(object sender, EventArgs e)
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

            label9.Text = "User ID: " + userid.ToString();
            LoadExerciseData();
        }
        void LoadExerciseData()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            // Check if the dietplan exists for the given user
            int DietPlanCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryCheck = "SELECT COUNT(*) FROM dietplan WHERE u_id = @userid AND t_id IS NULL ";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@userid", userid);
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
                               "WHERE d.u_id = @userid AND t_id IS NULL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;

     

            dataGridView1.Columns["d_id"].HeaderText = "DIET PLAN ID";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_1 s = new User_1();
            s.receive_data(userid);
            this.Close();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_5 secondForm = new User_5('a');
            secondForm.receivedata(userid);
            this.Close();
            secondForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            if (((comboBox1.SelectedIndex == -1)|| (comboBox2.SelectedIndex == -1)|| (comboBox3.SelectedIndex == -1) ))
            {
                MessageBox.Show("Please Select form drop down list");
                return;
            }
 
            string selectedOption2 = comboBox1.SelectedItem.ToString();
            string selectedOption1 = comboBox2.SelectedItem.ToString();
            string selectedOption3 = comboBox3.SelectedItem.ToString();


            //Insert into workoutplan
            string query1 = "INSERT INTO dietplan VALUES('" + selectedOption1 + "','" + selectedOption2 + "', '" + selectedOption3 + "' ,'" + userid + "', NULL )";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("DIET PLAN SUCCESSFULLY CREATED");
            cmd1.Dispose();
        }

   

        private void button6_Click(object sender, EventArgs e)
        {
            User_4 s = new User_4();
            s.receive_data(userid);
            this.Hide();
            s.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            User_12 s = new User_12();
            s.receive_data(userid);
            this.Hide();
            s.Show();
        }
    }
}
