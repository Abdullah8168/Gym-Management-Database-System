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
    public partial class Admin_4 : Form
    {
        public int adminid;
        public Admin_4()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            adminid = a;
        }
        private void Admin_4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Number of Members");
            comboBox1.Items.Add("Number of Trainers");
            comboBox1.Items.Add("Number of Premium membership");
            comboBox1.Items.Add("All");
            comboBox1.SelectedItem = "All";

            string query = "SELECT g.g_id,g.g_name,g.g_address,g.o_id " +
                         "FROM gym g  " +
                         "WHERE g.a_id IS NOT NULL ";
            
            loadtable1(query, "");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_1 second = new Admin_1();
            second.receive_data(adminid);
            this.Close();
            second.Show();
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

                string query = "SELECT g.g_id,g.g_name,g.g_address,g.o_id " +
                        "FROM gym g  " +
                        "WHERE g.a_id IS NOT NULL ";

                loadtable1(query, sortby);

            }
            else if (sortby == "Number of Trainers")
            {
                // Fill table 2 (user plans)
                string query = "SELECT g.g_id, g.g_name, g.g_address, g.o_id, COUNT(t.t_id) as count1 " +
                               "FROM gym g " +
                               "INNER JOIN r_trainer_gym r ON g.g_id = r.g_id " +
                               "INNER JOIN trainer t ON r.t_id = t.t_id " +
                               "GROUP BY g.g_id, g.g_name, g.g_address, g.o_id " +
                               "ORDER BY count1 DESC"; // Use the correct alias here

                loadtable1(query, sortby);
            }
            else if (sortby == "Number of Members")
            {
                // Fill table 2 (user plans)
                string query = "SELECT g.g_id, g.g_name, g.g_address, g.o_id, COUNT(u.u_id) as count1  " +
                               "FROM gym g " +
                               "INNER JOIN r_user_gym r ON g.g_id = r.g_id " +
                               "INNER JOIN user_ u ON r.u_id = u.u_id " +
                               "GROUP BY g.g_id, g.g_name, g.g_address, g.o_id " +
                               "ORDER BY count1 DESC"; // Use the correct alias here

                loadtable1(query, sortby);
            }
            else if (sortby == "Number of Premium membership")
            {
                string query = "SELECT g.g_id, g.g_name, g.g_address, g.o_id, COUNT(u.u_id) as count1  " +
                               "FROM gym g " +
                               "INNER JOIN r_user_gym r ON g.g_id = r.g_id " +
                               "INNER JOIN user_ u ON r.u_id = u.u_id " +
                               "WHERE u.u_membertype = 'Premium' " +
                               "GROUP BY g.g_id, g.g_name, g.g_address, g.o_id " +
                               "ORDER BY count1 DESC"; // Use the correct alias here

                loadtable1(query, sortby);
            }

        }
        
            void loadtable1(string query, string sortby)
            {
                string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";



                // Retrieve  IDs for the user
                DataTable exerciseTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@adminid", adminid);

                        command.Parameters.AddWithValue("@sortby", sortby);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(exerciseTable);
                    }
                }

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = exerciseTable;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

         
                dataGridView1.Columns["g_id"].Width = 100;
                dataGridView1.Columns["g_name"].Width = 100;
                dataGridView1.Columns["g_address"].Width = 100;
                dataGridView1.Columns["o_id"].Width = 100;
                
                dataGridView1.Columns["g_id"].HeaderText = "GYM ID";
                dataGridView1.Columns["g_name"].HeaderText = "GYM NAME";
                dataGridView1.Columns["g_address"].HeaderText = "ADDRESS";
                dataGridView1.Columns["o_id"].HeaderText = "OWNER ID";
                
            }
        }
    }

