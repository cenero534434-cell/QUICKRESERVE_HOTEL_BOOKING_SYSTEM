using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;


namespace Hotel_Booking___Reservation_03
{
    public partial class Reservation_Hall : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private readonly HashSet<DateTime> unavailableDates = new HashSet<DateTime>();

        public Reservation_Hall()
        {
            InitializeComponent();
            LoadFunctionHallData();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Reservation_Hall_Load(object sender, EventArgs e)
        {
            LoadUnavailableDates();
            LoadFunctionHallData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadSearchResults(searchKeyword);
        }


        private void LoadSearchResults(string searchKeyword)
        {
            // Clear previous search results
            listBoxResults.Items.Clear();

            if (string.IsNullOrEmpty(searchKeyword))
            {
                return; // If search bar is empty, do nothing
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, name, reference, contact FROM reservation WHERE reference LIKE @searchKeyword";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchKeyword", $"%{searchKeyword}%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string displayText = $"Reference: {reader["reference"]} - Name: {reader["name"]} - Contact: {reader["contact"]}";
                                listBoxResults.Items.Add(new ListBoxItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    DisplayText = displayText,
                                    Name = reader["name"].ToString(),
                                    Reference = reader["reference"].ToString(),
                                    Contact = reader["contact"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching reservation data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                        if (result != DBNull.Value && result != null)
                        {
                            reference = Convert.ToInt32(result) + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting next reference: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return reference;
        }


        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If an item is selected from the ListBox, load it into the textboxes
            if (listBoxResults.SelectedItem is ListBoxItem selectedItem)
            {
                txtName.Text = selectedItem.Name;
                txtReference.Text = selectedItem.Reference;
                txtContact.Text = selectedItem.Contact;
            }
        }




        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start;

            if (unavailableDates.Contains(selectedDate))
            {
                MessageBox.Show("This day is unavailable. Please choose another day.", "Unavailable Day", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtEventDay.Text = selectedDate.ToShortDateString();
            unavailableDates.Add(selectedDate);
            SaveUnavailableDates();
            UpdateCalendarColors();
        }

        private void UpdateCalendarColors()
        {
            foreach (DateTime date in unavailableDates)
            {
                monthCalendar.AddBoldedDate(date);
            }
            monthCalendar.UpdateBoldedDates();
        }

        private void LoadUnavailableDates()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Event_Day FROM reservation_hall";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (DateTime.TryParse(reader["Event_Day"].ToString(), out DateTime eventDay))
                                {
                                    unavailableDates.Add(eventDay);
                                }
                                else
                                {
                                    MessageBox.Show($"Invalid date format: {reader["Event_Day"]}", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading unavailable dates: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            UpdateCalendarColors();
        }


        private void SaveUnavailableDates()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtReference.Text) ||
                string.IsNullOrEmpty(txtContact.Text) || string.IsNullOrEmpty(cmbEventType.Text))
            {
                MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO reservation_hall (Reference, Name, Contact, Event_Type, Date, Start_time, End_time, NoOfDays, Amount, Event_Day) " +
                                   "VALUES (@Reference, @Name, @Contact, @Event_Type, @Date, @Start_time, @End_time, @NoOfDays, @Amount, @Event_Day)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Reference", txtReference.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@Event_Type", cmbEventType.Text.Trim());
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Start_time", txtStartTime.Text.Trim());
                        cmd.Parameters.AddWithValue("@End_time", txtEndTime.Text.Trim());
                        cmd.Parameters.AddWithValue("@NoOfDays", txtNoOfDays.Text.Trim());
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim());
                        cmd.Parameters.AddWithValue("@Event_Day", DateTime.Parse(txtEventDay.Text));


                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadFunctionHallData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {

            txtName.Clear();
            txtReference.Clear();
            txtContact.Clear();
            txtStartTime.Clear();
            txtEndTime.Clear();
            txtNoOfDays.Clear();
            txtAmount.Clear();
            txtEventDay.Clear();


            cmbEventType.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;


            txtSearch.Clear();
            listBoxResults.Items.Clear();
        }
        public class ListBoxItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }
            public string Name { get; set; }
            public string Reference { get; set; }
            public string Contact { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgHallReservation.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dtgHallReservation.Rows[e.RowIndex].Cells["id"].Value);
                Reservation_Hall_Action_Form actionForm = new Reservation_Hall_Action_Form(id);
                actionForm.ShowDialog();
                LoadFunctionHallData();
            }
        }

        private void LoadFunctionHallData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Reference, Event_Type, Event_Day FROM reservation_hall";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgHallReservation.DataSource = dt;

                            if (!dtgHallReservation.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgHallReservation.Columns.Add(actionColumn);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnbooked_Click(object sender, EventArgs e)
        {
            Booked bookedForm = new Booked();
            bookedForm.Show();
            this.Hide();

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Check_In checkInForm = new Check_In();
            checkInForm.Show();
            this.Hide();

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Check_Out checkOutForm = new Check_Out();
            checkOutForm.Show();
            this.Hide();
        }

        private void btnRoomList_Click(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();

        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            Staff_Management manageuserForm = new Staff_Management();
            manageuserForm.Show();
            this.Hide();

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
            this.Hide();
        }
    }
}

