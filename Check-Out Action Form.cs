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
    public partial class Check_Out_Action_Form : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        private int checkOutId;
        public Check_Out_Action_Form(int id)
        {
            InitializeComponent();
            checkOutId = id;
            LoadCheckOutDetails();
        }

        private void Check_Out_Action_Form_Load(object sender, EventArgs e)
        {

        }

        private void LoadCheckOutDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM checkout WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", checkOutId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtCategory.Text = reader["Category"].ToString();
                                txtRoom.Text = reader["Room"].ToString();
                                txtReference.Text = reader["Reference"].ToString();
                                dtpReservationDate.Text = reader["CheckOutDate"].ToString();
                                txtContact.Text = reader["Contact"].ToString();
                                txtDaysOfStay.Text = reader["DaysOfStay"].ToString();
                                txtAmount.Text = reader["Amount"].ToString();
                                txtNoOfRoom.Text = reader["NoOfRoom"].ToString();
                                txtReservationDate.Text = reader["ReservationDate"].ToString();
                                txtCheckinDate.Text = reader["CheckInDate"].ToString();

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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRoom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
