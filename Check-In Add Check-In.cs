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

    public partial class CheckIn_AddCheckIn : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public CheckIn_AddCheckIn()
        {
            InitializeComponent();
        }

        private void CheckIn_AddCheckIn_Load(object sender, EventArgs e)
        {
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            int reference = int.Parse(txtReference.Text.Trim());
            string category = txtCategory.Text.Trim();
            string room = txtRoom.Text.Trim();
            string noofroom = txtRoomQuantity.Text.Trim();
            string checkInDate = dtpReservationDate.Text.Trim();
            string contact = txtContact.Text.Trim();
            int daysOfStay = int.Parse(txtDaysOfStay.Text.Trim());
            decimal amount = decimal.Parse(txtAmount.Text.Trim());

            if (AddReservation(name, reference,noofroom, category, room, checkInDate, contact, daysOfStay, amount))
            {
                MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();

            }
        }

        private bool AddReservation(string name, int reference, string category, string noofroom, string room, string reservationDate, string contact, int daysOfStay, decimal amount)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO checkIn (name, reference, category, noofroom, room, checkindate, contact, daysofstay, amount) " +
                                   "VALUES (@name, @reference, @category, @room, @noofroom, @checkindate, @contact, @daysofstay, @amount)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@reference", reference);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@room", room);
                        cmd.Parameters.AddWithValue("@checkindate", reservationDate);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@daysofstay", daysOfStay);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@noofroom", noofroom);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtRoomQuantity.Clear();
            txtAmount.Clear();
            dtpReservationDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

                txtRoom.Text = row.Cells["Room_Number"].Value.ToString();

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
