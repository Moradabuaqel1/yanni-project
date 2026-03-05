namespace WpfAppClientAdmin.ServiceReference1
{
    public partial class Category
    {
        // מצב עריכה ב-UI
        public bool IsEditing { get; set; }

        // לשמור זמנית את השם המקורי בשביל Cancel
        public string OriginalCategoryName { get; set; }

        public string DisplayImagePath { get; set; }
        /*__________________________________*/

    }
}
