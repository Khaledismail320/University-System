using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBMS3
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Adminlogin(object sender, EventArgs e)
        {
            if (UserNameAdmin.Text.ToString()=="1" && PassWordAdmin.Text.ToString() == "1")
            {
                ErrorMessageAdmin.Visible = false;
                Session["ID"] = "1";
                Response.Redirect("~/AdminHome.aspx");
            }
            else
            {
                ErrorMessageAdmin.Visible = true;
            }




        }

        protected void StartPageClick(object sender, EventArgs e)
        {

            Response.Redirect("~/StartPage.aspx");
        }
    }
}