using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppClientAdmin.ServiceReference1;

namespace WpfAppClientAdmin.Pages.Admins
{
    /// <summary>
    /// Interaction logic for PageUpdateRegularAdmin.xaml
    /// </summary>
    public partial class PageUpdateRegularAdmin : Page
    {
       public string adminEmail;
        Service1Client srv = new Service1Client();
        public PageUpdateRegularAdmin(string em)
        {
            InitializeComponent();
            adminEmail = em;
            Admin a = srv.GetAdminByEmail(adminEmail);
            txtEmail.Text = a.AdminEmail;
            txtEmail.IsEnabled = false;
            txtFullName.Text = a.AdminName;
            txtPassword.Text = a.AdminPassword;
            txtPhone.Text = a.AdminPhone;
            txtGender.Text = a.AdminGender;
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Admin a = new Admin
            {
                AdminEmail = txtEmail.Text,
                AdminName = txtFullName.Text,
                AdminPassword = txtPassword.Text,
                AdminPhone = txtPhone.Text,
                AdminGender = txtGender.Text
            };
            int result = srv.UpdateAdmin(a);
            if (result > 0)
                MessageBox.Show("Update Successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }
}
