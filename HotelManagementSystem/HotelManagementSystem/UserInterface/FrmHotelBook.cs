using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HotelManagementSystem.UserInterface
{
    public partial class FrmHotelBook : Form
    {
        int a, b;
        int y = 1;
        public FrmHotelBook()
        {
            InitializeComponent();
        }
        public void clear()
        {
            this.Btxtid.Text = "";
            this.btxtname.Text = "";
            this.Btxtmoney.Text = "";
            this.btxtphone.Text = "";
            this.btxtcardid.Text = "";
            this.bcomroomtype.Text = "";
            this.bcomroomid.Text = "";
            this.btxttime.Text = "";
            this.bdqtime.Text = "";
            this.btxtnotes.Text = "";

        }
        public void dgv()
        {
            dataGridView1.Columns.Add("B_Id", "ID");
            dataGridView1.Columns[0].DataPropertyName = "B_ID";
            dataGridView1.Columns.Add("B_Customer", "Name");
            dataGridView1.Columns[1].DataPropertyName = "B_Customer";
            dataGridView1.Columns.Add("B_AllMoney", "Deposit");
            dataGridView1.Columns[2].DataPropertyName = "B_AllMoney";
            dataGridView1.Columns.Add("B_Phone", "ContactNo");
            dataGridView1.Columns[3].DataPropertyName = "B_Phone";
            dataGridView1.Columns.Add("B_CardId", "ICNo");
            dataGridView1.Columns[4].DataPropertyName = "B_CardId";
            dataGridView1.Columns.Add("B_time", "Check In");
            dataGridView1.Columns[5].DataPropertyName = "B_time";
            dataGridView1.Columns.Add("B_daoqitime", "Check Out");
            dataGridView1.Columns[6].DataPropertyName = "B_daoqitime";
            dataGridView1.Columns.Add("R_type", "RoomTYpe");
            dataGridView1.Columns[7].DataPropertyName = "R_type";
            dataGridView1.Columns.Add("R_ID", "RoomId");
            dataGridView1.Columns[8].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("B_Notes", "Remarks");
            dataGridView1.Columns[9].DataPropertyName = "B_Notes";
        }
        public void dgvroom()
        {
            dataGridView1.Columns.Add("R_ID", "RoomId");
            dataGridView1.Columns[0].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("R_money", "Price");
            dataGridView1.Columns[1].DataPropertyName = "R_money";
            dataGridView1.Columns.Add("R_type", "RoomType");
            dataGridView1.Columns[2].DataPropertyName = "R_type";
            dataGridView1.Columns.Add("R_status", "Status");
            dataGridView1.Columns[3].DataPropertyName = "R_status";
            dataGridView1.Columns.Add("R_notes", "Remarks");
            dataGridView1.Columns[4].DataPropertyName = "R_notes";
        }

        private void bbutselect_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            DataSet ds = new DataSet();
            ds = BLL.B_bll.dataread();
            dgv();
            dataGridView1.DataSource = ds.Tables[0];
            clear();
        }
        string rgphone = "^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$";
        string rgcardid = "^[0-9][0-9][0-9][0-9][0-9][0-9][0-9]$";
        string rgcardid1 = "^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][x]$";

        private void bbutadd_Click(object sender, EventArgs e)
        {
            if (btxtname.Text != "" && Btxtmoney.Text != null && btxtcardid.Text != "" && btxtphone.Text != "" && bcomroomid.Text != "" && bcomroomtype.Text != "")
            {
                if (this.bcomroomtype.Text == "Single Room".Trim() || bcomroomtype.Text == "Double Room".Trim() || bcomroomtype.Text == "Luxury Room ".Trim() || bcomroomtype.Text == "Three-Bedroom".Trim() || bcomroomtype.Text == "Presidential Room".Trim())
                {
                    string flag2 = BLL.B_bll.selectRoomid(this.bcomroomid.Text);
                    if (flag2 == "Empty")
                    {
                        if (Regex.IsMatch(this.btxtphone.Text, rgphone))
                        {
                            if (Regex.IsMatch(this.btxtcardid.Text, rgcardid) || Regex.IsMatch(this.btxtcardid.Text, rgcardid1))
                            {
                                if (this.bdqtime.Value > this.btxttime.Value)
                                {

                                    bool flag1 = BLL.B_bll.selectcarid(this.btxtcardid.Text.ToString());
                                    if (!flag1)
                                    {
                                        Boxcs bx = new Boxcs();
                                        bx.Name = this.btxtname.Text.ToString();
                                        bx.Money = double.Parse(this.Btxtmoney.Text);
                                        bx.Phone = this.btxtphone.Text.ToString();
                                        bx.Cardid = this.btxtcardid.Text.ToString();
                                        bx.Yutime = this.btxttime.Text.ToString();
                                        bx.Dqtime = this.bdqtime.Text.ToString();
                                        bx.Roomid = int.Parse(bcomroomid.Text);
                                        bx.Notes = this.btxtnotes.Text.ToString();
                                        bool flag = new BLL.B_bll().addExecuteQuery(bx);
                                        if (!flag)
                                        {
                                            MessageBox.Show("Add Failed");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Add Successful");
                                            bool bflag = new BLL.B_bll().updataR_status(int.Parse(bcomroomid.Text.ToString()));
                                            clear();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("IC No repeated！！！");
                                        this.btxtcardid.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ceeck out must greater than Check in！！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("IC Wrong!!!");
                                this.btxtcardid.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contact No Wrong!!!!");
                            this.btxtphone.Text = "";

                        }
                    }
                    else
                    {
                        MessageBox.Show("Room No Wrong！");
                    }

                }



                else
                {
                    MessageBox.Show("Room Type Wrong！！");
                    this.bcomroomtype.Text = "";
                }

            }

            else
            {
                MessageBox.Show("No Empty Field！！");
            }
            dataGridView1.Columns.Clear();
            DataSet ds = new DataSet();
            ds = BLL.B_bll.dataread();
            dgv();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void bbutupdate_Click(object sender, EventArgs e)
        {

            if (this.btxtcardid.Text != "")
            {
                if (btxtname.Text != "" && Btxtmoney.Text != null && btxtcardid.Text != "" && btxtphone.Text != "" && bcomroomid.Text != "" && bcomroomtype.Text != "")
                {
                    if (this.bcomroomtype.Text == "Single Room".Trim() || bcomroomtype.Text == "Double Room".Trim() || bcomroomtype.Text == "Luxury Room ".Trim() || bcomroomtype.Text == "three-Bedroom".Trim() || bcomroomtype.Text == "Presidential Room".Trim())
                    {
                        string flag2 = BLL.B_bll.selectRoomid(this.bcomroomid.Text);
                        if (flag2 == "Empty Room    ")
                        {
                            if (Regex.IsMatch(this.btxtphone.Text, rgphone))
                            {

                                if (Regex.IsMatch(this.btxtcardid.Text, rgcardid) || Regex.IsMatch(this.btxtcardid.Text, rgcardid1))
                                {
                                    if (this.bdqtime.Value > this.btxttime.Value)
                                    {
                                        Boxcs bx = new Boxcs();
                                        bx.Id = int.Parse(this.Btxtid.Text);
                                        bx.Name = this.btxtname.Text.ToString();
                                        bx.Money = double.Parse(this.Btxtmoney.Text);
                                        bx.Phone = this.btxtphone.Text.ToString();
                                        bx.Cardid = this.btxtcardid.Text.ToString();
                                        bx.Yutime = this.btxttime.Text.ToString();
                                        bx.Dqtime = this.bdqtime.Text.ToString();
                                        bx.Roomid = int.Parse(bcomroomid.Text);
                                        bx.Notes = this.btxtnotes.Text.ToString();
                                        DialogResult dr = MessageBox.Show("Confirm Change！！！", "Remind", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                        if (dr == DialogResult.Yes)
                                        {
                                            bool flag = new BLL.B_bll().updateExecuteQuery(bx);
                                            if (!flag)
                                            {
                                                MessageBox.Show("Change Failed");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Change Successful");
                                            }
                                            clear();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Validation data must Greater than Booking date！！");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("IC No Wrong！！！");
                                    this.btxtcardid.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Contact No Wrong");
                                this.btxtphone.Text = "";
                            }

                        }
                        else
                        {
                            MessageBox.Show("Room No Wrong！");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Room Type Wrong！！！");
                        this.bcomroomtype.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("No Empty Field！！！！");
                }
                dataGridView1.Columns.Clear();
                DataSet ds = new DataSet();
                ds = BLL.B_bll.dataread();
                dgv();
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Pls select to change ！！！！");
            }


        }

        private void bbutdelete_Click(object sender, EventArgs e)
        {
            if (this.btxtcardid.Text != "")
            {
                a = int.Parse(BLL.B_bll.selecttopend().ToString());
                int b = (a + 3 - 1) / 3;
                if (a == 0)
                {
                    MessageBox.Show("No Booking Information, pls add！！！");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Confirm delete！！！！", "Remind", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        bool flag = new BLL.B_bll().deleteExecuteQuery(int.Parse(this.Btxtid.Text));
                        if (!flag)
                        {
                            MessageBox.Show("Delet Failed");
                        }
                        else
                        {
                            MessageBox.Show("Delete Successful");
                        }
                        clear();
                    }
                    dataGridView1.Columns.Clear();
                    DataSet ds = new DataSet();
                    ds = BLL.B_bll.dataread();
                    dgv();
                    dataGridView1.DataSource = ds.Tables[0];
                    clear();
                }
            }
            else
            {
                MessageBox.Show("pls select to delete！！！");
            }

        }

        private void bbutfirst_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            DataSet ds = new DataSet();
            ds = BLL.B_bll.selecttopfirst();
            dgv();
            dataGridView1.DataSource = ds.Tables[0];
            y = 1;

        }

        private void bbutprevious_Click(object sender, EventArgs e)
        {
            y--;
            dataGridView1.Columns.Clear();
            if (y > 0)
            {
                DataSet ds = new DataSet();
                ds = BLL.B_bll.selecttopy(y);
                dgv();
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                y++;
                dataGridView1.Columns.Clear();
                DataSet ds = new DataSet();
                ds = BLL.B_bll.selecttopfirst();
                dgv();
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("This is First Page");
            }

        }

        private void bbutnext_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            a = int.Parse(BLL.B_bll.selecttopend().ToString());
            int b = (a + 3 - 1) / 3;

            y++;
            DataSet ds = new DataSet();
            ds = BLL.B_bll.selecttopy(y);
            dgv();
            dataGridView1.DataSource = ds.Tables[0];
            if (y > b)
            {
                y--;
                DataSet dsend = BLL.B_bll.selecttopy(b);
                dataGridView1.Columns.Clear();
                dgv();
                dataGridView1.DataSource = dsend.Tables[0];
                MessageBox.Show("This is Last Page");
            }

        }

        private void bbutend_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            a = int.Parse(BLL.B_bll.selecttopend().ToString());
            int b = (a + 3 - 1) / 3;
            DataSet ds = BLL.B_bll.selecttopy(b);
            dgv();
            dataGridView1.DataSource = ds.Tables[0];
            this.bcomys.Items.Clear();
            a = int.Parse(BLL.B_bll.selecttopend().ToString());
            b = (a + 3 - 1) / 3;
            y = b;

        }

        private void selectroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bcomroomtype.Text == "Single Room")
                this.Btxtmoney.Text = (200).ToString();
            if (this.bcomroomtype.Text == "Double Room")
                this.Btxtmoney.Text = (200).ToString();
            if (this.bcomroomtype.Text == "Three-Bedroom")
                this.Btxtmoney.Text = (200).ToString();
            if (this.bcomroomtype.Text == "Luxury Room")
                this.Btxtmoney.Text = (450).ToString();
            if (this.bcomroomtype.Text == "Presidential Room")
                this.Btxtmoney.Text = (700).ToString();

            if (this.bcomroomtype.Text != "")
            {

                string type = this.bcomroomtype.Text.ToString();
                SqlDataReader reader = BLL.B_bll.selectroom(type);
                while (reader.Read())
                    bcomroomid.Items.Add(reader[0]);

                dataGridView1.Columns.Clear();
                DataSet ds = BLL.B_bll.selectroomtype(type);
                dgvroom();
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Pls Select Room Type");

            }

        }
        private void selectroomtype_Click(object sender, EventArgs e)
        {

            this.bcomroomid.Items.Clear();
            this.bcomroomid.Text = "";
        }

        private void bcomroomid_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            DataSet ds = new DataSet();
            ds = BLL.B_bll.selectroomid(int.Parse(this.bcomroomid.Text));
            dgvroom();
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                this.Btxtid.Text = row.Cells[0].Value.ToString();
                this.btxtname.Text = row.Cells[1].Value.ToString();
                this.Btxtmoney.Text = row.Cells[2].Value.ToString();
                this.btxtphone.Text = row.Cells[3].Value.ToString();
                this.btxtcardid.Text = row.Cells[4].Value.ToString();
                this.btxttime.Text = row.Cells[5].Value.ToString();
                this.bdqtime.Text = row.Cells[6].Value.ToString();
                this.bcomroomtype.Text = row.Cells[7].Value.ToString();
                this.bcomroomid.Text = row.Cells[8].Value.ToString();
                this.btxtnotes.Text = row.Cells[9].Value.ToString();

            }
            catch
            {
                this.bcomroomid.Text = "";
                this.bcomroomtype.Text = "";
                this.btxtname.Text = "";
                this.Btxtmoney.Text = "";
                this.btxtphone.Text = "";
                this.btxtcardid.Text = "";
                this.Btxtid.Text = "";
            }
        }

        private void bbutok_Click(object sender, EventArgs e)
        {
            if (this.bcomys.Text != "")
            {
                this.dataGridView1.Columns.Clear();
                y = int.Parse(this.bcomys.Text);
                DataSet ds = BLL.B_bll.selecttopy(y);
                dgv();
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Pls select page！！！");
            }

        }

        private void bcomys_Click(object sender, EventArgs e)
        {
            this.bcomys.Items.Clear();
            a = int.Parse(BLL.B_bll.selecttopend().ToString());
            b = (a + 3 - 1) / 3;
            for (int i = 1; i <= b; i++)
            {
                bcomys.Items.Add(i);
            }
        }

        private void bbutslelectroom_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            DataSet ds = new DataSet();
            ds = BLL.B_bll.selectkong();
            dgvroom();
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void bbutclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void bbutfalse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btxtid_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
