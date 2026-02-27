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

namespace WpfAppClientAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string em = txtEmail.Text.Trim();
            string pass = txtPass.Password.Trim();

            Service1Client srv = new Service1Client();

            if (srv.CheckAdminExist(em,pass))
            {
                MessageBox.Show("Login Successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                AdminPanel win = new AdminPanel(em);
                win.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid Email or Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
