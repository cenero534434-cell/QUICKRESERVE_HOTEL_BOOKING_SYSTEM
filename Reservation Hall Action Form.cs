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
    public partial class Reservation_Hall_Action_Form : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private int functionhallId;
        public Reservation_Hall_Action_Form(int id)
        {
            InitializeComponent();
            functionhallId = id;
            LoadHallDetails();
        }

        private void Reservation_Hall_Action_Form_Load(object sender, EventArgs e)
        {
            LoadHallDetails();
        }

        private void LoadHallDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM reservation_hall WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", functionhallId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtReference.Text = reader["Reference"].ToString();
                                txtName.Text = reader["Name"].ToString();
                                txtContact.Text = reader["Contact"].ToString();
                                dtpDate.Value = Convert.ToDateTime(reader["Date"]);
                                txtNoOfDays.Text = reader["NoOfDays"].ToString();
                                cmbEventType.Text = reader["Event_Type"].ToString();
                                txtAmount.Text = reader["Amount"].ToString();
                                txtStartTime.Text = reader["Start_time"].ToString();
                                txtEndTime.Text = reader["End_time"].ToString();
                                txtEventDay.Text = reader["Event_Day"].ToString();
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
                    string query = "UPDATE reservation_hall SET Name = @name, Event_Type = @eventType, Reference = @reference, Date = @date, NoOfDays = @noOfDays, Amount = @amount, Contact = @contact, Start_time = @startTime, End_time = @endTime, Event_Day = @eventDay WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@eventType", cmbEventType.Text);
                        cmd.Parameters.AddWithValue("@reference", txtReference.Text);
                        cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@noOfDays", txtNoOfDays.Text);
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@startTime", txtStartTime.Text);
                        cmd.Parameters.AddWithValue("@endTime", txtEndTime.Text);
                        cmd.Parameters.AddWithValue("@eventDay", txtEventDay.Text);
                        cmd.Parameters.AddWithValue("@id", functionhallId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string archiveQuery = "INSERT INTO archive_hall SELECT * FROM reservation_hall WHERE id = @id";
                    using (MySqlCommand archiveCmd = new MySqlCommand(archiveQuery, conn))
                    {
                        archiveCmd.Parameters.AddWithValue("@id", functionhallId);
                        archiveCmd.ExecuteNonQuery();
                    }

                    string deleteQuery = "DELETE FROM reservation_hall WHERE id = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", functionhallId);
                        deleteCmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
