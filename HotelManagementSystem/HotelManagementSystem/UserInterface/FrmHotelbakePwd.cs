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
    public partial class FrmHotelbakePwd : Form
    {
        public FrmHotelbakePwd()
        {
            InitializeComponent();
        }

        string str = "^\\w$";

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("User cannot be empty");
            }
            else if (cbmquestion.Text == "")
            {
                MessageBox.Show("Question cannot be emoty");
            }
            else if (txtansert.Text == "")
            {
                MessageBox.Show("Answer cannot be empty");
            }
            else if (Regex.IsMatch(txtname.Text, str))
            {
                MessageBox.Show("Must be Number or Alphabet");
            }
            else if (Regex.IsMatch(txtname.Text, str))
            {
                MessageBox.Show("Must be Number or Alphabet");
            }
            else if (Regex.IsMatch(txtname.Text, str))
            {
                MessageBox.Show("Must be Number or Alphabet");
            }

            else
            {
                SqlDataReader dr = BLL.CustomerBLL.BllFindLogin(this.txtname.Text.ToString(), this.cbmquestion.Text.ToString(), this.txtansert.Text.ToString());
                if (dr.Read())
                {
                    this.label7.Text = dr[0].ToString();
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            cbmquestion.Text = "";
            txtansert.Text = "";
            label7.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
