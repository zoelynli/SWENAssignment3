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

    public partial class FrmHotelVip : Form
    {
        public FrmHotelVip()
        {
            InitializeComponent();
        }

        int i = 1;
        string str1 = "^\\d{9}$";
        private void FrmHotelVip_Load(object sender, EventArgs e)
        {
            this.cbSex.Text = "Male";
            this.cbCard.Text = "VIP";
            this.cbpage.Text = "1";


            //write down in dataGridView from database
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
            con.Open();
            //Display the first page
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Vip";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "V_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds, "Vip");

            dataGridView1.Columns.Add("V_ID", "ID");
            dataGridView1.Columns[0].DataPropertyName = "V_ID";
            dataGridView1.Columns.Add("V_name", "Name");
            dataGridView1.Columns[1].DataPropertyName = "V_name";
            dataGridView1.Columns.Add("V_sex", "Sex");
            dataGridView1.Columns[2].DataPropertyName = "V_sex";
            dataGridView1.Columns.Add("V_phone", "Phone");
            dataGridView1.Columns[3].DataPropertyName = "V_phone";
            dataGridView1.Columns.Add("V_cardid", "IC No");
            dataGridView1.Columns[4].DataPropertyName = "V_cardid";
            dataGridView1.Columns.Add("V_card", "VipType");
            dataGridView1.Columns[5].DataPropertyName = "V_card";

            dataGridView1.Columns.Add("V_notes", "Remarks");
            dataGridView1.Columns[6].DataPropertyName = "V_notes";

            dataGridView1.DataSource = ds.Tables[0];
            int j = 1;
            while (j <= int.Parse(p.Value.ToString()))
            {
                this.cbpage.Items.Add(j);
                j++;
            }

            this.cbpage.Text = i.ToString();
            this.lbgong.Text = p.SqlValue.ToString();

            string sr = "select max(V_ID) from Vip";
            SqlCommand cmd1 = new SqlCommand(sr, con);
            int id = int.Parse(cmd1.ExecuteScalar().ToString());
            tbId.Text = Convert.ToString(id + 1);

        }
        public void yanz()
        {
            Regex rg = new Regex("\\W");
            if (!rg.IsMatch(tbName.Text.ToString()))
            {
                MessageBox.Show("Cannot be empty");
                return;
            }
        }

        //add
        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (this.tbName.Text != "")
            {
                if (this.tbPhone.Text != "")
                {
                    try
                    {
                        if (this.tbCardid.Text != "")
                        {
                            if (this.cbCard.Text != "")
                            {

                                if (!Regex.IsMatch(tbPhone.Text, str1))
                                {
                                    MessageBox.Show("Phone no should be 9 numbers");
                                }
                                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                                con.Open();
                                string str = string.Format("insert into Vip values(@name,@sex,@phone,@cardid,@card,@notes)");
                                SqlCommand com = new SqlCommand(str, con);

                                com.Parameters.Add("@name", SqlDbType.NVarChar, 20).Value = this.tbName.Text.Trim();
                                com.Parameters.Add("@sex", SqlDbType.NChar, 2).Value = this.cbSex.SelectedItem.ToString();
                                com.Parameters.Add("@phone", SqlDbType.NChar, 11).Value = this.tbPhone.Text.Trim();
                                com.Parameters.Add("@cardid", SqlDbType.NVarChar, 18).Value = this.tbCardid.Text.Trim();
                                com.Parameters.Add("@card", SqlDbType.NVarChar, 20).Value = this.cbCard.Text.Trim();

                                com.Parameters.Add("@notes", SqlDbType.NVarChar, 100).Value = this.tbNotes.Text.Trim();

                                int row = com.ExecuteNonQuery();
                                if (row > 0)
                                {
                                    this.tbId.Text = "";
                                    this.tbName.Text = "";
                                    this.cbSex.Text = "";
                                    this.tbPhone.Text = "";
                                    this.tbCardid.Text = "";
                                    this.cbCard.Text = "";

                                    this.tbNotes.Text = "";
                                    MessageBox.Show("Add Successful", "Remind", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    FrmHotelVip_Load(sender, e);
                                }


                            }
                            else
                            {
                                MessageBox.Show("Pls enter Type", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.cbCard.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pls enter IC No", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.tbCardid.Focus();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Pls enter Again", "Remind", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.tbPhone.Text = "";
                        this.tbCardid.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Pls enter Phone no", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.tbPhone.Focus();
                }

            }
            else
            {
                MessageBox.Show("Pls enter Name", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.tbName.Focus();
            }

            this.dataGridView1.Columns.Clear();
            FrmHotelVip_Load(sender, e);
        }

        //delete
        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (this.tbId.Text == "")
            {
                MessageBox.Show("Pls choose！！");
                return;
            }
            else
            {
                DialogResult dia = MessageBox.Show("Delete！！", "Remind", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dia == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                    con.Open();

                    string sql = "delete from Vip where V_ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(this.tbId.Text);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Delete Successful！！！");

                        this.tbId.Text = "";
                        this.tbName.Text = "";
                        this.cbSex.Text = "";
                        this.tbPhone.Text = "";
                        this.tbCardid.Text = "";
                        this.cbCard.Text = "";

                        this.tbNotes.Text = "";
                        MessageBox.Show("You have deleted ONE member！！！");


                        this.dataGridView1.Columns.Clear();
                        FrmHotelVip_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed！！");
                        return;
                    }
                }
            }
        }

        //upate
        private void bt_Update_Click(object sender, EventArgs e)
        {
            if (this.tbName.Text != "")
            {

                if (this.tbPhone.Text != "")
                {
                    try
                    {
                        if (this.tbCardid.Text != "")
                        {
                            if (this.cbCard.Text != "")
                            {

                                if (!Regex.IsMatch(tbPhone.Text, str1))
                                {
                                    MessageBox.Show("Phone No should be 9 numbers");
                                }
                                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                                con.Open();
                                string sql = "update Vip set V_name=@name ,V_sex=@sex,V_phone=@phone,V_cardid=@cardid,V_card=@card,V_notes=@notes where V_ID=@ID ";
                                SqlCommand com = new SqlCommand(sql, con);
                                com.Parameters.Add("@name", SqlDbType.NVarChar, 20).Value = this.tbName.Text.Trim();
                                com.Parameters.Add("@sex", SqlDbType.NChar, 2).Value = this.cbSex.Text.ToString();
                                com.Parameters.Add("@phone", SqlDbType.NChar, 11).Value = this.tbPhone.Text.Trim();
                                com.Parameters.Add("@cardid", SqlDbType.NVarChar, 18).Value = this.tbCardid.Text.Trim();
                                com.Parameters.Add("@card", SqlDbType.NVarChar, 20).Value = this.cbCard.Text.Trim();

                                com.Parameters.Add("@notes", SqlDbType.NVarChar, 100).Value = this.tbNotes.Text.Trim();
                                com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(this.tbId.Text);

                                int row = com.ExecuteNonQuery();
                                if (row > 0)
                                {
                                    MessageBox.Show("Update Successful！！！");

                                }

                            }
                            else
                            {
                                MessageBox.Show("Pls enter Type", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.cbCard.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pls enter IC No", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.tbCardid.Focus();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Pls Check and Re-enter", "Remind", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
                else
                {
                    MessageBox.Show("Pls enter Phone No", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.tbPhone.Focus();
                }

            }
            else
            {
                MessageBox.Show("Pls enter Name", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.tbName.Focus();
            }



            this.dataGridView1.Columns.Clear();
            FrmHotelVip_Load(sender, e);
        }

        //back
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
            con.Open();
            StringBuilder str = new StringBuilder();
            str.Append("select * from Vip ");

            SqlDataAdapter da = new SqlDataAdapter(str.ToString(), con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Vip");
            //dataGridView1.DataSource = ds.Tables[0];

            DataGridViewRow stRow = dataGridView1.SelectedRows[0];
            this.tbId.Text = stRow.Cells[0].Value.ToString();
            this.tbName.Text = stRow.Cells[1].Value.ToString();
            this.cbSex.Text = stRow.Cells[2].Value.ToString();
            this.tbPhone.Text = stRow.Cells[3].Value.ToString();
            this.tbCardid.Text = stRow.Cells[4].Value.ToString();
            this.cbCard.Text = stRow.Cells[5].Value.ToString();

            this.tbNotes.Text = stRow.Cells[6].Value.ToString();
        }

        //retrieve
        private void bt_Select_Click(object sender, EventArgs e)
        {
            if (tbmingzi.Text == "")
            {
                MessageBox.Show("No empty！！！");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                string str = string.Format("select * from Vip where V_name like '{0}%'", this.tbmingzi.Text.Trim().ToString());

                SqlDataAdapter sda = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Vip");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Cannot find the member, pls check again！！");
                }
                this.tbId.Text = "";
                this.tbName.Text = "";

                this.tbPhone.Text = "";
                this.tbCardid.Text = "";


                this.tbNotes.Text = "";
            }
        }

        private void bt_One_Click(object sender, EventArgs e)
        {
            int r = 1;
            if (this.cbpage.Text == r.ToString())
            {
                MessageBox.Show("This is the first page！！");
            }
            else
            {
                this.dataGridView1.Columns.Clear();
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                DataSet ds3 = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "page";
                cmd.Parameters.Add("@current", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Vip";
                cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "V_ID";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@totalpage";
                p.Direction = ParameterDirection.Output;
                p.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds3, "Vip");

                dataGridView1.Columns.Add("V_ID", "ID");
                dataGridView1.Columns[0].DataPropertyName = "V_ID";
                dataGridView1.Columns.Add("V_name", "Name");
                dataGridView1.Columns[1].DataPropertyName = "V_name";
                dataGridView1.Columns.Add("V_sex", "Sex");
                dataGridView1.Columns[2].DataPropertyName = "V_sex";
                dataGridView1.Columns.Add("V_phone", "Phone");
                dataGridView1.Columns[3].DataPropertyName = "V_phone";
                dataGridView1.Columns.Add("V_cardid", "IC No");
                dataGridView1.Columns[4].DataPropertyName = "V_cardid";
                dataGridView1.Columns.Add("V_card", "VipType");
                dataGridView1.Columns[5].DataPropertyName = "V_card";

                dataGridView1.Columns.Add("V_notes", "Remarks");
                dataGridView1.Columns[6].DataPropertyName = "V_notes";

                dataGridView1.DataSource = ds3.Tables["Vip"];

                int q = 1;
                this.cbpage.Text = q.ToString();
                i = int.Parse(this.cbpage.Text);
            }
        }

        private void bt_Pre_Click(object sender, EventArgs e)
        {
            if (i != 1)
            {
                i--;

                dataGridView1.Columns.Clear();
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                DataSet ds2 = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "page";
                cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
                cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Vip";
                cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "V_ID";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@totalpage";
                p.Direction = ParameterDirection.Output;
                p.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds2, "Vip");

                dataGridView1.Columns.Add("V_ID", "ID");
                dataGridView1.Columns[0].DataPropertyName = "V_ID";
                dataGridView1.Columns.Add("V_name", "Name");
                dataGridView1.Columns[1].DataPropertyName = "V_name";
                dataGridView1.Columns.Add("V_sex", "Sex");
                dataGridView1.Columns[2].DataPropertyName = "V_sex";
                dataGridView1.Columns.Add("V_phone", "Phone");
                dataGridView1.Columns[3].DataPropertyName = "V_phone";
                dataGridView1.Columns.Add("V_cardid", "IC No");
                dataGridView1.Columns[4].DataPropertyName = "V_cardid";
                dataGridView1.Columns.Add("V_card", "VipType");
                dataGridView1.Columns[5].DataPropertyName = "V_card";

                dataGridView1.Columns.Add("V_notes", "Remarks");
                dataGridView1.Columns[6].DataPropertyName = "V_notes";

                dataGridView1.DataSource = ds2.Tables["Vip"];


                this.cbpage.Text = i.ToString();
            }
            else
            {
                MessageBox.Show("This is the first page！！");
                return;
            }


        }

        private void bt_Next_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.cbpage.Text) != int.Parse(this.lbgong.Text))
            {
                i++;
                dataGridView1.Columns.Clear();
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                DataSet ds1 = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "page";
                cmd.Parameters.Add("@current", SqlDbType.Int).Value = i;
                cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Vip";
                cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "V_ID";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@totalpage";
                p.Direction = ParameterDirection.Output;
                p.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds1, "Vip");

                dataGridView1.Columns.Add("V_ID", "ID");
                dataGridView1.Columns[0].DataPropertyName = "V_ID";
                dataGridView1.Columns.Add("V_name", "Name");
                dataGridView1.Columns[1].DataPropertyName = "V_name";
                dataGridView1.Columns.Add("V_sex", "Sex");
                dataGridView1.Columns[2].DataPropertyName = "V_sex";
                dataGridView1.Columns.Add("V_phone", "Phone");
                dataGridView1.Columns[3].DataPropertyName = "V_phone";
                dataGridView1.Columns.Add("V_cardid", "IC No");
                dataGridView1.Columns[4].DataPropertyName = "V_cardid";
                dataGridView1.Columns.Add("V_card", "VipType");
                dataGridView1.Columns[5].DataPropertyName = "V_card";

                dataGridView1.Columns.Add("V_notes", "Remarks");
                dataGridView1.Columns[6].DataPropertyName = "V_notes";

                dataGridView1.DataSource = ds1.Tables["Vip"];
                this.cbpage.Text = i.ToString();
            }
            else
            {
                MessageBox.Show("This is the last page！！");
                return;
            }
        }

        private void bt_end_Click(object sender, EventArgs e)
        {
            if (this.cbpage.Text == this.lbgong.Text)
            {
                MessageBox.Show("This is the last page！！");

            }
            else
            {
                this.dataGridView1.Columns.Clear();
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
                con.Open();
                DataSet ds3 = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "page";
                cmd.Parameters.Add("@current", SqlDbType.Int).Value = this.lbgong.Text;
                cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Vip";
                cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "V_ID";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@totalpage";
                p.Direction = ParameterDirection.Output;
                p.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p);
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds3, "Vip");

                dataGridView1.Columns.Add("V_ID", "ID");
                dataGridView1.Columns[0].DataPropertyName = "V_ID";
                dataGridView1.Columns.Add("V_name", "Name");
                dataGridView1.Columns[1].DataPropertyName = "V_name";
                dataGridView1.Columns.Add("V_sex", "Sex");
                dataGridView1.Columns[2].DataPropertyName = "V_sex";
                dataGridView1.Columns.Add("V_phone", "Phone");
                dataGridView1.Columns[3].DataPropertyName = "V_phone";
                dataGridView1.Columns.Add("V_cardid", "身份证号码");
                dataGridView1.Columns[4].DataPropertyName = "V_cardid";
                dataGridView1.Columns.Add("V_card", "VipType");
                dataGridView1.Columns[5].DataPropertyName = "V_card";

                dataGridView1.Columns.Add("V_notes", "Remarks");
                dataGridView1.Columns[6].DataPropertyName = "V_notes";

                dataGridView1.DataSource = ds3.Tables["Vip"];

                this.cbpage.Text = p.Value.ToString();
                i = int.Parse(this.cbpage.Text);
            }
        }

        private void cbpage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            int r = int.Parse(cbpage.SelectedItem.ToString());
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
            con.Open();
            DataSet ds3 = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "page";
            cmd.Parameters.Add("@current", SqlDbType.Int).Value = r;
            cmd.Parameters.Add("@rowcount", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, 20).Value = "Vip";
            cmd.Parameters.Add("@columname", SqlDbType.NVarChar, 20).Value = "V_ID";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@totalpage";
            p.Direction = ParameterDirection.Output;
            p.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds3, "Vip");

            dataGridView1.Columns.Add("V_ID", "ID");
            dataGridView1.Columns[0].DataPropertyName = "V_ID";
            dataGridView1.Columns.Add("V_name", "Name");
            dataGridView1.Columns[1].DataPropertyName = "V_name";
            dataGridView1.Columns.Add("V_sex", "Sex");
            dataGridView1.Columns[2].DataPropertyName = "V_sex";
            dataGridView1.Columns.Add("V_phone", "Phone");
            dataGridView1.Columns[3].DataPropertyName = "V_phone";
            dataGridView1.Columns.Add("V_cardid", "IC No");
            dataGridView1.Columns[4].DataPropertyName = "V_cardid";
            dataGridView1.Columns.Add("V_card", "VipTYpe");
            dataGridView1.Columns[5].DataPropertyName = "V_card";

            dataGridView1.Columns.Add("V_notes", "Remarks");
            dataGridView1.Columns[6].DataPropertyName = "V_notes";

            dataGridView1.DataSource = ds3.Tables["Vip"];

            try
            {
                r = 3 * (Convert.ToInt32(this.cbpage.Text.Trim()) - 1);
                i = Convert.ToInt32(this.cbpage.Text.Trim());
            }
            catch
            {
                cbpage.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True");
            con.Open();

            this.tbId.Text = "";


            string sr = "select max(V_ID) from Vip";
            SqlCommand cmd1 = new SqlCommand(sr, con);
            int id = int.Parse(cmd1.ExecuteScalar().ToString());
            this.tbId.Text = Convert.ToString(id + 1);


            this.tbName.Text = "";
            this.tbPhone.Text = "";
            this.tbCardid.Text = "";
            this.cbCard.Text = "";

            this.tbNotes.Text = "";

        }

        

    }
}