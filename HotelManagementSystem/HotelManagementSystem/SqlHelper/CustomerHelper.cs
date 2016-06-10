using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HotelManagementSystem.SqlHelper
{
    class CustomerHelper
    {
        static string strconn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public static DataSet HelperSelect(string str)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(str, conn);
                da.Fill(ds);
            }
            return ds;
        }
        public static SqlDataReader HelperSelectID(string str, SqlParameter p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        public static string HelperSelectmain(string str, SqlParameter p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(p);
            string dr = Convert.ToString(cmd.ExecuteScalar());

            return dr;
        }

        //Forgot Password
        public static SqlDataReader HelperSelectID(string str, params SqlParameter[] p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            foreach (SqlParameter f in p)
            {
                cmd.Parameters.Add(f);
            }
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        //Total
        public static int HelperSelectID(string str)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count;
        }

        public static DataSet HelperSelectType(string str, SqlParameter p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(p);
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;

        }
        public static DataSet HelperSelectRoomID(string str, SqlParameter p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(p);
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;



        }
        public static DataSet HelperSelect(string strbd, params SqlParameter[] p)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(strbd, conn);
                foreach (SqlParameter f in p)
                {
                    da.SelectCommand.Parameters.Add(f);
                }
                da.Fill(ds);
            }
            return ds;
        }
        public static bool HelperInsert(string str, params SqlParameter[] p)
        {

            using (SqlConnection conn = new SqlConnection(strconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                foreach (SqlParameter f in p)
                {
                    cmd.Parameters.Add(f);
                }
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
                return false;

            }

        }

        public static SqlDataReader HelperLogin(string str, params SqlParameter[] p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            foreach (SqlParameter f in p)
            {
                cmd.Parameters.Add(f);
            }
            return cmd.ExecuteReader();
        }
        public static bool HelperUpdate(string str, params SqlParameter[] p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            foreach (SqlParameter f in p)
            {
                cmd.Parameters.Add(f);
            }
            int id = cmd.ExecuteNonQuery();
            if (id > 0)
                return true;
            return false;
        }
        //Roon Type
        public static SqlDataReader HelperSelectAllType(string str)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            return cmd.ExecuteReader();
        }
        
        public static bool HelperSelectLogin(string str, SqlParameter p)
        {
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                return true;
            return false;

        }
        
    }
}
