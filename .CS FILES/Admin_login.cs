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
    public partial class Admin_login : Form
    {
        public Admin_login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            this.Hide();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            string name = textBox1.Text;
            string password = textBox2.Text;

            if ( (string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)) )
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string query1 = "SELECT COUNT(*) FROM admin WHERE a_name = @name AND a_password = @password";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@name", name);
            cmd1.Parameters.AddWithValue("@password", password);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());


            if (count1 == 0)
            {
                MessageBox.Show("INVALID USERNAME OR PASSWORD");
                return;
            }
            //extract admin id
                string query2 = "SELECT a_id from admin WHERE a_name=@name AND a_password=@password";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@name", name);
               cmd2.Parameters.AddWithValue("@password", password);
               int count2 = Convert.ToInt32(cmd2.ExecuteScalar());



               
                cmd1.Dispose();
                cmd2.Dispose();

                conn.Close();

                Admin_1 s = new Admin_1();
                s.receive_data(count2);
                this.Hide();
                s.Show();
        }
    }
}
