using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    class CustomerDAL
    {
        public static DataSet DalSelect()
        {
            string str = string.Format("select C_name,C_sex,R_id,C_AllMoney,C_money,C_Phone,C_cardid,C_time,C_notes from Customer");
            return SqlHelper.CustomerHelper.HelperSelect(str);
        }

        public static SqlDataReader DalSelectID(string type)
        {
            string str = "select R_ID from Room where R_type=@type and R_status='Empty'";
            SqlParameter pmter = new SqlParameter();
            pmter.ParameterName = "@type";
            pmter.SqlDbType = SqlDbType.NChar;
            pmter.Size = 5;
            pmter.Value = type;
            return SqlHelper.CustomerHelper.HelperSelectID(str, pmter);
        }

        public static SqlDataReader DalSelectID(int id)
        {
            string str = "select * from Room where R_ID=@id and R_status='Empty'";
            SqlParameter pmter = new SqlParameter();
            pmter.ParameterName = "@id";
            pmter.SqlDbType = SqlDbType.Int;
            pmter.Value = id;
            return SqlHelper.CustomerHelper.HelperSelectID(str, pmter);
        }

        public static SqlDataReader DalSelectoneID(int id)
        {
            string str = "select * from Room where R_ID=@id";
            SqlParameter pmter = new SqlParameter();
            pmter.ParameterName = "@id";
            pmter.SqlDbType = SqlDbType.Int;
            pmter.Value = id;
            return SqlHelper.CustomerHelper.HelperSelectID(str, pmter);
        }
  
        public static string DalSelectmain(int id)
        {
            string str = "select C_name from Customer where R_ID=@id";
            SqlParameter pmter = new SqlParameter();
            pmter.ParameterName = "@id";
            pmter.SqlDbType = SqlDbType.Int;
            pmter.Value = id;
            return SqlHelper.CustomerHelper.HelperSelectmain(str, pmter);
        }

        public static int DalSelectID()
        {
            string str = "select count(R_ID) from Room where R_status='Occupied'";
            return SqlHelper.CustomerHelper.HelperSelectID(str);
        }

        public static int DalSelectEmpty()
        {
            string str = "select count(R_ID) from Room where R_status='Empty'";
            return SqlHelper.CustomerHelper.HelperSelectID(str);
        }
      
        public static int DalSelectBooking()
        {
            string str = "select count(R_ID) from Room where R_status='Booking'";
            return SqlHelper.CustomerHelper.HelperSelectID(str);
        }
     
        public static int DalSelectCleaning()
        {
            string str = "select count(R_ID) from Room where R_status='Cleaning' and R_status='Maintanence'";
            return SqlHelper.CustomerHelper.HelperSelectID(str);
        }

        public static int DalSelectmoney()
        {
            string str = "select sum(E_allprice) from Expense";
            return SqlHelper.CustomerHelper.HelperSelectID(str);
        }
   
        public static SqlDataReader DalSelectExpense(int id)
        {
            string str = "select R_ID,E_name,E_price,E_daze,E_dprice,E_count,E_time,E_allprice from Expense where R_ID=@id";
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.SqlDbType = SqlDbType.Int;
            p.Value = id;
            return SqlHelper.CustomerHelper.HelperSelectID(str, p);
        }
  
        public static DataSet DalSelect(int NumRoom)
        {
            StringBuilder strbd = new StringBuilder();
            strbd.Append("select * from Customer where R_ID=@id");
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.SqlDbType = SqlDbType.Int;
            p.Value = NumRoom;
            DataSet ds = SqlHelper.CustomerHelper.HelperSelect(strbd.ToString(), p);
            return ds;
        }

        public static DataSet DalSelectType(string type)
        {
            string str = "select * from Room where R_type=@type";
            SqlParameter pmter = new SqlParameter();
            pmter.ParameterName = "@type";
            pmter.SqlDbType = SqlDbType.NChar;
            pmter.Size = 5;
            pmter.Value = type;
            return SqlHelper.CustomerHelper.HelperSelectType(str, pmter);
        }

     
        public static DataSet DalSelectRoomID(string id)
        {
            string str = "select * from Room where R_ID=@ID";
            SqlParameter pmter = new SqlParameter();
            pmter.ParameterName = "@ID";
            pmter.SqlDbType = SqlDbType.NChar;
            pmter.Size = 5;
            pmter.Value = id;
            return SqlHelper.CustomerHelper.HelperSelectRoomID(str, pmter);
        }

        public static DataSet DalSelectRoom()
        {
            string str = string.Format("select * from Room where R_status='Booking'");
            return SqlHelper.CustomerHelper.HelperSelect(str);
        }
        public static DataSet DalSelectRoomrz()
        {
            string str = string.Format("select * from Room where R_status='Occupied'");
            return SqlHelper.CustomerHelper.HelperSelect(str);
        }
 
        public static DataSet DalSelectNullRoom()
        {
            string str = string.Format("select * from Room where R_status='Empty'");
            return SqlHelper.CustomerHelper.HelperSelect(str);
        }

        public static SqlDataReader DalSelectLogin(string name, string question, string anser)
        {
            string str = string.Format("select L_password from HotelLogin where L_name=@name and L_question=@question and L_anser=@anser");
            SqlParameter mingzi = new SqlParameter();
            mingzi.ParameterName = "@name";
            mingzi.SqlDbType = SqlDbType.NVarChar;
            mingzi.Size = 20;
            mingzi.Value = name;

            SqlParameter wenti = new SqlParameter();
            wenti.ParameterName = "@question";
            wenti.SqlDbType = SqlDbType.NVarChar;
            wenti.Size = 50;
            wenti.Value = question;

            SqlParameter daan = new SqlParameter();
            daan.ParameterName = "@anser";
            daan.SqlDbType = SqlDbType.NVarChar;
            daan.Size = 50;
            daan.Value = anser;

            return SqlHelper.CustomerHelper.HelperSelectID(str, new SqlParameter[] { mingzi, wenti, daan });
        }


        public static bool DalintsertKongRoom(int m, int i)
        {
            StringBuilder sbd = new StringBuilder();
            sbd.Append("update Room set R_money=@Rmoney,R_status='Occupied'  where R_ID=@id");

            SqlParameter mon = new SqlParameter();
            mon.ParameterName = "@Rmoney";
            mon.SqlDbType = SqlDbType.Money;
            mon.Value = m;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@id";
            id.SqlDbType = SqlDbType.Int;
            id.Value = i;
            return SqlHelper.CustomerHelper.HelperInsert(sbd.ToString(), new SqlParameter[] { mon, id });
        }
  
        public static bool DalinsertLogin(string name, string password, string type, string question, string anser)
        {
            StringBuilder strber = new StringBuilder();
            strber.Append("insert into HotelLogin values(@L_name,@L_password,@L_type,@L_question,@L_anser)");

            SqlParameter Name = new SqlParameter();
            Name.ParameterName = "@L_name";
            Name.SqlDbType = SqlDbType.NVarChar;
            Name.Size = 20;
            Name.Value = name;

            SqlParameter pwd = new SqlParameter();
            pwd.ParameterName = "@L_password";
            pwd.SqlDbType = SqlDbType.NVarChar;
            pwd.Size = 20;
            pwd.Value = password;


            SqlParameter L_type = new SqlParameter();
            L_type.ParameterName = "@L_type";
            L_type.SqlDbType = SqlDbType.NVarChar;
            L_type.Size = 20;
            L_type.Value = type;


            SqlParameter L_question = new SqlParameter();
            L_question.ParameterName = "@L_question";
            L_question.SqlDbType = SqlDbType.NVarChar;
            L_question.Size = 20;
            L_question.Value = question;


            SqlParameter L_anser = new SqlParameter();
            L_anser.ParameterName = "@L_anser";
            L_anser.SqlDbType = SqlDbType.NVarChar;
            L_anser.Size = 20;
            L_anser.Value = anser;
            return SqlHelper.CustomerHelper.HelperInsert(strber.ToString(), new SqlParameter[] { Name, pwd, L_type, L_question, L_anser });
        }
        
        public static bool DalSelectLogin(string n)
        {
            StringBuilder strber = new StringBuilder();
            strber.Append("select L_name from HotelLogin where L_name=@name");

            SqlParameter LoginName = new SqlParameter();
            LoginName.ParameterName = "@name";
            LoginName.SqlDbType = SqlDbType.NVarChar;
            LoginName.Size = 20;
            LoginName.Value = n;
            return SqlHelper.CustomerHelper.HelperSelectLogin(strber.ToString(), LoginName);
        }
       
        public static bool DalSelectLogin(int n)
        {
            StringBuilder strber = new StringBuilder();
            strber.Append("select L_password from HotelLogin where L_password=@L_password and L_name=@L_name");

            SqlParameter password = new SqlParameter();
            password.ParameterName = "@L_password";
            password.SqlDbType = SqlDbType.Int;
            password.Value = n;
            return SqlHelper.CustomerHelper.HelperSelectLogin(strber.ToString(), password);
        }
  
        public static bool DalSelectNullRoom(CustomerInf sti)
        {
            StringBuilder strber = new StringBuilder();
            strber.Append("insert into Customer values(@C_name,@C_sex,@R_id,@C_AllMoney,@C_money,@C_Phone,@C_cardid,default,@C_daoqtime,@C_notes)");

            SqlParameter Name = new SqlParameter();
            Name.ParameterName = "@C_name";
            Name.SqlDbType = SqlDbType.NVarChar;
            Name.Size = 20;
            Name.Value = sti.Name;

            SqlParameter Sex = new SqlParameter();
            Sex.ParameterName = "@C_sex";
            Sex.SqlDbType = SqlDbType.NVarChar;
            Sex.Size = 2;
            Sex.Value = sti.Sex;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@R_id";
            id.SqlDbType = SqlDbType.Int;
            id.Value = sti.Id;

            SqlParameter allmoney = new SqlParameter();
            allmoney.ParameterName = "@C_AllMoney";
            allmoney.SqlDbType = SqlDbType.Money;
            allmoney.Value = sti.Amoney;

            SqlParameter money = new SqlParameter();
            money.ParameterName = "@C_money";
            money.SqlDbType = SqlDbType.Money;
            money.Value = sti.Moeny;

            SqlParameter Phone = new SqlParameter();
            Phone.ParameterName = "@C_Phone";
            Phone.SqlDbType = SqlDbType.NChar;
            Phone.Size = 11;
            Phone.Value = sti.Phone;

            SqlParameter Cardid = new SqlParameter();
            Cardid.ParameterName = "@C_cardid";
            Cardid.SqlDbType = SqlDbType.NVarChar;
            Cardid.Size = 18;
            Cardid.Value = sti.Cardid;

            SqlParameter daoqtime = new SqlParameter();
            daoqtime.ParameterName = "@C_daoqtime";
            daoqtime.SqlDbType = SqlDbType.DateTime;
            daoqtime.Value = Convert.ToDateTime(sti.DaoqTime);

            SqlParameter notse = new SqlParameter();
            notse.ParameterName = "@C_notes";
            notse.SqlDbType = SqlDbType.NVarChar;
            notse.Size = 50;
            notse.Value = sti.Notes;
            return SqlHelper.CustomerHelper.HelperInsert(strber.ToString(), new SqlParameter[] { Name, Sex, id, allmoney, money, Phone, Cardid, daoqtime, notse });

        }
  
        public static SqlDataReader DalLogin(string n, string p, string t)
        {
            string str = "select L_name,L_password,L_type from HotelLogin where  L_name=@name and L_password=@pwd and L_type=@type";
            SqlParameter name = new SqlParameter();
            name.ParameterName = "@name";
            name.SqlDbType = SqlDbType.NVarChar;
            name.Size = 20;
            name.Value = n;
            SqlParameter pwd = new SqlParameter();
            pwd.ParameterName = "@pwd";
            pwd.SqlDbType = SqlDbType.NVarChar;
            pwd.Size = 20;
            pwd.Value = p;

            SqlParameter type = new SqlParameter();
            type.ParameterName = "@type";
            type.SqlDbType = SqlDbType.NVarChar;
            type.Size = 20;
            type.Value = t;
            return SqlHelper.CustomerHelper.HelperLogin(str, new SqlParameter[] { name, pwd, type });
            //if (dr.Read())
            //    return true;
            //return false;
        }
        public static bool DalUpdate(int id)
        {
            string str = string.Format("update Room set R_status = 'Empty' where R_ID=@id");
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.SqlDbType = SqlDbType.Int;
            p.Value = id;
            return SqlHelper.CustomerHelper.HelperUpdate(str, p);

        }
        public static bool DalUpdate1(int id)
        {
            string str = string.Format("update Room set R_status = 'Occupied' where R_ID=@id");
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.SqlDbType = SqlDbType.Int;
            p.Value = id;
            return SqlHelper.CustomerHelper.HelperUpdate(str, p);

        }
        public static bool DalUpdate(string t1, string t2, int id)
        {
            string str = string.Format("update Room set R_intime = @time1,R_daoqitime=@time2 where R_ID=@id");

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@time1";
            p1.SqlDbType = SqlDbType.DateTime;
            p1.Value = t1;

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@time2";
            p2.SqlDbType = SqlDbType.DateTime;
            p2.Value = t2;

            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.SqlDbType = SqlDbType.Int;
            p.Value = id;
            return SqlHelper.CustomerHelper.HelperUpdate(str, new SqlParameter[] { p1, p2, p });

        }
        public static bool DalUpdate(string type, int id)
        {
            string str = string.Format("update Room set R_type = @type where R_ID=@id");

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@type";
            p1.SqlDbType = SqlDbType.NVarChar;
            p1.Size = 20;
            p1.Value = type;

            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.SqlDbType = SqlDbType.Int;
            p.Value = id;
            return SqlHelper.CustomerHelper.HelperUpdate(str, new SqlParameter[] { p1, p });

        }


   
        public static SqlDataReader DalselectAlltype()
        {
            string str = "select * from Room where R_type='Single Room'";
            return SqlHelper.CustomerHelper.HelperSelectAllType(str);
        }
        public static SqlDataReader DalselectAlltype1()
        {
            string str = "select * from Room where R_type='Double Room'";
            return SqlHelper.CustomerHelper.HelperSelectAllType(str);
        }
        public static SqlDataReader DalselectAlltype2()
        {
            string str = "select * from Room where R_type='Yhree-Bedroom'";
            return SqlHelper.CustomerHelper.HelperSelectAllType(str);
        }
        public static SqlDataReader DalselectAlltype3()
        {
            string str = "select * from Room where R_type='Luxury Room'";
            return SqlHelper.CustomerHelper.HelperSelectAllType(str);
        }
        public static SqlDataReader DalselectAlltype4()
        {
            string str = "select * from Room where R_type='Presidential Room'";
            return SqlHelper.CustomerHelper.HelperSelectAllType(str);
        }
    }
}
