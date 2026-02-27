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
    /// Interaction logic for PageDeleteAdmin.xaml
    /// </summary>
    public partial class PageDeleteAdmin : Page
    {
        Service1Client srv = new Service1Client();
        public PageDeleteAdmin()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (srv.DeleteAdmin(this.AdminEmailTextBox.Text)>0)
            {
                MessageBox.Show("Delete Successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
