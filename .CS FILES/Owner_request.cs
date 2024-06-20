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
    public partial class Owner_request : Form
    {
        public Owner_request()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Owner_request_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flex_Trainer_Management_SystemDataSet16.admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.flex_Trainer_Management_SystemDataSet16.admin);

        }

        private void button2_Click(object sender, EventArgs e)
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
            if ((string.IsNullOrEmpty(textBox4.Text)) || (string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)) )
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string name = textBox1.Text;
            string password = textBox2.Text;
            string gymid = textBox4.Text;


            // Check for owner is registered in database
            string query_check = ("SELECT COUNT (*) FROM owner where o_name=@name AND o_password=@password");
            SqlCommand cmd_check = new SqlCommand(query_check, conn);
            cmd_check.Parameters.AddWithValue("@name", name);
            cmd_check.Parameters.AddWithValue("@password", password);
            int count1 = (int)cmd_check.ExecuteScalar();

            if (count1 == 0)
            {
                MessageBox.Show("Incorrect Username or password ");
                return;
            }

            // extract owner id
            string query1 = ("SELECT o_id FROM owner where o_name=@name AND o_password=@password");
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@name", name);
            cmd1.Parameters.AddWithValue("@password", password);
            int ownerid = (int)cmd1.ExecuteScalar();

           
            //check that gym exists in the database
            string query_check3 = ("SELECT COUNT (*) FROM gym where g_id=@gymid ");
            SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
            cmd_check3.Parameters.AddWithValue("@gymid", gymid);
            int count3 = (int)cmd_check3.ExecuteScalar();

            if (count3 == 0)
            {
                MessageBox.Show("Gym does not exist");
                return;
            }

            //check that gym belongs to same owner
            string query_check4 = ("SELECT COUNT (*) FROM gym where g_id=@gymid AND o_id=@ownerid ");
            SqlCommand cmd_check4 = new SqlCommand(query_check4, conn);
            cmd_check4.Parameters.AddWithValue("@gymid", gymid);
            cmd_check4.Parameters.AddWithValue("@ownerid", ownerid);
            int count4 = (int)cmd_check4.ExecuteScalar();

            if (count4 == 0)
            {
                MessageBox.Show("Gym does not belongs to you");
                return;
            }

            //check for duplicate requests
            string query5 = ("SELECT COUNT (*) FROM request_owner_admin where o_id=@ownerid AND  g_id=@gymid");
            SqlCommand cmd5 = new SqlCommand(query5, conn);
            cmd5.Parameters.AddWithValue("@ownerid", ownerid);
            cmd5.Parameters.AddWithValue("@gymid", gymid);
            int count5 = (int)cmd5.ExecuteScalar();

            if (count5 > 0)
            {
                MessageBox.Show("You have already sent request ");
                return;
            }

            //check that gym is already managed by any admin
            string query_check6 = ("SELECT COUNT (*) FROM gym where g_id=@gymid AND a_id IS NOT NULL ");
            SqlCommand cmd_check6 = new SqlCommand(query_check6, conn);
            cmd_check6.Parameters.AddWithValue("@gymid", gymid);
            int count6 = (int)cmd_check6.ExecuteScalar();

            if (count6 > 0)
            {
                MessageBox.Show("Gym is already managed by admin");
                return;
            }
            // INSERTION iN REQUEST TABLE
            string query2 = "INSERT INTO Request_owner_admin VALUES('" + ownerid + "','" + gymid + "')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();

            cmd2.Dispose();

            MessageBox.Show("YOUR REQUEST IS SEND TO ADMIN ");



            conn.Close();
        }
    }
}
