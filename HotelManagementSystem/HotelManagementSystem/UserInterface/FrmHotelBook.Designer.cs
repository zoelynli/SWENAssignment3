namespace HotelManagementSystem.UserInterface
{
    partial class FrmHotelBook
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btxttime = new System.Windows.Forms.DateTimePicker();
            this.btxtnotes = new System.Windows.Forms.TextBox();
            this.bcomroomtype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bdqtime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Btxtid = new System.Windows.Forms.TextBox();
            this.B_Custome = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btxtname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btxtphone = new System.Windows.Forms.TextBox();
            this.btxtcardid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bbutdelete = new System.Windows.Forms.Button();
            this.bbutupdate = new System.Windows.Forms.Button();
            this.bbutselect = new System.Windows.Forms.Button();
            this.bbutadd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bcomys = new System.Windows.Forms.ComboBox();
            this.bbutok = new System.Windows.Forms.Button();
            this.bbutnext = new System.Windows.Forms.Button();
            this.bbutprevious = new System.Windows.Forms.Button();
            this.bbutend = new System.Windows.Forms.Button();
            this.bbutfirst = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bbutclear = new System.Windows.Forms.Button();
            this.bbutfalse = new System.Windows.Forms.Button();
            this.bbutslelectroom = new System.Windows.Forms.Button();
            this.Btxtmoney = new System.Windows.Forms.TextBox();
            this.bcomroomid = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.bcomroomid);
            this.groupBox2.Controls.Add(this.Btxtmoney);
            this.groupBox2.Controls.Add(this.btxttime);
            this.groupBox2.Controls.Add(this.btxtnotes);
            this.groupBox2.Controls.Add(this.bcomroomtype);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.bdqtime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Btxtid);
            this.groupBox2.Controls.Add(this.B_Custome);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btxtname);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btxtphone);
            this.groupBox2.Controls.Add(this.btxtcardid);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 517);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // btxttime
            // 
            this.btxttime.CalendarFont = new System.Drawing.Font("SimSun", 9F);
            this.btxttime.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btxttime.Location = new System.Drawing.Point(78, 327);
            this.btxttime.Name = "btxttime";
            this.btxttime.Size = new System.Drawing.Size(111, 21);
            this.btxttime.TabIndex = 53;
            // 
            // btxtnotes
            // 
            this.btxtnotes.Font = new System.Drawing.Font("SimSun", 9F);
            this.btxtnotes.Location = new System.Drawing.Point(9, 429);
            this.btxtnotes.Multiline = true;
            this.btxtnotes.Name = "btxtnotes";
            this.btxtnotes.Size = new System.Drawing.Size(179, 83);
            this.btxtnotes.TabIndex = 52;
            // 
            // bcomroomtype
            // 
            this.bcomroomtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bcomroomtype.Font = new System.Drawing.Font("SimSun", 9F);
            this.bcomroomtype.FormattingEnabled = true;
            this.bcomroomtype.Items.AddRange(new object[] {
            "Single Room",
            "Double Room",
            "Three-Bedroom",
            "Luxury Room",
            "Presidential Room"});
            this.bcomroomtype.Location = new System.Drawing.Point(79, 61);
            this.bcomroomtype.Name = "bcomroomtype";
            this.bcomroomtype.Size = new System.Drawing.Size(111, 20);
            this.bcomroomtype.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-3, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 48;
            this.label8.Text = "Room Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Remarks";
            // 
            // bdqtime
            // 
            this.bdqtime.Font = new System.Drawing.Font("SimSun", 9F);
            this.bdqtime.Location = new System.Drawing.Point(77, 374);
            this.bdqtime.Name = "bdqtime";
            this.bdqtime.Size = new System.Drawing.Size(110, 21);
            this.bdqtime.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "Room No:";
            // 
            // Btxtid
            // 
            this.Btxtid.Font = new System.Drawing.Font("SimSun", 9F);
            this.Btxtid.Location = new System.Drawing.Point(80, 22);
            this.Btxtid.Name = "Btxtid";
            this.Btxtid.ReadOnly = true;
            this.Btxtid.Size = new System.Drawing.Size(111, 21);
            this.Btxtid.TabIndex = 19;
            this.Btxtid.TextChanged += new System.EventHandler(this.Btxtid_TextChanged);
            // 
            // B_Custome
            // 
            this.B_Custome.AutoSize = true;
            this.B_Custome.Location = new System.Drawing.Point(6, 151);
            this.B_Custome.Name = "B_Custome";
            this.B_Custome.Size = new System.Drawing.Size(47, 17);
            this.B_Custome.TabIndex = 20;
            this.B_Custome.Text = "Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Validation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "ID:";
            // 
            // btxtname
            // 
            this.btxtname.Font = new System.Drawing.Font("SimSun", 9F);
            this.btxtname.Location = new System.Drawing.Point(78, 148);
            this.btxtname.Name = "btxtname";
            this.btxtname.Size = new System.Drawing.Size(111, 21);
            this.btxtname.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Book Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Deposit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "IC No:";
            // 
            // btxtphone
            // 
            this.btxtphone.Font = new System.Drawing.Font("SimSun", 9F);
            this.btxtphone.Location = new System.Drawing.Point(78, 238);
            this.btxtphone.Name = "btxtphone";
            this.btxtphone.Size = new System.Drawing.Size(111, 21);
            this.btxtphone.TabIndex = 29;
            // 
            // btxtcardid
            // 
            this.btxtcardid.Font = new System.Drawing.Font("SimSun", 9F);
            this.btxtcardid.Location = new System.Drawing.Point(78, 284);
            this.btxtcardid.Name = "btxtcardid";
            this.btxtcardid.Size = new System.Drawing.Size(111, 21);
            this.btxtcardid.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Contact No:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(232, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(556, 335);
            this.dataGridView1.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bbutdelete);
            this.groupBox1.Controls.Add(this.bbutupdate);
            this.groupBox1.Controls.Add(this.bbutselect);
            this.groupBox1.Controls.Add(this.bbutadd);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(232, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 108);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking Operation";
            // 
            // bbutdelete
            // 
            this.bbutdelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutdelete.Location = new System.Drawing.Point(119, 77);
            this.bbutdelete.Name = "bbutdelete";
            this.bbutdelete.Size = new System.Drawing.Size(69, 25);
            this.bbutdelete.TabIndex = 20;
            this.bbutdelete.Text = "Cancel ";
            this.bbutdelete.UseVisualStyleBackColor = true;
            this.bbutdelete.Click += new System.EventHandler(this.bbutdelete_Click);
            // 
            // bbutupdate
            // 
            this.bbutupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutupdate.Location = new System.Drawing.Point(6, 77);
            this.bbutupdate.Name = "bbutupdate";
            this.bbutupdate.Size = new System.Drawing.Size(61, 25);
            this.bbutupdate.TabIndex = 21;
            this.bbutupdate.Text = "Edit ";
            this.bbutupdate.UseVisualStyleBackColor = true;
            this.bbutupdate.Click += new System.EventHandler(this.bbutupdate_Click);
            // 
            // bbutselect
            // 
            this.bbutselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutselect.Location = new System.Drawing.Point(119, 29);
            this.bbutselect.Name = "bbutselect";
            this.bbutselect.Size = new System.Drawing.Size(69, 25);
            this.bbutselect.TabIndex = 22;
            this.bbutselect.Text = "Check";
            this.bbutselect.UseVisualStyleBackColor = true;
            this.bbutselect.Click += new System.EventHandler(this.bbutselect_Click);
            // 
            // bbutadd
            // 
            this.bbutadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutadd.Location = new System.Drawing.Point(6, 29);
            this.bbutadd.Name = "bbutadd";
            this.bbutadd.Size = new System.Drawing.Size(61, 25);
            this.bbutadd.TabIndex = 19;
            this.bbutadd.Text = "Add ";
            this.bbutadd.UseVisualStyleBackColor = true;
            this.bbutadd.Click += new System.EventHandler(this.bbutadd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bcomys);
            this.groupBox3.Controls.Add(this.bbutok);
            this.groupBox3.Controls.Add(this.bbutnext);
            this.groupBox3.Controls.Add(this.bbutprevious);
            this.groupBox3.Controls.Add(this.bbutend);
            this.groupBox3.Controls.Add(this.bbutfirst);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(452, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 108);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pages";
            // 
            // bcomys
            // 
            this.bcomys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bcomys.FormattingEnabled = true;
            this.bcomys.Location = new System.Drawing.Point(23, 29);
            this.bcomys.Name = "bcomys";
            this.bcomys.Size = new System.Drawing.Size(75, 25);
            this.bcomys.TabIndex = 32;
            this.bcomys.SelectedIndexChanged += new System.EventHandler(this.bcomys_Click);
            // 
            // bbutok
            // 
            this.bbutok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.bbutok.Location = new System.Drawing.Point(23, 75);
            this.bbutok.Name = "bbutok";
            this.bbutok.Size = new System.Drawing.Size(75, 25);
            this.bbutok.TabIndex = 31;
            this.bbutok.Text = "OK";
            this.bbutok.UseVisualStyleBackColor = true;
            this.bbutok.Click += new System.EventHandler(this.bbutok_Click);
            // 
            // bbutnext
            // 
            this.bbutnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutnext.Location = new System.Drawing.Point(235, 76);
            this.bbutnext.Name = "bbutnext";
            this.bbutnext.Size = new System.Drawing.Size(75, 25);
            this.bbutnext.TabIndex = 28;
            this.bbutnext.Text = "Next";
            this.bbutnext.UseVisualStyleBackColor = true;
            this.bbutnext.Click += new System.EventHandler(this.bbutnext_Click);
            // 
            // bbutprevious
            // 
            this.bbutprevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutprevious.Location = new System.Drawing.Point(132, 76);
            this.bbutprevious.Name = "bbutprevious";
            this.bbutprevious.Size = new System.Drawing.Size(75, 25);
            this.bbutprevious.TabIndex = 27;
            this.bbutprevious.Text = "Previous";
            this.bbutprevious.UseVisualStyleBackColor = true;
            this.bbutprevious.Click += new System.EventHandler(this.bbutprevious_Click);
            // 
            // bbutend
            // 
            this.bbutend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutend.Location = new System.Drawing.Point(235, 28);
            this.bbutend.Name = "bbutend";
            this.bbutend.Size = new System.Drawing.Size(75, 25);
            this.bbutend.TabIndex = 26;
            this.bbutend.Text = "End";
            this.bbutend.UseVisualStyleBackColor = true;
            this.bbutend.Click += new System.EventHandler(this.bbutend_Click);
            // 
            // bbutfirst
            // 
            this.bbutfirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutfirst.Location = new System.Drawing.Point(132, 28);
            this.bbutfirst.Name = "bbutfirst";
            this.bbutfirst.Size = new System.Drawing.Size(75, 25);
            this.bbutfirst.TabIndex = 25;
            this.bbutfirst.Text = "First ";
            this.bbutfirst.UseVisualStyleBackColor = true;
            this.bbutfirst.Click += new System.EventHandler(this.bbutfirst_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bbutclear);
            this.groupBox4.Controls.Add(this.bbutfalse);
            this.groupBox4.Controls.Add(this.bbutslelectroom);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(233, 489);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(556, 46);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other Function";
            // 
            // bbutclear
            // 
            this.bbutclear.Font = new System.Drawing.Font("SimSun", 9F);
            this.bbutclear.Location = new System.Drawing.Point(242, 15);
            this.bbutclear.Name = "bbutclear";
            this.bbutclear.Size = new System.Drawing.Size(75, 25);
            this.bbutclear.TabIndex = 29;
            this.bbutclear.Text = "Clear";
            this.bbutclear.UseVisualStyleBackColor = true;
            this.bbutclear.Click += new System.EventHandler(this.bbutclear_Click);
            // 
            // bbutfalse
            // 
            this.bbutfalse.Location = new System.Drawing.Point(454, 13);
            this.bbutfalse.Name = "bbutfalse";
            this.bbutfalse.Size = new System.Drawing.Size(75, 25);
            this.bbutfalse.TabIndex = 28;
            this.bbutfalse.Text = "Exit";
            this.bbutfalse.UseVisualStyleBackColor = true;
            this.bbutfalse.Click += new System.EventHandler(this.bbutfalse_Click);
            // 
            // bbutslelectroom
            // 
            this.bbutslelectroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bbutslelectroom.Location = new System.Drawing.Point(94, 15);
            this.bbutslelectroom.Name = "bbutslelectroom";
            this.bbutslelectroom.Size = new System.Drawing.Size(111, 25);
            this.bbutslelectroom.TabIndex = 27;
            this.bbutslelectroom.Text = "Empty Room";
            this.bbutslelectroom.UseVisualStyleBackColor = true;
            this.bbutslelectroom.Click += new System.EventHandler(this.bbutslelectroom_Click);
            // 
            // Btxtmoney
            // 
            this.Btxtmoney.Font = new System.Drawing.Font("SimSun", 9F);
            this.Btxtmoney.Location = new System.Drawing.Point(78, 191);
            this.Btxtmoney.Name = "Btxtmoney";
            this.Btxtmoney.ReadOnly = true;
            this.Btxtmoney.Size = new System.Drawing.Size(111, 21);
            this.Btxtmoney.TabIndex = 54;
            // 
            // bcomroomid
            // 
            this.bcomroomid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bcomroomid.Font = new System.Drawing.Font("SimSun", 9F);
            this.bcomroomid.FormattingEnabled = true;
            this.bcomroomid.Location = new System.Drawing.Point(80, 108);
            this.bcomroomid.Name = "bcomroomid";
            this.bcomroomid.Size = new System.Drawing.Size(111, 20);
            this.bcomroomid.TabIndex = 55;
            // 
            // FrmHotelBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 556);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmHotelBook";
            this.Text = "Reservation";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker btxttime;
        private System.Windows.Forms.TextBox btxtnotes;
        private System.Windows.Forms.ComboBox bcomroomtype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker bdqtime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Btxtid;
        private System.Windows.Forms.Label B_Custome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox btxtname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox btxtphone;
        private System.Windows.Forms.TextBox btxtcardid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bbutdelete;
        private System.Windows.Forms.Button bbutupdate;
        private System.Windows.Forms.Button bbutselect;
        private System.Windows.Forms.Button bbutadd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox bcomys;
        private System.Windows.Forms.Button bbutok;
        private System.Windows.Forms.Button bbutnext;
        private System.Windows.Forms.Button bbutprevious;
        private System.Windows.Forms.Button bbutend;
        private System.Windows.Forms.Button bbutfirst;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bbutclear;
        private System.Windows.Forms.Button bbutfalse;
        private System.Windows.Forms.Button bbutslelectroom;
        private System.Windows.Forms.ComboBox bcomroomid;
        private System.Windows.Forms.TextBox Btxtmoney;
    }
}