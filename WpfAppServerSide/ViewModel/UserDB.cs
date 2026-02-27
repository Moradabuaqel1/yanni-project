using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB
    {

        public string dbFileName = "MyDB.accdb";
        DBFunctions dbf = new DBFunctions();

        public int AddNewUser(string uName, string uEmail, string uGender, string uBirthday, string uPass)
        {
            string sqlStr = string.Format("insert into users (username,email,gender,birthday,pass)" +
               " values ('{0}','{1}','{2}','{3}','{4}')", uName, uEmail, uGender, uBirthday, uPass);
            return dbf.ChangeTable(sqlStr, dbFileName);
        }

        public bool CheckUserExist(string uEmail, string uPass)
        {
            
            string sqlStr = string.Format("select * from users where email='" + uEmail + "' and pass='" + uPass + "'");
            DataTable dt = dbf.Select(sqlStr, dbFileName);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }

}
