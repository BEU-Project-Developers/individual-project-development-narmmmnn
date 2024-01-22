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

        public void FillUsnCb()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string query = "select StdUsn from Student_tbl";
            SqlCommand cmd = new SqlCommand(query, Con);

            // SqlDataReader to read the results of the query
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StdUsn", typeof(string));
            dt.Load(rdr);

            // Set the ValueMember and DataSource properties of the ComboBox (UsnCb)
            UsnCb.ValueMember = "StdUsn";
            UsnCb.DataSource = dt;

            // Close the database connection
            Con.Close();

        }


        string studname, roomname;
        public void FetchData() // Method to fetch data for a selected Student USN and update UI elements
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
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

        void FillFeesDGV()
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                string myquery = "SELECT * FROM Fees_tbl";
                SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
                var ds = new DataSet();
                da.Fill(ds);
                PaymentDGV.DataSource = ds.Tables[0];
                Con.Close();
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

                UsnCb.SelectedValue = PaymentDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();


            }
        }


        private void Fees_Load(object sender, EventArgs e)
        {
            FillUsnCb();
            FillFeesDGV();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();

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
                {
                    string paymentperiode;
                    paymentperiode = Periode.Value.Month.ToString() + "/" + Periode.Value.Year.ToString();



                    // Check if the payment for the selected month already exists
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
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

                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
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
                MessageBox.Show("Error" + ex.Message);
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
                if (PaymentIdTb.Text == "" || StudentNameTb.Text == "" || UsnCb.Text == "" || AmountTb.Text == "")
                {
                    MessageBox.Show("Enter The Payment Id");
                }
                else
                {
                    // Check if the payment for the selected month already exists
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string paymentperiode = Periode.Value.Month.ToString() + "/" + Periode.Value.Year.ToString();
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
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
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

