using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Hotel_Booking___Reservation_03
{
    public partial class Check_In : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Check_In()
        {
            InitializeComponent();
            LoadCheckInData();
            txtSearch.TextChanged += TxtSearch_TextChanged;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadCheckInData(string searchKeyword = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM checkin";

                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query += " WHERE Category LIKE @keyword OR Room LIKE @keyword OR Reference LIKE @keyword";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchKeyword))
                        {
                            cmd.Parameters.AddWithValue("@keyword", $"%{searchKeyword}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgCheckIn.DataSource = dt;

                            if (!dtgCheckIn.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgCheckIn.Columns.Add(actionColumn);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoadCheckInData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM checkin";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgCheckIn.DataSource = dt;

                           
                            if (!dtgCheckIn.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgCheckIn.Columns.Add(actionColumn);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckIn_AddCheckIn addcheckInForm = new CheckIn_AddCheckIn();
            addcheckInForm.Show();
        }


        private void Check_In_Load(object sender, EventArgs e)
        {
            LoadCheckInData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            Staff_Management manageuserForm = new Staff_Management();
            manageuserForm.Show();
            this.Hide();

        }

        private void btnRoomList_Click(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Check_Out checkOutForm = new Check_Out();
            checkOutForm.Show();
            this.Hide();

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
            this.Hide();

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadCheckInData(searchKeyword);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadCheckInData(searchKeyword);
        }

        private void dtgCheckIn_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgCheckIn.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dtgCheckIn.Rows[e.RowIndex].Cells["id"].Value);
                Check_In_Action_Form actionForm = new Check_In_Action_Form(id);
                actionForm.ShowDialog();
                LoadCheckInData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCheckInData();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();
        }

        private void btndashboard_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();

        }

        private void btnReservation_Click_1(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Booked bookedForm = new Booked();
            bookedForm.Show();
            this.Hide();

        }

        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            Check_Out checkOutForm = new Check_Out();
            checkOutForm.Show();
            this.Hide();

        }

        private void btnRoomList_Click_1(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();

        }

        private void btnManageUser_Click_1(object sender, EventArgs e)
        {
            Staff_Management manageuserForm = new Staff_Management();
            manageuserForm.Show();
            this.Hide();


        }

        private void Logout_Click_1(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();

        }
    }
}
