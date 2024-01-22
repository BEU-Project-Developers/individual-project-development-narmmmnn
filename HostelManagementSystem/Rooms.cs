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


        void FillRoomDGV()
        {

            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string myquery = "Select * from Room_tbl";
            SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(); // SqlCommandBuilder is used to automatically generate SQL commands for updating the database
            var ds = new DataSet();
            da.Fill(ds);
            // Set the DataGridView's data source to the retrieved dataset
            RoomDGV.DataSource = ds.Tables[0];
            Con.Close();


        }



        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoomNumbTb.Text == "" || RoomStatusCb.SelectedItem == null)
                {
                    MessageBox.Show("Enter Room Number and Select Room Status");
                }
                else
                {
                    // Determine if the room is booked or free based on the radio button
                    string roomBooked = YesRadio.Checked ? "Busy" : "Free";
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    // SQL query to insert a new room into Room_tbl
                    string query = "INSERT INTO Room_tbl (RoomNum, RoomStatus, Booked) VALUES (@RoomNum, @RoomStatus, @Booked)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Add parameters to the SqlCommand
                    cmd.Parameters.AddWithValue("@RoomNum", RoomNumbTb.Text);
                    cmd.Parameters.AddWithValue("@RoomStatus", RoomStatusCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Booked", roomBooked);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room Successfully Added");

                    Con.Close();
                    FillRoomDGV();
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


        private void button6_Click(object sender, EventArgs e)// Updating an existing room
        {
            try
            {
                if (RoomNumbTb.Text == "")
                {
                    MessageBox.Show("Enter The Room Number");
                }
                else
                {
                    string roomBooked = YesRadio.Checked ? "Busy" : "Free";

                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
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
            finally
            {

                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
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

        private void button5_Click(object sender, EventArgs e)// Deleting an existing room
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

                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string query = "DELETE FROM Room_tbl WHERE RoomNum = @RoomNum";

                    SqlCommand cmd = new SqlCommand(query, Con); // Create SqlCommand Object to execute and retrieve single value
                    cmd.Parameters.AddWithValue("@RoomNum", RoomNumbTb.Text); // used for replace roomnum placeholder, the value is  RoomNumbTb.Text

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room Successfully Deleted");

                    Con.Close();
                    FillRoomDGV();
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
                // the null-conditional operator (?.) to safely access the ToString
                RoomNumbTb.Text = RoomDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();

                string selectedstatus = RoomDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                RoomStatusCb.SelectedItem = selectedstatus;

            }
        }
    }
}
