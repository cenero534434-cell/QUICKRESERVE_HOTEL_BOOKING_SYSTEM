using MySql.Data.MySqlClient;
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
using System.Xml.Linq;

namespace Hotel_Booking___Reservation_03
{
    public partial class Reservation_ActionForm : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private int reservationId;
        public Reservation_ActionForm(int id)
        {
            InitializeComponent();
            reservationId = id;
            LoadReservationDetails();
            LoadAvailableRoomData();
            LoadRoomTypeFilter();
        }

        private void Reservation_ActionForm_Load(object sender, EventArgs e)
        {
            LoadReservationDetails();
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

        private void LoadReservationDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM reservation WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", reservationId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtCategory.Text = reader["Category"].ToString();
                                txtRoom.Text = reader["NoOfRoom"].ToString();
                                txtReference.Text = reader["Reference"].ToString();
                                dtpReservationDate.Text = reader["ReservationDate"].ToString();
                                txtContact.Text = reader["Contact"].ToString();
                                txtDaysOfStay.Text = reader["DaysOfStay"].ToString();
                                txtAmount.Text = reader["Amount"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE reservation SET Name = @name, Category = @category, NoOfRoom = @room, Reference = @reference, ReservationDate = @reservationdate, DaysOfStay = @daysofstay, Amount = @amount, Contact = @contact WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                        cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        cmd.Parameters.AddWithValue("@reservationdate", dtpReservationDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@daysofstay", txtDaysOfStay.Text);
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@id", reservationId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string archiveQuery = "INSERT INTO archive_reservation (id, Name, Category, NoOfRoom, Reference, DaysOfStay, ReservationDate, Contact, Amount) SELECT id, Name, Category, NoOfRoom, Reference, DaysOfStay, ReservationDate, Contact, Amount FROM reservation WHERE id = @id";
                    using (MySqlCommand archiveCmd = new MySqlCommand(archiveQuery, conn))
                    {
                        archiveCmd.Parameters.AddWithValue("@id", reservationId);
                        archiveCmd.ExecuteNonQuery();
                    }

                    string deleteQuery = "DELETE FROM reservation WHERE id = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", reservationId);
                        deleteCmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the room field is empty
            if (string.IsNullOrEmpty(txtNewRoom.Text))
            {
                MessageBox.Show("Please choose room before checking in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if the room is not selected
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Insert check-in data
                    string insertQuery = "INSERT INTO checkin (Name, Reference, Category, NoOfRoom, ReservationDate, DaysOfStay, Amount, Contact, Room, CheckInDate) " +
                                         "VALUES (@name, @reference, @category, @noOfRoom, @reservationDate, @daysOfStay, @amount, @contact, @room, @checkInDate)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                        cmd.Parameters.AddWithValue("@noOfRoom", txtRoom.Text);
                        cmd.Parameters.AddWithValue("@reservationDate", dtpReservationDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@daysOfStay", txtDaysOfStay.Text);
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@room", txtNewRoom.Text);
                        cmd.Parameters.AddWithValue("@checkInDate", dtpCheckIn.Value.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }

                    // Delete reservation data
                    string deleteQuery = "DELETE FROM reservation WHERE id = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", reservationId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Check-in completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during check-in: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ClearForm()
        {
            txtName.Clear();
            txtReference.Clear();
            txtCategory.SelectedIndex = -1;
            txtRoom.Clear();
            txtContact.Clear();
            txtDaysOfStay.Clear();
            txtAmount.Clear();
            txtNewRoom.Clear();
            dtpCheckIn.Value = DateTime.Now;
            dtpReservationDate.Value = DateTime.Now;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpReservationDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

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
    }
}


