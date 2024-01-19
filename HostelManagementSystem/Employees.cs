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
            SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
            var ds = new DataSet();
            da.Fill(ds);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter The Employee Id");
            }
            else
            {
                Con.Open();
                string query = "DELETE FROM Employee_tbl WHERE EmpID = '" + EmpIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Employee Info Successfully Deleted");

                Con.Close();
                FillEmployeeDGV();
                
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
            if (e.RowIndex >= 0 && e.RowIndex < EmployeeDGV.Rows.Count)
            {
                EmpIdTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                EmpNameTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                EmpPhoneTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                EmpAddTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();

                // Check if the item exists in the combo box before setting it
                string positionValue = EmployeeDGV.Rows[e.RowIndex].Cells[4].Value?.ToString();
                if (EmpPositionCb.Items.Contains(positionValue))
                {
                    EmpPositionCb.SelectedItem = positionValue;
                }

                string statusValue = EmployeeDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();
                if (EmpStatusCb.Items.Contains(statusValue))
                {
                    EmpStatusCb.SelectedItem = statusValue;
                }
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "" || EmpPositionCb.SelectedItem.ToString() == "" || EmpStatusCb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Fill All The Information");
            }
            else
            {

                Con.Open();
                string query = "update Employee_tbl set EmpName='" + EmpNameTb.Text + "',EmpPhone='" + EmpPhoneTb.Text + "' ,EmpAddress='" + EmpAddTb.Text + "' ,EmpPos='" + EmpPositionCb.SelectedItem.ToString() + "' ,EmpStatus='" + EmpStatusCb.SelectedItem.ToString() + "' where EmpID = '" + EmpIdTb.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Employee Info Successfully Updated");
                Con.Close();
                
                FillEmployeeDGV();
                

            }
        }
    }
}
