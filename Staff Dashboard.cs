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
    public partial class UserDashboard : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public UserDashboard()
        {
            InitializeComponent();
            LoadReservationData();
            txtSearch.TextChanged += txtSearch_TextChanged;
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

                            // Add "Action" button column if not already added
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



        private void LoadReservationData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, NoOfRoom, Reference FROM reservation";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
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
                    MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btndashboard_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void DisplayNextReference()
        {
            int reference = GetNextReferenceNumber();
            txtReference.Text = reference.ToString("D6"); // Format as 6 digits (e.g., 000001)
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtReference.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) || string.IsNullOrWhiteSpace(txtRoom.Text) ||
                string.IsNullOrWhiteSpace(dtpReservationDate.Text) || string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtDaysOfStay.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if any field is empty
            }

            string name = txtName.Text.Trim();
            int reference = int.Parse(txtReference.Text.Trim());
            string category = txtCategory.Text.Trim();
            string noOfRoom = txtRoom.Text.Trim();

            // Ensure reservationDate is handled correctly as DateTime
            DateTime reservationDate;
            if (!DateTime.TryParse(dtpReservationDate.Text.Trim(), out reservationDate))
            {
                MessageBox.Show("Invalid reservation date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contact = txtContact.Text.Trim();

            // Ensure daysOfStay is an integer
            int daysOfStay;
            if (!int.TryParse(txtDaysOfStay.Text.Trim(), out daysOfStay))
            {
                MessageBox.Show("Invalid number of days of stay.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure amount is a decimal
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

                // Refresh the DataGridView after saving
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

                    // First query: Insert into 'reservation'
                    string reservationQuery = "INSERT INTO reservation (name, reference, category, NoOfRoom, daysOfStay, reservationdate, contact, amount) " +
                                              "VALUES (@name, @reference, @category, @noOfRoom, @daysOfStay, @reservationdate, @contact, @amount)";
                    using (MySqlCommand cmd1 = new MySqlCommand(reservationQuery, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@name", name);
                        cmd1.Parameters.AddWithValue("@reference", reference);
                        cmd1.Parameters.AddWithValue("@category", category);
                        cmd1.Parameters.AddWithValue("@noOfRoom", noOfRoom);
                        cmd1.Parameters.AddWithValue("@daysOfStay", daysOfStay);
                        cmd1.Parameters.AddWithValue("@reservationdate", reservationDate.ToString("yyyy-MM-dd")); // Ensure correct date format
                        cmd1.Parameters.AddWithValue("@contact", contact);
                        cmd1.Parameters.AddWithValue("@amount", amount);
                        cmd1.ExecuteNonQuery();
                    }

                    // Second query: Insert into 'payment'
                    string paymentQuery = "INSERT INTO payment (Reference, Reservation_Booked_Date, NoOfRoom, DaysofStay, Payment) " +
                                          "VALUES (@reference, @reservationdate, @noOfRoom, @daysofstay, @amount)";
                    using (MySqlCommand cmd2 = new MySqlCommand(paymentQuery, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@reference", reference);
                        cmd2.Parameters.AddWithValue("@reservationdate", reservationDate.ToString("yyyy-MM-dd")); // Ensure correct date format
                        cmd2.Parameters.AddWithValue("@noOfRoom", noOfRoom);
                        cmd2.Parameters.AddWithValue("@daysofstay", daysOfStay);
                        cmd2.Parameters.AddWithValue("@amount", amount);
                        cmd2.ExecuteNonQuery();
                    }

                    // Commit transaction if both queries succeed
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback transaction if any query fails
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadReservationData(searchKeyword);
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            LoadReservationData();
            int reference = GetNextReferenceNumber();

            txtReference.Text = reference.ToString("D6");
        }

        private void AddreserveForm_ReservationAdded()
        {
            LoadReservationData();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Staff_Reservation_Hall ReservationForm = new Staff_Reservation_Hall();
            ReservationForm.Show();
            this.Hide();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
           Staff_Check_in ReservationForm = new Staff_Check_in();
            ReservationForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Staff_Check_out ReservationForm = new Staff_Check_out();
            ReservationForm.Show();
            this.Hide();
        }
    }
}
