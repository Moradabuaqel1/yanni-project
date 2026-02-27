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
    /// Interaction logic for PageAddNewAdmin.xaml
    /// </summary>
    public partial class PageAddNewAdmin : Page
    {
        public PageAddNewAdmin()
        {
            InitializeComponent();
        }
        private void BtnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            string adminname = txtAdminName.Text;
            string adminemail = txtAdminEmail.Text;
            string adminpassword = txtAdminPassword.Password;
            string adminphone = txtAdminPhone.Text;
            string gender = null;
            if (rbMale.IsChecked == true)
                gender = "Male";
            else
                if (rbFemale.IsChecked == true)
                gender = "Female";

            if (string.IsNullOrWhiteSpace(adminname) ||
                string.IsNullOrWhiteSpace(adminemail) ||
                string.IsNullOrWhiteSpace(adminpassword) ||
                string.IsNullOrWhiteSpace(adminphone) ||
                string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Service1Client srv = new Service1Client();
            if (srv.AddNewAdmin(adminname, adminemail, adminpassword, adminphone, gender) > 0)
            {
                MessageBox.Show("Insert Successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
