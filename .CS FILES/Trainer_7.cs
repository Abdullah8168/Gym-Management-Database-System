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
    public partial class Trainer_7 : Form
    {
        public int trainerid;
        public Trainer_7()
        {
            InitializeComponent();
        }
        public void receive_data(int a)
        {
            trainerid = a;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trainer_1 secondForm = new Trainer_1();
            secondForm.receive_data(trainerid);
            this.Close();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_13 secondForm = new Trainer_13();
            secondForm.receive_data(trainerid);
            this.Close();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trainer_14 secondForm = new Trainer_14();
            secondForm.receive_data(trainerid);
            this.Close();
            secondForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Trainer_15 secondForm = new Trainer_15();
            secondForm.receive_data(trainerid);
            this.Close();
            secondForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Trainer_16 secondForm = new Trainer_16();
            secondForm.receive_data(trainerid);
            this.Close();
            secondForm.Show();
        }
    }
}
