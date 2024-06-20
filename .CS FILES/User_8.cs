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
    public partial class User_8 : Form
    {
        public int userid;
        public User_8()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            userid = a;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            User_1 secondForm = new User_1();
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_7 secondForm = new User_7('a');
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void User_8_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.SelectedItem = "5";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();
            string ratings = comboBox2.SelectedItem.ToString();
            string trainerid  = textBox2.Text;

            if ((comboBox2.SelectedIndex == -1) )
                {
                MessageBox.Show("Please Select form drop down list");
                return;
            }
            // Check trainer id should be INT
            if (!int.TryParse(trainerid, out int number))
            {
                MessageBox.Show("INVALID Trainer ID");
                return;
            }

            // Check that member and trainer works in same gym
            string query_check2 = "SELECT count(*) from r_user_gym as r " +
                                  "INNER JOIN gym as g on r.g_id = g.g_id "+
                                  "INNER JOIN r_trainer_gym as t on g.g_id = t.g_id "+
                                  "WHERE r.u_id = @userid AND t.t_id = @trainerid";
            SqlCommand cmd_check2 = new SqlCommand(query_check2, conn);
            cmd_check2.Parameters.AddWithValue("@userid", userid);
            cmd_check2.Parameters.AddWithValue("@trainerid", trainerid);
            int count2 = (int)cmd_check2.ExecuteScalar();

            if (count2 == 0)
            {
                MessageBox.Show("The trainer does not work at the same gym as the user.");
                return;
            }

            //Insert into feedback table
            string query1 = "INSERT INTO feedback VALUES('" + ratings + "','" + userid + "', '" + trainerid + "')";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@userid", userid);
            cmd1.Parameters.AddWithValue("@trainerid", trainerid);
            cmd1.Parameters.AddWithValue("@ratings", ratings);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Feedback Is Successfull submitted");
            cmd1.Dispose();
        }
    }
}
