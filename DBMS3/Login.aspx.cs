using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBMS3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string test = UserNameA.Text;

            int advisor_Id= Int16.Parse(UserNameA.Text);

            System.Diagnostics.Debug.WriteLine(advisor_Id);

            String password = PassWordA.Text;



            SqlCommand loginfn = new SqlCommand("FN_AdvisorLogin", conn);
            loginfn.CommandType= CommandType.StoredProcedure;
            loginfn.Parameters.Add(new SqlParameter("@advisor_Id", advisor_Id));    
            loginfn.Parameters.Add(new SqlParameter("@password", password));



            SqlParameter success = loginfn.Parameters.Add("@success", SqlDbType.Bit);
            success.Direction = ParameterDirection.ReturnValue;


            



            conn.Open();
            loginfn.ExecuteNonQuery();
            conn.Close();

            //Response.Write(success.Value.ToString());
            //Response.Write(success.Value);

            if (success.Value.ToString()== "True")
            {
                ErrorMessageL.Visible = false;
                Session["ID"]= advisor_Id;
                Response.Redirect("~/AdvisorHome.aspx");
            }
            else if (success.Value.ToString() == "False")
            {
                ErrorMessageL.Visible = true;
            }
        }

        protected void RegClick(object sender, EventArgs e)
        {
            Response.Redirect("~/AdvisorRegister.aspx");
        }

        protected void StartPageClick(object sender, EventArgs e)
        {

            Response.Redirect("~/StartPage.aspx");
        }
    }
}