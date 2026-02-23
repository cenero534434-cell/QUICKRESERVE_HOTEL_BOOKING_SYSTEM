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

namespace Hotel_Booking___Reservation_03
{
    public partial class Booked : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Booked()
        {
            InitializeComponent();
            LoadCheckOutData();
            txtSearch.TextChanged += txtSearch_TextChanged;

        }

        private void OpenBookedActionForm()
        {
            Booked_Action_Form actionForm = new Booked_Action_Form();

            // Subscribe to the event to automatically refresh the DataGridView in the Booked form
            actionForm.bookedAdded += () =>
            {
                LoadCheckOutData(); // Reload data when the booking is added
            };

            actionForm.ShowDialog();
        }

        private void LoadCheckOutData(string searchKeyword = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM booked";
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
                            dtgBooked.DataSource = dt;

                            // Add the Action column if it doesn't exist
                            if (!dtgBooked.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgBooked.Columns.Add(actionColumn);
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

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Check_Out checkOutForm = new Check_Out();
            checkOutForm.Show();
            this.Hide();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRoomList_Click(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Booked_Action_Form loginForm = new Booked_Action_Form();
            loginForm.Show();

        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadCheckOutData(searchKeyword);
        }

        private void dtgBooked_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.ColumnIndex == dtgBooked.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    int id = Convert.ToInt32(dtgBooked.Rows[e.RowIndex].Cells["id"].Value);
                    Booked_Add_Booking actionForm = new Booked_Add_Booking(id);
                    actionForm.ShowDialog();
                    LoadCheckOutData();
                }
            }
        }

        private void Booked_Load(object sender, EventArgs e)
        {
            LoadCheckOutData();
        }
    }


   
    
    }
    

