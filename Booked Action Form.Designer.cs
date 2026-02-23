namespace Hotel_Booking___Reservation_03
{
    partial class Booked_Action_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgAvailableRoom = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewRoom = new System.Windows.Forms.TextBox();
            this.dsd = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDaysOfStay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hehe = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btndashboard = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAvailableRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSearch
            // 
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "Single room",
            "Deluxe room",
            "Double room",
            "Family room"});
            this.cmbSearch.Location = new System.Drawing.Point(908, 22);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(221, 21);
            this.cmbSearch.TabIndex = 103;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(838, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.TabIndex = 102;
            this.label8.Text = "Search:";
            // 
            // dtgAvailableRoom
            // 
            this.dtgAvailableRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAvailableRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAvailableRoom.Location = new System.Drawing.Point(633, 49);
            this.dtgAvailableRoom.Name = "dtgAvailableRoom";
            this.dtgAvailableRoom.RowHeadersVisible = false;
            this.dtgAvailableRoom.Size = new System.Drawing.Size(496, 281);
            this.dtgAvailableRoom.TabIndex = 99;
            this.dtgAvailableRoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAvailableRoom_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(331, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 19);
            this.label6.TabIndex = 98;
            this.label6.Text = "Room Number";
            // 
            // txtNewRoom
            // 
            this.txtNewRoom.Location = new System.Drawing.Point(335, 246);
            this.txtNewRoom.Name = "txtNewRoom";
            this.txtNewRoom.Size = new System.Drawing.Size(267, 20);
            this.txtNewRoom.TabIndex = 97;
            // 
            // dsd
            // 
            this.dsd.AutoSize = true;
            this.dsd.BackColor = System.Drawing.Color.Transparent;
            this.dsd.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.dsd.ForeColor = System.Drawing.Color.Maroon;
            this.dsd.Location = new System.Drawing.Point(40, 288);
            this.dsd.Name = "dsd";
            this.dsd.Size = new System.Drawing.Size(125, 19);
            this.dsd.TabIndex = 96;
            this.dsd.Text = "Room Quantity";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(44, 310);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(267, 20);
            this.txtRoom.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(40, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 94;
            this.label5.Text = "Reference";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(44, 49);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(267, 20);
            this.txtReference.TabIndex = 93;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.Maroon;
            this.btnCheckIn.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(335, 292);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(109, 38);
            this.btnCheckIn.TabIndex = 92;
            this.btnCheckIn.Text = "SAVE";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Location = new System.Drawing.Point(335, 49);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(267, 20);
            this.dtpReservationDate.TabIndex = 91;
            // 
            // txtCategory
            // 
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Items.AddRange(new object[] {
            "Single room",
            "Deluxe room",
            "Double room",
            "Family room"});
            this.txtCategory.Location = new System.Drawing.Point(44, 245);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(267, 21);
            this.txtCategory.TabIndex = 90;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(335, 183);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(267, 20);
            this.txtAmount.TabIndex = 89;
            // 
            // txtDaysOfStay
            // 
            this.txtDaysOfStay.Location = new System.Drawing.Point(335, 117);
            this.txtDaysOfStay.Name = "txtDaysOfStay";
            this.txtDaysOfStay.Size = new System.Drawing.Size(267, 20);
            this.txtDaysOfStay.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(331, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 87;
            this.label4.Text = "Amount";
            // 
            // hehe
            // 
            this.hehe.AutoSize = true;
            this.hehe.BackColor = System.Drawing.Color.Transparent;
            this.hehe.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.hehe.ForeColor = System.Drawing.Color.Maroon;
            this.hehe.Location = new System.Drawing.Point(40, 158);
            this.hehe.Name = "hehe";
            this.hehe.Size = new System.Drawing.Size(68, 19);
            this.hehe.TabIndex = 86;
            this.hehe.Text = "Contact";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(44, 180);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(267, 20);
            this.txtContact.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(331, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 82;
            this.label3.Text = "Days of Stay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(331, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 81;
            this.label2.Text = "Booking Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(40, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 80;
            this.label1.Text = "Category";
            // 
            // btndashboard
            // 
            this.btndashboard.AutoSize = true;
            this.btndashboard.BackColor = System.Drawing.Color.Transparent;
            this.btndashboard.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndashboard.ForeColor = System.Drawing.Color.Maroon;
            this.btndashboard.Location = new System.Drawing.Point(40, 92);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Size = new System.Drawing.Size(55, 19);
            this.btndashboard.TabIndex = 79;
            this.btndashboard.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 114);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(267, 20);
            this.txtName.TabIndex = 78;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(493, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 38);
            this.button1.TabIndex = 104;
            this.button1.Text = "CANCEL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Booked_Action_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1168, 358);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtgAvailableRoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNewRoom);
            this.Controls.Add(this.dsd);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.dtpReservationDate);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtDaysOfStay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hehe);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndashboard);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Booked_Action_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD BOOKING";
            this.Load += new System.EventHandler(this.Booked_Action_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAvailableRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtgAvailableRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewRoom;
        private System.Windows.Forms.Label dsd;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDaysOfStay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label hehe;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btndashboard;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
    }
}