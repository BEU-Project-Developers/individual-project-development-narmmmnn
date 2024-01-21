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
    public partial class Employees : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");

        public Employees()
        {
            InitializeComponent();
        }
        
        void FillEmployeeDGV()
        {
            
                Con.Open();
                string myquery = "SELECT * FROM Employee_tbl";

                // SqlDataAdapter to fetch data from the database
                SqlDataAdapter da = new SqlDataAdapter(myquery, Con);

                // DataSet to store the retrieved data
                var ds = new DataSet();
                da.Fill(ds);

                // Set the DataSource of the Employee DataGridView to the DataSet
                EmployeeDGV.DataSource = ds.Tables[0];
                Con.Close();
            
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

        private void Employees_Load(object sender, EventArgs e)
        {
            FillEmployeeDGV();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
                Application.Exit();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpIdTb.Text == "")
                {
                    MessageBox.Show("Enter The Employee Id");
                }
                else
                {
                    Con.Open();

                    // SQL query to delete employee information based on the provided Employee Id
                    string query = "DELETE FROM Employee_tbl WHERE EmpID = '" + EmpIdTb.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();                   
                    MessageBox.Show("Employee Info Successfully Deleted");

                    Con.Close();
                    FillEmployeeDGV();
                }
            }            
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpIdTb.Text == "" || EmpPhoneTb.Text == "")
            {
                MessageBox.Show("No Empty Filled Accepted");
            }
            else
            {
                try
                {
                    Con.Open();
                    // SQL query to insert a new employee into Employee_tbl using parameters to avoid SQL injection
                    String query = "INSERT INTO Employee_tbl VALUES (@EmpId, @EmpName, @EmpPhone, @EmpAddress, @EmpPosition, @EmpStatus)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Use parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@EmpId", EmpIdTb.Text);
                    cmd.Parameters.AddWithValue("@EmpName", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EmpPhone", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EmpAddress", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@EmpPosition", EmpPositionCb.SelectedItem?.ToString());
                    cmd.Parameters.AddWithValue("@EmpStatus", EmpStatusCb.SelectedItem?.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                }
                finally
                {
                    Con.Close();
                    FillEmployeeDGV();
                }
            }
        }


        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0 && e.RowIndex < EmployeeDGV.Rows.Count)
            {
                EmpIdTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                EmpNameTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                EmpPhoneTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                EmpAddTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();

                
                string positionValue = EmployeeDGV.Rows[e.RowIndex].Cells[4].Value?.ToString();                
                    EmpPositionCb.SelectedItem = positionValue;
                

                string statusValue = EmployeeDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();                
                    EmpStatusCb.SelectedItem = statusValue;
                
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            // Check if all the fields are filled
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "" || EmpPositionCb.SelectedItem == null || EmpPositionCb.SelectedItem.ToString() == "" || EmpStatusCb.SelectedItem == null || EmpStatusCb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Fill All The Information");
            }
            else
            {
                try
                {                   
                    Con.Open();                    
                    string query = "update Employee_tbl set EmpName='" + EmpNameTb.Text + "',EmpPhone='" + EmpPhoneTb.Text + "' ,EmpAddress='" + EmpAddTb.Text + "' ,EmpPos='" + EmpPositionCb.SelectedItem.ToString() + "' ,EmpStatus='" + EmpStatusCb.SelectedItem.ToString() + "' where EmpID = '" + EmpIdTb.Text + "'";

                    // Execute the query
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Info Successfully Updated");
                    Con.Close();
                    
                    FillEmployeeDGV();
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("An error occurred: " + ex.Message);

                    // Ensure the connection is closed if an exception occurs
                    if (Con.State == System.Data.ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }
            }
        }

    }
}
