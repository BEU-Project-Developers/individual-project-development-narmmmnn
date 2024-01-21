using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelManagementSystem
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");
        void FillStudentDGV()
        {
                Con.Open();
                string myquery = "SELECT * FROM Student_tbl";
                SqlDataAdapter da = new SqlDataAdapter(myquery, Con); // SqlDataAdapter to fetch data from the database
            var ds = new DataSet();
                da.Fill(ds);
                StudentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
            

        void FillRoomCombobox()
        {

            Con.Open();
            string query = "Select * from Room_tbl WHERE RoomStatus = 'Active' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;// Declare a SqlDataReader to read data from the database
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RoomNum", typeof(int));
            dt.Load(rdr);
            
            StudRoomCb.ValueMember = "RoomNum";//This is the value that the ComboBox will use as the actual value for the items.
            StudRoomCb.DisplayMember = "RoomNum";//will be displayed to the user in the ComboBox list

            StudRoomCb.DataSource = dt;

            Con.Close();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudUSN.Text == "")
                {
                    MessageBox.Show("Enter The Student USN");
                }
                else
                {
                    // Open the database connection
                    Con.Open();
                    string query = "update Student_tbl set StdName='" + StudName.Text + "', FatherName='" + FatherName.Text + "' , MotherName='" + MotherName.Text + "' , StdAddress='" + AddressTb.Text + "' , College='" + CollegeTb.Text + "' , StdRoom= " + StudRoomCb.SelectedValue.ToString() + " , StdStatus='" + StudStatusCb.SelectedItem.ToString() + "' where StdUsn = '" + StudUSN.Text + "' ";

                    // Execute the query
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Successfully Updated");
                    Con.Close();

                    updateBookedStatus();
                    updateBookedStatusOnDelete();
                    
                    FillStudentDGV();
                   
                    FillRoomCombobox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in button10_Click: " + ex.Message);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (StudUSN.Text == "" || StudName.Text == "" || FatherName.Text == "" || MotherName.Text == "" || AddressTb.Text == "" || CollegeTb.Text == "")
            {
                MessageBox.Show("No Empty Fields Accepted");
            }
            else
            {
                try
                {
                    Con.Open();

                    // SQL query to insert a new student into Student_tbl using parameters to avoid SQL injection
                    string query = "INSERT INTO Student_tbl VALUES (@StdUSN, @StdName, @FatherName, @MotherName, @StdAddress, @College, @StdRoom, @StdStatus)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Set parameters with values from the form controls
                    cmd.Parameters.AddWithValue("@StdUSN", StudUSN.Text);
                    cmd.Parameters.AddWithValue("@StdName", StudName.Text);
                    cmd.Parameters.AddWithValue("@FatherName", FatherName.Text);
                    cmd.Parameters.AddWithValue("@MotherName", MotherName.Text);
                    cmd.Parameters.AddWithValue("@StdAddress", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@College", CollegeTb.Text);
                    cmd.Parameters.AddWithValue("@StdRoom", StudRoomCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@StdStatus", StudStatusCb.SelectedItem.ToString());

                    // Execute the query to insert the new student
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Successfully Added");
                    Con.Close();
                    updateBookedStatus();
                    updateBookedStatusOnDelete();
                    FillStudentDGV();
                    FillRoomCombobox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudUSN.Text == "")
                {
                    MessageBox.Show("Enter The Student Number");
                }
                else
                {
                    Con.Open();
                    string query = "delete from Student_tbl where StdUsn = '" + StudUSN.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Info Successfully Deleted");

                    Con.Close();
                    updateBookedStatus();
                    updateBookedStatusOnDelete();
                    FillStudentDGV();
                    FillRoomCombobox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in button11_Click: " + ex.Message);
            }
        }


        private void Students_Load(object sender, EventArgs e)
        {
            FillStudentDGV();
            FillRoomCombobox();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
                Application.Exit();
            
        }
        void updateBookedStatusOnDelete()
        {
            try
            {
                Con.Open();

                string studStatus = StudStatusCb.SelectedItem?.ToString();

                // If the student status is "Left," update the corresponding room status to "Free"
                if (studStatus == "Left" && StudRoomCb.SelectedValue != null)
                {
                    string roomNum = StudRoomCb.SelectedValue.ToString();
                    string query = "update Room_tbl set Booked = @FreeStatus where RoomNum = @RoomNum";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@FreeStatus", "Free");
                    cmd.Parameters.AddWithValue("@RoomNum", roomNum);

                    cmd.ExecuteNonQuery();
                }
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




        void updateBookedStatus()
        {
            try
            {
                Con.Open();

                // Get the selected student status from StudStatusCb
                string studStatus = StudStatusCb.SelectedItem?.ToString();

                if (studStatus == "Living")
                {
                    // Update the Booked status to "busy" in Room_tbl for the selected room
                    string query = "update Room_tbl set Booked='" + "Busy" + "' where RoomNum=" + StudRoomCb.SelectedValue?.ToString() + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
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



        private void StudStatusCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected in the StudStatusCb ComboBox
            if (StudStatusCb.SelectedItem != null)
            {
                // Retrieve the selected status as a string
                string selectedStatus = StudStatusCb.SelectedItem.ToString();
                // we add this when we select new item execute these task
                updateBookedStatus();
                updateBookedStatusOnDelete();
            }

        }        

        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0 && e.RowIndex < StudentDGV.Rows.Count)
            {
                DataGridViewRow selectedRow = StudentDGV.Rows[e.RowIndex];

                // Retrieve values from the selected row and populate the corresponding controls
                StudUSN.Text = Convert.ToString(selectedRow.Cells["StdUsn"].Value);
                StudName.Text = Convert.ToString(selectedRow.Cells["StdName"].Value);
                FatherName.Text = Convert.ToString(selectedRow.Cells["FatherName"].Value);
                MotherName.Text = Convert.ToString(selectedRow.Cells["MotherName"].Value);
                AddressTb.Text = Convert.ToString(selectedRow.Cells["StdAddress"].Value);
                CollegeTb.Text = Convert.ToString(selectedRow.Cells["College"].Value);

                StudRoomCb.SelectedValue = Convert.ToString(selectedRow.Cells["StdRoom"].Value);
                StudStatusCb.SelectedItem = Convert.ToString(selectedRow.Cells["StdStatus"].Value);

                
                updateBookedStatusOnDelete();
                updateBookedStatus();
            }
        }
    }
}

