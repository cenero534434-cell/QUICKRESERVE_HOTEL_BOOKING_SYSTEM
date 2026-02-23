using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Booking___Reservation_03
{
    public partial class Check_Out : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Check_Out()
        {
            InitializeComponent();
            LoadCheckOutData();
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadCheckOutData(string searchKeyword = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM checkout";

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
                            dtgCheckOut.DataSource = dt;

                            if (!dtgCheckOut.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgCheckOut.Columns.Add(actionColumn);
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


        private void LoadCheckOutData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM checkout";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgCheckOut.DataSource = dt;

                            if (!dtgCheckOut.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgCheckOut.Columns.Add(actionColumn);
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

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
            this.Hide();

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Check_In checkInForm = new Check_In();
            checkInForm.Show();
            this.Hide();

        }

        private void btnRoomList_Click(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            Staff_Management manageuserForm = new Staff_Management();
            manageuserForm.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dtgCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.ColumnIndex == dtgCheckOut.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    int id = Convert.ToInt32(dtgCheckOut.Rows[e.RowIndex].Cells["id"].Value);
                    Check_Out_Action_Form actionForm = new Check_Out_Action_Form(id);
                    actionForm.ShowDialog();
                    LoadCheckOutData();
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadCheckOutData(searchKeyword);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadCheckOutData(searchKeyword);
        }

        private void Check_Out_Load(object sender, EventArgs e)
        {
            LoadCheckOutData();
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

        private void btnCheckIn_Click_1(object sender, EventArgs e)
        {
            Check_In checkInForm = new Check_In();
            checkInForm.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Logout_Click_1(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();

        }
    }
}
