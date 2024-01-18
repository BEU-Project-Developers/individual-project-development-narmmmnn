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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HostelManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\LENOVO\\Documents\\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(first_name.Text!="" && l_name.Text!="" && date.Text!="" && gender.Text!="" && emailadd.Text!="" && address.Text!="" && password.Text!="" && con_password.Text != "" )
                {
                    if(password.Text== con_password.Text)
                    {
                        int v = check(emailadd.Text);
                        if(v!= 1)
                        {
                            Random random = new Random();
                            Con.Open();
                            SqlCommand cmd = new SqlCommand("insert into Registration_tbl values(@Id, @f_name,@l_name," + "@b_date, @gender, @address, @email, @password)", Con);
                            int Id = random.Next();
                            cmd.Parameters.AddWithValue("@Id", Id);
                            cmd.Parameters.AddWithValue("@f_name", first_name.Text);
                            cmd.Parameters.AddWithValue("@email", emailadd.Text);
                            cmd.Parameters.AddWithValue("@l_name", l_name.Text);
                            cmd.Parameters.AddWithValue("@b_date", Convert.ToDateTime(date.Text));
                            cmd.Parameters.AddWithValue("@gender", gender.Text);
                            cmd.Parameters.AddWithValue("@address", address.Text);
                            cmd.Parameters.AddWithValue("@password", password.Text);
                            cmd.ExecuteNonQuery();
                            Con.Close();
                            MessageBox.Show("Register Successfully");
                            first_name.Text = "";
                            l_name.Text = "";
                            gender.Text = "";
                            emailadd.Text = "";
                            password.Text = "";
                            con_password.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("You are already registered");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password does not match.");
                    }
                }
                else
                {
                    MessageBox.Show("Fill the blinks!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int check(string email)
        {
            Con.Open();
            string query = " select count(*) from Registration_tbl where email='" + email + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            int v=(int)cmd.ExecuteScalar();
            Con.Close();
            return v;
        }
        
        private void check_pass_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login2 login2 = new Login2();
            login2.Show();
            this.Hide();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }

        private void con_password_TextChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }

        private void hidepass_CheckedChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !hidepass.Checked;
        }

        private void hidepass1_CheckedChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !hidepass1.Checked;
        }
    }
}
