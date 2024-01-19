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
                Con.Close();
            }
        }
        void FillRoomCombobox()
        {
            try
            {
                Con.Open();
                string query = "Select * from Room_tbl where RoomStatus = '"+"Active"+"' and Booked = '"+"Free"+"' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataReader rdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("RoomNum", typeof(int));
                dt.Load(rdr);

                StudRoomCb.ValueMember = "RoomNum";
                StudRoomCb.DataSource = dt;
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
            try
            {
                if (StudUSN.Text == "")
                {
                    MessageBox.Show("Enter The Student Number");
                }
                else
                {
                    Con.Open();
                    string query = "update Student_tbl set StdName='" + StudName.Text + "',FatherName='" + FatherName.Text + "' ,MotherName='" + MotherName.Text + "' ,StdAddress='" + AddressTb.Text + "' ,College='" + CollegeTb.Text + "' ,StdRoom=" + StudRoomCb.SelectedValue.ToString() + " ,StdStatus='" + StudStatusCb.SelectedValue.ToString() + "'where StdUsn = '" + StudUSN.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Successfully Updated");

                    Con.Close();
                    FillStudentDGV();
                    FillRoomCombobox();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            try
            {
                if (StudUSN.Text == "" || StudName.Text == "" || FatherName.Text == "" || MotherName.Text == "" || AddressTb.Text == "" || CollegeTb.Text == "")
                {
                    MessageBox.Show("No Empty Filled Accepted");
                }
                else
                {
                    Con.Open();

                    // Check if StudRoomCb.SelectedValue is not null before using it
                    string roomValue = StudRoomCb.SelectedValue != null ? StudRoomCb.SelectedValue.ToString() : "";

                    string query = "insert into Student_tbl values('" + StudUSN.Text + "','" + StudName.Text + "','" + FatherName.Text + "','" + MotherName.Text + "','" + AddressTb.Text + "','" + CollegeTb.Text + "','" + roomValue + "','" + StudStatusCb.SelectedItem?.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Successfully Added");

                    Con.Close();
                    FillStudentDGV();
                    FillRoomCombobox();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                    string query = "DELETE FROM Student_tbl WHERE StdUsn = '" + StudUSN.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Info Successfully Deleted");

                    Con.Close();
                    updateBookedStatusOnDelete();
                    FillStudentDGV();
                    FillRoomCombobox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            String query = "update Room_tbl set Booked='" + "Free" + "' where RoomNum=" + StudRoomCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Room successfully Updated!");
            Con.Close();
        }
        void updateBookedStatus()
        {
            Con.Open();
            String query = "update Room_tbl set Booked='" + "busy" + "' where RoomNum=" + StudRoomCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            // MessageBox.Show("Room successfully Updated!");
            Con.Close();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void StudentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudUSN.Text = StudentDGV.SelectedRows[0].Cells[0].Value.ToString();
            StudName.Text = StudentDGV.SelectedRows[0].Cells[1].Value.ToString();
            FatherName.Text = StudentDGV.SelectedRows[0].Cells[2].Value.ToString();
            MotherName.Text = StudentDGV.SelectedRows[0].Cells[3].Value.ToString();
            AddressTb.Text = StudentDGV.SelectedRows[0].Cells[4].Value.ToString();
            CollegeTb.Text = StudentDGV.SelectedRows[0].Cells[5].Value.ToString();
            
        }
    }
}
