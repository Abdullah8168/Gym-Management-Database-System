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
    public partial class Owner_login : Form
    {
        public Owner_login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            this.Hide();
            secondForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner_signup secondForm = new Owner_signup();
            this.Hide();
            secondForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            // Check that all values are filled
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox1.Text;
            string password = textBox2.Text;

            // Extract owner_id by user name and password
            string query = "SELECT o_id FROM Owner WHERE o_name=@name AND o_password=@password";
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
                MessageBox.Show("Incorrect User name or password");
                return;
            }

            // Check that owner owns at least one gym that is registered
            string query1 = "SELECT count(*) FROM gym WHERE o_id=@owner_id AND a_id IS NOT NULL";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@owner_id", owner_id);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
            if (count1 == 0)
            {
                MessageBox.Show("Please Register a gym!, You have not register any gym yet");
                return;
            }
            Owner_1 secondForm = new Owner_1();
            secondForm.receive_data(owner_id);
            this.Close();
            secondForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Owner_signup secondForm = new Owner_signup();
            this.Hide();
            secondForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            Owner_request secondForm = new Owner_request();
            this.Hide();
            secondForm.Show();
        }
    }
}
