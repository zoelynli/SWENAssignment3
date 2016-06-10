namespace HotelManagementSystem.UserInterface
{
    partial class FrmHotelLoging
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
            this.cmbqu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbmtype = new System.Windows.Forms.ComboBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnout = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.txtanser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbqu
            // 
            this.cmbqu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbqu.FormattingEnabled = true;
            this.cmbqu.Items.AddRange(new object[] {
            "What is your name?"});
            this.cmbqu.Location = new System.Drawing.Point(120, 163);
            this.cmbqu.Name = "cmbqu";
            this.cmbqu.Size = new System.Drawing.Size(132, 21);
            this.cmbqu.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Type: ";
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(120, 84);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(132, 20);
            this.txtpwd.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Password: ";
            // 
            // cbmtype
            // 
            this.cbmtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmtype.FormattingEnabled = true;
            this.cbmtype.Items.AddRange(new object[] {
            "Receptionist",
            "Administration",
            "Manager"});
            this.cbmtype.Location = new System.Drawing.Point(120, 121);
            this.cbmtype.Name = "cbmtype";
            this.cbmtype.Size = new System.Drawing.Size(132, 21);
            this.cbmtype.TabIndex = 30;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(120, 48);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(132, 20);
            this.txtname.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Answer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Question: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "User: ";
            // 
            // btnout
            // 
            this.btnout.Location = new System.Drawing.Point(204, 259);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(75, 25);
            this.btnout.TabIndex = 25;
            this.btnout.Text = "Exit";
            this.btnout.UseVisualStyleBackColor = true;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(42, 259);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 25);
            this.btnok.TabIndex = 24;
            this.btnok.Text = "Confirm";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtanser
            // 
            this.txtanser.Location = new System.Drawing.Point(120, 203);
            this.txtanser.Name = "txtanser";
            this.txtanser.Size = new System.Drawing.Size(132, 20);
            this.txtanser.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "ID: ";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(120, 15);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(132, 20);
            this.txtid.TabIndex = 38;
            // 
            // FrmHotelLoging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 307);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtanser);
            this.Controls.Add(this.cmbqu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbmtype);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnout);
            this.Controls.Add(this.btnok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmHotelLoging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbqu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbmtype;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.TextBox txtanser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtid;
    }
}