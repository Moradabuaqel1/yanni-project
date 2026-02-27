using Microsoft.Win32;
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

namespace WpfAppClientAdmin.Pages.Products
{
    /// <summary>
    /// Interaction logic for PageAddNewProduct.xaml
    /// </summary>
    public partial class PageAddNewProduct : Page
    {
        private string selectedImagePath = "";
        private string selectedImageName = "";
        Service1Client srv = new Service1Client();
        public PageAddNewProduct()
        {
            InitializeComponent();
            cmbCategory.ItemsSource = srv.SelectAllCategoryList();
        }

        private void DisplayImage(string filePath, string imageName)
        {
            BitmapImage imgsrc = new BitmapImage();
            imgsrc.BeginInit();
            imgsrc.UriSource = new Uri(filePath);
            imgsrc.CacheOption = BitmapCacheOption.OnLoad;
            imgsrc.EndInit();
            this.Photo.Source = imgsrc;
            this.txtImageName.Text = $"{imageName}";
        }
       

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePath = openFileDialog.FileName;
                selectedImageName = System.IO.Path.GetFileName(openFileDialog.FileName);
                DisplayImage(selectedImagePath, selectedImageName);
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            string productId = txtProductId.Text.Trim();
            string productName = txtProductName.Text.Trim();
            string productDescription = txtDescription.Text.Trim();
            string productImage = txtImageName.Text.Trim();
            // Remove "image " if present
            /*if (productImage.StartsWith("image ", StringComparison.OrdinalIgnoreCase))
            {
                productImage = productImage.Substring(6).Trim();
            }

            // Extract filename between single quotes
            int firstQuote = productImage.IndexOf('\'');
            int lastQuote = productImage.LastIndexOf('\'');

            if (firstQuote >= 0 && lastQuote > firstQuote)
            {
                productImage = productImage.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
            }
            */
            double productPrice;
            int productStock;

            if (string.IsNullOrWhiteSpace(productId) ||
                string.IsNullOrWhiteSpace(productName) ||
                string.IsNullOrWhiteSpace(productDescription) ||
                //string.IsNullOrWhiteSpace(productImage) ||
                !double.TryParse(txtPrice.Text.Trim(), out productPrice) ||
                !int.TryParse(txtStock.Text.Trim(), out productStock))
            {
                MessageBox.Show("Please fill in all fields correctly!",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            Product p1 = new Product();
            p1.ProductId = productId;
            p1.ProductName = productName;
            //p1.Category = cmbCategory.Text;
            if (cmbCategory.SelectedItem != null)
            {
                // המרה של הפריט שנבחר לאובייקט מסוג קטגוריה
                // שים לב: ייתכן שתצטרך להוסיף את ה-Namespace הנכון של Category
                var selectedCategory = (Category)cmbCategory.SelectedItem;
                p1.Category = selectedCategory.CategoryName;
            }
            else
            {
                MessageBox.Show("Please select a category!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            p1.Price = productPrice;
            p1.Stock = productStock;
            p1.Description = productDescription;
            p1.ProductImage = productImage;
            //p1.ProductImage = "testimage";

            if (srv.AddNewProduct(p1) > 0)
            {
                MessageBox.Show("Insert Successfull!" + productImage, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else {
                MessageBox.Show("Insert not Successfull!" + productImage, "failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
