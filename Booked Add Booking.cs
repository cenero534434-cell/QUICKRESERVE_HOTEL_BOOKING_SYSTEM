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
    public partial class Booked_Add_Booking : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private int bookedId;
        public Booked_Add_Booking(int id)
        {
            InitializeComponent();
            bookedId = id;
            LoadCheckOutDetails();

        }


        private void LoadCheckOutDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM booked WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", bookedId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtCategory.Text = reader["Category"].ToString();
                                txtRoom.Text = reader["NoOfRoom"].ToString();
                                txtReference.Text = reader["Reference"].ToString();
                                dtpReservationDate.Text = reader["BookedDate"].ToString();
                                txtContact.Text = reader["Contact"].ToString();
                                txtDaysOfStay.Text = reader["DaysOfStay"].ToString();
                                txtAmount.Text = reader["Amount"].ToString();
                                txtNewRoom.Text = reader["Room"].ToString();

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
        }

       
        private void Booked_Add_Booking_Load(object sender, EventArgs e)

        {
           
        }

      


        private void dtgAvailableRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL Update query
                    string query = "UPDATE booked SET Name = @name, Category = @category, NoOfRoom = @noofroom, Reference = @reference, " +
                                   "BookedDate = @bookeddate, DaysOfStay = @daysofstay, Amount = @amount, Contact = @contact, Room = @room " +
                                   "WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@noofroom", txtRoom.Text.Trim());
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text.Trim());
                        cmd.Parameters.AddWithValue("@bookeddate", dtpReservationDate.Text.Trim());
                        cmd.Parameters.AddWithValue("@daysofstay", txtDaysOfStay.Text.Trim());
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@room", txtNewRoom.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", bookedId); // Add the bookedId parameter

                        // Execute the update command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No record updated. Please check if the ID exists.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show("Error updating reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)

       {
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
                   cmd.Parameters.AddWithValue("@reservationDate", dtpReservationDate.Text);
                cmd.Parameters.AddWithValue("@daysOfStay", txtDaysOfStay.Text);
                cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@room", txtNewRoom.Text);
                cmd.Parameters.AddWithValue("@checkInDate", DateTime.Now.ToString("yyyy-MM-dd"));

                cmd.ExecuteNonQuery();
            }

            // Delete reservation data
            string deleteQuery = "DELETE FROM booked WHERE id = @id";
            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
            {
                deleteCmd.Parameters.AddWithValue("@id", bookedId);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string archiveQuery = "INSERT INTO archive_booking (id, Name, Category, NoOfRoom, Reference, Room, DaysOfStay, BookedDate, Contact, Amount) SELECT id, Name, Category, NoOfRoom, Reference, DaysOfStay, BookedDate, Room, Contact, Amount FROM booked WHERE id = @id";
                    using (MySqlCommand archiveCmd = new MySqlCommand(archiveQuery, conn))
                    {
                        archiveCmd.Parameters.AddWithValue("@id", bookedId);
                        archiveCmd.ExecuteNonQuery();
                    }

                    string deleteQuery = "DELETE FROM booked WHERE id = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", bookedId);
                        deleteCmd.ExecuteNonQuery();
                        MessageBox.Show("Booking canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing booking: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




    }

}



