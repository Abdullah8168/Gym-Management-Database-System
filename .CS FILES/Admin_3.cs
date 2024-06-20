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
    public partial class Admin_3 : Form
    {
        public int adminid;
        public Admin_3()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            adminid = a;
        }
        private void Admin_3_Load(object sender, EventArgs e)
        {
            loadtable1();
        }
        void loadtable1()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = " SELECT g.g_id,g.g_name,g.g_address,g.o_id " +
                               "FROM gym as g " +
                               "WHERE g.a_id IS NOT NULL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }


            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = exerciseTable;
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            dataGridView2.Columns["g_id"].Width = 25;
            dataGridView2.Columns["g_name"].Width = 100;
            dataGridView2.Columns["g_address"].Width = 100;
            dataGridView2.Columns["o_id"].Width = 65;

            dataGridView2.Columns["g_id"].HeaderText = "ID";
            dataGridView2.Columns["g_name"].HeaderText = "NAME";
            dataGridView2.Columns["g_address"].HeaderText = "ADDRESS";
            dataGridView2.Columns["o_id"].HeaderText = "OWNER";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_1 second = new Admin_1();
            second.receive_data(adminid);
            this.Close();
            second.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_3 second = new Admin_3();
            second.receive_data(adminid);
            this.Close();
            second.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True");
            conn.Open();
            if ((string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            string gymid = textBox1.Text;

            //check that gym is managed by any admin
            string query_check3 = ("SELECT COUNT (*) FROM gym where a_id IS NOT NULL AND g_id=@gymid ");
            SqlCommand cmd_check3 = new SqlCommand(query_check3, conn);
            cmd_check3.Parameters.AddWithValue("@gymid", gymid);
            int count3 = (int)cmd_check3.ExecuteScalar();

            if (count3 == 0)
            {
                MessageBox.Show("Gym is not managed by admin ");
                return;
            }

          

            //delete all the users of this gym
            string query1 = "DELETE FROM R_user_gym WHERE g_id = @gymid ";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@gymid", gymid);
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();

            //delete all the trainers of this gym
            string query3 = "DELETE FROM R_trainer_gym WHERE g_id = @gymid ";
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd3.Parameters.AddWithValue("@gymid", gymid);
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();

            //remove gym admin
            string query2 = "DELETE FROM gym WHERE g_id=@gymid";

            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@gymid", gymid);
            cmd2.Parameters.AddWithValue("@adminid", adminid);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();

            MessageBox.Show("GYM Removed");
        }
    }
}
