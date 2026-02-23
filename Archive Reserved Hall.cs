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
    public partial class Archive_Reserved_Hall : Form
    {

        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Archive_Reserved_Hall()
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
                    string query = "SELECT * FROM archive_hall";
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

        private void Archive_Reserved_Hall_Load(object sender, EventArgs e)
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
                        string name = selectedRow.Cells["Name"].Value.ToString();
                        string reference = selectedRow.Cells["Reference"].Value.ToString();
                        string eventtype = selectedRow.Cells["Event_Type"].Value.ToString();
                        string amount = selectedRow.Cells["Amount"].Value.ToString();
                        string contact = selectedRow.Cells["Contact"].Value.ToString();
                        string starttime = selectedRow.Cells["Start_time"].Value.ToString();
                        string endtime = selectedRow.Cells["End_time"].Value.ToString();
                        string noofdays = selectedRow.Cells["NoOfDays"].Value.ToString();
                        string eventday = selectedRow.Cells["Event_Day"].Value.ToString();
                        string date = selectedRow.Cells["Date"].Value.ToString();



                        string insertQuery = "INSERT INTO  reservation_hall (id, Name, Reference, Event_Type, Amount, Contact, Date, Start_time, End_time, NoOfDays, Event_Day) VALUES (@id, @Name, @Reference, @Event_Type, @Amount, @Contact, @Date, @Start_time, @End_time, @NoOfDays, @Event_Day)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Reference", reference);
                            cmd.Parameters.AddWithValue("@Event_Type", eventtype);
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@Contact", contact);
                            cmd.Parameters.AddWithValue("@Start_time", starttime);
                            cmd.Parameters.AddWithValue("@End_time", endtime);
                            cmd.Parameters.AddWithValue("@NoOfDays", noofdays);
                            cmd.Parameters.AddWithValue("@Event_Day", eventday);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.ExecuteNonQuery();
                        }


                        string deleteQuery = "DELETE FROM archive_hall WHERE id = @id";
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

