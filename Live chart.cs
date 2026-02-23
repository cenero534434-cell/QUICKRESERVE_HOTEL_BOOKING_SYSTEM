using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using LiveCharts.Defaults;

namespace Hotel_Booking___Reservation_03
{
    public partial class Live_chart : Form
    {

        

        public Live_chart()
        {
                InitializeComponent();
                // Initial chart setup (Day view)
                SetDayView(); // Default view is Day
            }

            // Function to set the chart to Day view
            private void SetDayView()
            {
                cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                // Reservation Series (Blue)
                new LineSeries
                {
                    Title = "Reservation",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 10), // Day 1
                        new ObservablePoint(1, 7),  // Day 2
                        new ObservablePoint(2, 3),  // Day 3
                        new ObservablePoint(3, 6),  // Day 4
                        new ObservablePoint(4, 8),  // Day 5
                        new ObservablePoint(5, 9),  // Day 6
                        new ObservablePoint(6, 10), // Day 7 (Sat)
                        new ObservablePoint(7, 12)  // Day 8 (Sun)
                    },
                    PointGeometrySize = 15,
                },

                // Booked Series (Red)
                new LineSeries
                {
                    Title = "Booked",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 2), // Day 1
                        new ObservablePoint(1, 5), // Day 2
                        new ObservablePoint(2, 6), // Day 3
                        new ObservablePoint(3, 8), // Day 4
                        new ObservablePoint(4, 5), // Day 5
                        new ObservablePoint(5, 3), // Day 6
                        new ObservablePoint(6, 5), // Day 7 (Sat)
                        new ObservablePoint(7, 4)  // Day 8 (Sun)
                    },
                    PointGeometrySize = 15,
                },

                // Check-in Series (Yellow)
                new LineSeries
                {
                    Title = "Check-in",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 4), // Day 1
                        new ObservablePoint(1, 5), // Day 2
                        new ObservablePoint(2, 7), // Day 3
                        new ObservablePoint(3, 10), // Day 4
                        new ObservablePoint(4, 5), // Day 5
                        new ObservablePoint(5, 1), // Day 6
                        new ObservablePoint(6, 9), // Day 7 (Sat)
                        new ObservablePoint(7, 8)  // Day 8 (Sun)
                    },
                    PointGeometrySize = 15,
                }
            };

                // X-Axis for Day view
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Days",
                    Labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" },
                });

                // Y-Axis settings for Day view
                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Count",
                    LabelFormatter = value => value.ToString("N0"),
                    MinValue = 0,
                    MaxValue = 15, // Adjust based on your data
                    
                });
            }

            // Function to set the chart to Month view
            private void SetMonthView()
            {
                cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                // Reservation Series (Blue)
                new LineSeries
                {
                    Title = "Reservation",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 15), // Jan
                        new ObservablePoint(1, 20), // Feb
                        new ObservablePoint(2, 10), // Mar
                        new ObservablePoint(3, 18), // Apr
                        new ObservablePoint(4, 25), // May
                        new ObservablePoint(5, 22), // Jun
                        new ObservablePoint(6, 30), // Jul
                        new ObservablePoint(7, 35), // Aug
                        new ObservablePoint(8, 28), // Sep
                        new ObservablePoint(9, 33), // Oct
                        new ObservablePoint(10, 40), // Nov
                        new ObservablePoint(11, 38) // Dec
                    },
                    PointGeometrySize = 15,
                },

                // Booked Series (Red)
                new LineSeries
                {
                    Title = "Booked",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 5), // Jan
                        new ObservablePoint(1, 8), // Feb
                        new ObservablePoint(2, 6), // Mar
                        new ObservablePoint(3, 12), // Apr
                        new ObservablePoint(4, 10), // May
                        new ObservablePoint(5, 15), // Jun
                        new ObservablePoint(6, 25), // Jul
                        new ObservablePoint(7, 22), // Aug
                        new ObservablePoint(8, 28), // Sep
                        new ObservablePoint(9, 30), // Oct
                        new ObservablePoint(10, 33), // Nov
                        new ObservablePoint(11, 35) // Dec
                    },
                    PointGeometrySize = 15,
                },

                // Check-in Series (Yellow)
                new LineSeries
                {
                    Title = "Check-in",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 8), // Jan
                        new ObservablePoint(1, 12), // Feb
                        new ObservablePoint(2, 6), // Mar
                        new ObservablePoint(3, 14), // Apr
                        new ObservablePoint(4, 20), // May
                        new ObservablePoint(5, 18), // Jun
                        new ObservablePoint(6, 22), // Jul
                        new ObservablePoint(7, 25), // Aug
                        new ObservablePoint(8, 28), // Sep
                        new ObservablePoint(9, 33), // Oct
                        new ObservablePoint(10, 40), // Nov
                        new ObservablePoint(11, 42) // Dec
                    },
                    PointGeometrySize = 15,
                }
            };

                // X-Axis for Month view
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Month",
                    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                });

                // Y-Axis settings for Month view
                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Count",
                    LabelFormatter = value => value.ToString("N0"),
                    MinValue = 0,
                    MaxValue = 80, // Adjust based on your data
                    
                });
            }

            // Function to set the chart to Year view
            private void SetYearView()
            {
                cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                // Reservation Series (Blue)
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

                // Booked Series (Red)
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

                // Check-in Series (Yellow)
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

                // X-Axis for Year view
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Year",
                    Labels = new[] { "2024", "2025", "2026", "2027", "2028", "2029", "2030" },
                });

                // Y-Axis settings for Year view
                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Count",
                    LabelFormatter = value => value.ToString("N0"),
                    MinValue = 0,
                    MaxValue = 200, // Adjust based on your data
                    
                });
            }

 



    private void Live_chart_Load(object sender, EventArgs e)
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
    }
}
