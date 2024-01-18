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
            Con.Open();
            string myquery = "Select * from Room_tbl";
            SqlDataAdapter da = new SqlDataAdapter(myquery, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            da.Fill(ds);
            RoomDGV.DataSource = ds.Tables[0];
            Con.Close();
            
        }

        string RoomBooked;
        private void button7_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The Room Number");
            }
            else
            {
                if (YesRadio.Checked == true)
                    RoomBooked = "busy";
                else
                    RoomBooked = "Free";
                Con.Open();
                string query = "insert into Room_tbl values(" + textBox1.Text + ",'" + RoomStatusCb.SelectedItem.ToString() + "','" + RoomBooked + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Room Successfully Added");

                Con.Close();
                FillRoomDGV();
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The Room Number");
            }
            else
            {
                if (YesRadio.Checked == true)
                    RoomBooked = "busy";
                else
                    RoomBooked = "Free";
                Con.Open();
                string query = "update Room_tbl set RoomStatus='"+RoomStatusCb.SelectedItem.ToString()+ "',Booked'" + RoomBooked + "' where RoomNum = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Room Successfully Updated");

                Con.Close();
                FillRoomDGV();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter The Room Number");
            }
            else
            {
                if (YesRadio.Checked == true)
                    RoomBooked = "busy";
                else
                    RoomBooked = "Free";
                Con.Open();
                string query = "delete from Room_tbl where RoomNum= " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Room Successfully Deleted");

                Con.Close();
                FillRoomDGV();
            }
        }

     

        private void RoomNumber_Click(object sender, EventArgs e)
        {

        }


        private void RoomStatusCb_SelectedIndexChanged(object sender, EventArgs e)
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

        private void RoomDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = RoomDGV.SelectedRows[0].Cells[0].Value.ToString();
            FillRoomDGV();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            FillRoomDGV();
        }
    }
}
