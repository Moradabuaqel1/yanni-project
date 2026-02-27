using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB:DBFunctions
    {
        public string dbFileName = "MyDB.accdb";
        DBFunctions dbf = new DBFunctions();
        ImageHandle imgdbf = new ImageHandle();
        private CategoryList list = new CategoryList();

        public int AddNewCategory(string catName,string catImage)
        {
            string sqlStr = string.Format("insert into categories(categoryName,categoryImage)" +
                " values('{0}','{1}')", catName, catImage);
            return dbf.ChangeTable(sqlStr, dbFileName);
        }

        public bool IsCategoryExist(string catName)
        {
            string sqlStr = "select * from categories where categoryName='" + catName + "'";
            return (dbf.Select(sqlStr, dbFileName).Rows.Count > 0);
        }

        private Category CreateModel(Category c)
        {
            string imagePath = dbf.Path();
            c.CategoryName = reader["categoryName"].ToString();
            c.CategoryImage = imgdbf.TargetPath() + reader["categoryImage"].ToString();
            return c;
        }
        private CategoryList GetCategoryList(string sqlStr)
        {
            // تتلقى العملية نص استعلام وتنفذ الاستعلام على قاعدة البيانات 
            //وتبني كائنا بمساعدة العملية السابقة وتخزنة في سلسلة حلقات مترابطة ثم تعيد السلسلة
            cmd = GeneratetOleDbCommand(sqlStr, dbFileName);
            conObj.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category c = new Category();
                list.Add(CreateModel(c));
            }

            if (this.conObj.State == System.Data.ConnectionState.Open)
                this.conObj.Close();
            if (reader != null)
                reader.Close();

            return list;
        }
        public CategoryList SelectAllCategoryList()
        {
            string sqlStr = "select * from categories";
            list = GetCategoryList(sqlStr);
            return list;
        }
        
    }
}
