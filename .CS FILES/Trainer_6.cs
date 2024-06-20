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
    public partial class Trainer_6 : Form
    {
        public int trainerid;
        public Trainer_6()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            trainerid = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trainer_1 secondForm = new Trainer_1();
            secondForm.receive_data(trainerid);
            this.Close();
            secondForm.Show();
        }

        private void Trainer_6_Load(object sender, EventArgs e)
        {
            Loadtable();
        }
        void Loadtable()
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";
            // Create a DataTable to hold the exercise and machine data
            DataTable exerciseTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to retrieve exercise and associated machines information
                string query = "SELECT f.f_id  ,f.f_ratings ,u.u_id ,u.u_name " +
                               "FROM feedback f " +
                               "INNER JOIN user_ u ON u.u_id = f.u_id " +
                               "WHERE f.t_id=@trainerid ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainerid",trainerid);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(exerciseTable);
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;

            dataGridView1.Columns["f_id"].HeaderText = "FEEDBACK ID";
            dataGridView1.Columns["f_ratings"].HeaderText = "RATING";
            dataGridView1.Columns["u_id"].HeaderText = "MEMBER ID";
            dataGridView1.Columns["u_name"].HeaderText = "MEMBER NAME";
        }

    }
}
