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

namespace HotelManagementSystem.UserInterface
{
    public partial class FrmHotelRoom : Form
    {
        static string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        DataSet ds = null;
        public FrmHotelRoom()
        {
            InitializeComponent();
        }
        int i = 1;// now page
        private void FrmHotelRoom_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            //Display first page
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 7;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Room";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "R_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Room");
            change();
            dgv1.DataSource = ds.Tables[0];
            int j = 1;
            while (j <= int.Parse(p.Value.ToString()))
            {
                this.cmbList.Items.Add(j);
                j++;
            }
            this.cmbList.Text = i.ToString();
            this.label7.Text = p.Value.ToString();
            this.dgv1.ReadOnly = true;//Read only
        }
        public void change()
        {
            dgv1.Columns.Add("R_ID", "RoomNo");
            dgv1.Columns[0].DataPropertyName = "R_ID";
            dgv1.Columns.Add("R_money", "Price");
            dgv1.Columns[1].DataPropertyName = "R_money";
            dgv1.Columns.Add("R_type", "Type");
            dgv1.Columns[2].DataPropertyName = "R_type";
            dgv1.Columns.Add("R_status", "Status");
            dgv1.Columns[3].DataPropertyName = "R_status";
            dgv1.Columns.Add("R_intime", "Check In");
            dgv1.Columns[4].DataPropertyName = "R_intime";
            dgv1.Columns.Add("R_daoqitime", "Check In");
            dgv1.Columns[5].DataPropertyName = "R_daoqitime";
            dgv1.Columns.Add("R_notes", "Remarks");
            dgv1.Columns[6].DataPropertyName = "R_notes";
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgv1.Columns.Clear();
            //this.cmbType.Text = null;
            DataSet dset = new DataSet();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = string.Format("select * from Room where R_status ='{0} '", cmbStatus.SelectedItem.ToString());
                SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                dapt.Fill(dset, "Room");
            }
            change();
            this.dgv1.DataSource = dset.Tables[0];
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.cmbStatus.Text = null;
            this.dgv1.Columns.Clear();

            DataSet dst = new DataSet();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = string.Format("select * from Room where R_type ='{0} '", cmbType.SelectedItem.ToString());
                SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                dapt.Fill(dst, "Room");
            }
            change();
            this.dgv1.DataSource = dst.Tables[0];


        }

        private void btnAllRoom_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = string.Format("select * from Room");
                SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                dapt.Fill(ds, "Room");
            }
            change();
            this.dgv1.DataSource = ds.Tables[0];
        }
        private void btnLeftRoom_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = string.Format("select * from Room where R_status =N'Empty'");
                SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                dapt.Fill(ds, "Room");
            }
            change();
            this.dgv1.DataSource = ds.Tables[0];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.dgv1.Columns.Clear();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //display the first page
        private void btnLastOne_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                //btnLastOne.Enabled = false;
                MessageBox.Show("This is the first page！");
                return;
            }
            i--;
            dgv1.Columns.Clear();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 7;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Room";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "R_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Room");
            change();
            dgv1.DataSource = ds.Tables[0];
            this.cmbList.Text = i.ToString();
        }

        //display this page
        private void btnFirst_Click(object sender, EventArgs e)
        {
            int y = 1;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            StringBuilder str = new StringBuilder();
            str.Append("select top 7 * from Room ");
            SqlDataAdapter da = new SqlDataAdapter(str.ToString(), con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Room");
            dgv1.DataSource = ds.Tables[0];
            this.cmbList.Text = y.ToString();
            i = int.Parse(this.cmbList.Text);
        }

        //display next page
        private void btnNextOne_Click(object sender, EventArgs e)
        {
            while (i < int.Parse(this.label7.Text.ToString()))
            {
                i++;
                break;
            }
            if (this.cmbList.Text.ToString() == this.label7.Text.ToString())
            {
                //btnNextOne.Enabled = false;
                MessageBox.Show("This is the last page");
                return;
            }
            dgv1.Columns.Clear();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 7;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Room";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "R_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Room");
            change();
            dgv1.DataSource = ds.Tables[0];
            this.cmbList.Text = i.ToString();
        }

        //display last page
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.cmbList.Text.ToString() != this.label7.Text.ToString())
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "page";
                cmd.Parameters.Add("@current", SqlDbType.Int).Value = this.label7.Text;
                cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 7;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Room";
                cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "R_ID";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@totalpage";
                p.Direction = ParameterDirection.Output;
                p.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds, "Room");
                change();
                dgv1.DataSource = ds.Tables[0];
                this.cmbList.Text = p.Value.ToString();
                i = int.Parse(this.cmbList.Text);
            }
            else { }
        }

        private void cmbList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int r = int.Parse(cmbList.SelectedItem.ToString());
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = r;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 7;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Room";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "R_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Room");
            change();
            dgv1.DataSource = ds.Tables[0];

            //cmblist 
            try
            {
                r = 7 * (Convert.ToInt32(cmbList.Text.Trim()) - 1);//Total lines
                i = Convert.ToInt32(cmbList.Text.Trim());//page now
            }
            catch
            {
                cmbList.Focus();
            }

        }

        private void btnLeftRoom_Click_1(object sender, EventArgs e)
        {

        }


    }
}
