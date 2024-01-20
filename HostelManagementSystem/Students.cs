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
            try
            {
                Con.Open();
                string myquery = "SELECT * FROM Student_tbl";
                SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
                var ds = new DataSet();
                da.Fill(ds);
                StudentDGV.DataSource = ds.Tables[0];
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



        void FillRoomCombobox()
        {
            
                Con.Open();
                string query = "Select * from Room_tbl ";
                SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("RoomNum", typeof(int));
                dt.Load(rdr);
            // Set the ValueMember and DisplayMember properties
                StudRoomCb.ValueMember = "RoomNum"; 
                StudRoomCb.DisplayMember = "RoomNum";

            // Set the DataSource property to the DataTable
            StudRoomCb.DataSource = dt;

            Con.Close();
            
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 Home = new Form1();
            Home.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {


                if (StudUSN.Text == "")
                {
                    MessageBox.Show("Enter The Student Number");
                }
                else
                {
                    
                    Con.Open();
                    string query = "update Student_tbl set StdName='" + StudName.Text + "',FatherName='" + FatherName.Text + "' ,MotherName='" + MotherName.Text + "' ,StdAddress='" + AddressTb.Text + "' ,College='" + CollegeTb.Text + "' ,StdRoom= " + StudRoomCb.SelectedValue.ToString() + " ,StdStatus='" + StudStatusCb.SelectedItem.ToString() + "'where StdUsn = '" + StudUSN.Text + "' ";
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
    

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (StudUSN.Text == "" || StudName.Text == "" || FatherName.Text == "" || MotherName.Text == "" || AddressTb.Text == "" || CollegeTb.Text == "")
            {
                MessageBox.Show("No Empty Filled Accepted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO Student_tbl VALUES (@StdUSN, @StdName, @FatherName, @MotherName, @StdAddress, @College, @StdRoom, @StdStatus)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Use parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@StdUSN", StudUSN.Text);
                    cmd.Parameters.AddWithValue("@StdName", StudName.Text);
                    cmd.Parameters.AddWithValue("@FatherName", FatherName.Text);
                    cmd.Parameters.AddWithValue("@MotherName", MotherName.Text);
                    cmd.Parameters.AddWithValue("@StdAddress", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@College", CollegeTb.Text);
                    cmd.Parameters.AddWithValue("@StdRoom", StudRoomCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@StdStatus", StudStatusCb.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Successfully Added");

                    Con.Close();

                    updateBookedStatus();
                    updateBookedStatusOnDelete();
                    FillStudentDGV();
                    FillRoomCombobox();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void button11_Click(object sender, EventArgs e)
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Students_Load(object sender, EventArgs e)
        {
            FillStudentDGV();
            FillRoomCombobox();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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
        void updateBookedStatusOnDelete()
        {
            Con.Open();
            string studStatus = StudStatusCb.SelectedItem?.ToString();

            if (studStatus == "Left")
            {
                String query = "update Room_tbl set Booked='" + "Free" + "' where RoomNum=" + StudRoomCb.SelectedValue?.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
            }
            // Add more conditions if needed

            Con.Close();
        }

        void updateBookedStatus()
        {
            Con.Open();
            string studStatus = StudStatusCb.SelectedItem?.ToString();

            if (studStatus == "Living")
            {
                String query = "update Room_tbl set Booked='" + "busy" + "' where RoomNum=" + StudRoomCb.SelectedValue?.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
            }
            // Add more conditions if needed

            Con.Close();
        }
        

        private void StudStatusCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudStatusCb.SelectedItem != null)
            {
                string selectedStatus = StudStatusCb.SelectedItem.ToString();
                updateBookedStatus();
                updateBookedStatusOnDelete();
            }
        }

        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < StudentDGV.Rows.Count && StudentDGV.SelectedRows.Count > 0)
            {
                StudUSN.Text = StudentDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                StudName.Text = StudentDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                FatherName.Text = StudentDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                MotherName.Text = StudentDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                AddressTb.Text = StudentDGV.Rows[e.RowIndex].Cells[4].Value?.ToString();
                CollegeTb.Text = StudentDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();

                // Assuming the columns for StudRoom and StudStatus are at index 6 and 7
                string selectedRoomNum = StudentDGV.Rows[e.RowIndex].Cells[6].Value?.ToString();
                StudRoomCb.SelectedValue = selectedRoomNum;
                StudStatusCb.SelectedItem = StudentDGV.Rows[e.RowIndex].Cells[7].Value?.ToString();

                // Update the Booked status in Room_tbl based on StudStatusCb
                updateBookedStatus();
                updateBookedStatusOnDelete();

                
            }
        }


    }
}
