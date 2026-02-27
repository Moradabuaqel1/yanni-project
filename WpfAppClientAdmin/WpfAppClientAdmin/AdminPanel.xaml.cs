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
using System.Windows.Shapes;
using WpfAppClientAdmin.ServiceReference1;

namespace WpfAppClientAdmin
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public string adminEmail;
        Service1Client srv = new Service1Client();
        public AdminPanel(string em)
        {
            InitializeComponent();
            adminEmail = em;
            this.AdminEm.Text += em;
        }
        

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            
            if (srv.IsMainAdmin(adminEmail))
            {
                this.MainContent.Content = new Pages.Admins.PageAddNewAdmin();
            }
            else
            {
                MessageBox.Show("You are not main admin !!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (srv.IsMainAdmin(adminEmail))
                this.MainContent.Content = new Pages.Admins.PageUpdateAdmin();
            else
                this.MainContent.Content = new Pages.Admins.PageUpdateRegularAdmin(adminEmail);
        }

        private void DeleteAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (srv.IsMainAdmin(adminEmail))
            {
                this.MainContent.Content = new Pages.Admins.PageDeleteAdmin();
            }
            else
                MessageBox.Show("You are not main admin !!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void SearchAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            adminEmail = null;
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new Pages.Categories.PageAddNewCategory();
        }

        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new Pages.Categories.PageUpdateCategory();
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchCategory_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new Pages.Products.PageAddNewProduct();
        }

       //@TODO change the page name 
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new Pages.Products.PageAddNewProduct();
        }
    }
}
