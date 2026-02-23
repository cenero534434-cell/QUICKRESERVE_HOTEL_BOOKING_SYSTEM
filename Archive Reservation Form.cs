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
    public partial class Archive_Reservation_Form : Form
    {

        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Archive_Reservation_Form()
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
                    string query = "SELECT * FROM archive_reservation"; 
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
        private void Archive_Reservation_Form_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
                        string reference = selectedRow.Cells["Reference"].Value.ToString();
                        string name = selectedRow.Cells["Name"].Value.ToString();
                        string reservationdate = selectedRow.Cells["ReservationDate"].Value.ToString();
                        string daysofstay = selectedRow.Cells["DaysOfStay"].Value.ToString();
                        string amount = selectedRow.Cells["Amount"].Value.ToString();
                        string contact = selectedRow.Cells["Contact"].Value.ToString();


                        string insertQuery = "INSERT INTO reservation (id, Name, Category, NoOfRoom, Reference, ReservationDate, DaysOfStay, Amount, Contact) VALUES (@id, @Name, @Category, @NoOfRoom, @Reference, @ReservationDate, @DaysOfStay, @Amount, @Contact)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@Category", category);
                            cmd.Parameters.AddWithValue("@NoOfRoom", room);
                            cmd.Parameters.AddWithValue("@Reference", reference);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@ReservationDate", reservationdate);
                            cmd.Parameters.AddWithValue("@DaysOfStay", daysofstay);
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@Contact", contact);
                            cmd.ExecuteNonQuery();
                        }


                        string deleteQuery = "DELETE FROM archive_reservation WHERE id = @id";
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


        private void dtgArchiveReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
