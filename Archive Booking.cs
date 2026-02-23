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
    
    public partial class Archive_Booking : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";

        public Archive_Booking()
        {
            InitializeComponent();
            LoadArchiveReservationData();
        }

        private void LoadArchiveReservationData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM archive_booking";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgArchiveReservation.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgArchiveReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUnarchive_Click(object sender, EventArgs e)
        {
            if (dtgArchiveReservation.SelectedRows.Count > 0)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        DataGridViewRow selectedRow = dtgArchiveReservation.SelectedRows[0];
                        string id = selectedRow.Cells["id"].Value.ToString();
                        string category = selectedRow.Cells["Category"].Value.ToString();
                        string room = selectedRow.Cells["NoOfRoom"].Value.ToString();
                        string newroom = selectedRow.Cells["Room"].Value.ToString();
                        string reference = selectedRow.Cells["Reference"].Value.ToString();
                        string name = selectedRow.Cells["Name"].Value.ToString();
                        string reservationdate = selectedRow.Cells["BookedDate"].Value.ToString();
                        string daysofstay = selectedRow.Cells["DaysOfStay"].Value.ToString();
                        string amount = selectedRow.Cells["Amount"].Value.ToString();
                        string contact = selectedRow.Cells["Contact"].Value.ToString();


                        string insertQuery = "INSERT INTO booked (id, Name, Reference, Category, NoOfRoom, BookedDate, DaysOfStay, Amount, Contact, Room) VALUES (@id, @name, @reference, @category, @noOfRoom, @bookedDate, @daysOfStay, @amount, @contact, @room)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@NoOfRoom", room);
                            cmd.Parameters.AddWithValue("@reference", reference);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@room", newroom);
                            cmd.Parameters.AddWithValue("@bookedDate", reservationdate);
                            cmd.Parameters.AddWithValue("@daysOfStay", daysofstay);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@contact", contact);
                            cmd.ExecuteNonQuery();
                        }


                        string deleteQuery = "DELETE FROM archive_booking WHERE id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Record successfully unarchived!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadArchiveReservationData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error unarchiving record: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to unarchive.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
