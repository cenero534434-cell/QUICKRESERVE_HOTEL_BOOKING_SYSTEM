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
    public partial class Archive_Rooms : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Archive_Rooms()
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
                    string query = "SELECT * FROM archived_room";
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
        private void Archive_Rooms_Load(object sender, EventArgs e)
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
                        string roomtype = selectedRow.Cells["Room_Type"].Value.ToString();
                        string roomnumber = selectedRow.Cells["Room_Number"].Value.ToString();
                        string price = selectedRow.Cells["Price"].Value.ToString();
                        string availability = selectedRow.Cells["Availability"].Value.ToString();

                        // Get image as byte array from the DataGridView cell
                        byte[] imageBytes = (byte[])selectedRow.Cells["Image"].Value;

                        string insertQuery = "INSERT INTO available_room (Room_Type, Room_Number, Price, Availability, Image) VALUES (@Room_Type, @Room_Number, @Price, @Availability, @Image)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Room_Type", roomtype);
                            cmd.Parameters.AddWithValue("@Room_Number", roomnumber);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Availability", availability);
                            cmd.Parameters.Add("@Image", MySqlDbType.Blob).Value = imageBytes; // Store image as BLOB
                            cmd.ExecuteNonQuery();
                        }

                        string deleteQuery = "DELETE FROM archived_room WHERE id = @id";
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