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
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace WpfAppClientAdmin.Pages.Categories
{
    /// <summary>
    /// Interaction logic for PageUpdateCategory.xaml
    /// </summary>
    public partial class PageUpdateCategory : Page
    {
        private readonly Service1Client _srv;
        public ObservableCollection<Category> Categories { get; set; }
        private string _imageBasePath;

        public PageUpdateCategory()
        {
            InitializeComponent();

            _srv = new Service1Client();

            LoadCategories();

            // אפשרי: אם תרצי binding דרך DataContext
            DataContext = this;
        }

        private void LoadCategories()
        {
            try
            {
                // 1. path בסיסי לתמונות – בדיוק כמו ב-AddNewCategory
                _imageBasePath = _srv.GetPath();

                var categoriesFromService = _srv.SelectAllCategoryList();

                // 2. בונים לכל קטגוריה נתיב מלא להצגה
                foreach (var cat in categoriesFromService)
                {
                    if (!string.IsNullOrEmpty(cat.CategoryImage))
                    {
                        cat.DisplayImagePath = System.IO.Path.Combine(_imageBasePath, cat.CategoryImage);
                    }
                }

                Categories = new ObservableCollection<Category>(categoriesFromService);
                CategoryListView.ItemsSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        // לחיצה על Edit – מפעיל מצב עריכה לאותה קטגוריה
        private void EditInline_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var category = btn.DataContext as Category;
            if (category == null) return;

            // שומרים את השם המקורי כדי שיהיה אפשר לבטל
            category.OriginalCategoryName = category.CategoryName;
            category.IsEditing = true;

            CategoryListView.Items.Refresh();
        }

        // לחיצה על Cancel – מחזיר לשם המקורי ומבטל עריכה
        private void CancelInline_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var category = btn.DataContext as Category;
            if (category == null) return;

            // מחזירים לשם המקורי אם שמרנו אותו
            if (!string.IsNullOrEmpty(category.OriginalCategoryName))
            {
                category.CategoryName = category.OriginalCategoryName;
            }

            category.IsEditing = false;
            CategoryListView.Items.Refresh();
        }

        // לחיצה על Save – שומרת לשירות + יוצאת ממצב עריכה
        private void SaveInline_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var category = btn.DataContext as Category;
            if (category == null) return;

            try
            {
                // לדוגמה – את צריכה להתאים לחתימה האמיתית:
                // srv.UpdateCategory(category.CategoryId, category.CategoryName, category.CategoryImage);
                // או מה שיש לך ב-IService1

                category.IsEditing = false;
                category.OriginalCategoryName = category.CategoryName;

                CategoryListView.Items.Refresh();

                MessageBox.Show("Category updated successfully.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        // מחיקה
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var category = btn.DataContext as Category;
            if (category == null) return;

            var result = MessageBox.Show(
                string.Format("Are you sure you want to delete '{0}'?", category.CategoryName),
                "Delete Category",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            try
            {
                // להתאים לשם הפונקציה בשירות:
                // _srv.DeleteCategory(category.CategoryId);

                Categories.Remove(category);

                MessageBox.Show("Category deleted.", "Deleted",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var category = btn.DataContext as Category;
            if (category == null) return;

            // בוחרים קובץ חדש
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() != true)
                return;

            string selectedImagePath = openFileDialog.FileName;
            string selectedImageName = System.IO.Path.GetFileName(selectedImagePath);

            try
            {
                // ודאות שיש לנו base path – אם עוד לא נטען, נקבל שוב מהשירות
                if (string.IsNullOrEmpty(_imageBasePath))
                {
                    _imageBasePath = _srv.GetPath();
                }

                // מעתיקים את הקובץ לתיקייה כמו ב-AddNewCategory
                string imagePath = System.IO.Path.Combine(_imageBasePath, selectedImageName);
                File.Copy(selectedImagePath, imagePath, true);

                // עדכון אובייקט הקטגוריה:
                // DB יקבל את שם הקובץ
                category.CategoryImage = selectedImageName;

                // WPF יקבל נתיב מלא להצגה
                category.DisplayImagePath = imagePath;

                CategoryListView.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading/saving image: " + ex.Message);
            }
        }

    }
}
