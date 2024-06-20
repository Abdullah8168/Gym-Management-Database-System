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
    public partial class Owner_4 : Form
    {
        public int ownerid;
        public Owner_4()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            ownerid = a;
        }
        private void Owner_4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Basic");
            comboBox1.Items.Add("Premium");
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("All");
            comboBox1.SelectedItem = "All";

            //Show all tables
            // Fill table 2 (user plans)
            string query = "SELECT u.u_id,u.u_membertype,u.u_membershipdate,u.u_name,u.u_address " +
                         "FROM user_ AS u " +
                         "INNER JOIN r_user_gym r ON r.u_id=u.u_id " +
                         "INNER JOIN gym g ON g.g_id=r.g_id " +
                         "WHERE g.o_id = @ownerid ";
           
            loadtable1(query, "");

        }
        public void loadtable1(string query,  string sortby)
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";



            // Retrieve  IDs for the user
            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@sortby", sortby);
                    command.Parameters.AddWithValue("@ownerid", ownerid);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            dataGridView1.Columns["u_id"].Width = 100;
            dataGridView1.Columns["u_membertype"].Width = 100;
            dataGridView1.Columns["u_membershipdate"].Width = 100;
            dataGridView1.Columns["u_name"].Width = 100;
            dataGridView1.Columns["u_address"].Width = 100;

            dataGridView1.Columns["u_id"].HeaderText = "MEMBER ID";
            dataGridView1.Columns["u_membertype"].HeaderText = "MEMBERSHIP";
            dataGridView1.Columns["u_membershipdate"].HeaderText = "DATE";
            dataGridView1.Columns["u_name"].HeaderText = "NAME";
            dataGridView1.Columns["u_address"].HeaderText = "ADDRESS";

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1))
            {
                MessageBox.Show("Please Select form drop down list");
                return;
            }

            string sortby = comboBox1.SelectedItem.ToString();

            if (sortby == "All")
            {
                string query = "SELECT u.u_id,u.u_membertype,u.u_membershipdate,u.u_name,u.u_address " +
                             "FROM user_ AS u " +
                             "INNER JOIN r_user_gym r ON r.u_id=u.u_id " +
                             "INNER JOIN gym g ON g.g_id=r.g_id " +
                             "WHERE g.o_id = @ownerid ";

                loadtable1(query, "");

            }
            else if (sortby == "Basic")
            {
                string query = "SELECT u.u_id,u.u_membertype,u.u_membershipdate,u.u_name,u.u_address " +
                                       "FROM user_ AS u " +
                                       "INNER JOIN r_user_gym r ON r.u_id=u.u_id " +
                                       "INNER JOIN gym g ON g.g_id=r.g_id " +
                                       "WHERE g.o_id = @ownerid AND u.u_membertype=@sortby ";

                loadtable1(query, sortby);

            }
            else if (sortby == "Premium")
            {
                // Fill table 2 (user plans)
                string query = "SELECT u.u_id,u.u_membertype,u.u_membershipdate,u.u_name,u.u_address " +
                                       "FROM user_ AS u " +
                                       "INNER JOIN r_user_gym r ON r.u_id=u.u_id " +
                                       "INNER JOIN gym g ON g.g_id=r.g_id " +
                                       "WHERE g.o_id = @ownerid AND u.u_membertype=@sortby ";

                loadtable1(query, sortby);

            }
            else if (sortby == "Student")
            {
                string query = "SELECT u.u_id,u.u_membertype,u.u_membershipdate,u.u_name,u.u_address " +
                                       "FROM user_ AS u " +
                                       "INNER JOIN r_user_gym r ON r.u_id=u.u_id " +
                                       "INNER JOIN gym g ON g.g_id=r.g_id " +
                                       "WHERE g.o_id = @ownerid AND u.u_membertype=@sortby ";

                loadtable1(query, sortby);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner_1 secondForm = new Owner_1();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }
    }
}
