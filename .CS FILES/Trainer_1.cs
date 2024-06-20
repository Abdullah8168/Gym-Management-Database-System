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
    public partial class Trainer_1 : Form
    {
        public int trainerid;
        public Trainer_1()
        {
            InitializeComponent();
            
        }
        public void receive_data(int a)
        {
            trainerid = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trainer_login secondForm = new Trainer_login();
            this.Close();
            secondForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_2 secondForm = new Trainer_2();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }



        private void Trainer_1_Load(object sender, EventArgs e)
        {
            label10.Text = "Trainer ID: " + trainerid.ToString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_4 secondForm = new Trainer_4();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }



        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_6 secondForm = new Trainer_6();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_7 secondForm = new Trainer_7();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_17 secondForm = new Trainer_17();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Trainer_18 secondForm = new Trainer_18();
            secondForm.receive_data(trainerid);
            this.Hide();
            secondForm.Show();
        }
    }
}
