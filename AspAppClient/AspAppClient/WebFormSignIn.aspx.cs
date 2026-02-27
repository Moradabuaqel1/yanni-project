using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspAppClient.ServiceReference1;

namespace AspAppClient
{
    public partial class WebFormSignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                pnlLogin.Visible = false;
                pnlAlreadyLogged.Visible = true;
            }
            else
            {
                pnlLogin.Visible = true;
                pnlAlreadyLogged.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1Client srv = new Service1Client();

            string em = txtboxEmail.Text;
            string up = txtboxPass.Text;
            

            if (srv.CheckUserExist(em, up))
            {
                lblMsg.Text = "User connected Successfully";
                Session["UserId"] = em;          
                Session["Username"] = em;


                Response.Redirect(Request.QueryString["return"] ?? "MasterPage.aspx");
            }
            else { lblMsg.Text = "User not Exist or pass is incorrect"; }
        }
    }
}