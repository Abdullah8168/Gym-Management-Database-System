using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT_FRONTEND
{
    public partial class Admin_1 : Form
    {
        public int adminid;
        public Admin_1()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            adminid = a;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_login secondForm = new Admin_login();
            this.Close();
            secondForm.Show();
        }

        private void Admin_1_Load(object sender, EventArgs e)
        {
            label5.Text = "Admin ID: " + adminid.ToString();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_2 second = new Admin_2();
            second.receive_data(adminid);
            this.Close();
            second.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_3 second = new Admin_3();
            second.receive_data(adminid);
            this.Close();
            second.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_4 second = new Admin_4();
            second.receive_data(adminid);
            this.Close();
            second.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports second = new Reports();
            this.Close();
            second.Show();
        }
    }
}
