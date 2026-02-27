using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetPath();
        //--------------- Admin ------------------------
        [OperationContract]
        bool CheckAdminExist(string aEmail, string aPassword);
        [OperationContract]
        int AddNewAdmin(string aName, string aEmail, string aPass, string aPhone, string aGender);
        [OperationContract]
        bool IsMainAdmin(string aEmail);

        [OperationContract]
        Admin GetAdminByEmail(string aEmail);
        [OperationContract]
        int UpdateAdmin(Admin a);

        [OperationContract]
        int DeleteAdmin(string em);

        //-------------- Category -------------------
        [OperationContract]
        int AddNewCategory(string catName, string catImage);

        [OperationContract]
        bool IsCategoryExist(string catName);

        [OperationContract]
        CategoryList SelectAllCategoryList();

        //--------------- User ----------------------
        [OperationContract]
        int AddNewUser(string uName, string uEmail, string uGender, string uBirthday, string uPass);

        [OperationContract]
        bool CheckUserExist(string uEmail, string uPass);

        //-------------- Product -------------------
        [OperationContract]
        int AddNewProduct(Product p);
    
      /*  int DeleteProduct(string productid);
        [OperationContract]
        bool IsProductExist(string productid);*/



    }



}
