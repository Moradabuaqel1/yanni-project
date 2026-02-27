using AspAppClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspAppClient
{
    public partial class WebFormSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignUp_Click(object sender, EventArgs e)
        {
            Service1Client srv = new Service1Client();
            string un = TextBoxUsrName.Text;
            string em = TextBoxEmail.Text;
            string gen = RadioButtonListGender.SelectedValue;   
            string bd = TextBoxBirthDay.Text;
            string up = TextBoxPass.Text;

            if (srv.AddNewUser(un, em, gen, bd, up) > 0)
            {
                LabelMsg.Text = "Added Successfully";
            }
            else
            {
                LabelMsg.Text = "User doesn't created successfully";
            }

        }
    }
}