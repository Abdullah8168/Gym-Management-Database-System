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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PROJECT_FRONTEND
{
    public partial class User_signup : Form
    {
        public User_signup()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_login secondForm = new User_login();
            this.Hide();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Query_check checks for unique username
            // Query1 match entered gym id with existing gym id
            // Query2 perform insertion in user_ table
            // Query3 retreive user id from the system
            // Query4 perform insertion in R_gym_user table.
            // Query5 check that gym is registered or not 
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            if((comboBox2.SelectedIndex == -1) || (string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)) || (string.IsNullOrEmpty(textBox3.Text)) || (string.IsNullOrEmpty(textBox4.Text)) || (string.IsNullOrEmpty(textBox5.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return ;
            }
            string name = textBox1.Text;
            string address = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;

            string selectedOption = comboBox2.SelectedItem.ToString();

            string gymid = textBox5.Text;
            string date_ = DateTime.Now.ToString("yyyy-MM-dd");

            // Check GYM id should be INT
            if(!int.TryParse(gymid, out int number))
                {
                  MessageBox.Show("INVALID GYM ID");
                  return;
                 }
            

            string query1 = ("SELECT COUNT (*) FROM gym where g_id=@gymid");
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@gymid", gymid);
            int count = (int)cmd1.ExecuteScalar();

            // Check for unique username
            string query_check = ("SELECT COUNT (*) FROM user_ where u_name=@name");
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@name",name);
            int count2 = (int)cmd_check.ExecuteScalar();

          
            if (count2 > 0)// Duplicate name
                {
            
                //extract userid from email and password
                string query6 = ("SELECT u_id FROM user_ where u_name=@name AND u_password=@password");
                SqlCommand cmd6 = new SqlCommand(query6, conn);
                cmd6.Parameters.AddWithValue("@name", name);
                cmd6.Parameters.AddWithValue("@password", password);
                int user_id = (int)cmd6.ExecuteScalar();

                //check that gym id is duplicate in r_gym_user table
                string query_check3 = ("SELECT COUNT (*) FROM r_user_gym where u_id=@user_id AND g_id=@gymid");
                SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
                cmd_check3.Parameters.AddWithValue("@user_id", user_id);
                cmd_check3.Parameters.AddWithValue("@gymid", gymid);
                int count4 = (int)cmd_check3.ExecuteScalar();
                if(count4>0)//duplicate gym id
                {
                    MessageBox.Show("You already have membership in this gym");
                    return;
                }


                //INSERTION OF NEW GYM
                string query5 = "INSERT INTO R_user_gym VALUES ('" + user_id + "' , '" + gymid + "' )";
                SqlCommand cmd5 = new SqlCommand(query5, conn);
                MessageBox.Show("You have successfully purchase membership");
                cmd5.ExecuteNonQuery();
                return;
            }
                if (count == 0)                
            {
                MessageBox.Show("GYM ID DOES NOT EXIST");
                return;
            }

            //check that gym is registered in the system
            string query_check2 = ("SELECT COUNT (*) FROM gym where g_id=@gymid AND a_id IS NOT NULL");
            SqlCommand cmd_check2 = new SqlCommand(query_check2, conn);
            cmd_check2.Parameters.AddWithValue("@gymid", gymid);
            int count3 = (int)cmd_check2.ExecuteScalar();

            if (count3 == 0)
            {
                MessageBox.Show("GYM is not registered ");
                return;
            }


            string query2 = "INSERT INTO user_ VALUES('" + name + "','" + selectedOption + "', '" + date_ + "' ,'" + email + "','" + password + "','" + address + "')";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.ExecuteNonQuery();

                string query3 = "SELECT TOP 1 u_id from user_ ORDER BY u_id DESC";
                SqlCommand cmd3 = new SqlCommand(query3, conn);
                int userId = Convert.ToInt32(cmd3.ExecuteScalar());

                string query4 = "INSERT INTO R_user_gym VALUES ('" + userId + "' , '" + gymid + "' )";
                SqlCommand cmd4 = new SqlCommand(query4, conn);

                cmd4.ExecuteNonQuery();

                cmd1.Dispose();
                cmd2.Dispose();
                cmd3.Dispose();
                cmd4.Dispose();
                MessageBox.Show("You have successfully purchase membership ");
                    //User_login secondForm = new User_login();
                    //this.Hide();
                    //secondForm.Show();

            



            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void User_signup_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet3.gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter1.Fill(this.flex_Trainer_Management_SystemDataSet3.gym);
          
            comboBox2.Items.Add("Basic");
            comboBox2.Items.Add("Premium");
            comboBox2.Items.Add("Student");
            comboBox2.SelectedItem = "Basic";

            loadtable1();
        }
        void loadtable1()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = " SELECT g.g_id , g.g_name " +
                               " FROM gym as g " +
                               " WHERE g.a_id IS NOT NULL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }


            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            dataGridView1.Columns["g_id"].Width = 60;
            dataGridView1.Columns["g_name"].Width = 90;
            
            dataGridView1.Columns["g_id"].HeaderText = "GYM ID";
            dataGridView1.Columns["g_name"].HeaderText = "GYM NAME";
           }


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
