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
    public partial class Owner_1 : Form
    {
        public int ownerid;
        public Owner_1()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            ownerid = a;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner_login secondForm = new Owner_login();
            this.Close();
            secondForm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner_2 secondForm = new Owner_2();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void Owner_1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner_3 secondForm = new Owner_3();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label11.Text = "Owner ID: " + ownerid.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner_4 secondForm = new Owner_4();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Owner_5 secondForm = new Owner_5();
            secondForm.receive_data(ownerid);
            this.Close();
            secondForm.Show();
        }
    }
}
