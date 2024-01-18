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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
