using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AspAppClient
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Show welcome text if logged in
            if (Session["UserId"] != null)
            {
                string username = Convert.ToString(Session["Username"]);
                if (string.IsNullOrWhiteSpace(username)) username = "User";
                lblWelcome.Text = "Welcome, " + username;
            }
            else
            {
                lblWelcome.Text = "Not logged in";
            }
        }
    }
}
