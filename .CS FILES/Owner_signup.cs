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
    public partial class Owner_signup : Form
    {
        public Owner_signup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner_login secondForm = new Owner_login();
            this.Hide();
            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            // Check that all values are filled
            if ((string.IsNullOrEmpty(textBox2.Text)) || (string.IsNullOrEmpty(textBox3.Text)) || (string.IsNullOrEmpty(textBox4.Text)) || (string.IsNullOrEmpty(textBox1.Text)) )
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox1.Text;
            string password = textBox2.Text;
            string address = textBox3.Text;
            string email = textBox4.Text;
          

            // Check for unique username
            string query_check = ("SELECT COUNT (*) FROM owner where o_name=@name");
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@name", name);
            int count2 = (int)cmd_check.ExecuteScalar();

            if (count2 != 0)
            {
                MessageBox.Show("USER NAME ALREADY TAKEN");
                return;
            }


            string query2 = "INSERT INTO owner VALUES('" + name + "','" + address + "', '" + email + "' ,'" + password + "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();

            cmd2.Dispose();

            MessageBox.Show("OWNER IS SUCCESFULLY REGISTERED ");
           


            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Owner_login secondForm = new Owner_login();
            this.Hide();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            // Check that all values are filled
            if ((string.IsNullOrEmpty(textBox5.Text)) || (string.IsNullOrEmpty(textBox6.Text)) || (string.IsNullOrEmpty(textBox7.Text)) || (string.IsNullOrEmpty(textBox8.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox5.Text;
            string password = textBox6.Text;
            string gym_name = textBox7.Text;
            string gym_address = textBox8.Text;

            // Extract owner_id by user name and password
            string query= "SELECT o_id FROM Owner WHERE o_name=@name AND o_password=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            object result = cmd.ExecuteScalar();
            int owner_id;
            if (result != null)
            {
                 owner_id = (int)cmd.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("Invalid Owner ID");
                return;
            }

            //check of unique gym name
            string query_check = "SELECT count(*) FROM gym WHERE g_name=@gym_name";
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@gym_name", gym_name);
            int check = (int)cmd_check.ExecuteScalar();

            if (check > 0)
            {
                MessageBox.Show("Gym Alreaady Exists");
                return;
            }
            // Insert into gym table
            string query2 = "INSERT INTO gym VALUES('" + gym_address + "','" + gym_name + "','" + owner_id + "',NULL)";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Gym is successfully added");
        }
    }
}
