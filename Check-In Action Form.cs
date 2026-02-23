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
    public partial class Check_In_Action_Form : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private int checkInId;
        public Check_In_Action_Form(int id)
        {
            InitializeComponent();
            checkInId = id;
            LoadCheckInDetails();
        }

        private void Check_In_Action_Form_Load(object sender, EventArgs e)
        {

        }

        private void LoadCheckInDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM checkin WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", checkInId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtCategory.Text = reader["Category"].ToString();
                                txtRoom.Text = reader["Room"].ToString();
                                txtReference.Text = reader["Reference"].ToString();
                                CheckInDate.Text = reader["CheckInDate"].ToString();
                                txtContact.Text = reader["Contact"].ToString();
                                txtDaysOfStay.Text = reader["DaysOfStay"].ToString();
                                txtAmount.Text = reader["Amount"].ToString();
                                txtRoomQuantity.Text = reader["NoOfRoom"].ToString();
                                ReservationDate.Text = reader["ReservationDate"].ToString();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE checkin SET Name = @name, Category = @category, NoOfRoom = @noofroom, Room = @room, Reference = @reference, CheckInDate = @checkindate, DaysOfStay = @daysofstay, Amount = @amount, Contact = @contact WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                        cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        cmd.Parameters.AddWithValue("@checkindate", CheckInDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@daysofstay", txtDaysOfStay.Text);
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@id", checkInId);
                        cmd.Parameters.AddWithValue("@noofroom", txtRoomQuantity.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating Checked In: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
                try
                {
                    conn.Open();

                    // Insert check-in data
                    string insertQuery = "INSERT INTO checkout (Name, Reference, Category, NoOfRoom, ReservationDate, DaysOfStay, Amount, Contact, Room, CheckOutDate, CheckInDate) " +
                                         "VALUES (@name, @reference, @category, @noOfRoom, @reservationDate, @daysOfStay, @amount, @contact, @room,@checkOutDate, @checkInDate)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                        cmd.Parameters.AddWithValue("@room", txtRoom.Text);
                        cmd.Parameters.AddWithValue("@reservationDate", ReservationDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@daysOfStay", txtDaysOfStay.Text);
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@noOfRoom", txtRoomQuantity.Text);
                        cmd.Parameters.AddWithValue("@checkInDate", CheckInDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@checkOutDate", checkoutdate.Value.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }

                    // Delete reservation data
                    string deleteQuery = "DELETE FROM checkin WHERE id = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", checkInId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Check-out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during check-in: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private void txtDaysOfStay_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
