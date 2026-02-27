using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        AdminDB aDB = new AdminDB();
        CategoryDB catDB = new CategoryDB();
        ProductDB prodDB = new ProductDB();
        ImageHandle h = new ImageHandle();
        UserDB uDB = new UserDB();
        public string GetPath()
        {
            return h.TargetPath();
        }

        // ----------------- Admin -------------------------
        public bool CheckAdminExist(string aEmail, string aPassword)
        {
            return aDB.CheckAdminExist(aEmail, aPassword);
        }

        public int AddNewAdmin(string aName, string aEmail, string aPass, string aPhone, string aGender)
        {
            return aDB.AddNewAdmin(aName, aEmail, aPass, aPhone, aGender);

        }

        public bool IsMainAdmin(string aEmail)
        {
            return aDB.IsMainAdmin(aEmail);
        }

        public Admin GetAdminByEmail(string aEmail)
        {
            return aDB.GetAdminByEmail(aEmail);
        }

        public int UpdateAdmin(Admin a)
        {
            return aDB.UpdateAdmin(a);
        }

        public int DeleteAdmin(string em)
        {
            return aDB.DeleteAdmin(em);
        }

        // ----------------- Category -------------------
        public int AddNewCategory(string catName, string catImage)
        {
            return catDB.AddNewCategory(catName, catImage);
        }

        public bool IsCategoryExist(string catName)
        {
            return catDB.IsCategoryExist(catName);
        }

        public CategoryList SelectAllCategoryList()
        {
            return catDB.SelectAllCategoryList();
        }
        // ------------------ User -----------------------
        public int AddNewUser(string uName, string uEmail, string uGender, string uBirthday, string uPass)
        {
            return uDB.AddNewUser(uName, uEmail, uGender, uBirthday, uPass);
        }
        public bool CheckUserExist(string uEmail, string uPass)
        {
            return uDB.CheckUserExist(uEmail, uPass);
        }

        // ----------------- Product -------------------

        public int AddNewProduct(Product p)
        {
            return prodDB.AddNewProduct(p);
        }

       /* public int DeleteProduct(string productid)
        {
            return prodDB.DeleteProduct(productid);
        }

        public bool IsProductExist(string productid)
        {
            return prodDB.IsProductExist(productid);
        }*/
    }
}
