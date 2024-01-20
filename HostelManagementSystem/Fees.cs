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
    public partial class Fees : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");

        public Fees()
        {
            InitializeComponent();
        }
        // Method to fill the ComboBox (UsnCb) with Student USNs from the Student_tbl table
        public void FillUsnCb()
        {
            try
            {
                // Open the database connection
                Con.Open();

                // SQL query to select Student USNs from the Student_tbl table
                string query = "select StdUsn from Student_tbl";

                // SqlCommand to execute the query
                SqlCommand cmd = new SqlCommand(query, Con);

                // SqlDataReader to read the results of the query
                SqlDataReader rdr = cmd.ExecuteReader();

                // DataTable to store the retrieved data
                DataTable dt = new DataTable();

                // Add a column named "StdUsn" to the DataTable
                dt.Columns.Add("StdUsn", typeof(string));

                // Load the DataTable with data from the SqlDataReader
                dt.Load(rdr);

                // Set the ValueMember and DataSource properties of the ComboBox (UsnCb)
                UsnCb.ValueMember = "StdUsn";
                UsnCb.DataSource = dt;

                // Close the database connection
                Con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Handle SQL errors
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other types of errors
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
        string studname, roomname;
        public void FetchData() // Method to fetch data for a selected Student USN and update UI elements
        {
            try
            {
                Con.Open();
                string query = "select * from Student_tbl where StdUsn = '" + UsnCb.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();

                // SqlDataAdapter to fill the DataTable with data from the SqlCommand
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

               
                foreach (DataRow dr in dt.Rows) // Loop through the rows in the DataTable
                {
                    // Extract values from the DataRow and store in variables
                    studname = dr["StdName"].ToString();
                    roomname = dr["StdRoom"].ToString();

                    // Update UI elements (text boxes) with the retrieved data
                    StudentNameTb.Text = studname;
                    RoomNumTb.Text = roomname;
                }
                Con.Close();
            }            
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void FillFeesDGV()
        {
            try
            {
                Con.Open();
                string myquery = "SELECT * FROM Fees_tbl";
                SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
                var ds = new DataSet();
                da.Fill(ds);
                PaymentDGV.DataSource = ds.Tables[0];
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
            if (e.RowIndex >= 0 && e.RowIndex < PaymentDGV.Rows.Count)
            {
                PaymentIdTb.Text = PaymentDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                StudentNameTb.Text = PaymentDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                RoomNumTb.Text = PaymentDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                AmountTb.Text = PaymentDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();
                
                string selectedUsn = PaymentDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();

                // Check if the selected value is not null before assigning
                if (selectedUsn != null)
                {
                    UsnCb.SelectedValue = selectedUsn;
                }
            }
        }


        private void Fees_Load(object sender, EventArgs e)
        {
            FillUsnCb();           
            FillFeesDGV();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void UsnCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaymentIdTb.Text == "" || StudentNameTb.Text == "" || UsnCb.Text == "" || AmountTb.Text == "")
                {
                    MessageBox.Show("Enter The Payment Id");
                }
                else
                {// Get the selected month and year from the Periode DateTimePicker
                    string paymentperiode;
                    paymentperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                    // This code combines the month and year to create a unique identifier for the payment period.
                    // It converts the selected month and year to strings and concatenates them to form the payment period.


                    // Check if the payment for the selected month already exists
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Fees_tbl where StudentUSN = '" + UsnCb.SelectedValue.ToString() + "' and PaymentMonth = '" + paymentperiode.ToString() + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Con.Close();

                    if (dt.Rows[0][0].ToString() == "1") // If the payment for the selected month doesn't exist, proceed with insertion
                    {
                        MessageBox.Show("There is No Due for This Month");
                    }
                    else
                    {
                        
                        Con.Open();
                        string query = "INSERT INTO Fees_tbl VALUES (" + PaymentIdTb.Text + ",'" + UsnCb.SelectedValue.ToString() + "' , '" + StudentNameTb.Text + "' , " + RoomNumTb.Text + " , '" + paymentperiode + "'," + AmountTb.Text + ")";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment Success");
                        Con.Close();
                    }
                    FillFeesDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in button9_Click: " + ex.Message);
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaymentIdTb.Text == "" || StudentNameTb.Text == "" || UsnCb.Text == "" || AmountTb.Text == "")
                {
                    MessageBox.Show("Enter The Payment Id");
                }
                else
                {
                    // Check if the payment for the selected month already exists
                    Con.Open();
                    string paymentperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Fees_tbl where StudentUSN = '" + UsnCb.SelectedValue.ToString() + "' and PaymentMonth = '" + paymentperiode.ToString() + "'", Con);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    Con.Close(); 

                    // If the payment for the selected month doesn't exist, proceed with updating
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("There is No Due for This Month");
                    }
                    else
                    {
                        Con.Open();

                        string query = "update Fees_tbl set Amount=" + AmountTb.Text + " where PaymentID = '" + PaymentIdTb.Text + "'";

                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Payment Successfully Updated");
                        Con.Close();
                        FillFeesDGV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in button10_Click: " + ex.Message);
            }
        }



        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaymentIdTb.Text == "")
                {
                    MessageBox.Show("Enter The Payment Id");
                }
                else
                {
                    Con.Open();
                    string query = "delete from Fees_tbl where PaymentID = " + PaymentIdTb.Text;
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment Info Successfully Deleted");
                    Con.Close();
                    FillFeesDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}

