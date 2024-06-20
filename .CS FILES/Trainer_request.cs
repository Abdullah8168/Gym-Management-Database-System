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
    public partial class Trainer_request : Form
    {
        public Trainer_request()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trainer_login s = new Trainer_login();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();

            // Check that all values are filled
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox4.Text)) || (string.IsNullOrEmpty(textBox8.Text)) )
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox1.Text;
            string password = textBox4.Text;
            string gymid = textBox8.Text;

    
            // Check for  trainer is registered in database
            string query_check = ("SELECT COUNT (*) FROM trainer where t_name=@name AND t_password=@password");
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@name", name);
            cmd_check.Parameters.AddWithValue("@password", password);
            int count2 = (int)cmd_check.ExecuteScalar();

            if (count2 == 0)
            {
                MessageBox.Show("Incorrect Username or password ");
                return;
            }
            //extract trainer id by user name and pass
            string query1 = "SELECT t_id from trainer WHERE t_name=@name";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@name", name);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());

           // extract gym ownerid by gym
            string query = "SELECT o_id from gym WHERE g_id=@gymid";
            SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@gymid", gymid);
               int count3 = Convert.ToInt32(cmd.ExecuteScalar());

            //check for duplicate requests
            string query4 = ("SELECT COUNT (*) FROM request_trainer_owner where g_id=@gymid AND t_id=@count1");
            SqlCommand cmd4 = new SqlCommand(query4, conn);
            cmd4.Parameters.AddWithValue("@count1", count1);
            cmd4.Parameters.AddWithValue("@gymid", gymid);
            int count4 = (int)cmd4.ExecuteScalar();

            if (count4 > 0)
            {
                MessageBox.Show("You have already send request ");
                return;
            }

            // INSERTION iN REQUEST TABLE
            string query2 = "INSERT INTO Request_trainer_owner VALUES('" + gymid + "','" + count3+ "','" + count1+ "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();

            cmd2.Dispose();

            MessageBox.Show("YOUR REQUEST IS SEND TO GYM OWNER ");
           


            conn.Close();
        }

        private void Trainer_request_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet15.gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter.Fill(this.flex_Trainer_Management_SystemDataSet15.gym);

        }
    }
}
