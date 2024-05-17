using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBMS3
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdminClick(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }

        protected void AdvisorClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void StudentClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Login_For_student.aspx");
        }
    }
}