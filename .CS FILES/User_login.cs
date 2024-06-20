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
    public partial class User_login : Form
    {
        public User_login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            string name = textBox1.Text;
            string password = textBox2.Text;

         //check username and password
            string query1 = "SELECT COUNT(*) FROM user_ WHERE u_name = @name AND u_password = @password";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@name", name);
            cmd1.Parameters.AddWithValue("@password", password);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());


            if (count1 == 0)
            { 
                MessageBox.Show("INVALID USERNAME OR PASSWORD");
                return;
            }

            //Extract userid by  username and password
            string query2 = "SELECT u_id from user_ WHERE u_name=@name AND u_password=@password";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@password", password);
                int userID = Convert.ToInt32(cmd2.ExecuteScalar());

                

             
                    User_1 secondForm = new User_1();
                    secondForm.receive_data(userID);
                    this.Hide();
                    secondForm.Show();
               
   
                    cmd2.Dispose();
            

            

            cmd1.Dispose();


            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            this.Close();
            secondForm.Show();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_signup secondForm = new User_signup();
            this.Hide();
            secondForm.Show();
        }

        private void User_login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet2.gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter.Fill(this.flex_Trainer_Management_SystemDataSet2.gym);

       
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
