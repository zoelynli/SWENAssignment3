using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HotelManagementSystem.DAL
{
    class B_dal
    {
        public static DataSet dataread()
        {
            String str = string.Format("select B_ID,B_Customer,B_AllMoney,B_Phone,B_Cardid,B_time,B_daoqitime,R.R_type,R.R_ID,B_Notes from Book as B left outer join Room as R on B.R_ID=R.R_ID");
            DataSet ds = SqlHelper.B_sqlhelper.dataread(str);
            return ds;
        }
        public bool addExecuteQuery(Boxcs x)
        {
            string str = string.Format("insert into Book values(@customer,@allmoney,@phone,@cardid,@rid,@time,@dqtime,@notes)");

            SqlParameter customer = new SqlParameter();
            customer.ParameterName = "@customer";
            customer.SqlDbType = System.Data.SqlDbType.NVarChar;
            customer.Size = 20;
            customer.Value = x.Name;

            SqlParameter allmoney = new SqlParameter();
            allmoney.ParameterName = "@allmoney";
            allmoney.SqlDbType = System.Data.SqlDbType.Money;
            allmoney.Value = x.Money;

            SqlParameter phone = new SqlParameter();
            phone.ParameterName = "@phone";
            phone.SqlDbType = System.Data.SqlDbType.NChar;
            phone.Size = 10;
            phone.Value = x.Phone;

            SqlParameter cardid = new SqlParameter();
            cardid.ParameterName = "@cardid";
            cardid.SqlDbType = System.Data.SqlDbType.NVarChar;
            cardid.Size = 20;
            cardid.Value = x.Cardid;

            SqlParameter time = new SqlParameter();
            time.ParameterName = "@time";
            time.SqlDbType = System.Data.SqlDbType.DateTime;
            time.Value = x.Yutime;

            SqlParameter dqtime = new SqlParameter();
            dqtime.ParameterName = "@dqtime";
            dqtime.SqlDbType = System.Data.SqlDbType.DateTime;
            dqtime.Value = x.Dqtime;

            SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@rid";
            rid.SqlDbType = System.Data.SqlDbType.Int;
            rid.Size = 32;
            rid.Value = x.Roomid;

            SqlParameter notes = new SqlParameter();
            notes.ParameterName = "@notes";
            notes.SqlDbType = System.Data.SqlDbType.NVarChar;
            notes.Size = 50;
            notes.Value = x.Notes;
            return SqlHelper.B_sqlhelper.ExecuteQuery(str, new SqlParameter[] { customer, allmoney, phone, cardid, rid, time, dqtime, notes });

        }

        public bool updateExecuteQuery(Boxcs x)
        {
            string str = string.Format("update Book set B_Customer=@customer,B_AllMoney=@allmoney,B_Phone=@phone,B_Cardid=@cardid,R_ID=@rid,B_time=@time,B_daoqitime=@dqtime,B_Notes=@notes  where B_ID=@id");
            SqlParameter customer = new SqlParameter();
            customer.ParameterName = "@customer";
            customer.SqlDbType = System.Data.SqlDbType.NVarChar;
            customer.Size = 20;
            customer.Value = x.Name;

            SqlParameter allmoney = new SqlParameter();
            allmoney.ParameterName = "@allmoney";
            allmoney.SqlDbType = System.Data.SqlDbType.Money;
            allmoney.Value = x.Money;

            SqlParameter phone = new SqlParameter();
            phone.ParameterName = "@phone";
            phone.SqlDbType = System.Data.SqlDbType.NChar;
            phone.Size = 11;
            phone.Value = x.Phone;

            SqlParameter cardid = new SqlParameter();
            cardid.ParameterName = "@cardid";
            cardid.SqlDbType = System.Data.SqlDbType.NVarChar;
            cardid.Size = 20;
            cardid.Value = x.Cardid;

            SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@rid";
            rid.SqlDbType = System.Data.SqlDbType.Int;
            rid.Size = 32;
            rid.Value = x.Roomid;

            SqlParameter time = new SqlParameter();
            time.ParameterName = "@time";
            time.SqlDbType = System.Data.SqlDbType.DateTime;
            time.Value = x.Yutime;

            SqlParameter dqtime = new SqlParameter();
            dqtime.ParameterName = "@dqtime";
            dqtime.SqlDbType = System.Data.SqlDbType.DateTime;
            dqtime.Value = x.Dqtime;

            SqlParameter notes = new SqlParameter();
            notes.ParameterName = "@notes";
            notes.SqlDbType = System.Data.SqlDbType.NVarChar;
            notes.Size = 100;
            notes.Value = x.Notes;


            SqlParameter id = new SqlParameter();
            id.ParameterName = "@id";
            id.SqlDbType = System.Data.SqlDbType.Int;
            id.Size = 32;
            id.Value = x.Id;
            return SqlHelper.B_sqlhelper.ExecuteQuery(str, new SqlParameter[] { id, customer, allmoney, phone, cardid, rid, time, dqtime, notes });
        }



        public bool deleteExecuteQuery(int bid)
        {
            string str = string.Format("delete from Book where B_ID=@id");
            SqlParameter id = new SqlParameter();
            id.ParameterName = "@id";
            id.SqlDbType = System.Data.SqlDbType.Int;
            id.Size = 32;
            id.Value = bid;
            return SqlHelper.B_sqlhelper.ExecuteQuery(str, new SqlParameter[] { id });
        }

        public static DataSet selecttopfirst()
        {
            string str = String.Format("select top 3 B_ID,B_Customer,B_AllMoney,B_Phone,B_Cardid,B_time,B_daoqitime,R.R_type,R.R_ID,B_Notes from Book as B left outer join Room as R on B.R_ID=R.R_ID");
            DataSet ds = SqlHelper.B_sqlhelper.dataread(str);
            return ds;
        }

        public static DataSet selecttopy(int y)
        {

            string str = String.Format("select top 3 B_ID,B_Customer,B_AllMoney,B_Phone,B_Cardid,B_time,B_daoqitime,R.R_type,R.R_ID,B_Notes from Book as B left outer join Room as R on B.R_ID=R.R_ID where B_ID not in (select top (( (@y)-1 ) * 3) B_ID from Book)");
            SqlParameter sy = new SqlParameter();
            sy.ParameterName = "@y";
            sy.SqlDbType = System.Data.SqlDbType.Int;
            sy.Value = y;
            DataSet ds = SqlHelper.B_sqlhelper.selecttopy(str, sy);
            return ds;
        }

        public static int selecttopend()
        {
            string str = String.Format("select count(*) from Book");
            int a = int.Parse(SqlHelper.B_sqlhelper.selecttopend(str).ToString());
            return a;
        }

        public static SqlDataReader selectroom(string type)
        {
            SqlDataReader reader = null;
            if (type == "Single Room")
            {
                string str = String.Format("select R_ID from Room where R_status='Empty' and R_type='Single Room'");
                reader = SqlHelper.B_sqlhelper.selectroom(str);
            }
            if (type == "Double Room")
            {
                string str = string.Format("select R_ID from Room where R_status='Empty' and R_type='Double Room'");
                reader = SqlHelper.B_sqlhelper.selectroom(str);
            }
            if (type == "Three-Bedroom")
            {
                string str = string.Format("select R_ID from Room where R_status='Empty' and R_type='Three-Bedroom'");
                reader = SqlHelper.B_sqlhelper.selectroom(str);
            }
            if (type == "Luxury Room")
            {
                string str = string.Format("select R_ID from Room where R_status='Empty' and R_type='Luxury Room'");
                reader = SqlHelper.B_sqlhelper.selectroom(str);
            }
            if (type == "Presidential Room")
            {
                string str = string.Format("select R_ID from Room where R_status='Empty' and R_type='Presidential Room'");
                reader = SqlHelper.B_sqlhelper.selectroom(str);
            }
            return reader;
        }

        public static DataSet selectroomtype(string type)
        {
            DataSet ds = null;
            if (type == "Single Room")
            {
                string str = String.Format("select * from Room where R_type='Single Room'");
                ds = SqlHelper.B_sqlhelper.dataread(str);

            }
            if (type == "Double Room")
            {
                string str = String.Format("select * from Room where R_type='Double Room'");
                ds = SqlHelper.B_sqlhelper.dataread(str);

            }
            if (type == "Three-Bedroom")
            {
                string str = String.Format("select * from Room where R_type='Three-Bedroom'");
                ds = SqlHelper.B_sqlhelper.dataread(str);

            }
            if (type == "Luxury Room")
            {
                string str = String.Format("select * from Room where R_type='Luxury Room'");
                ds = SqlHelper.B_sqlhelper.dataread(str);

            }
            if (type == "Presidential Room")
            {
                string str = String.Format("select * from Room where R_type='Presidential Room'");
                ds = SqlHelper.B_sqlhelper.dataread(str);

            }
            return ds;
        }
        public static DataSet selectroomid(int bid)
        {
            string str = "select * from Room where R_ID=@id";
            SqlParameter id = new SqlParameter();
            id.ParameterName = "@id";
            id.SqlDbType = SqlDbType.Int;
            id.Value = bid;
            DataSet ds = SqlHelper.B_sqlhelper.selectroomid(str, id);
            return ds;
        }
        public static DataSet selectkong()
        {
            string str = "select * from Room where R_status='Empty'";
            DataSet ds = SqlHelper.B_sqlhelper.dataread(str);
            return ds;
        }

        public bool updataR_status(int bid)
        {
            string str = "update Room set R_status='Occupied' where R_ID=@id";

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@id";
            id.SqlDbType = SqlDbType.Int;
            id.Value = bid;
            return SqlHelper.B_sqlhelper.ExecuteQuery(str, new SqlParameter[] { id });
        }
        public static bool selectcardid(string bcardid)
        {
            string str = "select * from Book where B_Cardid=@cardid";
            SqlParameter cardid = new SqlParameter();
            cardid.ParameterName = "@cardid";
            cardid.SqlDbType = SqlDbType.NVarChar;
            cardid.Value = bcardid;
            SqlDataReader reader = SqlHelper.B_sqlhelper.selectcardid(str, cardid);
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        public static string selectRoomid(string broomid)
        {
            string str = "select R_status from Room where R_ID=@id";
            SqlParameter roomid = new SqlParameter();
            roomid.ParameterName = "@id";
            roomid.SqlDbType = SqlDbType.Int;
            roomid.Value = broomid;
            string flag2 = SqlHelper.B_sqlhelper.selectRoomid(str, roomid);
            return flag2;
        }
    }
}

