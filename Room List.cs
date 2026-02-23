using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Booking___Reservation_03
{
    public partial class Room_List : Form
    {
        string connectionString = "server=localhost;database=hotel;uid=root;pwd=password;";


        public Room_List()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;

        }

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=Hotel;Uid=root;Pwd=;");
      


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();

        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();
        }

        private void btndashboard_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();

        }

        private void btnReservation_Click_1(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
            this.Hide();

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Booked bookedForm = new Booked();
            bookedForm.Show();
            this.Hide();

        }

        private void btnCheckIn_Click_1(object sender, EventArgs e)
        {
            Check_In checkInForm = new Check_In();
            checkInForm.Show();
            this.Hide();

        }

        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            Check_Out checkOutForm = new Check_Out();
            checkOutForm.Show();
            this.Hide();


        }

        private void label6_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();
        }

        private void btnManageUser_Click_1(object sender, EventArgs e)
        {
            Staff_Management manageuserForm = new Staff_Management();
            manageuserForm.Show();
            this.Hide();

        }

        private void Logout_Click_1(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            PboxImage.Image.Save(ms, PboxImage.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("INSERT INTO available_room (Room_Type, Room_Number, Price, Availability, Image) VALUES (@roomtype, @roomnumber, @price, @availability, @image)", connection);

            command.Parameters.Add("@roomtype", MySqlDbType.VarChar).Value = txtRoomType.Text;
            command.Parameters.Add("@roomnumber", MySqlDbType.VarChar).Value = txtRoomNo.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = txtPrice.Text;
            command.Parameters.Add("@availability", MySqlDbType.VarChar).Value = txtAvailability.Text;
            command.Parameters.Add("@image", MySqlDbType.Blob).Value = img;

            ExecMyQuery(command, "Room has been saved successfully.");
            FillDGV();
            ClearFields();       
        }

        public void ExecMyQuery(MySqlCommand mcomd, string myMsg)
        {
            // Check if the connection is already open
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); // Open the connection if it's closed
            }

            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }
            
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dtgRoom.CurrentRow == null)
            {
                MessageBox.Show("Please select a room to update.");
                return;
            }

            if (PboxImage.Image == null)
            {
                MessageBox.Show("Please upload an image.");
                return;
            }

            MemoryStream ms = new MemoryStream();
            PboxImage.Image.Save(ms, PboxImage.Image.RawFormat);
            byte[] img = ms.ToArray();

            // Ensure the table name is correct (e.g., "available_room")
            MySqlCommand command = new MySqlCommand("UPDATE available_room SET Room_Type=@roomtype, Room_Number=@roomnumber, Price=@price, Availability=@availability, Image=@image WHERE id = @id", connection);

            // Adding parameters
            command.Parameters.Add("@roomtype", MySqlDbType.VarChar).Value = txtRoomType.Text;
            command.Parameters.Add("@roomnumber", MySqlDbType.VarChar).Value = txtRoomNo.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = txtPrice.Text;
            command.Parameters.Add("@availability", MySqlDbType.VarChar).Value = txtAvailability.Text;
            command.Parameters.Add("@image", MySqlDbType.Blob).Value = img;

            // Assuming the id of the room is being fetched from the selected row
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(dtgRoom.CurrentRow.Cells[0].Value); // Ensure the ID is correctly converted to Int32

            try
            {
                ExecMyQuery(command, "Room has been updated successfully.");
                FillDGV();  // Reload the DataGridView after update
                ClearFields();  // Clear input fields
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a room is selected in the DataGridView
                if (dtgRoom.CurrentRow == null)
                {
                    MessageBox.Show("Please select a room to remove.");
                    return;
                }

                // Extract room details from DataGridView
                int roomId = Convert.ToInt32(dtgRoom.CurrentRow.Cells[0].Value);
                string roomType = dtgRoom.CurrentRow.Cells[3].Value.ToString();
                string roomNumber = dtgRoom.CurrentRow.Cells[2].Value.ToString();
                string price = dtgRoom.CurrentRow.Cells[4].Value.ToString();
                string availability = dtgRoom.CurrentRow.Cells[5].Value.ToString();

                // Image might not be set, so we need to handle the case where it's null
                byte[] img = null;
                if (dtgRoom.CurrentRow.Cells[5].Value != DBNull.Value)
                {
                    img = (byte[])dtgRoom.CurrentRow.Cells[1].Value;
                }

                // Open connection if it's not already open
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Insert the data into archived_room table
                MySqlCommand insertCommand = new MySqlCommand(
                    "INSERT INTO archived_room (Room_Type, Room_Number, Price, Availability, Image) VALUES (@roomtype, @roomnumber, @price, @availability, @image)",
                    connection);

                insertCommand.Parameters.AddWithValue("@roomtype", roomType);
                insertCommand.Parameters.AddWithValue("@roomnumber", roomNumber);
                insertCommand.Parameters.AddWithValue("@price", price);
                insertCommand.Parameters.AddWithValue("@availability", availability);
                insertCommand.Parameters.AddWithValue("@image", img);

                if (insertCommand.ExecuteNonQuery() > 0)
                {
                    // Delete the data from available_room table
                    MySqlCommand deleteCommand = new MySqlCommand(
                        "DELETE FROM available_room WHERE id = @id",
                        connection);

                    deleteCommand.Parameters.AddWithValue("@id", roomId);

                    if (deleteCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Room has been removed successfully.");
                        FillDGV(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the room from available rooms.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to archive the room.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close(); // Always ensure the connection is closed
                }
            }

            ClearFields(); // Clear the fields after the operation
        }




        private void ClearFields()
        {
            // Clear ComboBoxes by setting the selected index to -1 (no selection)
            txtRoomType.SelectedIndex = -1;
            txtAvailability.SelectedIndex = -1;

            // Clear textboxes
            txtRoomNo.Clear();
            txtPrice.Clear();

            // Clear the picture box (if there's an image to clear)
            if (PboxImage.Image != null)
            {
                PboxImage.Image = null;
            }
        }




        private void dtgRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Room_List_Load(object sender, EventArgs e)
        {

        }


        private void dtgRoom_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        public void FillDGV()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM available_room", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            dtgRoom.RowTemplate.Height = 80;
            dtgRoom.AllowUserToAddRows = false;


            dtgRoom.DataSource = table;

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dtgRoom.Columns[1];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dtgRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           

        }
      

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF;)|*.jpg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
            {
                PboxImage.Image = Image.FromFile(opf.FileName);
            }
        }


        private void Room_List_Load_1(object sender, EventArgs e)
        {
            FillDGV();

        }

        private void dtgRoom_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void dtgRoom_Click(object sender, EventArgs e)
        {
 
            Byte[] img = (Byte[])dtgRoom.CurrentRow.Cells[1].Value;

            MemoryStream ms = new MemoryStream(img);

            PboxImage.Image = Image.FromStream(ms);


            txtRoomType.Text = dtgRoom.CurrentRow.Cells[3].Value.ToString();
            txtRoomNo.Text = dtgRoom.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dtgRoom.CurrentRow.Cells[4].Value.ToString();
            txtAvailability.Text = dtgRoom.CurrentRow.Cells[5].Value.ToString();

        }

        private void PboxImage_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Open the connection if not already open
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Query to filter data based on the search text
                string query = "SELECT * FROM available_room WHERE Room_Type LIKE @searchText OR Room_Number LIKE @searchText OR Price LIKE @searchText OR Availability LIKE @searchText";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchText", "%" + txtSearch.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the filtered data to the DataGridView
                dtgRoom.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dtgRoom_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }



