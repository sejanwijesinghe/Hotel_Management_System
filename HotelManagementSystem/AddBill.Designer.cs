namespace HotelManagementSystem
{
    partial class AddBill
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeltext = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2ComboBoxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ComboBox1Reservation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ComboBoxMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textAdvance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMainPayment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.labeltext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 90);
            this.panel1.TabIndex = 5;
            // 
            // labeltext
            // 
            this.labeltext.AutoSize = true;
            this.labeltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltext.ForeColor = System.Drawing.Color.White;
            this.labeltext.Location = new System.Drawing.Point(32, 31);
            this.labeltext.Name = "labeltext";
            this.labeltext.Size = new System.Drawing.Size(104, 29);
            this.labeltext.TabIndex = 0;
            this.labeltext.Text = "Add Bill";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.guna2ComboBoxStatus);
            this.panel2.Controls.Add(this.guna2ComboBox1Reservation);
            this.panel2.Controls.Add(this.guna2ComboBoxMethod);
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textAdvance);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxMainPayment);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(40, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 731);
            this.panel2.TabIndex = 6;
            // 
            // guna2ComboBoxStatus
            // 
            this.guna2ComboBoxStatus.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBoxStatus.BorderColor = System.Drawing.Color.Black;
            this.guna2ComboBoxStatus.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBoxStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxStatus.FocusedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBoxStatus.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxStatus.ItemHeight = 30;
            this.guna2ComboBoxStatus.Items.AddRange(new object[] {
            "Paid",
            "Pending",
            "Overdue"});
            this.guna2ComboBoxStatus.ItemsAppearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxStatus.ItemsAppearance.SelectedFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxStatus.Location = new System.Drawing.Point(47, 374);
            this.guna2ComboBoxStatus.Name = "guna2ComboBoxStatus";
            this.guna2ComboBoxStatus.Size = new System.Drawing.Size(399, 36);
            this.guna2ComboBoxStatus.TabIndex = 5;
            // 
            // guna2ComboBox1Reservation
            // 
            this.guna2ComboBox1Reservation.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1Reservation.BorderColor = System.Drawing.Color.Black;
            this.guna2ComboBox1Reservation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1Reservation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1Reservation.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1Reservation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1Reservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBox1Reservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1Reservation.ItemHeight = 30;
            this.guna2ComboBox1Reservation.Location = new System.Drawing.Point(45, 45);
            this.guna2ComboBox1Reservation.Name = "guna2ComboBox1Reservation";
            this.guna2ComboBox1Reservation.Size = new System.Drawing.Size(399, 36);
            this.guna2ComboBox1Reservation.TabIndex = 5;
            this.guna2ComboBox1Reservation.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1Reservation_SelectedIndexChanged);
            // 
            // guna2ComboBoxMethod
            // 
            this.guna2ComboBoxMethod.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBoxMethod.BorderColor = System.Drawing.Color.Black;
            this.guna2ComboBoxMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBoxMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBoxMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBoxMethod.ItemHeight = 30;
            this.guna2ComboBoxMethod.Items.AddRange(new object[] {
            "Credit Card",
            "Cash",
            "Online Payment"});
            this.guna2ComboBoxMethod.Location = new System.Drawing.Point(47, 483);
            this.guna2ComboBoxMethod.Name = "guna2ComboBoxMethod";
            this.guna2ComboBoxMethod.Size = new System.Drawing.Size(399, 36);
            this.guna2ComboBoxMethod.TabIndex = 5;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Blue;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.guna2Button1.Location = new System.Drawing.Point(49, 619);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(159, 45);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Save";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Payment Status:";
            // 
            // textAdvance
            // 
            this.textAdvance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAdvance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAdvance.Location = new System.Drawing.Point(47, 254);
            this.textAdvance.Name = "textAdvance";
            this.textAdvance.Size = new System.Drawing.Size(399, 45);
            this.textAdvance.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Payment Method:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Advance payment:";
            // 
            // textBoxMainPayment
            // 
            this.textBoxMainPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMainPayment.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMainPayment.Location = new System.Drawing.Point(45, 144);
            this.textBoxMainPayment.Name = "textBoxMainPayment";
            this.textBoxMainPayment.Size = new System.Drawing.Size(399, 45);
            this.textBoxMainPayment.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Main payment:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservation ID:";
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            // 
            // AddBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(732, 894);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBill";
            this.Load += new System.EventHandler(this.AddBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labeltext;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBoxStatus;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBoxMethod;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAdvance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMainPayment;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1Reservation;
        private System.Windows.Forms.ErrorProvider errorProvider5;
    }
}