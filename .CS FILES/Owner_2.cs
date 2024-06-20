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
    public partial class Owner_2 : Form
    {
        public int ownerid;
        public Owner_2()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            ownerid = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner_1 secondForm = new Owner_1();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            if ((string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("Please fill Appointment  ID and date ");
                return;
            }

            string accountid = textBox2.Text;

            // Check  trainer id should be INT
            if (!int.TryParse(accountid, out int number))
            {
                MessageBox.Show("INVALID TRAINER ID");
                return;
            }

            //check that TRAINER WORKS IN OWNER's GYM
            string query_check = "SELECT count(*) FROM r_trainer_gym r " +
                                 "INNER JOIN gym g  ON g.g_id=r.g_id " +
                                 "WHERE r.r_id=@accountid AND g.o_id=@ownerid";
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@ownerid", ownerid);
            cmd_check.Parameters.AddWithValue("@accountid", accountid);
            int count1 = (int)cmd_check.ExecuteScalar();

            if (count1 == 0)
            {
                MessageBox.Show("Trainer does not belongs to your gym");
                return;
            }

            // DELETION
            string query2 = "DELETE FROM r_trainer_gym WHERE r_id= @accountid ";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@accountid", accountid);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();

            MessageBox.Show("Traier account has been removed");

        }

        private void Owner_2_Load(object sender, EventArgs e)
        {
            LoadExerciseData();
            LoadExerciseData2();
        }

        void LoadExerciseData()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Create a DataTable to hold the exercise and machine data
            DataTable exerciseTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query =
                                 "SELECT r.r_id,r.t_id,g.g_name FROM r_trainer_gym r " +
                                 "INNER JOIN gym g ON g.g_id = r.g_id " +
                                 "WHERE g.o_id = @ownerid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ownerid", ownerid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
        }
        void LoadExerciseData2()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Create a DataTable to hold the exercise and machine data
            DataTable exerciseTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query =
                                 "SELECT r.r_id,r.u_id,g.g_name FROM r_user_gym r " +
                                 "INNER JOIN gym g ON g.g_id = r.g_id " +
                                 "WHERE g.o_id = @ownerid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ownerid", ownerid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = exerciseTable;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Owner_2 secondForm = new Owner_2();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            if ((string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Please enter the account id ");
                return;
            }

            string accountid = textBox1.Text;

            // Check  trainer id should be INT
            if (!int.TryParse(accountid, out int number))
            {
                MessageBox.Show("INVALID TRAINER ID");
                return;
            }

            //check that user WORKS IN OWNER's GYM
            string query_check = "SELECT count(*) FROM r_user_gym r " +
                                 "INNER JOIN gym g  ON g.g_id=r.g_id " +
                                 "WHERE r.r_id=@accountid AND g.o_id=@ownerid";
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@ownerid", ownerid);
            cmd_check.Parameters.AddWithValue("@accountid", accountid);
            int count1 = (int)cmd_check.ExecuteScalar();

            if (count1 == 0)
            {
                MessageBox.Show("Trainer does not belongs to your gym");
                return;
            }

            // DELETION
            string query2 = "DELETE FROM r_user_gym WHERE r_id= @accountid ";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@accountid", accountid);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();

            MessageBox.Show("Traier account has been removed");

        }
    }
    
}
