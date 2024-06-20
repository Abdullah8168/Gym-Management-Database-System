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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_1 second = new Report_1();
            this.Close();
            second.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_2 second = new Report_2();
            this.Close();
            second.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_3 second = new Report_3();
            this.Close();
            second.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_4 second = new Report_4();
            this.Close();
            second.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_5 second = new Report_5();
            this.Close();
            second.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_6 second = new Report_6();
            this.Close();
            second.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_7 second = new Report_7();
            this.Close();
            second.Show();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_8 second = new Report_8();
            this.Close();
            second.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_9 second = new Report_9();
            this.Close();
            second.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_10 second = new Report_10();
            this.Close();
            second.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_1 second = new Admin_1();
            this.Close();
            second.Show();
        }
    }
}
