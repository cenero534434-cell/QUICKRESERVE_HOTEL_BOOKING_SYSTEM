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
    public partial class Staff_Check_out : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";
        public Staff_Check_out()
        {
            InitializeComponent();
            LoadCheckOutData();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void LoadCheckOutData(string searchKeyword = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM checkout";

                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query += " WHERE Category LIKE @keyword OR Room LIKE @keyword OR Reference LIKE @keyword";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchKeyword))
                        {
                            cmd.Parameters.AddWithValue("@keyword", $"%{searchKeyword}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgCheckOut.DataSource = dt;

                            if (!dtgCheckOut.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgCheckOut.Columns.Add(actionColumn);
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


        private void LoadCheckOutData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, Category, Room, Reference FROM checkout";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgCheckOut.DataSource = dt;

                            if (!dtgCheckOut.Columns.Contains("Action"))
                            {
                                DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                                {
                                    Name = "Action",
                                    Text = "View",
                                    UseColumnTextForButtonValue = true
                                };
                                dtgCheckOut.Columns.Add(actionColumn);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Staff_Check_in quiz2Form = new Staff_Check_in();
            quiz2Form.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            UserDashboard quiz2Form = new UserDashboard();
            quiz2Form.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.ColumnIndex == dtgCheckOut.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    int id = Convert.ToInt32(dtgCheckOut.Rows[e.RowIndex].Cells["id"].Value);
                    Check_Out_Action_Form actionForm = new Check_Out_Action_Form(id);
                    actionForm.ShowDialog();
                    LoadCheckOutData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            LoadCheckOutData(searchKeyword);
        }

        private void Staff_Check_out_Load(object sender, EventArgs e)
        {
            LoadCheckOutData();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login quiz2Form = new Login();
            quiz2Form.Show();
            this.Hide();
        }
    }
}
