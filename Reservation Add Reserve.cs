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
    public partial class Reservation_AddReserve : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Reservation_AddReserve()
        {
            InitializeComponent();
        }

        private void Reservation_AddReserve_Load(object sender, EventArgs e)
        {
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
                        if (result != DBNull.Value)
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

        public event Action ReservationAdded;

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            int reference = int.Parse(txtReference.Text.Trim());
            string category = txtCategory.Text.Trim();
            string noOfRoom = txtRoom.Text.Trim();
            string reservationDate = dtpReservationDate.Text.Trim();
            string contact = txtContact.Text.Trim();
            int daysOfStay = int.Parse(txtDaysOfStay.Text.Trim());
            decimal amount = decimal.Parse(txtAmount.Text.Trim());

            if (AddReservationAndPayment(name, reference, category, noOfRoom, reservationDate, contact, daysOfStay, amount))
            {
                MessageBox.Show("Reservation and payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();

                ReservationAdded?.Invoke();
                this.Close();
            }
        }

        private bool AddReservationAndPayment(string name, int reference, string category, string noOfRoom, string reservationDate, string contact, int daysOfStay, decimal amount)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Begin transaction to ensure both queries succeed or fail together
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Query 1: Insert into reservation table
                            string queryReservation = "INSERT INTO reservation (name, reference, category, NoOfRoom, reservationdate, contact, daysofstay, amount) " +
                                                      "VALUES (@name, @reference, @category, @noOfRoom, @reservationdate, @contact, @daysofstay, @amount)";
                            using (MySqlCommand cmd = new MySqlCommand(queryReservation, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@name", name);
                                cmd.Parameters.AddWithValue("@reference", reference);
                                cmd.Parameters.AddWithValue("@category", category);
                                cmd.Parameters.AddWithValue("@noOfRoom", noOfRoom);
                                cmd.Parameters.AddWithValue("@reservationdate", reservationDate);
                                cmd.Parameters.AddWithValue("@contact", contact);
                                cmd.Parameters.AddWithValue("@daysofstay", daysOfStay);
                                cmd.Parameters.AddWithValue("@amount", amount);

                                cmd.ExecuteNonQuery();
                            }

                            // Query 2: Insert into payment table
                            string queryPayment = "INSERT INTO payment (Reference, Reservation_Booked_Date, NoOfRoom, Payment) " +
                                                  "VALUES (@reference, @reservationdate, @noOfRoom, @amount)";
                            using (MySqlCommand cmdPayment = new MySqlCommand(queryPayment, conn, transaction))
                            {
                                cmdPayment.Parameters.AddWithValue("@reference", reference);
                                cmdPayment.Parameters.AddWithValue("@reservationdate", reservationDate);
                                cmdPayment.Parameters.AddWithValue("@noOfRoom", noOfRoom);
                                cmdPayment.Parameters.AddWithValue("@payment", amount);

                                cmdPayment.ExecuteNonQuery();
                            }

                            // Commit the transaction if both queries succeed
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction on error
                            transaction.Rollback();
                            MessageBox.Show("Error adding reservation and payment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReservationDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
