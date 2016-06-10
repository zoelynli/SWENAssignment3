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
    public partial class FrmHotelSP : Form
    {
        public FrmHotelSP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "^[0-9]{6}$";

            if (textBox1.Text == "")
            {
                MessageBox.Show("Pls enter password");
            }
            else if (!Regex.IsMatch(textBox1.Text, str))
            {
                MessageBox.Show("Must be 6 numbers");
            }
            else
            {

                bool right = BLL.CustomerBLL.BllSelectLogin(int.Parse(textBox1.Text));
                if (right)
                {
                    //this.Close();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Password wrong");
                }

            }

        }
        private void FrmHotelSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        } 

       
    }
}
