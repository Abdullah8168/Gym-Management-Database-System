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
    public partial class User_1 : Form
    {
        public int userid;
        public User_1()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            userid = a;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_login secondForm = new User_login();
            this.Close();
            secondForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_2 n = new User_2();
            n.receive_data(userid);
            this.Hide();
            n.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_4 a = new User_4();
            a.receive_data(userid);
            this.Close();
            a.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_6 secondForm = new User_6();
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_8 secondForm = new User_8();
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_10 s = new User_10();
            s.receive_data(userid);
            this.Close();
            s.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User_15 secondForm = new User_15();
            secondForm.receive_data(userid);
            this.Close();
            secondForm.Show();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            }

        private void label6_Click_2(object sender, EventArgs e)
        {
            
        }

        private void User_1_Load(object sender, EventArgs e)
        {
            label6.Text = "User ID: " + userid.ToString();
        }

        private void label6_Click_3(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_4(object sender, EventArgs e)
        {

        }
    }
}
