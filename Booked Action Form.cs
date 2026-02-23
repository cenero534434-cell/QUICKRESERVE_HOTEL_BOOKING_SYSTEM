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
    public partial class Booked_Action_Form : Form
    {

        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private int reservationId;
        public Booked_Action_Form()
        {
            InitializeComponent();
            LoadAvailableRoomData();
            LoadRoomTypeFilter();
        }

        private int GetNextReferenceNumber()
        {
            int reference = 200001; // Start from 200001
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MAX(reference) FROM booked";
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
                    MessageBox.Show("Error getting next reference: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return reference;
        }

        private void Booked_Action_Form_Load(object sender, EventArgs e)
        {
            int reference = GetNextReferenceNumber();
            txtReference.Text = reference.ToString(); // Display the reference number
            LoadAvailableRoomData();
            LoadRoomTypeFilter();

            foreach (DataGridViewRow row in dtgAvailableRoom.Rows)
            {
                if (row.Cells["Availability"].Value != null && row.Cells["Availability"].Value.ToString() == "Unavailable")
                {
                    row.Cells["Availability"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void LoadAvailableRoomData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Room_Number, Room_Type, Availability FROM available_room";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgAvailableRoom.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRoomTypeFilter()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Room_Type FROM available_room";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbSearch.Items.Clear();
                            while (reader.Read())
                            {
                                cmbSearch.Items.Add(reader["Room_Type"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public event Action bookedAdded;
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
          
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
        }



        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewRoom.Text))
            {
                MessageBox.Show("Please choose room before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Insert data into 'booked' table
                    string insertBookedQuery = "INSERT INTO booked (Name, Reference, Category, NoOfRoom, BookedDate, DaysOfStay, Amount, Contact, Room) " +
                                               "VALUES (@name, @reference, @category, @noOfRoom, @bookedDate, @daysOfStay, @amount, @contact, @room)";
                    using (MySqlCommand cmd = new MySqlCommand(insertBookedQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                        cmd.Parameters.AddWithValue("@noOfRoom", txtRoom.Text);
                        cmd.Parameters.AddWithValue("@bookedDate", dtpReservationDate.Text);
                        cmd.Parameters.AddWithValue("@daysOfStay", txtDaysOfStay.Text);
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@room", txtNewRoom.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert data into 'payment' table
                    string insertPaymentQuery = "INSERT INTO payment (Reference, Reservation_Booked_Date, DaysOfStay, NoOfRoom, Payment) " +
                             "VALUES (@reference, @reservationbookedDate, @noOfRoom, @daysofstay, @payment)";
                    using (MySqlCommand paymentCmd = new MySqlCommand(insertPaymentQuery, conn))
                    {
                        paymentCmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        paymentCmd.Parameters.AddWithValue("@reservationbookedDate", dtpReservationDate.Text);
                        paymentCmd.Parameters.AddWithValue("@noOfRoom", txtRoom.Text);
                        paymentCmd.Parameters.AddWithValue("@payment", txtAmount.Text);
                        paymentCmd.Parameters.AddWithValue("@daysofstay", txtDaysOfStay.Text);
                        paymentCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Booked saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Trigger the event to update the DataGrid in the Booked form
                    bookedAdded?.Invoke();

                    // Refresh the DataGrid to show new booking
                    LoadAvailableRoomData();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding booking: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dtgAvailableRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgAvailableRoom.Rows[e.RowIndex];

                if (row.Cells["Availability"].Value.ToString() == "Unavailable")
                {
                    MessageBox.Show("This room is not available. Please choose another room.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtNewRoom.Text = row.Cells["Room_Number"].Value.ToString();

                UpdateRoomAvailability(row.Cells["id"].Value.ToString(), "Unavailable");

                row.Cells["Availability"].Style.ForeColor = Color.Red;
                row.Cells["Availability"].Value = "Unavailable";
            }
        }

        private void UpdateRoomAvailability(string roomId, string status)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE available_room SET Availability = @availability WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@availability", status);
                        cmd.Parameters.AddWithValue("@id", roomId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating room availability: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM available_room WHERE Room_Type = @roomType";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@roomType", cmbSearch.SelectedItem.ToString());
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgAvailableRoom.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
