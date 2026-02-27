using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppClientAdmin.Pages.Categories
{
    /// <summary>
    /// Interaction logic for PageAddNewCategory.xaml
    /// </summary>
    public partial class PageAddNewCategory : Page
    {
        private string selectedImagePath = "";
        private string selectedImageName = "";
        public PageAddNewCategory()
        {
            InitializeComponent();
        }
        private void DisplayImage(string filePath,string imageName)
        {
            BitmapImage imgsrc = new BitmapImage();
            imgsrc.BeginInit();
            imgsrc.UriSource = new Uri(filePath);
            imgsrc.CacheOption = BitmapCacheOption.OnLoad;
            imgsrc.EndInit();
            this.Photo.Source = imgsrc;
            this.txtImageName.Text = $"Image '{imageName}' uploaded successfully. Ready to save.";
        }
        private void BtnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog()==true)
            {
                selectedImagePath = openFileDialog.FileName;
                selectedImageName = System.IO.Path.GetFileName(openFileDialog.FileName);
                DisplayImage(selectedImagePath, selectedImageName);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                MessageBox.Show("Please enter category name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Please upload an image first", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Service1Client srv = new Service1Client();

            string imageSavePath = srv.GetPath();
            if (!Directory.Exists(imageSavePath))
            {
                Directory.CreateDirectory(imageSavePath);
            }

            string imagePath = System.IO.Path.Combine(imageSavePath, selectedImageName);
            File.Copy(selectedImagePath, imagePath, true);

            if (srv.IsCategoryExist(txtCatName.Text))
                MessageBox.Show("Category Is Exists in database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (srv.AddNewCategory(txtCatName.Text, selectedImageName) > 0)
                {
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtImageName.Text = "Category Added Successfully";
                    ClearForm();
                }
                else
                {
                    txtImageName.Text = "Category not Added- Database Error";
                    MessageBox.Show("Failed to add category to database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void ClearForm()
        {
            txtCatName.Clear();
            Photo.Source = null;
            
            selectedImagePath = "";
            selectedImageName = "";
        }
    }
}
