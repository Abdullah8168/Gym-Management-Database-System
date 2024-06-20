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

    public partial class User_7 : Form
    {
        public int userid;
        public int trainerid;
        public char data_;
        public User_7(char d)
        {
            InitializeComponent();
            data_= d;
        }
        public void receive_data(int a)
        {
            userid = a;
        }
        public void receive_data2(int a)
        {
            trainerid = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(data_ == 'a')
            { 
            User_8 secondForm = new User_8();
                secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
            }
            else if(data_ == 'b')
            {
                User_6 secondForm = new User_6();
                secondForm.receive_data(userid);
                this.Close();
                secondForm.Show();
            }
            else if( data_=='c')
            {
                Trainer_2 secondForm = new Trainer_2();
                //secondForm.receive_data(trainerid);
                this.Close();
                secondForm.Show();
            }

        }

        private void User_7_Load(object sender, EventArgs e)
        {
     
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Create a DataTable to hold the exercise and machine data
            DataTable exerciseTable = new DataTable();

            string gymid = textBox1.Text;
            // Check gym id should be INT
            if (!int.TryParse(gymid, out int number))
            {
                MessageBox.Show("INVALID GYM ID");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query = "SELECT t.t_id, t.t_name, t.t_email,t.t_speciality,t.t_experience,t.t_qulification  " +
                               "FROM trainer t " +
                               "INNER JOIN  R_TRAINER_GYM r ON r.t_id = t.t_id " +
                               "WHERE r.g_id=@gymid ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gymid", gymid); 
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }
            dataGridView1.DataSource = exerciseTable;

            dataGridView1.Columns["t_id"].Width = 25;
            dataGridView1.Columns["t_name"].Width = 70;
            dataGridView1.Columns["t_email"].Width = 55;
            dataGridView1.Columns["t_speciality"].Width = 90;
            dataGridView1.Columns["t_experience"].Width = 100;
            dataGridView1.Columns["t_qulification"].Width = 100;

            dataGridView1.Columns["t_id"].HeaderText = "ID";
            dataGridView1.Columns["t_name"].HeaderText = "Purpose";
            dataGridView1.Columns["t_email"].HeaderText = "Shedule";
            dataGridView1.Columns["t_speciality"].HeaderText = "Speciality";
            dataGridView1.Columns["t_experience"].HeaderText = "Experience";
            dataGridView1.Columns["t_qulification"].HeaderText = "Qualification";

        }
    }

}
