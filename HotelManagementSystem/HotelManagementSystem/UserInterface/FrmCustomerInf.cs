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
    public partial class FrmCustomerInf : Form
    {
        public FrmCustomerInf()
        {
            InitializeComponent();
        }
        int i = 1;
        DataSet ds = null;
        static string strconn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public void change()
        {
            dataGridView1.Columns.Add("C_ID", "Id");
            dataGridView1.Columns[0].DataPropertyName = "C_ID";
            dataGridView1.Columns.Add("C_name", "Name");
            dataGridView1.Columns[1].DataPropertyName = "C_name";
            dataGridView1.Columns.Add("C_sex", "Sex");
            dataGridView1.Columns[2].DataPropertyName = "C_sex";
            dataGridView1.Columns.Add("R_ID", "RoomNo");
            dataGridView1.Columns[3].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("C_AllMoney", "Deposit");
            dataGridView1.Columns[4].DataPropertyName = "C_AllMoney";
            dataGridView1.Columns.Add("C_money", "RoomPrice");
            dataGridView1.Columns[5].DataPropertyName = "C_money";
            dataGridView1.Columns.Add("C_Phone", "ContactNo");
            dataGridView1.Columns[6].DataPropertyName = "C_Phone";
            dataGridView1.Columns.Add("C_cardid", "IC");
            dataGridView1.Columns[7].DataPropertyName = "C_cardid";
            dataGridView1.Columns.Add("C_time", "CheckIn");
            dataGridView1.Columns[8].DataPropertyName = "C_time";
            dataGridView1.Columns.Add("C_daoqitime", "CheckOut");
            dataGridView1.Columns[9].DataPropertyName = "C_daoqitime";
            dataGridView1.Columns.Add("C_notes", "Remarks");
            dataGridView1.Columns[10].DataPropertyName = "C_notes";
        }

        public void fenye()
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            //Display the First page Information
            dataGridView1.Columns.Clear();
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Customer";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "C_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Customer");
            change();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void FrmCustomerInfor1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            //display first page infor
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Customer";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "C_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Customer");
            change();
            dataGridView1.DataSource = ds.Tables[0];
            int j = 1;
            while (j <= int.Parse(p.Value.ToString()))
            {
                this.cbmcount.Items.Add(j);
                j++;
            }
            this.cbmcount.Text = i.ToString();
            this.lbtotal.Text = p.Value.ToString();
            this.dataGridView1.ReadOnly = true;//read only

        }

              private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (cmbsex.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (cmbtype.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (cmbID.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (txtpr.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (txtroompr.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (txtphone.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (txtcardid.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }
            else if (txtphone.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }

            else if (txtcardid.Text == "")
            {
                MessageBox.Show("Cannot Empty");
            }

            else
            {

                CustomerInf sti = new CustomerInf();

                sti.Name = txtname.Text.Trim().ToString();
                sti.Sex = cmbsex.SelectedItem.ToString();
                sti.Id = Convert.ToInt32(cmbID.SelectedItem.ToString());
                sti.Amoney = Convert.ToInt32(txtpr.Text);
                sti.Moeny = Convert.ToInt32(txtroompr.Text);
                sti.Phone = txtphone.Text.Trim().ToString();
                sti.Cardid = txtcardid.Text.Trim().ToString();
                sti.DaoqTime = dateTimePicker1.Text.ToString();
                sti.Notes = txtinf.Text.Trim().ToString();
                bool v = BLL.CustomerBLL.BllSelectNullRoom(sti);
                bool insertroom = BLL.CustomerBLL.BllinsertRoom(Convert.ToInt32(txtroompr.Text), Convert.ToInt32(cmbID.SelectedItem.ToString()));

                if (v)
                {

                    MessageBox.Show("Create Successful....");
                }

                ds = BLL.CustomerBLL.BllSelect();
                dataGridView1.DataSource = ds.Tables[0];

            }
            ////ds = BLL.CustomerBLL.BllSelect();
            ////rows();
            //dataGridView1.DataSource = ds.Tables[0];

        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEmpty_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            DataSet ds = BLL.CustomerBLL.BllSelectNullRoom();
            dataGridView1.Columns.Add("R_ID", "RoomNo");
            dataGridView1.Columns[0].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("R_money", "Price");
            dataGridView1.Columns[1].DataPropertyName = "R_money";
            dataGridView1.Columns.Add("R_type", "Type");
            dataGridView1.Columns[2].DataPropertyName = "R_type";
            dataGridView1.Columns.Add("R_status", "Status");
            dataGridView1.Columns[3].DataPropertyName = "R_status";
            dataGridView1.Columns.Add("R_intime", "CheckIn");
            dataGridView1.Columns[4].DataPropertyName = "R_intime";
            dataGridView1.Columns.Add("R_daoqitime", "CheckOut");
            dataGridView1.Columns[5].DataPropertyName = "R_daoqitime";
            dataGridView1.Columns.Add("R_notes", "Remarks");
            dataGridView1.Columns[6].DataPropertyName = "R_notes";
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            int y = 1;
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            StringBuilder str = new StringBuilder();
            str.Append("select top 3 * from Customer");
            SqlDataAdapter da = new SqlDataAdapter(str.ToString(), conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customer");
            dataGridView1.DataSource = ds.Tables[0];
            this.cbmcount.Text = y.ToString();
            i = int.Parse(this.cbmcount.Text);

        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
        
            dataGridView1.Columns.Clear();
            DataSet ds = BLL.CustomerBLL.BllSelectRoom();
            dataGridView1.Columns.Add("R_ID", "RoomNo");
            dataGridView1.Columns[0].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("R_money", "Price");
            dataGridView1.Columns[1].DataPropertyName = "R_money";
            dataGridView1.Columns.Add("R_type", "Type");
            dataGridView1.Columns[2].DataPropertyName = "R_type";
            dataGridView1.Columns.Add("R_status", "Status");
            dataGridView1.Columns[3].DataPropertyName = "R_status";
            dataGridView1.Columns.Add("R_intime", "CheckIn");
            dataGridView1.Columns[4].DataPropertyName = "R_intime";
            dataGridView1.Columns.Add("R_daoqitime", "CheckOut");
            dataGridView1.Columns[5].DataPropertyName = "R_daoqitime";
            dataGridView1.Columns.Add("R_notes", "Remarks");
            dataGridView1.Columns[6].DataPropertyName = "R_notes";
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txttime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            cmbsex.Text = null;
            cmbtype.Text = null;
            cmbID.Text = null;
            txtpr.Text = "";
            txtroompr.Text = "";
            txtphone.Text = "";
            txtcardid.Text = "";
            txtinf.Text = "";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            FrmRoom fr = new FrmRoom();
            fr.ShowDialog();

        }

        private void btnChangeRoom_Click(object sender, EventArgs e)
        {
            FrmRoom fr = new FrmRoom();
            fr.ShowDialog();

        }

        private void btnExtension_Click(object sender, EventArgs e)
        {
            FrmRoom fr = new FrmRoom();
            fr.ShowDialog();

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int i = 200;
            cmbID.Items.Clear();
            dataGridView1.Columns.Clear();
            SqlDataReader dr = BLL.CustomerBLL.BllSelectID(cmbtype.Text.ToString());
            DataSet ds = BLL.CustomerBLL.bllSelectType(cmbtype.Text.ToString());
            dataGridView1.Columns.Add("R_ID", "RoomNo");
            dataGridView1.Columns[0].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("R_money", "Price");
            dataGridView1.Columns[1].DataPropertyName = "R_money";
            dataGridView1.Columns.Add("R_type", "Type");
            dataGridView1.Columns[2].DataPropertyName = "R_type";
            dataGridView1.Columns.Add("R_status", "Status");
            dataGridView1.Columns[3].DataPropertyName = "R_status";
            dataGridView1.Columns.Add("R_intime", "CheckIn");
            dataGridView1.Columns[4].DataPropertyName = "R_intime";
            dataGridView1.Columns.Add("R_daoqitime", "CheckOut");
            dataGridView1.Columns[5].DataPropertyName = "R_daoqitime";
            dataGridView1.Columns.Add("R_notes", "Remarks");
            dataGridView1.Columns[6].DataPropertyName = "R_notes";
            dataGridView1.DataSource = ds.Tables[0];
            while (dr.Read())
            {
                cmbID.Items.Add(dr[0].ToString());
            }
            if (cmbtype.Text.ToString() == "Single Room")
            {
                this.txtpr.Text = (200).ToString();
                this.txtroompr.Text = (130).ToString();
            }
            else if (cmbtype.Text.ToString() == "Double Room")
            {
                this.txtpr.Text = (200).ToString();
                this.txtroompr.Text = (130).ToString();
            }
            else if (cmbtype.Text.ToString() == "Three-Bedroom")
            {
                this.txtpr.Text = (200).ToString();
                this.txtroompr.Text = (150).ToString();
            }
            else if (cmbtype.Text.ToString() == "Luxury Room")
            {
                this.txtpr.Text = (450).ToString();
                this.txtroompr.Text = (280).ToString();
            }
            else if (cmbtype.Text.ToString() == "Presidential Suite")
            {
                this.txtpr.Text = (700).ToString();
                this.txtroompr.Text = (588).ToString();
            }

        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = BLL.CustomerBLL.bllSelectRoomID(cmbID.Text.ToString());
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                //btnLastOne.Enabled = false;
                MessageBox.Show("This is the First Page");
                return;
            }
            i--;
            fenye();
            this.cbmcount.Text = i.ToString();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            while (i < int.Parse(this.lbtotal.Text.ToString()))
            {
                i++;
                break;
            }
            //if (cbmcount.Text!="")
            //{
            //    int x = int.Parse(cbmcount.Text);
            //    x++;
            //}
            if (this.cbmcount.Text.ToString() == this.lbtotal.Text.ToString())
            {
                //btnNextOne.Enabled = false;
                MessageBox.Show("This is the Last Page");
                return;
            }
            fenye();
            this.cbmcount.Text = i.ToString();

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //if (this.cbmcount.Text.ToString() == this.lbtotal.Text.ToString())
            //{
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = this.lbtotal.Text;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Customer";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "C_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Customer");
            // change();
            dataGridView1.DataSource = ds.Tables[0];
            this.cbmcount.Text = p.Value.ToString();
            i = int.Parse(this.cbmcount.Text);
            //}
            //else { }

        }

        private void cbmcount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int r = int.Parse(cbmcount.SelectedItem.ToString());
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = r;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Customer";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "C_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Customer");
            // change();
            dataGridView1.DataSource = ds.Tables[0];

            try
            {
                r = 7 * (Convert.ToInt32(cbmcount.Text.Trim()) - 1);
                i = Convert.ToInt32(cbmcount.Text.Trim());
            }
            catch
            {
                cbmcount.Focus();
            }
        }

        private void FrmCustomerInf_Activated(object sender, EventArgs e)
        {
            this.txtname.Focus();
        }


    }
}
