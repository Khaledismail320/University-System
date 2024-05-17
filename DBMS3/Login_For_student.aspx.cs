
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Services.Description;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    namespace  DBMS3
    {
        public partial class Login_For_student : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }


            protected void login1(object sender, EventArgs e)
            {
                string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection newconn = new SqlConnection(conntstr);
                try
                {
                    int id_user = Int16.Parse(id.Text);
                    string pass = password.Text;
                    Session["ID"] = id_user;
                    Session["Password"] = pass;
                    
                        SqlCommand FN_StudentLogin = new SqlCommand("[FN_StudentLogin]", newconn);
                        FN_StudentLogin.CommandType = CommandType.StoredProcedure;
                        FN_StudentLogin.Parameters.AddWithValue("@Student_id", id_user);
                        FN_StudentLogin.Parameters.AddWithValue("@password", pass);
                        SqlParameter FN_StudentLoginParameter = FN_StudentLogin.Parameters.Add("@FN_StudentLoginParameter", SqlDbType.Bit);
                        FN_StudentLoginParameter.Direction = ParameterDirection.ReturnValue;
                        newconn.Open();
                        FN_StudentLogin.ExecuteNonQuery();
                        newconn.Close();
                        if (FN_StudentLoginParameter.Value.ToString() == "True")
                        {
                            Response.Write("ok");
                            Response.Redirect("student_page.aspx");
                        }
                        else
                        {
                            Response.Write("error");
                        }
                    
                }
                catch
                {
                    message.Text = "please make sure you put your user name and your password";
                }

            }
        protected void StartPageClick(object sender, EventArgs e)
        {

            Response.Redirect("~/StartPage.aspx");
        }
        protected void RegClick(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentReg.aspx");
        }

    }
    }
 