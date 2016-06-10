using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace HotelManagementSystem.UserInterface
{
    public partial class FrmHotelLoging : Form
    {
        public FrmHotelLoging()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string str = "^\\w{6,10}$";

            if (txtname.Text == "")
            {
                MessageBox.Show("User cannot be empty");
            }
            else if (txtpwd.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else if (cbmtype.Text == "")
            {
                MessageBox.Show("Type cannot be empty");
            }
            else if (cmbqu.Text == "")
            {
                MessageBox.Show("Question cannot be empty");
            }
            else if (txtanser.Text == "")
            {
                MessageBox.Show("Answer cannot be empty");
            }

            else
            {
                if (Regex.IsMatch(this.txtname.Text, str) && Regex.IsMatch(txtpwd.Text, str))
                {
                    bool bl = BLL.CustomerBLL.BllSelectLogin(txtname.Text.ToString());
                    if (bl)
                    {
                        MessageBox.Show("You have been registered!");
                    }
                    else
                    {
                        bool insert = BLL.CustomerBLL.BllinsertLogin(this.txtname.Text.ToString(), this.txtpwd.Text.ToString(), this.cbmtype.Text.ToString(), this.cmbqu.Text.ToString(), this.txtanser.Text.ToString());
                        if (insert)
                        {
                            MessageBox.Show("Sucessful");
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                        }
                    }



                }
                else
                {
                    MessageBox.Show("User and Password must be 6-10 numbers or alphabets...");
                }
            }

        }

        private void btnout_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
