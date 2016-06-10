using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace HotelManagementSystem.UserInterface
{
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }

        private void btnfindID_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            string str = @"[0-9]{1,2}";
            if (txtfindID.Text == "")
            {
                MessageBox.Show("Pls enter Room No");
            }
            else if (!Regex.IsMatch(txtfindID.Text, str))
            {
                MessageBox.Show("Only 1 or 2 numbers");
            }
            else
            {
                SqlDataReader dr = BLL.CustomerBLL.BllSelectoneID(int.Parse(this.txtfindID.Text));
                while (dr.Read())
                {
                    ListViewItem lv = this.listView1.Items.Add(dr[0].ToString());
                    lv.SubItems.Add(dr[1].ToString());
                    lv.SubItems.Add(dr[2].ToString());
                    lv.SubItems.Add(dr[3].ToString());
                    lv.SubItems.Add(dr[4].ToString());
                    lv.SubItems.Add(dr[5].ToString());
                    lv.SubItems.Add(dr[6].ToString());
                }
            }

        }

        private void btncheckout_Click(object sender, EventArgs e)
        {
            if (txtfindID.Text == "")
            {
                MessageBox.Show("Pls select room");
            }
            else
            {
                bool id = BLL.CustomerBLL.BllUpdate(int.Parse(this.txtfindID.Text));
                if (id)
                {
                    listView1.Items.Clear();
                    SqlDataReader dr = BLL.CustomerBLL.BllSelectID(int.Parse(this.txtfindID.Text));
                    while (dr.Read())
                    {
                        ListViewItem lv = this.listView2.Items.Add(dr[0].ToString());
                        lv.SubItems.Add(dr[1].ToString());
                        lv.SubItems.Add(dr[2].ToString());
                        lv.SubItems.Add(dr[3].ToString());
                        lv.SubItems.Add(dr[4].ToString());
                        lv.SubItems.Add(dr[5].ToString());
                        lv.SubItems.Add(dr[6].ToString());
                    }
                    MessageBox.Show("Check out Successful");
                }
                else
                {
                    MessageBox.Show("Check out Failed");
                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            ListViewItem lv = this.listView1.SelectedItems[0];
            this.cmbID.Text = lv.Text;
            this.txtroompr.Text = lv.SubItems[1].Text;
            this.cmbtype.Text = lv.SubItems[2].Text;
            this.cbmstatus.Text = lv.SubItems[3].Text;
            this.dtime.Text = lv.SubItems[4].Text;
            this.douttime.Text = lv.SubItems[5].Text;
            this.txtinf.Text = lv.SubItems[6].Text;
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbID.Items.Clear();
            SqlDataReader dr = BLL.CustomerBLL.BllSelectID(cmbtype.Text.ToString());

            while (dr.Read())
            {
                cmbID.Items.Add(dr[0].ToString());
            }
            if (cmbtype.Text.ToString() == "Single Room")
            {

                this.txtroompr.Text = (130).ToString();
            }
            else if (cmbtype.Text.ToString() == "Double Room")
            {

                this.txtroompr.Text = (130).ToString();
            }
            else if (cmbtype.Text.ToString() == "Three-Bedroom")
            {

                this.txtroompr.Text = (150).ToString();
            }
            else if (cmbtype.Text.ToString() == "Luxury Room")
            {

                this.txtroompr.Text = (280).ToString();
            }
            else if (cmbtype.Text.ToString() == "Presidential Room")
            {
                this.txtroompr.Text = (588).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmbtype.Text == "")
            {
                MessageBox.Show("Pls enter Room Type ");
            }
            else if (cbmstatus.Text == "")
            {
                MessageBox.Show("Pls enter Room Status");
            }
            else if (cmbID.Text == "")
            {
                MessageBox.Show("Pls enter Room No");
            }
            else if (txtroompr.Text == "")
            {
                MessageBox.Show("Pls Enter Price");
            }
            else
            {
                bool id = BLL.CustomerBLL.BllUpdate(this.dtime.Text.ToString(), this.douttime.Text.ToString(), int.Parse(this.cmbID.Text));
                if (id)
                {
                    listView1.Items.Clear();
                    SqlDataReader dr = BLL.CustomerBLL.BllSelectID(int.Parse(this.cmbID.Text));
                    while (dr.Read())
                    {
                        ListViewItem lv = this.listView2.Items.Add(dr[0].ToString());
                        lv.SubItems.Add(dr[1].ToString());
                        lv.SubItems.Add(dr[2].ToString());
                        lv.SubItems.Add(dr[3].ToString());
                        lv.SubItems.Add(dr[4].ToString());
                        lv.SubItems.Add(dr[5].ToString());
                        lv.SubItems.Add(dr[6].ToString());
                    }
                    MessageBox.Show("Extension Successful");
                }
                else
                {
                    MessageBox.Show("Extension Failed");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtfindID.Text == "")
            {
                MessageBox.Show("Retrieve room no if you not enter the change room no ");
            }
            else if (cmbtype.Text == "")
            {
                MessageBox.Show("Pls enter Room Type");
            }
            else if (cbmstatus.Text == "")
            {
                MessageBox.Show("Pls enter Room Status");
            }
            else if (cmbID.Text == "")
            {
                MessageBox.Show("Pls enter Room No");
            }
            else if (txtroompr.Text == "")
            {
                MessageBox.Show("Pls enter Price");
            }
            else
            {
                bool id = BLL.CustomerBLL.BllUpdate(int.Parse(this.txtfindID.Text));
                bool id1 = BLL.CustomerBLL.BllUpdate1(int.Parse(this.cmbID.Text));
                if (id1)
                {
                    listView1.Items.Clear();
                    SqlDataReader dr = BLL.CustomerBLL.BllSelectoneID(int.Parse(this.cmbID.Text));
                    while (dr.Read())
                    {
                        ListViewItem lv = this.listView2.Items.Add(dr[0].ToString());
                        lv.SubItems.Add(dr[1].ToString());
                        lv.SubItems.Add(dr[2].ToString());
                        lv.SubItems.Add(dr[3].ToString());
                        lv.SubItems.Add(dr[4].ToString());
                        lv.SubItems.Add(dr[5].ToString());
                        lv.SubItems.Add(dr[6].ToString());
                    }
                    MessageBox.Show("Change Room Successful");
                }
                else
                {
                    MessageBox.Show("Change Room Failed");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmbtype.Text = null;
            cbmstatus.Text = null;
            cmbID.Text = null;
            txtroompr.Text = "";
            txtinf.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Pls follow the room type to select room no");
        }

    }
}