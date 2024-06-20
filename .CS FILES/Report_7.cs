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
    public partial class Report_7 : Form
    {
        public Report_7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports second = new Reports();
            this.Close();
            second.Show();
        }
        void loadtable1()
        {
            string machineid = textBox3.Text;
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            string query = "SELECT W_id, W_purpose, W_shedule, W_expLevel "+
                        "FROM workoutplan "+
                        "WHERE W_id NOT IN( " +
                         "   SELECT W_id " +
                          "  FROM R_WORKOUTPLAN_EXERCISES " +
                           " WHERE e_id IN( " +
                           " SELECT e_id "+
                              "FROM R_EXERCISE_MACHINERY "+
                             "WHERE m_id = @machineid )"+
                               " )";


            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@machineid", machineid);


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
            string machineid = textBox4.Text;
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            string query = "SELECT W_id, W_purpose, W_shedule, W_expLevel " +
                        "FROM workoutplan " +
                        "WHERE W_id NOT IN( " +
                         "   SELECT W_id " +
                          "  FROM R_WORKOUTPLAN_EXERCISES " +
                           " WHERE e_id IN( " +
                           " SELECT e_id " +
                              "FROM R_EXERCISE_MACHINERY " +
                             "WHERE m_id != @machineid )" +
                               " )";

            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@machineid", machineid);


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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            loadtable1();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadtable2();
        }
    }
}
