using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public class DBFunctions
    {
        protected OleDbConnection conObj;
        protected OleDbCommand cmd;
        protected OleDbDataReader reader;

        public DBFunctions()

        {
            conObj = new OleDbConnection();
            cmd = new OleDbCommand();
        }
        public OleDbCommand GeneratetOleDbCommand(string sqlStr, string dbFileName)
        {
            conObj = GenerateConnection(dbFileName);
            cmd = new OleDbCommand(sqlStr, conObj);
            return cmd;
        }
        public OleDbConnection GenerateConnection(string dbFileName)
        {
            try
            {

                conObj.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Path() + "\\App_Data\\" + dbFileName;
                conObj.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error : " + ex.Message);
            }
            finally
            {
                conObj.Close();
            }
            return conObj;
        }
        public string Path()
        {
            string currentDir = Environment.CurrentDirectory;
            string[] dirStr = currentDir.Split('\\');
            int index = dirStr.Length - 3;
            dirStr[index] = "ViewModel";
            Array.Resize(ref dirStr, index + 1);
            string pathStr = string.Join("\\", dirStr);
            return pathStr;
        }
        public DataTable Select(string sqlString, string dbFileName)
        {
            conObj = GenerateConnection(dbFileName);
            DataTable dt = null;
            DataSet dsUser = new DataSet();
            try
            {
                OleDbDataAdapter daObj = new OleDbDataAdapter(sqlString, conObj);
                daObj.Fill(dsUser);
                dt = dsUser.Tables[0];
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error : " + ex.Message);
            }
            finally
            {
                conObj.Close();
            }
            return dt;
        }
        public int ChangeTable(string sqlString, string dbFileName)
        {
            int records = 0;
            cmd = GeneratetOleDbCommand(sqlString, dbFileName);
            conObj.Open();
            try
            {
                records = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error : " + ex.Message);
            }
            finally
            {
                conObj.Close();
            }
            return records;
        }
    }
}
