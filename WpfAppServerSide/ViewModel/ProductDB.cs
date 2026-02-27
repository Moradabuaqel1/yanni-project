using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ViewModel
{
    public class ProductDB : DBFunctions
    {
        public string dbFileName = "MyDB.accdb";
        DBFunctions dbf = new DBFunctions();
        ImageHandle imgdbf = new ImageHandle();
        private ProductList list = new ProductList();

        public int AddNewProduct(Product p)
        {
            try
            {

                string sqlStr = string.Format("insert into products (productid,productname,category,price,productimage,[description],[stock])" +
                   " values ('{0}','{1}','{2}',{3},'{4}','{5}',{6})", p.ProductId, p.ProductName, p.Category, p.Price, p.ProductImage, p.Description, p.Stock);
                return dbf.ChangeTable(sqlStr, dbFileName);
            }
            catch (Exception ex)
            {
                // שים כאן Breakpoint! (F9) 
                // כשהתוכנה תעצור פה, תוכל להסתכל על המשתנה ex ולראות מה השגיאה המדויקת!
                throw new Exception("Error in DB: " + ex.Message);
            }
        }
        /* string sqlStr = string.Format("insert into products(productid,productname,category,price,productimage,description,stock)" +
             " values('{0}','{1}','{2}',{3},'{4}','{5}',{6})",p.ProductId,p.ProductName,p.Category,p.Price,p.ProductImage,p.Description,p.Stock);

        string sql = "INSERT INTO products " +
             "(productid, productname, category, price, productimage, description, stock) " +
             "VALUES (@id, @name, @category, @price, @image, @desc, @stock)";

        using (OleDbConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", p.ProductId);
                cmd.Parameters.AddWithValue("@name", p.ProductName);
                cmd.Parameters.AddWithValue("@category", p.Category);
                cmd.Parameters.AddWithValue("@price", p.Price);
                cmd.Parameters.AddWithValue("@image", p.ProductImage);
                cmd.Parameters.AddWithValue("@desc", p.Description);
                cmd.Parameters.AddWithValue("@stock", p.Stock);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            return dbf.ChangeTable(sql, dbFileName);
        }*/


        /* public int DeleteProduct(string productid)
         {
             string sqlStr = string.Format("delete * from products where productid= '" + productid + "'");
             return dbf.ChangeTable(sqlStr, dbFileName);
         }

         public bool IsProductExist(string productid)
         {
             string sqlStr = string.Format("select * from products where productid = '" + productid + "'");
             return dbf.Select(sqlStr, dbFileName).Rows.Count > 0 ;
         }*/
        private Product CreateModel(Product p)
        {
            string imagePath = dbf.Path();
            p.ProductImage = reader["productimage"].ToString();
            p.ProductImage = imgdbf.TargetPath() + reader["productimage"].ToString();
            p.ProductImage = reader["productid"].ToString();
            p.ProductName = reader["productname"].ToString();
            p.Category = reader["category"].ToString();
            p.Price =double.Parse( reader["price"].ToString());
            p.Description = reader["description"].ToString();
            p.Stock = int.Parse(reader["stock"].ToString());
            return p;
        }
        private ProductList GetProductList(string sqlStr)
        {
            // تتلقى العملية نص استعلام وتنفذ الاستعلام على قاعدة البيانات 
            //وتبني كائنا بمساعدة العملية السابقة وتخزنة في سلسلة حلقات مترابطة ثم تعيد السلسلة
            cmd = GeneratetOleDbCommand(sqlStr, dbFileName);
            conObj.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product p = new Product();
                list.Add(CreateModel(p));
            }

            if (this.conObj.State == System.Data.ConnectionState.Open)
                this.conObj.Close();
            if (reader != null)
                reader.Close();

            return list;
        }
    }

}
