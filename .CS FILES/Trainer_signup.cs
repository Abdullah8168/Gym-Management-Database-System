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
    public partial class Trainer_signup : Form
    {
        public Trainer_signup()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            // Check that all values are filled
            if ( (string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)) || (string.IsNullOrEmpty(textBox3.Text)) || (string.IsNullOrEmpty(textBox4.Text)) || (string.IsNullOrEmpty(textBox5.Text)) || (string.IsNullOrEmpty(textBox6.Text)) || (string.IsNullOrEmpty(textBox7.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox1.Text;
            string address = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;
            string experience = textBox5.Text;
            string speciality = textBox6.Text;
            string qualification = textBox7.Text;
  
            // Check for unique username
            string query_check = ("SELECT COUNT (*) FROM trainer where t_name=@name");
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@name", name);
            int count2 = (int)cmd_check.ExecuteScalar();

            if (count2 != 0)
            {   
              MessageBox.Show("USER NAME ALREADY TAKEN");
                return;
             }
   

                    string query2 = "INSERT INTO trainer VALUES('" + name + "','" + email + "', '" + password + "' ,'" + address + "','" + speciality + "','" + experience + "','" + qualification + "')";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.ExecuteNonQuery();

                    cmd2.Dispose();
                
                    MessageBox.Show("TRAINER IS SUCCESFULLY REGISTERED ");
                    Trainer_login secondForm = new Trainer_login();
                    this.Hide();
                    secondForm.Show();
       

            conn.Close();
        }
    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_login secondForm = new Trainer_login();
            this.Hide();
            secondForm.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
