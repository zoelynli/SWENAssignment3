using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.BLL
{
    class CustomerBLL
    {

        public static DataSet BllSelect()
        {
            return DAL.CustomerDAL.DalSelect();
        }
        public static SqlDataReader BllSelectID(string type)
        {
            return DAL.CustomerDAL.DalSelectID(type);
        }
        public static SqlDataReader BllSelectID(int id)
        {
            return DAL.CustomerDAL.DalSelectID(id);
        }
        public static SqlDataReader BllSelectoneID(int id)
        {
            return DAL.CustomerDAL.DalSelectoneID(id);
        }

        public static int BllSelectID()
        {
            return DAL.CustomerDAL.DalSelectID();
        }

        public static int BllSelectEmpty()
        {
            return DAL.CustomerDAL.DalSelectEmpty();
        }

        public static int BllSelectBooking()
        {
            return DAL.CustomerDAL.DalSelectBooking();
        }

        public static int BllSelectCleaning()
        {
            return DAL.CustomerDAL.DalSelectCleaning();
        }

        public static int BllSelectmoney()
        {
            return DAL.CustomerDAL.DalSelectmoney();
        }
        public static DataSet BllSelect(int NumRoom)
        {
            return DAL.CustomerDAL.DalSelect(NumRoom);
        }
        public static DataSet bllSelectType(string type)
        {
            return DAL.CustomerDAL.DalSelectType(type);
        }

        public static DataSet bllSelectRoomID(string id)
        {
            return DAL.CustomerDAL.DalSelectRoomID(id);
        }
        public static DataSet BllSelectRoom()
        {
            return DAL.CustomerDAL.DalSelectRoom();
        }
        public static DataSet BllSelectRoomrz()
        {
            return DAL.CustomerDAL.DalSelectRoomrz();
        }
        public static DataSet BllSelectNullRoom()
        {
            return DAL.CustomerDAL.DalSelectNullRoom();
        }
        public static bool BllSelectNullRoom(CustomerInf sti)
        {
            return DAL.CustomerDAL.DalSelectNullRoom(sti);
        }

        public static SqlDataReader BllLogin(string name, string pwd, string type)
        {
            return DAL.CustomerDAL.DalLogin(name, pwd, type);
        }
        public static bool BllUpdate(int id)
        {
            return DAL.CustomerDAL.DalUpdate(id);
        }
        public static bool BllUpdate(string t1, string t2, int id)
        {
            return DAL.CustomerDAL.DalUpdate(t1, t2, id);
        }
        public static bool BllUpdate1(int id)
        {
            return DAL.CustomerDAL.DalUpdate1(id);
        }
        public static bool BllinsertRoom(int m, int i)
        {
            return DAL.CustomerDAL.DalintsertKongRoom(m, i);
        }

        public static bool BllinsertLogin( string name, string password, string type, string question, string anser)
        {
            return DAL.CustomerDAL.DalinsertLogin( name, password, type, question, anser);
        }

        public static SqlDataReader BllFindLogin(string name, string question, string anser)
        {
            return DAL.CustomerDAL.DalSelectLogin(name, question, anser);
        }

        public static SqlDataReader BllSelectAllType()
        {
            return DAL.CustomerDAL.DalselectAlltype();
        }
        public static SqlDataReader BllSelectAllType1()
        {
            return DAL.CustomerDAL.DalselectAlltype1();
        }
        public static SqlDataReader BllSelectAllType2()
        {
            return DAL.CustomerDAL.DalselectAlltype2();
        }
        public static SqlDataReader BllSelectAllType3()
        {
            return DAL.CustomerDAL.DalselectAlltype3();
        }
        public static SqlDataReader BllSelectAllType4()
        {
            return DAL.CustomerDAL.DalselectAlltype4();
        }

        public static SqlDataReader BllSelectExpense(int id)
        {
            return DAL.CustomerDAL.DalSelectExpense(id);
        }

        public static string BllSelectmain(int id)
        {
            return DAL.CustomerDAL.DalSelectmain(id);
        }
        public static bool BllSelectLogin(string L_name)
        {
            return DAL.CustomerDAL.DalSelectLogin(L_name);
        }
        public static bool BllSelectLogin(int L_possword)
        {
            return DAL.CustomerDAL.DalSelectLogin(L_possword);
        }
    }
}


