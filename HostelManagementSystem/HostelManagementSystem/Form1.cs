using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rooms Myroom = new Rooms();
            Myroom.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Students MyStudent = new Students();
            MyStudent.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employees MyEmployee = new Employees();
            MyEmployee.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fees MyFees = new Fees();
            MyFees.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Salary MySalary = new Salary();
            MySalary.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
