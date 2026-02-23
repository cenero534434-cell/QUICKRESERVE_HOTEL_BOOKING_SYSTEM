namespace Hotel_Booking___Reservation_03
{
    partial class Archive_Booking
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnUnarchive = new System.Windows.Forms.Button();
            this.dtgArchiveReservation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchiveReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.label1.Location = new System.Drawing.Point(275, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 39;
            this.label1.Text = "ARCHIVE BOOKING";
            // 
            // btnUnarchive
            // 
            this.btnUnarchive.BackColor = System.Drawing.Color.Snow;
            this.btnUnarchive.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnarchive.ForeColor = System.Drawing.Color.Maroon;
            this.btnUnarchive.Location = new System.Drawing.Point(640, 375);
            this.btnUnarchive.Name = "btnUnarchive";
            this.btnUnarchive.Size = new System.Drawing.Size(148, 51);
            this.btnUnarchive.TabIndex = 38;
            this.btnUnarchive.Text = "UNARCHIVE";
            this.btnUnarchive.UseVisualStyleBackColor = false;
            this.btnUnarchive.Click += new System.EventHandler(this.btnUnarchive_Click);
            // 
            // dtgArchiveReservation
            // 
            this.dtgArchiveReservation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgArchiveReservation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgArchiveReservation.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dtgArchiveReservation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgArchiveReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArchiveReservation.GridColor = System.Drawing.SystemColors.Control;
            this.dtgArchiveReservation.Location = new System.Drawing.Point(12, 57);
            this.dtgArchiveReservation.Name = "dtgArchiveReservation";
            this.dtgArchiveReservation.RowHeadersVisible = false;
            this.dtgArchiveReservation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgArchiveReservation.Size = new System.Drawing.Size(776, 312);
            this.dtgArchiveReservation.TabIndex = 37;
            this.dtgArchiveReservation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchiveReservation_CellContentClick);
            // 
            // Archive_Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnarchive);
            this.Controls.Add(this.dtgArchiveReservation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Archive_Booking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchiveReservation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUnarchive;
        private System.Windows.Forms.DataGridView dtgArchiveReservation;
    }
}