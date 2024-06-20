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
    public partial class Report_3 : Form
    {
        public Report_3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports second = new Reports();
            this.Close();
            second.Show();
        }

        private void Report_3_Load(object sender, EventArgs e)
        {

        }
        void loadtable1()
        {
            string gymid = textBox3.Text;
            string trainerid = textBox2.Text;

            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";

            string query = "SELECT u.u_id, u.u_name, u.u_membertype, u.u_membershipDate, u.u_email, u.u_address FROM user_ u "+
"INNER JOIN R_user_gym r ON u.u_id = r.u_id "+
"INNER JOIN gym g ON r.g_id = g.g_id "+
"INNER JOIN R_TRAINER_GYM tg ON g.g_id = tg.g_id "+
"INNER JOIN trainer t ON tg.t_id = t.t_id "+
"INNER JOIN dietplan d ON u.u_id = d.u_id " +
"WHERE t.t_id = @trainer_id "+
"AND d.d_id = @diet_plan_id; ";


            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gymid", gymid);

                    command.Parameters.AddWithValue("@trainerid", trainerid);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        void loadtable2()
        {
            string gymid = textBox4.Text;
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            string query = " SELECT g.g_id, g.g_name, COUNT(t.t_id) AS total_members FROM gym g " +
                          " LEFT JOIN R_trainer_gym r ON g.g_id = r.g_id " +
                           "LEFT JOIN trainer t ON r.t_id = t.t_id " +
                           "WHERE g.g_id = @gymid " +
                           "GROUP BY g.g_id, g.g_name" ;


            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gymid", gymid);


                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = exerciseTable;
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadtable1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadtable2();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
