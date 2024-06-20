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
    public partial class Report_4 : Form
    {
        public Report_4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports second = new Reports();
            this.Close();
            second.Show();
        }

        private void Report_4_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //loadtable1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //loadtable2();
        }
    }
}
