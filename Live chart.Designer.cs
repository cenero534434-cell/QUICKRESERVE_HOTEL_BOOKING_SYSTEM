namespace Hotel_Booking___Reservation_03
{
    partial class Live_chart
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.btnYear = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnDay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(12, 29);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(941, 340);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // btnYear
            // 
            this.btnYear.Location = new System.Drawing.Point(657, 375);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(97, 39);
            this.btnYear.TabIndex = 1;
            this.btnYear.Text = "YEAR";
            this.btnYear.UseVisualStyleBackColor = true;
            this.btnYear.Click += new System.EventHandler(this.btnYear_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(544, 375);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(97, 39);
            this.btnMonth.TabIndex = 2;
            this.btnMonth.Text = "MONTH";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnDay
            // 
            this.btnDay.Location = new System.Drawing.Point(431, 375);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(97, 39);
            this.btnDay.TabIndex = 3;
            this.btnDay.Text = "DAY";
            this.btnDay.UseVisualStyleBackColor = true;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // Live_chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.btnDay);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnYear);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "Live_chart";
            this.Text = "Live_chart";
            this.Load += new System.EventHandler(this.Live_chart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button btnYear;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnDay;
    }
}