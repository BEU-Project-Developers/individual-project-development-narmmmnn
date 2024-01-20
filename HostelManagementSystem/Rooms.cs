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
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\HostelMgmt.mdf;Integrated Security=True;Connect Timeout=30");

        // Method to fill the Room DataGridView
        void FillRoomDGV()
        {
            try
            {
                Con.Open();
                // SQL query to select all records from Room_tbl
                string myquery = "Select * from Room_tbl";
                SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                da.Fill(ds);
                // Set the DataGridView's data source to the retrieved dataset
                RoomDGV.DataSource = ds.Tables[0];
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

        string RoomBooked;

        // Event handler for adding a new room
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoomNumbTb.Text == "")
                {
                    MessageBox.Show("Enter The Room Number");
                }
                else
                {
                    // Determine if the room is booked or free
                    string roomBooked = YesRadio.Checked ? "Busy" : "Free";

                    Con.Open();
                    // SQL query to insert a new room into Room_tbl
                    string query = "insert into Room_tbl values(" + RoomNumbTb.Text + ",'" + RoomStatusCb.SelectedItem.ToString() + "','" + roomBooked + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room Successfully Added");

                    Con.Close();
                    // Refresh the DataGridView after adding a new room
                    FillRoomDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Event handler for updating an existing room
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoomNumbTb.Text == "")
                {
                    MessageBox.Show("Enter The Room Number");
                }
                else
                {
                    // Determine if the room is booked or free
                    string roomBooked = YesRadio.Checked ? "Busy" : "Free";

                    Con.Open();
                    // SQL query to update an existing room in Room_tbl
                    string query = "update Room_tbl set RoomStatus='" + RoomStatusCb.SelectedItem.ToString() + "', Booked='" + roomBooked + "' where RoomNum = " + RoomNumbTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room Successfully Updated");

                    Con.Close();
                    // Refresh the DataGridView after updating a room
                    FillRoomDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoomNumbTb.Text == "")
                {
                    MessageBox.Show("Enter The Room Number");
                }
                else
                {
                    // Determine if the room is booked or free based on the radio button
                    string roomBooked = YesRadio.Checked ? "Busy" : "Free";

                    Con.Open();

                    // Delete room query
                    string query = "DELETE FROM Room_tbl WHERE RoomNum = @RoomNum";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@RoomNum", RoomNumbTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room Successfully Deleted");

                    Con.Close();

                    // Refresh the DataGridView after deleting the room
                    FillRoomDGV();
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
        
                Application.Exit();
            
        }
        

        private void Rooms_Load(object sender, EventArgs e)
        {
            FillRoomDGV();
        }

        private void RoomDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked row is valid
            if (e.RowIndex >= 0 && e.RowIndex < RoomDGV.Rows.Count)
            {
                RoomNumbTb.Text = RoomDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
              
                // Assuming UsnCb is a ComboBox
                string selectedstatus = RoomDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();

                // Check if the selected value is not null before assigning
                if (selectedstatus != null)
                {
                    RoomStatusCb.SelectedValue = selectedstatus;
                }
            }
        }
    }
}
