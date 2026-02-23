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
    public partial class Archive_Reservation : Form
    {
        private const string connectionString = "Server=localhost;Database=Hotel;Uid=root;Pwd=;";

        public Archive_Reservation()
        {
            InitializeComponent();
           
        }




        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        private void Archive_Reservation_Load(object sender, EventArgs e)
        {
          
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

        private void btnRoomList_Click(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Staff_Management manageuserForm = new Staff_Management();
            manageuserForm.Show();
            this.Hide();

        }

   
        private void dtgArchiveReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
                   }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void label4_Click(object sender, EventArgs e)
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

        private void btnRoomList_Click_1(object sender, EventArgs e)
        {
            Room_List roomlistForm = new Room_List();
            roomlistForm.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            paymentForm.Show();
            this.Hide();

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            Archive_Reservation_Form reservationForm = new Archive_Reservation_Form();
            reservationForm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Archive_Reservation_Form reservationForm = new Archive_Reservation_Form();
            reservationForm.Show();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Archive_Reserved_Hall archivehallForm = new Archive_Reserved_Hall();
            archivehallForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Archive_Booking archivebookingForm = new Archive_Booking();
            archivebookingForm.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Archive_Booking archivebookingForm = new Archive_Booking();
            archivebookingForm.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Archive_Booking archivebookingForm = new Archive_Booking();
            archivebookingForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Archive_Rooms roomForm = new Archive_Rooms();
            roomForm.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

            Archive_Rooms roomForm = new Archive_Rooms();
            roomForm.Show();
        }
    }
}
