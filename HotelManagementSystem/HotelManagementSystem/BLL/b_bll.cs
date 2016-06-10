using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagementSystem.BLL
{
    class B_bll
    {
        public static DataSet dataread()
        {
            return DAL.B_dal.dataread();
        }


        public bool addExecuteQuery(Boxcs x)
        {
            return new DAL.B_dal().addExecuteQuery(x);

        }

        public bool updateExecuteQuery(Boxcs x)
        {
            return new DAL.B_dal().updateExecuteQuery(x);

        }
        public bool deleteExecuteQuery(int id)
        {
            return new DAL.B_dal().deleteExecuteQuery(id);

        }
        public static DataSet selecttopfirst()
        {
            return DAL.B_dal.selecttopfirst();
        }

        public static DataSet selecttopy(int y)
        {
            return DAL.B_dal.selecttopy(y);
        }

        public static SqlDataReader selectroom(string type)
        {
            return DAL.B_dal.selectroom(type);
        }

        public static DataSet selectroomtype(string type)
        {
            return DAL.B_dal.selectroomtype(type);
        }

        public static DataSet selectroomid(int id)
        {
            return DAL.B_dal.selectroomid(id);
        }
        public static int selecttopend()
        {
            return DAL.B_dal.selecttopend();
        }
        public static DataSet selectkong()
        {
            return DAL.B_dal.selectkong();
        }
        public bool updataR_status(int bid)
        {
            return new DAL.B_dal().updataR_status(bid);
        }
        public static bool selectcarid(string bcardid)
        {
            return DAL.B_dal.selectcardid(bcardid);
        }
        public static string selectRoomid(string broomid)
        {
            return DAL.B_dal.selectRoomid(broomid);
        }
    }
}
