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
    public partial class Owner_3 : Form
    {
        public int ownerid;
        public Owner_3()
        {
            InitializeComponent();
        }
        public void receive_data (int a)
            {
            ownerid=a;
            }
        private void Owner_3_Load(object sender, EventArgs e)
        {
            loadtable1();
        }
        void loadtable1()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = " SELECT r.r_id,t.t_name,g.g_name,t.t_address,t.t_email,t.t_qulification,t.t_experience,t.t_speciality " +
                               "FROM trainer as t " +
                               "INNER JOIN REQUEST_trainer_owner as r " +
                               "ON t.t_id = r.t_id "+
                               "INNER JOIN gym g " +
                               "ON g.g_id = r.g_id " +
                               "WHERE r.o_id=@ownerid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ownerid", ownerid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }


            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            dataGridView1.Columns["r_id"].Width = 60;
            dataGridView1.Columns["t_name"].Width = 90;
            dataGridView1.Columns["g_name"].Width = 90;
            dataGridView1.Columns["t_address"].Width = 90;
            dataGridView1.Columns["t_email"].Width = 65;
            dataGridView1.Columns["t_qulification"].Width = 100;
            dataGridView1.Columns["t_experience"].Width = 90;
            dataGridView1.Columns["t_speciality"].Width = 90;

            dataGridView1.Columns["r_id"].HeaderText = "REQUEST ID";
            dataGridView1.Columns["t_name"].HeaderText = "TRAINER NAME";
            dataGridView1.Columns["g_name"].HeaderText = "GYM NAME";
            dataGridView1.Columns["t_address"].HeaderText = " TRAINER ADDRESS";
            dataGridView1.Columns["t_email"].HeaderText = "EMAIL";
            dataGridView1.Columns["t_qulification"].HeaderText = "QUALIFICATION";
            dataGridView1.Columns["t_experience"].HeaderText = "EXPERIENCE";
            dataGridView1.Columns["t_speciality"].HeaderText = "SPECIALITY";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();
            if ((string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string requestid = textBox1.Text;
            //request should be INT
            if (!int.TryParse(requestid, out int number))
            {
                MessageBox.Show("INVALID REQUEST ID");
                return;
            }
            //check that request exists in the request table
            string query_check3 = ("SELECT COUNT (*) FROM Request_trainer_owner where r_id=@requestid ");
            SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
            cmd_check3.Parameters.AddWithValue("@requestid", requestid);
            int count3 = (int)cmd_check3.ExecuteScalar();

            if (count3 == 0)
            {
                MessageBox.Show("Invalid Request ID");
                return;
            }

            //check that the request belongs to this owner
            string query_check4 = ("SELECT COUNT (*) FROM Request_trainer_owner where o_id=@ownerid AND r_id=@requestid");
            SqlCommand cmd_check4 = new SqlCommand(query_check4, conn);
            cmd_check4.Parameters.AddWithValue("@ownerid", ownerid);
            cmd_check4.Parameters.AddWithValue("@requestid", requestid);
            int count4 = (int)cmd_check4.ExecuteScalar();

            if (count4 == 0)
            {
                MessageBox.Show("Invalid request ID");
                return;
            }

            //extract trainerid
            string query3 = ("SELECT t_id FROM Request_trainer_owner where r_id=@requestid ");
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd3.Parameters.AddWithValue("@requestid", requestid);
            int trainerid = (int)cmd3.ExecuteScalar();

            //extract gymid
            string query4 = ("SELECT g_id FROM Request_trainer_owner where r_id=@requestid ");
            SqlCommand cmd4 = new SqlCommand(query4, conn);
            cmd4.Parameters.AddWithValue("@requestid", requestid);
            int gymid = (int)cmd4.ExecuteScalar();
            
            //delete from request table
            string query1 = ("DELETE FROM Request_trainer_owner WHERE r_id = @requestid ");
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@requestid", requestid);
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();

            //add trainer in R_Trainer_gym table
            string query2 = "INSERT INTO R_trainer_gym VALUES('" + gymid + "','" + trainerid + "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@gymid", gymid);
            cmd2.Parameters.AddWithValue("@trainerid", trainerid);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();

            MessageBox.Show("Request Accepted");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Owner_3 secondForm = new Owner_3();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner_1 secondForm = new Owner_1();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }
    }
}
