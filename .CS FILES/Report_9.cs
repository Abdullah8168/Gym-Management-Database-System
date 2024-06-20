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
    public partial class Report_9 : Form
    {
        public Report_9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports second = new Reports();
            this.Close();
            second.Show();
        }

        private void Report_9_Load(object sender, EventArgs e)
        {

        }
        void loadtable1()
        {

            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            string query = "SELECT u.u_id, u.u_name, u.u_membertype, u.u_membershipDate, u.u_email, u.u_address "+
                           "FROM user_ u "+
                           "WHERE u.u_membershipDate >= DATEADD(MONTH, -3, GETDATE())";


            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {


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

            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            string query = "SELECT u.u_id, u.u_name, u.u_membertype, u.u_membershipDate, u.u_email, u.u_address " +
                           "FROM user_ u " +
                           "WHERE u.u_membershipDate >= DATEADD(MONTH, -6, GETDATE())";

            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {


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
    }
}
