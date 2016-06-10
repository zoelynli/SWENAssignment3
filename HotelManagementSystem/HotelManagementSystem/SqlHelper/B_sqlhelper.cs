using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;



namespace HotelManagementSystem.SqlHelper
{
    class B_sqlhelper
    {
        static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public static DataSet dataread(string str)
        {

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(str, con);
                sda.Fill(ds);
                return ds;
            }
        }


        public static bool ExecuteQuery(string str, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand com = new SqlCommand(str, con);
                foreach (SqlParameter p in par)
                {
                    com.Parameters.Add(p);
                }
                if (com.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }

        }
        public static DataSet selecttopy(string str, SqlParameter y)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand(str, con);
                com.Parameters.Add(y);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                sda.Fill(ds);
                return ds;
            }
        }
        public static SqlDataReader selectroom(string str)
        {
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            reader = com.ExecuteReader();
            return reader;
        }

        public static DataSet selectroomid(string str, SqlParameter id)
        {
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                ds = new DataSet();
                SqlCommand com = new SqlCommand(str, con);
                com.Parameters.Add(id);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = com;
                sda.Fill(ds);
            }
            return ds;
        }
        public static int selecttopend(string str)
        {
            int a;
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                a = new int();
                SqlCommand com = new SqlCommand(str, con);
                a = int.Parse(com.ExecuteScalar().ToString());
                return a;
            }
        }
        public static SqlDataReader selectcardid(string str, SqlParameter cardid)
        {
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            com.Parameters.Add(cardid);
            reader = com.ExecuteReader();
            return reader;
        }
        public static string selectRoomid(string str, SqlParameter roomid)
        {

            string flag2;
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand com = new SqlCommand(str, con);
            com.Parameters.Add(roomid);
            flag2 = com.ExecuteScalar().ToString();
            return flag2;

        }
    }
}

 