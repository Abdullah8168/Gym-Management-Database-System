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
    public partial class Owner_5 : Form
    {
        public int ownerid;
        public Owner_5()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            ownerid = a;
        }
        private void Owner_5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Speciality");
            comboBox1.Items.Add("Experience");
            comboBox1.Items.Add("Qualification");
            comboBox1.Items.Add("All");
            comboBox1.SelectedItem = "All";

            //Show all tables
            string query = "SELECT t.t_id,t.t_name,t.T_address,t.T_speciality,t.T_experience,t.T_qulification " +
                         "FROM trainer AS t " +
                         "INNER JOIN r_trainer_gym r ON r.t_id=t.t_id " +
                         "INNER JOIN gym g ON g.g_id=r.g_id " +
                         "WHERE g.o_id = @ownerid ";

            loadtable1(query, "");
        }
        public void loadtable1(string query, string text)
        {
            string connectionString = "Data Source=DESKTOP-QPKL2R5\\SQLEXPRESS;Initial Catalog=Flex_Trainer_Management_System;Integrated Security=True";



            // Retrieve  IDs for the user
            DataTable exerciseTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@text", text);
                    command.Parameters.AddWithValue("@ownerid", ownerid);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(exerciseTable);
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = exerciseTable;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            
            dataGridView1.Columns["t_id"].Width = 100;
            dataGridView1.Columns["t_name"].Width = 100;
            dataGridView1.Columns["t_address"].Width = 100;
            dataGridView1.Columns["t_speciality"].Width = 100;
            dataGridView1.Columns["t_experience"].Width = 100;
            dataGridView1.Columns["t_qulification"].Width = 100;

            dataGridView1.Columns["t_id"].HeaderText = "TRAINER ID";
            dataGridView1.Columns["t_name"].HeaderText = "NAME";
            dataGridView1.Columns["t_address"].HeaderText = "ADDRESS";
            dataGridView1.Columns["t_speciality"].HeaderText = "SPECIALITY";
            dataGridView1.Columns["t_experience"].HeaderText = "EXPERIENCE";
            dataGridView1.Columns["t_qulification"].HeaderText = "QUALIFICATION";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner_1 secondForm = new Owner_1();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1))
            {
                MessageBox.Show("Please Select form drop down list");
                return;
            }
            string text = textBox2.Text;

            string sortby = comboBox1.SelectedItem.ToString();

            if (sortby == "All")
            {
                string query = "SELECT t.t_id,t.t_name,t.T_address,t.T_speciality,t.T_experience,t.T_qulification " +
                             "FROM trainer AS t " +
                             "INNER JOIN r_trainer_gym r ON r.t_id=t.t_id " +
                             "INNER JOIN gym g ON g.g_id=r.g_id " +
                             "WHERE g.o_id = @ownerid ";

                loadtable1(query,"");

            }
            else if (sortby == "Speciality")
            {
                string query = "SELECT t.t_id,t.t_name,t.T_address,t.T_speciality,t.T_experience,t.T_qulification " +
                "FROM trainer AS t " +
                "INNER JOIN r_trainer_gym r ON r.t_id=t.t_id " +
                "INNER JOIN gym g ON g.g_id=r.g_id " +
                "WHERE g.o_id = @ownerid AND t.t_speciality=@text ";

                loadtable1(query, text);

            }
            else if (sortby == "Experience")
            {
                string query = "SELECT t.t_id,t.t_name,t.T_address,t.T_speciality,t.T_experience,t.T_qulification " +
                "FROM trainer AS t " +
                "INNER JOIN r_trainer_gym r ON r.t_id=t.t_id " +
                "INNER JOIN gym g ON g.g_id=r.g_id " +
                "WHERE g.o_id = @ownerid AND t.t_experience=@text ";

                loadtable1(query, text);

            }
            else if (sortby == "Qualification")
            {
                string query = "SELECT t.t_id,t.t_name,t.T_address,t.T_speciality,t.T_experience,t.T_qulification " +
                "FROM trainer AS t " +
                "INNER JOIN r_trainer_gym r ON r.t_id=t.t_id " +
                "INNER JOIN gym g ON g.g_id=r.g_id " +
                "WHERE g.o_id = @ownerid AND t.t_qulification=@text ";

                loadtable1(query, text);
            }
        }
    }
}
