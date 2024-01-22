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

namespace HostelManagementSystem
{
    public partial class Login2 : Form
    {

        public Login2()
        {
            InitializeComponent();

        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\LENOVO\\Documents\\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (u_name.Text != "" && password.Text != "")
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    // SQL query to check the count of rows where the given email and password match
                    string query = "select count(*) from Registration_tbl where email = '" + u_name.Text + "' and password='" + password.Text + "'";
                    // Create a SqlCommand object to execute the SQL query and retrieve a single value
                    SqlCommand cmd = new SqlCommand(query, Con);

                    int v = (int)cmd.ExecuteScalar();

                    if (v != 1)
                    {
                        MessageBox.Show("Error username or password", "Error!");
                    }
                    else
                    {
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Fill in the blanks!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login signup = new Login();
            signup.Show();
            this.Hide();

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
