
using LiveCharts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using LiveCharts.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts.Definitions.Charts;
using LiveCharts.Defaults;


namespace Hotel_Booking___Reservation_03
{
    public partial class Dashboard : Form
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=Hotel;Uid=root;Pwd=;");
        private string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";

        public Dashboard()
        {
            InitializeComponent();
            SetDayView();
        }

        private void SetDayView()
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "Reservation",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 10), 
                        new ObservablePoint(1, 7),  
                        new ObservablePoint(2, 3), 
                        new ObservablePoint(3, 6),  
                        new ObservablePoint(4, 8),  
                        new ObservablePoint(5, 9),  
                        new ObservablePoint(6, 10), 
                        new ObservablePoint(7, 12)  
                    },
                    PointGeometrySize = 15,
                },

                new LineSeries
                {
                    Title = "Booked",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 2), 
                        new ObservablePoint(1, 5), 
                        new ObservablePoint(2, 6), 
                        new ObservablePoint(3, 8), 
                        new ObservablePoint(4, 5), 
                        new ObservablePoint(5, 3), 
                        new ObservablePoint(6, 5), 
                        new ObservablePoint(7, 4)  
                    },
                    PointGeometrySize = 15,
                },

                new LineSeries
                {
                    Title = "Check-in",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 4), 
                        new ObservablePoint(1, 5), 
                        new ObservablePoint(2, 7), 
                        new ObservablePoint(3, 10), 
                        new ObservablePoint(4, 5), 
                        new ObservablePoint(5, 1), 
                        new ObservablePoint(6, 9),
                        new ObservablePoint(7, 8) 
                    },
                    PointGeometrySize = 15,
                }
            };

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Days",
                Labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" },
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Count",
                LabelFormatter = value => value.ToString("N0"),
                MinValue = 0,
                MaxValue = 15, 

            });
        }

        private void SetMonthView()
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "Reservation",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 15), 
                        new ObservablePoint(1, 20), 
                        new ObservablePoint(2, 10), 
                        new ObservablePoint(3, 18), 
                        new ObservablePoint(4, 25), 
                        new ObservablePoint(5, 22), 
                        new ObservablePoint(6, 30), 
                        new ObservablePoint(7, 35), 
                        new ObservablePoint(8, 28),
                        new ObservablePoint(9, 33), 
                        new ObservablePoint(10, 40), 
                        new ObservablePoint(11, 38)
                    },
                    PointGeometrySize = 15,
                },

                new LineSeries
                {
                    Title = "Booked",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 5), 
                        new ObservablePoint(1, 8), 
                        new ObservablePoint(2, 6), 
                        new ObservablePoint(3, 12), 
                        new ObservablePoint(4, 10), 
                        new ObservablePoint(5, 15), 
                        new ObservablePoint(6, 25), 
                        new ObservablePoint(7, 22), 
                        new ObservablePoint(8, 28), 
                        new ObservablePoint(9, 30), 
                        new ObservablePoint(10, 33), 
                        new ObservablePoint(11, 35) 
                    },
                    PointGeometrySize = 15,
                },

                new LineSeries
                {
                    Title = "Check-in",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 8),
                        new ObservablePoint(1, 12), 
                        new ObservablePoint(2, 6), 
                        new ObservablePoint(3, 14),
                        new ObservablePoint(4, 20), 
                        new ObservablePoint(5, 18), 
                        new ObservablePoint(6, 22),
                        new ObservablePoint(7, 25), 
                        new ObservablePoint(8, 28), 
                        new ObservablePoint(9, 33), 
                        new ObservablePoint(10, 40), 
                        new ObservablePoint(11, 42) 
                    },
                    PointGeometrySize = 15,
                }
            };

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Count",
                LabelFormatter = value => value.ToString("N0"),
                MinValue = 0,
                MaxValue = 80, 

            });
        }

        private void SetYearView()
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {

                new LineSeries
                {
                    Title = "Reservation",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(2024, 100),
                        new ObservablePoint(2025, 120),
                        new ObservablePoint(2026, 150),
                        new ObservablePoint(2027, 130),
                        new ObservablePoint(2028, 140),
                        new ObservablePoint(2029, 160),
                        new ObservablePoint(2030, 180)
                    },
                    PointGeometrySize = 15,
                },

                new LineSeries
                {
                    Title = "Booked",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(2024, 60),
                        new ObservablePoint(2025, 80),
                        new ObservablePoint(2026, 90),
                        new ObservablePoint(2027, 85),
                        new ObservablePoint(2028, 100),
                        new ObservablePoint(2029, 120),
                        new ObservablePoint(2030, 150)
                    },
                    PointGeometrySize = 15,
                },


                new LineSeries
                {
                    Title = "Check-in",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(2024, 50),
                        new ObservablePoint(2025, 70),
                        new ObservablePoint(2026, 80),
                        new ObservablePoint(2027, 90),
                        new ObservablePoint(2028, 110),
                        new ObservablePoint(2029, 130),
                        new ObservablePoint(2030, 160)
                    },
                    PointGeometrySize = 15,
                }
            };

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Year",
                Labels = new[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030" },
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Count",
                LabelFormatter = value => value.ToString("N0"),
                MinValue = 0,
                MaxValue = 200, 

            });
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            ExecuteCountQuery("SELECT COUNT(*) FROM available_room WHERE Availability = 'Available'", availroomtotal);
            ExecuteCountQuery("SELECT COUNT(*) FROM reservation", reservationtotal);
            ExecuteCountQuery("SELECT COUNT(*) FROM checkin", checkedintotal);
            ExecuteCountQuery("SELECT COUNT(*) FROM booked", bookedtotal);
        }

        private void CountAvailableRooms()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT COUNT(*) FROM available_room WHERE Availability = 'Available'";
                MySqlCommand command = new MySqlCommand(query, connection);

                int availableRoomsCount = Convert.ToInt32(command.ExecuteScalar());

                availroomtotal.Text = availableRoomsCount.ToString();
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
        private void CountReservations()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT COUNT(*) FROM reservation";
                MySqlCommand command = new MySqlCommand(query, connection);

                int availableRoomsCount = Convert.ToInt32(command.ExecuteScalar());

                reservationtotal.Text = availableRoomsCount.ToString();
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
        private void CountCheckedIn()
        {
            try
            {
                
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT COUNT(*) FROM checkin";
                MySqlCommand command = new MySqlCommand(query, connection);

                
                int availableRoomsCount = Convert.ToInt32(command.ExecuteScalar());

               
                checkedintotal.Text = availableRoomsCount.ToString();
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
     private void CountBooked()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

               
                string query = "SELECT COUNT(*) FROM booked";
                MySqlCommand command = new MySqlCommand(query, connection);

                int availableRoomsCount = Convert.ToInt32(command.ExecuteScalar());

                bookedtotal.Text = availableRoomsCount.ToString();
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

        private void ExecuteCountQuery(string query, Label label)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());
                label.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error counting data: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


      
   
        private DataTable GetDataFromDatabase(string viewType)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = $"CALL Get{viewType}Data()"; 

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dataTable;
        }


        private void label4_Click(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Check_In reservationForm = new Check_In();
            reservationForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           Check_Out checkoutForm = new Check_Out();
            checkoutForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
      

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Reservation reservationForm = new Reservation();
            reservationForm.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
          Staff_Management usermanagementForm = new Staff_Management();
            usermanagementForm.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Booked bookedForm = new Booked();
            bookedForm.Show();
            this.Hide();
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void ButtonDay_Click(object sender, EventArgs e)
        {
        }

        private void ButtonMonth_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonYear_Click(object sender, EventArgs e)
        {
        
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            SetDayView();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            SetMonthView();

        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            SetYearView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Live_chart loginForm = new Live_chart();
            loginForm.Show();
        }

        private void cartesianChart1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}

