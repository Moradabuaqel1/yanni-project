using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspAppClient
{
    public partial class UserManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("WebFormSignIn.aspx?return=UserManagment.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblMsg.Text = "User connected to User Manager Successfully";
            }

        }
    }
}