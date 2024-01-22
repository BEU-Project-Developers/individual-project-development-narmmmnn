﻿using System;
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
    public partial class Salary : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");

        public Salary()
        {
            InitializeComponent();
        }
        private void FillEmployeeIdCb()// Method to fill the EmployeeIdCb with Employee Ids from the Employee_tbl table
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string query = "SELECT EmpID FROM Employee_tbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpID", typeof(string));
            dt.Load(rdr);
            EmployeeIdCb.ValueMember = "EmpID";
            EmployeeIdCb.DataSource = dt;
            Con.Close();

        }
        string empname, emppos;
        public void FetchData()// Method to fetch data for a selected Employee Id and update UI elements
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string query = "select * from Employee_tbl where EmpID = '" + EmployeeIdCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                empname = dr["EmpName"].ToString();
                emppos = dr["EmpPos"].ToString();
                EmployeeNameTb.Text = empname;
                PositionTb.Text = emppos;
            }
            Con.Close();
        }


        void FillSalaryDGV()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string myquery = "SELECT * FROM Salary_tbl";
            SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
            var ds = new DataSet();
            da.Fill(ds);
            SalaryDGV.DataSource = ds.Tables[0];
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0 && e.RowIndex < SalaryDGV.Rows.Count)
            {
                SalaryIdTb.Text = SalaryDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                EmployeeNameTb.Text = SalaryDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                PositionTb.Text = SalaryDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                AmountTb.Text = SalaryDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();

                string selectedId = SalaryDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();

                EmployeeIdCb.SelectedValue = selectedId;

            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void Salary_Load(object sender, EventArgs e)
        {
            FillSalaryDGV();
            FillEmployeeIdCb();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all required fields are filled
                if (SalaryIdTb.Text == "" || EmployeeNameTb.Text == "" || EmployeeIdCb.Text == "" || PositionTb.Text == "" || AmountTb.Text == "")
                {
                    MessageBox.Show("Enter The Salary Id");
                }
                else
                {
                    // Get the selected month and year from the Periode DateTimePicker
                    string paymentperiode = Periode.Value.Month.ToString() + "/" + Periode.Value.Year.ToString();

                    // Check if the salary for the selected month already exists
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Salary_tbl WHERE SalEmpID = @EmpID AND SalMonth = @Month", Con);
                    sda.SelectCommand.Parameters.AddWithValue("@EmpID", EmployeeIdCb.SelectedValue.ToString());
                    sda.SelectCommand.Parameters.AddWithValue("@Month", paymentperiode);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Con.Close();

                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("There is No Due for This Month");
                    }
                    else
                    {
                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
                        string query = "INSERT INTO Salary_tbl (SalID, SalEmpID, SalEmpName, SalEmpPosition, SalMonth, SalAmount) VALUES (@SalID, @EmpID, @EmpName, @Position, @Month, @Amount)";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.Parameters.AddWithValue("@SalID", SalaryIdTb.Text);
                        cmd.Parameters.AddWithValue("@EmpID", EmployeeIdCb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@EmpName", EmployeeNameTb.Text);
                        cmd.Parameters.AddWithValue("@Position", PositionTb.Text);
                        cmd.Parameters.AddWithValue("@Month", paymentperiode);
                        cmd.Parameters.AddWithValue("@Amount", AmountTb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Salary Payment Success");
                        Con.Close();
                    }

                    FillSalaryDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }




        private void EmployeeIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchData();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the Salary ID is provided
                if (SalaryIdTb.Text == "")
                {
                    MessageBox.Show("Enter The Salary Id");
                }
                else
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string query = "DELETE FROM Salary_tbl WHERE SalID = @SalID";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Add a parameter for the Salary ID to prevent SQL injection
                    cmd.Parameters.AddWithValue("@SalID", SalaryIdTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary Info Successfully Deleted");
                    Con.Close();
                    FillSalaryDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if required fields are filled
                if (SalaryIdTb.Text == "" || EmployeeNameTb.Text == "" || EmployeeIdCb.Text == "" || PositionTb.Text == "" || AmountTb.Text == "")
                {
                    MessageBox.Show("Enter The Salary Id");
                }
                else
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }

                    string paymentperiode = Periode.Value.Month.ToString() + "/" + Periode.Value.Year.ToString();

                    string query = "UPDATE Salary_tbl SET SalAmount = @SalAmount, SalMonth = @SalMonth WHERE SalID = @SalID";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Set parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@SalAmount", AmountTb.Text);
                    cmd.Parameters.AddWithValue("@SalMonth", paymentperiode);
                    cmd.Parameters.AddWithValue("@SalID", SalaryIdTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary Info Successfully Updated");
                    Con.Close();
                    FillSalaryDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }



    }
}
