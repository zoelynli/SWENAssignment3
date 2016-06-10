using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem.UserInterface
{
    public partial class FrmHotelMain : Form
    {
        string type = null;
        string name = null;

        public FrmHotelMain(string name, string type)
        {
            this.type = type;
            this.name = name;
            InitializeComponent();
        }

        ListViewItem lv = null;

        private void HotelManager_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = type;
            toolStripStatusLabel4.Text = name;

            lb1.Text = (25).ToString();
            lb2.Text = (BLL.CustomerBLL.BllSelectID()).ToString();
            lb3.Text = (BLL.CustomerBLL.BllSelectEmpty()).ToString();
            lb4.Text = (BLL.CustomerBLL.BllSelectBooking()).ToString();
            lb5.Text = (BLL.CustomerBLL.BllSelectCleaning()).ToString();
            lb6.Text = (BLL.CustomerBLL.BllSelectmoney()).ToString();

            SqlDataReader dr = BLL.CustomerBLL.BllSelectAllType();
            while (dr.Read())
            {
                lv = this.listView2.Items.Add(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[4].ToString());
                lv.SubItems.Add(dr[5].ToString());
                lv.SubItems.Add(dr[6].ToString());
            }
            SqlDataReader dr1 = BLL.CustomerBLL.BllSelectAllType1();
            while (dr1.Read())
            {
                lv = this.listView3.Items.Add(dr1[0].ToString());
                lv.SubItems.Add(dr1[1].ToString());
                lv.SubItems.Add(dr1[2].ToString());
                lv.SubItems.Add(dr1[3].ToString());
                lv.SubItems.Add(dr1[4].ToString());
                lv.SubItems.Add(dr1[5].ToString());
                lv.SubItems.Add(dr1[6].ToString());
            }
            SqlDataReader dr2 = BLL.CustomerBLL.BllSelectAllType2();
            while (dr2.Read())
            {
                lv = this.listView4.Items.Add(dr2[0].ToString());
                lv.SubItems.Add(dr2[1].ToString());
                lv.SubItems.Add(dr2[2].ToString());
                lv.SubItems.Add(dr2[3].ToString());
                lv.SubItems.Add(dr2[4].ToString());
                lv.SubItems.Add(dr2[5].ToString());
                lv.SubItems.Add(dr2[6].ToString());

            }
            SqlDataReader dr3 = BLL.CustomerBLL.BllSelectAllType3();
            while (dr3.Read())
            {
                lv = this.listView5.Items.Add(dr3[0].ToString());
                lv.SubItems.Add(dr3[1].ToString());
                lv.SubItems.Add(dr3[2].ToString());
                lv.SubItems.Add(dr3[3].ToString());
                lv.SubItems.Add(dr3[4].ToString());
                lv.SubItems.Add(dr3[5].ToString());
                lv.SubItems.Add(dr3[6].ToString());

            }
            SqlDataReader dr4 = BLL.CustomerBLL.BllSelectAllType4();
            while (dr4.Read())
            {
                lv = this.listView6.Items.Add(dr4[0].ToString());
                lv.SubItems.Add(dr4[1].ToString());
                lv.SubItems.Add(dr4[2].ToString());
                lv.SubItems.Add(dr4[3].ToString());
                lv.SubItems.Add(dr4[4].ToString());
                lv.SubItems.Add(dr4[5].ToString());
                lv.SubItems.Add(dr4[6].ToString());

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel5.Text = DateTime.Now.ToString();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FrmHotelBook fhb = new FrmHotelBook();
            fhb.ShowDialog();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lv = listView2.SelectedItems[0];
            label7.Text = lv.Text;
            SqlDataReader dr = BLL.CustomerBLL.BllSelectExpense(int.Parse(lv.Text));
            label9.Text = (BLL.CustomerBLL.BllSelectmain(int.Parse(lv.Text))).ToString();
            while (dr.Read())
            {
                lv = this.listView1.Items.Add(dr[0].ToString());
                lv.SubItems.Add(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[4].ToString());
                lv.SubItems.Add(dr[5].ToString());
                lv.SubItems.Add(dr[6].ToString());
                lv.SubItems.Add(dr[7].ToString());
                label11.Text = dr[7].ToString();

            }

        }
        private void listView3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lv = listView3.SelectedItems[0];
            label7.Text = lv.Text;
            SqlDataReader dr = BLL.CustomerBLL.BllSelectExpense(int.Parse(lv.Text));
            label9.Text = (BLL.CustomerBLL.BllSelectmain(int.Parse(lv.Text))).ToString();
            while (dr.Read())
            {
                lv = this.listView1.Items.Add(dr[0].ToString());
                lv.SubItems.Add(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[4].ToString());
                lv.SubItems.Add(dr[5].ToString());
                lv.SubItems.Add(dr[6].ToString());
                lv.SubItems.Add(dr[7].ToString());
                label11.Text = dr[7].ToString();

            }

        }

        private void listView4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lv = listView4.SelectedItems[0];
            label7.Text = lv.Text;
            SqlDataReader dr = BLL.CustomerBLL.BllSelectExpense(int.Parse(lv.Text));
            label9.Text = (BLL.CustomerBLL.BllSelectmain(int.Parse(lv.Text))).ToString();
            while (dr.Read())
            {
                lv = this.listView1.Items.Add(dr[0].ToString());
                lv.SubItems.Add(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[4].ToString());
                lv.SubItems.Add(dr[5].ToString());
                lv.SubItems.Add(dr[6].ToString());
                lv.SubItems.Add(dr[7].ToString());
                label11.Text = dr[7].ToString();

            }

        }

        private void listView5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lv = listView5.SelectedItems[0];
            label7.Text = lv.Text;
            SqlDataReader dr = BLL.CustomerBLL.BllSelectExpense(int.Parse(lv.Text));
            label9.Text = (BLL.CustomerBLL.BllSelectmain(int.Parse(lv.Text))).ToString();
            while (dr.Read())
            {
                lv = this.listView1.Items.Add(dr[0].ToString());
                lv.SubItems.Add(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[4].ToString());
                lv.SubItems.Add(dr[5].ToString());
                lv.SubItems.Add(dr[6].ToString());
                lv.SubItems.Add(dr[7].ToString());
                label11.Text = dr[7].ToString();

            }

        }

        private void listView6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lv = listView6.SelectedItems[0];
            label7.Text = lv.Text;
            SqlDataReader dr = BLL.CustomerBLL.BllSelectExpense(int.Parse(lv.Text));
            label9.Text = (BLL.CustomerBLL.BllSelectmain(int.Parse(lv.Text))).ToString();
            while (dr.Read())
            {
                lv = this.listView1.Items.Add(dr[0].ToString());
                lv.SubItems.Add(dr[0].ToString());
                lv.SubItems.Add(dr[1].ToString());
                lv.SubItems.Add(dr[2].ToString());
                lv.SubItems.Add(dr[3].ToString());
                lv.SubItems.Add(dr[4].ToString());
                lv.SubItems.Add(dr[5].ToString());
                lv.SubItems.Add(dr[6].ToString());
                lv.SubItems.Add(dr[7].ToString());
                label11.Text = dr[7].ToString();

            }

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (type == "Administration")
            {
                FrmHotelLoging fhlg = new FrmHotelLoging();
                fhlg.Show();
            }
            else
            {
                MessageBox.Show("Unauthority");
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            FrmHotelBook fhb = new FrmHotelBook();
            fhb.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            FrmCustomerInf fci = new FrmCustomerInf();
            fci.ShowDialog();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            FrmHotelRoom fhr = new FrmHotelRoom();
            fhr.ShowDialog();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            FrmHotelVip vip = new FrmHotelVip();
            vip.ShowDialog();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            FrmHotelExpense fhe = new FrmHotelExpense();
            fhe.ShowDialog();
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            FrmHotelLogin fhl = new FrmHotelLogin();
            fhl.ShowDialog();
            this.Close();
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Lock？", "Remind", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmHotelSP sp = new FrmHotelSP();
                sp.ShowDialog();
            }
        }

        private void toolStripButton15_Click_1(object sender, EventArgs e)
        {
            DialogResult drt = MessageBox.Show("Exit？", "Remind", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drt == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LogoffToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmHotelLogin fhl = new FrmHotelLogin();
            fhl.ShowDialog();
            this.Close();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePswdMToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (type == "Administration")
            {
                FrmHotelbakePwd fhbp = new FrmHotelbakePwd();
                fhbp.Show();
            }
            else
            {
                MessageBox.Show("Unauthority");
            }
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            FrmCustomerInf fcti = new FrmCustomerInf();
            fcti.ShowDialog();
        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {
            FrmRoom fr = new FrmRoom();
            fr.ShowDialog();
        }

        private void toolStripButton12_Click_1(object sender, EventArgs e)
        {
            FrmRoom fr1 = new FrmRoom();
            fr1.ShowDialog();
        }

        private void toolStripButton13_Click_1(object sender, EventArgs e)
        {
            FrmRoom fr1 = new FrmRoom();
            fr1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }



 

    }
}
