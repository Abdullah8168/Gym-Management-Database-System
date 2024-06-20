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
    public partial class Report_6 : Form
    {
        public Report_6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports second = new Reports();
            this.Close();
            second.Show();
        }

        private void Report_6_Load(object sender, EventArgs e)
        {

        }
        void loadtable1()
        {

            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            string query = "SELECT d.d_id, d.d_type, d.d_objective "+
                           "FROM dietplan d " +
                          "JOIN R_DIETPLAN_MEAL rdm ON d.d_id = rdm.d_id "+
                           "JOIN meal m ON rdm.ml_id = m.ml_id "+
                          " GROUP BY d.d_id, d.d_type, d.d_objective "+
 "HAVING SUM(m.ml_nutrition_quantity) < 300 AND SUM(CASE WHEN m.ml_nutrition = 'carbohydrate' THEN m.ml_nutrition_quantity ELSE 0 END) < 300";


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
            string query = "SELECT d.d_id, d.d_type, d.d_objective " +
                           "FROM dietplan d " +
                          "JOIN R_DIETPLAN_MEAL rdm ON d.d_id = rdm.d_id " +
                           "JOIN meal m ON rdm.ml_id = m.ml_id " +
                          " GROUP BY d.d_id, d.d_type, d.d_objective " +
 "HAVING SUM(m.ml_nutrition_quantity) < 300 AND SUM(CASE WHEN m.ml_nutrition = 'proteins' THEN m.ml_nutrition_quantity ELSE 0 END) < 300";


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
