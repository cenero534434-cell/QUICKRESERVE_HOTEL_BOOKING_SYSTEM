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
    public partial class Reservation : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";

        public Reservation()
        {
            InitializeComponent();
            LoadReservationData();
            txtSearch.TextChanged += TxtSearch_TextChanged;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void LoadReservationData(string searchKeyword = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, NoOfRoom, Reference FROM reservation";

                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query += " WHERE Category LIKE @keyword OR NoOfRoom LIKE @keyword OR Reference LIKE @keyword";
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
                            dtgReservation.DataSource = dt;

                           
                            if (!dtgReservation.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgReservation.Columns.Add(actionColumn);
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





        private void button1_Click(object sender, EventArgs e)
        {
            {
                Reservation_AddReserve addreserveForm = new Reservation_AddReserve();
                addreserveForm.ReservationAdded += AddreserveForm_ReservationAdded;  
                addreserveForm.Show();
            }

        }

        private void AddreserveForm_ReservationAdded()
        {
            LoadReservationData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadReservationData(searchKeyword);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadReservationData(searchKeyword);
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            LoadReservationData();
            int reference = GetNextReferenceNumber();

            txtReference.Text = reference.ToString("D6");


        }


        private int GetNextReferenceNumber()
        {
            int reference = 1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MAX(reference) FROM reservation";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            reference = Convert.ToInt32(result) + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting next reference: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return reference;
        }


        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard ReservationForm = new Dashboard();
            ReservationForm.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadReservationData();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void dtgReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.ColumnIndex == dtgReservation.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dtgReservation.Rows[e.RowIndex].Cells["id"].Value);
                Reservation_ActionForm actionForm = new Reservation_ActionForm(id);
                actionForm.ShowDialog();
                LoadReservationData();
            }
        }


        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadReservationData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btndashboard_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();

        }

        private void btnbooked_Click(object sender, EventArgs e)
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

        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            Check_Out checkOutForm = new Check_Out();
            checkOutForm.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {
            Reservation_Hall HallForm = new Reservation_Hall();
            HallForm.Show();
           this.Hide();        
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

       private void btnSave_Click(object sender, EventArgs e)
         {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtReference.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) || string.IsNullOrWhiteSpace(txtRoom.Text) ||
                string.IsNullOrWhiteSpace(dtpReservationDate.Text) || string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtDaysOfStay.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string name = txtName.Text.Trim();
            int reference = int.Parse(txtReference.Text.Trim());
            string category = txtCategory.Text.Trim();
            string noOfRoom = txtRoom.Text.Trim();

            DateTime reservationDate;
            if (!DateTime.TryParse(dtpReservationDate.Text.Trim(), out reservationDate))
            {
                MessageBox.Show("Invalid reservation date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contact = txtContact.Text.Trim();

           
            int daysOfStay;
            if (!int.TryParse(txtDaysOfStay.Text.Trim(), out daysOfStay))
            {
                MessageBox.Show("Invalid number of days of stay.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount))
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AddReservation(name, reference, category, noOfRoom, reservationDate, contact, daysOfStay, amount))
            {
                MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();

           
                LoadReservationData();
            }
            else
            {
                MessageBox.Show("Failed to add reservation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AddReservation(string name, int reference, string category, string noOfRoom, DateTime reservationDate, string contact, int daysOfStay, decimal amount)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                   
                    string reservationQuery = "INSERT INTO reservation (name, reference, category, NoOfRoom, daysOfStay, reservationdate, contact, amount) " +
                                              "VALUES (@name, @reference, @category, @noOfRoom, @daysOfStay, @reservationdate, @contact, @amount)";
                    using (MySqlCommand cmd1 = new MySqlCommand(reservationQuery, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@name", name);
                        cmd1.Parameters.AddWithValue("@reference", reference);
                        cmd1.Parameters.AddWithValue("@category", category);
                        cmd1.Parameters.AddWithValue("@noOfRoom", noOfRoom);
                        cmd1.Parameters.AddWithValue("@daysOfStay", daysOfStay);
                        cmd1.Parameters.AddWithValue("@reservationdate", reservationDate.ToString("yyyy-MM-dd")); 
                        cmd1.Parameters.AddWithValue("@contact", contact);
                        cmd1.Parameters.AddWithValue("@amount", amount);
                        cmd1.ExecuteNonQuery();
                    }

                    string paymentQuery = "INSERT INTO payment (Reference, Reservation_Booked_Date, NoOfRoom, DaysofStay, Payment) " +
                                          "VALUES (@reference, @reservationdate, @noOfRoom, @daysofstay, @amount)";
                    using (MySqlCommand cmd2 = new MySqlCommand(paymentQuery, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@reference", reference);
                        cmd2.Parameters.AddWithValue("@reservationdate", reservationDate.ToString("yyyy-MM-dd")); 
                        cmd2.Parameters.AddWithValue("@noOfRoom", noOfRoom);
                        cmd2.Parameters.AddWithValue("@daysofstay", daysOfStay);
                        cmd2.Parameters.AddWithValue("@amount", amount);
                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    
                    transaction?.Rollback();
                    MessageBox.Show("Error adding reservation" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }



        private void ClearFields()
        {
            txtName.Clear();
            txtReference.Clear();
            txtCategory.SelectedIndex = -1;
            txtRoom.Clear();
            txtContact.Clear();
            txtDaysOfStay.Clear();
            txtAmount.Clear();
            dtpReservationDate.Value = DateTime.Now;
        }

        private void txtReference_TextChanged(object sender, EventArgs e)
        {

        }
    }
}