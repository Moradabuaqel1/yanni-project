using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AdminDB:DBFunctions
    {
        public string dbFileName = "MyDB.accdb";
        DBFunctions dbf = new DBFunctions();

        public bool CheckAdminExist(string aEmail, string aPassword)
        {
            string sqlStr = "select * from admins where adminEmail='" + aEmail + "' and adminPassword='" + aPassword + "'";
            DataTable dt = null;
            dt = dbf.Select(sqlStr, dbFileName);
            return (dt.Rows.Count == 1);
        }

        public int AddNewAdmin(string aName,string aEmail,string aPass,string aPhone,string aGender)
        {
            string sqlStr = string.Format("insert into admins (adminName,adminEmail,adminPassword,adminPhone,isMainAdmin,adminGender)" +
                " values ('{0}','{1}','{2}','{3}',{4},'{5}')", aName, aEmail, aPass, aPhone, false, aGender);
            return dbf.ChangeTable(sqlStr, dbFileName);
        }
        
        public bool IsMainAdmin(string aEmail)
        {
            string sqlStr = "select * from admins where adminEmail='" + aEmail + "' and isMainAdmin=true";
            DataTable dt = null;
            dt = dbf.Select(sqlStr, dbFileName);
            return (dt.Rows.Count == 1);

        }

        public Admin GetAdminByEmail(string aEmail)
        {
            string sqlStr = "select * from admins where adminEmail='" + aEmail + "'";
            DataTable dt = dbf.Select(sqlStr, dbFileName);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            
            Admin a = new Admin
            {
                AdminName = dt.Rows[0][0].ToString(),
                AdminEmail= dt.Rows[0][1].ToString(),
                AdminPassword = dt.Rows[0][2].ToString(),
                AdminPhone = dt.Rows[0][3].ToString(),
                IsMainAdmin = Convert.ToBoolean(dt.Rows[0][4]),
                AdminGender=dt.Rows[0][5].ToString()
            };
            return a;
        }
        public int UpdateAdmin(Admin a)
        {
            string sqlStr = string.Format("update admins set " +
                "adminName='"+a.AdminName+"',"+
                 "adminPassword='" + a.AdminPassword + "'," +
                  "adminPhone='" + a.AdminPhone + "'," +
                   "adminGender='" + a.AdminGender + "' where adminEmail='" +a.AdminEmail+"'"
                );
            return dbf.ChangeTable(sqlStr, dbFileName);
        }

        public int DeleteAdmin(string em)
        {
            string sqlStr = string.Format("delete * from admins where adminEmail='" + em + "'");
            return dbf.ChangeTable(sqlStr, dbFileName);
        }

    }
}
