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
    public partial class User_5 : Form
    {
        public char data_;
        public int userid;
        public int trainid;
        public User_5(char d)
        {
            data_ = d;
            InitializeComponent();
            
        }
        public void receivedata(int a)
            {
            userid = a;
            }
        public void receivedata2(int a)
        {
            trainid = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (data_ == 'a')
            {
                User_4 secondForm = new User_4();
                secondForm.receive_data(userid);
                this.Close();
                secondForm.Show();
            }
            else if (data_ == 'c')
            {
                User_15 secondForm = new User_15();
                secondForm.receive_data(userid);
                this.Close();
                secondForm.Show();
            }
            else if (data_ == 'b')
            {
                Trainer_4 secondForm = new Trainer_4();
                secondForm.receive_data(trainid);
                this.Close();
                secondForm.Show();
            }


        }

        private void User_5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet14.meal' table. You can move, or remove it, as needed.
            this.mealTableAdapter3.Fill(this.flex_Trainer_Management_SystemDataSet14.meal);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            User_5 s = new User_5(data_);
            s.receivedata(userid);
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadExercisedata();
        }
        void LoadExercisedata()
        {

            string did = textBox1.Text;
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            // Check diet id should be INT
            if (!int.TryParse(did, out int number))
            {
                MessageBox.Show("INVALID DIET ID");
                return;
            }
            DataTable exerciseTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve meals in a diet plan
                string query = "SELECT d.d_id,d.D_Type,d. D_Objective, d.D_nutrition,m.ml_id,m.Ml_alergies,m.Ml_Nutrition,m.Ml_nutrition_quantity,m.Calories,m.Ml_type " +
                               "FROM meal AS m " +
                               "INNER JOIN R_DIETPLAN_MEAL AS r ON m.ml_id = r.ml_id " +
                               "INNER JOIN dietplan AS d ON d.d_id = r.d_id " +
                               "WHERE d.d_id = @did";

                // Create a new SqlCommand object
                SqlCommand command = new SqlCommand(query, connection);

                // Add a parameter for @wid
                command.Parameters.AddWithValue("@did", did);

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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();
            string did = textBox3.Text;
            string mid = textBox2.Text;

            // Check ids should be INT
            if (!int.TryParse(mid, out int number))
            {
                MessageBox.Show("MEAL ID should be INT");
                return;
            }

            // Check workoutplan id should be INT
            if (!int.TryParse(did, out int numb))
            {
                MessageBox.Show("DEITOUTPLAN ID should be INT");
                return;
            }

            //check that meal is available
            string query_check = "SELECT count(*) FROM meal WHERE ml_id=@mid";
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@mid", mid);
            int count1 = (int)cmd_check.ExecuteScalar();

            if (count1 == 0)
            {
                MessageBox.Show("MEAL DOES NOT EXIST");
                return;
            }

            //check if deitplan exists
            string query_check2 = "SELECT count(*) FROM dietPLAN WHERE d_id=@did";
            SqlCommand cmd_check2 = new SqlCommand(query_check2, conn);
            cmd_check2.Parameters.AddWithValue("@did", did);
            int count2 = (int)cmd_check2.ExecuteScalar();

            if (count2 == 0)
            {
                MessageBox.Show("DEIT PLAN DOES NOT EXIST");
                return;
            }
            if (trainid == 0) { 
            //check if this deit belongs to same user
            string query_check4 = "SELECT count(*) FROM DieTPLAN WHERE d_id=@did AND u_id=@userid AND t_id IS NULL";
            SqlCommand cmd_check4 = new SqlCommand(query_check4, conn);
            cmd_check4.Parameters.AddWithValue("@did", did);
            cmd_check4.Parameters.AddWithValue("@userid", userid);
            int count4 = (int)cmd_check4.ExecuteScalar();

            if (count4 == 0)
            {
                MessageBox.Show("DIET PLAN BELONGS TO OTHER USER");
                return;
            }
            }
            else
            {
                //check if this deit belongs to same trainer
                string query_check4 = "SELECT count(*) FROM DieTPLAN WHERE d_id=@did AND t_id=@trainid ";
                SqlCommand cmd_check4 = new SqlCommand(query_check4, conn);
                cmd_check4.Parameters.AddWithValue("@did", did);
                cmd_check4.Parameters.AddWithValue("@trainid", trainid);
                int count4 = (int)cmd_check4.ExecuteScalar();

                if (count4 == 0)
                {
                    MessageBox.Show("DIET PLAN BELONGS TO OTHER TRAINER");
                    return;
                }
            }
            //check of meal already added
            string query_check3 = "SELECT count(*) FROM R_DieTPLAN_MEAL WHERE d_id=@did AND ml_id=@mid";
            SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
            cmd_check3.Parameters.AddWithValue("@mid", mid);
            cmd_check3.Parameters.AddWithValue("@did", did);
            int count3 = (int)cmd_check3.ExecuteScalar();

            if (count3 > 0)
            {
                MessageBox.Show("MEAL IS ALREADY ADDED");
                return;
            }


            //INSERT INTO R_dietplan_meal TABLE
            string query2 = "INSERT INTO R_dietplan_meal VALUES('" + did + "','" + mid + "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();



            cmd2.Dispose();
            cmd_check.Dispose();
            cmd_check2.Dispose();
            cmd_check3.Dispose();

            MessageBox.Show("MEAL IS SUCCESSFULLY ADDED ");


        }
    }
}
