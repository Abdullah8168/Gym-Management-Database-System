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
    public partial class Trainer_login : Form
    {
        public Trainer_login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_signup secondForm = new Trainer_signup();
            this.Hide();
            secondForm.Show();
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

            // Check that all values are filled
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox1.Text;
            string password = textBox2.Text;

            // Extract trainer_id by user name and password
            string query = "SELECT t_id FROM trainer WHERE t_name=@name AND t_password=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            object result = cmd.ExecuteScalar();
            int trainer_id;
            if (result != null)
            {
                trainer_id = (int)cmd.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("Incorrect User name or password");
                return;
            }

            // Check that trainer works in at least one gym that is registered
            string query1 = "SELECT count(*) FROM r_trainer_gym WHERE t_id=@trainer_id ";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@trainer_id", trainer_id);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
            if (count1 == 0)
            {
                MessageBox.Show("Please Register in gym, You have not registered in any gym yet");
                return;
            }
            Trainer_1 secondForm = new Trainer_1();
            secondForm.receive_data(trainer_id);
            this.Hide();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trainer_request s = new Trainer_request();
            this.Hide();
            s.Show();
        }
    }
}
