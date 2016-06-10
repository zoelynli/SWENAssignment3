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
    public partial class FrmHotelExpense : Form
    {
        DataSet ds = null;
        public FrmHotelExpense()
        {
            InitializeComponent();
        }
        string str = @"[0-9]{4}-[0-9]{2}-[0-9]{2}";
        private void FrmHotelExpense_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True"))
            {
                con.Open();
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from Room");
                SqlDataAdapter dapt = new SqlDataAdapter(sql.ToString(), con);
                ds = new DataSet();
                dapt.Fill(ds, "Room");

            }
            dataGridView1.Columns.Add("R_ID", "Room No");
            dataGridView1.Columns[0].DataPropertyName = "R_ID";
            dataGridView1.Columns.Add("R_money", "Price");
            dataGridView1.Columns[1].DataPropertyName = "R_money";
            dataGridView1.Columns.Add("R_type", "Type");
            dataGridView1.Columns[2].DataPropertyName = "R_type";
            dataGridView1.Columns.Add("R_status", "Status");
            dataGridView1.Columns[3].DataPropertyName = "R_status";
            dataGridView1.Columns.Add("R_intime", "Check In");
            dataGridView1.Columns[4].DataPropertyName = "R_intime";
            dataGridView1.Columns.Add("R_daoqitime", "Check Out");
            dataGridView1.Columns[5].DataPropertyName = "R_daoqitime";
            dataGridView1.Columns.Add("R_notes", "Remarks");
            dataGridView1.Columns[6].DataPropertyName = "R_notes";
            dataGridView1.DataSource = ds.Tables[0];
        }
        //daily
        private void butdaily_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pls enter Date");
            }
            else if (!Regex.IsMatch(textBox1.Text, str))
            {
                MessageBox.Show("Wrong formate, pls follow xxxx-xx-xx");
            }
            else
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True"))
                {
                    con.Open();
                    DataSet dst = new DataSet();
                    string sql = string.Format("select * from Room where R_daoqitime='{0}'", this.textBox1.Text);
                    SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                    dapt.Fill(dst, "Room");
                    dataGridView1.DataSource = dst.Tables[0];
                    float sun = 0;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (!dataGridView1.Rows[i].IsNewRow)
                            sun = sun + float.Parse(dataGridView1[1, i].Value.ToString());
                    }
                    textBox2.Text = sun.ToString();
                }
            }
        }

        //monthly
        private void butmonthly_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pls enter Date");
            }
            else if (!Regex.IsMatch(textBox1.Text, str))
            {
                MessageBox.Show("Formate wrong, pls follow xxxx-xx-xx");
            }
            else
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True"))
                {
                    con.Open();
                    DataSet dst = new DataSet();
                    string time = this.textBox1.Text.Trim();
                    string year = time.Substring(0, 4);
                    string month = time.Substring(5, 2);
                    //MessageBox.Show(year+"-"+month);

                    string sql = "select * from Expense where year(E_time)='" + year + "' and month(E_time)='" + month + "'";
                    SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                    dapt.Fill(dst, "Expense");
                    dataGridView1.DataSource = dst.Tables[0];

                    float sun = 0;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (!dataGridView1.Rows[i].IsNewRow)
                            sun = sun + float.Parse(dataGridView1[8, i].Value.ToString());
                    }

                    textBox3.Text = sun.ToString();
                }
            }
        }

        //yearly
        private void butyearly_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pls enter Date");
            }
            else if (!Regex.IsMatch(textBox1.Text, str))
            {
                MessageBox.Show("Formate wrong, Pls follow xxxx-xx-xx");
            }
            else
            {
                ds = new DataSet();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True"))
                {
                    con.Open();
                    DataSet dst = new DataSet();
                    string time = this.textBox1.Text.Trim();
                    string year = time.Substring(0, 4);

                    string sql = "select * from Expense where year(E_time)='" + year + "'";
                    SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                    dapt.Fill(dst, "Expense");
                    dataGridView1.DataSource = dst.Tables[0];

                    float sun = 0;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (!dataGridView1.Rows[i].IsNewRow)
                            sun = sun + float.Parse(dataGridView1[8, i].Value.ToString());
                    }

                    textBox4.Text = sun.ToString();
                }
            }
        }

        //occupied
        private void butliu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pls enter Date");
            }
            else if (!Regex.IsMatch(textBox1.Text, str))
            {
                MessageBox.Show("Formate wrong, pls follow xxxx-xx-xx");
            }
            else
            {
                ds = new DataSet();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True"))
                {
                    con.Open();
                    DataSet dst = new DataSet();
                    string sql = string.Format("select * from Customer where C_time='{0}'", this.textBox1.Text);
                    SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                    dapt.Fill(dst, "Customer");
                    dataGridView1.DataSource = dst.Tables[0];

                    textBox5.Text = Convert.ToString(dataGridView1.Rows.Count - 1);
                }
            }
        }

        private void butclear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\v11.0;Initial Catalog=Hotel;Integrated Security=True"))
            {
                con.Open();
                DataSet dst = new DataSet();
                string sql = string.Format("select * from Expense");
                SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
                dapt.Fill(dst, "Expense");
                dataGridView1.DataSource = dst.Tables[0];

                //textBox5.Text = Convert.ToString(dataGridView1.Rows.Count - 1);

                //zong = Convert.ToDouble(Convert.ToString(dataGridView1.Rows.Count - 1));
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}

