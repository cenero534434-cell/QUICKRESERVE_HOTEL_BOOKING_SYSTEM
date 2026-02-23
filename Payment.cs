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
    public partial class Payment : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";

        public Payment()
        {
            InitializeComponent();
            LoadPaymentData();
        }


        
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void label4_Click(object sender, EventArgs e)
        {
            Booked bookedForm = new Booked();
            bookedForm.Show();
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

        private void Payment_Load(object sender, EventArgs e)
        {
            LoadPaymentData();
        }

        private void LoadPaymentData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to select all data from the 'payment' table
                    string query = "SELECT Reference, Reservation_Booked_Date, NoOfRoom, Payment, DaysOfStay FROM payment";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Add a 'Total' column programmatically to the DataTable
                        if (!dt.Columns.Contains("Total"))
                        {
                            dt.Columns.Add("Total", typeof(decimal));
                        }

                        // Calculate the Total for each row
                        foreach (DataRow row in dt.Rows)
                        {
                            int noOfRoom = Convert.ToInt32(row["NoOfRoom"]);
                            decimal payment = Convert.ToDecimal(row["Payment"]);
                            int noOfStay = Convert.ToInt32(row["DaysOfStay"]);

                            // Formula: Total = NoOfRoom * Payment * NoOfStay
                            row["Total"] = noOfRoom * payment * noOfStay;
                        }

                        // Bind the updated DataTable to the DataGridView
                        dtgPayment.DataSource = dt;

                        // Set DataGridView properties for better display
                        dtgPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Format the 'Total' column explicitly to display in Philippine Peso
                        dtgPayment.Columns["Total"].HeaderText = "Total Amount";
                        dtgPayment.Columns["Total"].DefaultCellStyle.Format = "C2"; // Currency format
                        dtgPayment.Columns["Total"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-PH");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payment data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadPaymentData();

        }
    }
}
