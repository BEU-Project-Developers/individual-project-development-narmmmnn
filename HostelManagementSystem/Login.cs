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
                if (first_name.Text != "" && l_name.Text != "" && date.Text != "" && gender.Text != "" && emailadd.Text != "" && address.Text != "" && password.Text != "" && con_password.Text != "")
                {
                    // Check if the email ends with "email.com"
                    if (!emailadd.Text.EndsWith("email.com", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Email must end with 'email.com'");
                        return;
                    }

                    if (password.Text == con_password.Text)
                    {
                        // Check if the email is not already registered
                        int v = check(emailadd.Text);

                        if (v != 1)
                        {
                            // If email is not registered, proceed with registration
                            Random random = new Random();
                            if (Con.State == ConnectionState.Closed)
                            {
                                Con.Open();
                            }
                            int Id = random.Next();

                            // Insert user registration data into the Registration_tbl
                            SqlCommand cmd = new SqlCommand("INSERT INTO Registration_tbl VALUES(@Id, @f_name, @l_name, @b_date, @gender, @address, @email, @password)", Con);

                            // Add parameters to the SqlCommand
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
                            MessageBox.Show("Registration Successful");

                            // Clear the input fields after successful registration
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
                    MessageBox.Show("Fill in the blanks!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int check(string email)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            // Construct the SQL query to count the occurrences of a specific email in the Registration_tbl
            string query = "SELECT COUNT(*) FROM Registration_tbl WHERE email='" + email + "'";
            SqlCommand cmd = new SqlCommand(query, Con);

            // Execute the query and cast the result to an integer
            int v = (int)cmd.ExecuteScalar();

            Con.Close();
            return v;
        }
      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login2 login2 = new Login2();
            login2.Show();
            this.Hide();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();            
        }

        private void password_TextChanged(object sender, EventArgs e)
        // When text changes in the password TextBox, set UseSystemPasswordChar to true     
        {
            password.UseSystemPasswordChar = true;
        }

        private void con_password_TextChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }

        private void hidepass_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property based on whether the CheckBox is checked or not
            // If checked, show the actual characters; otherwise, hide them
            password.UseSystemPasswordChar = !hidepass.Checked;
        }

        private void hidepass1_CheckedChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !hidepass1.Checked;
        }
    }
}
