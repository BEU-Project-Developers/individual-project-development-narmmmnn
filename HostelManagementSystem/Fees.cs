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
            Con.Open();
            string query = "select StdUsn from Student_tbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StdUsn", typeof(string));
            dt.Load(rdr);
            UsnCb.ValueMember = "StdUsn";
            UsnCb.DataSource = dt;
            Con.Close();
        }
        string studname, roomname;
        public void FetchData()
        {
            Con.Open();
            string query = "select * from Student_tbl where StdUsn = '" + UsnCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                studname = dr["StdName"].ToString();
                roomname = dr["StdRoom"].ToString();
                StudentNameTb.Text = studname;
                RoomNumTb.Text = roomname;
            }
            Con.Close();
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
                // Ensure the connection is closed even if an exception occurs
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

                // Assuming UsnCb is a ComboBox
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
            //FetchData();
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
            if (PaymentIdTb.Text == "" || StudentNameTb.Text == "" || UsnCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Enter The Payment Id");
            }
            else
            {
                string paymentperiode;
                paymentperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();

                // Check if the payment for the selected month already exists
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Fees_tbl where StudentUSN = '" + UsnCb.SelectedValue.ToString() + "' and PaymentMonth = '" + paymentperiode.ToString() + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Con.Close(); // Close the connection after checking

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("There is No Due for This Month");
                }
                else
                {
                    // Open a new connection before inserting
                    Con.Open();
                    string query = "INSERT INTO Fees_tbl VALUES (" + PaymentIdTb.Text + ",'" + UsnCb.SelectedValue.ToString() + "' , '" + StudentNameTb.Text + "' , " + RoomNumTb.Text + " , '" + paymentperiode + "'," + AmountTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment Success");
                    Con.Close(); // Close the connection after inserting
                }

                FillFeesDGV();
            }
        }

        private void button10_Click(object sender, EventArgs e)
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
                Con.Close(); // Close the connection after checking

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("There is No Due for This Month");
                }
                else
                {
                    Con.Open();

                    // Update query excluding StudentName, StdRoom, and PaymentMonth
                    string query = "update Fees_tbl set Amount=" + AmountTb.Text + " where PaymentID = '" + PaymentIdTb.Text + "'";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Payment Successfully Updated");
                    Con.Close();

                    FillFeesDGV();
                }
            }
        }



        private void button11_Click(object sender, EventArgs e)
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
    }
}

