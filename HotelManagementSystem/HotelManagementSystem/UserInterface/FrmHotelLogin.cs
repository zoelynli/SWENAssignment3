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
    public partial class FrmHotelLogin : Form
    {
        public FrmHotelLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string str = "\\w";
            if (this.txtname.Text == "")
            {
                MessageBox.Show("User cannot empty");
            }
            else if (this.txtpwd.Text == "")
            {
                MessageBox.Show("Password cannot empty, only number or alphabet!");
            }
            else if (this.comboBox1.Text == "")
            {
                MessageBox.Show("Pls choose login type");
            }
            else
            {
                if (!Regex.IsMatch(this.txtname.Text, str))
                {
                    MessageBox.Show("User must be number or alphabet!");
                }
                else if (!Regex.IsMatch(this.txtpwd.Text, str))
                {
                    MessageBox.Show("Password must be number or alphabet!");
                }
                else
                {
                    SqlDataReader dr = BLL.CustomerBLL.BllLogin(txtname.Text.ToString(), txtpwd.Text.ToString(), comboBox1.Text.ToString());
                    if (dr.Read())
                    {
                        if (txtname.Text == dr[0].ToString() && txtpwd.Text == dr[1].ToString())
                        {
                            FrmHotelMain fhm = new FrmHotelMain(dr[0].ToString(), dr[2].ToString());
                            fhm.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        MessageBox.Show("User, Password or Type wrong....");
                    }
                }
            }

        }

        private void btnOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}
