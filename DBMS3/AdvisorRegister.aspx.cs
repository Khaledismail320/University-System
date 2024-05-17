using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace DBMS3
{
    public partial class AdvisorRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUp(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            idB.Visible = false;

            if (TextBox1.Text.Length == 0 || TextBox2.Text.Length == 0 || TextBox3.Text.Length == 0 || TextBox4.Text.Length == 0)
            {
                idB.Text = "Please fill all fields";
                idB.Visible = true;

            }
            else
            {

                string advisorname = TextBox1.Text.ToString();
                string password = TextBox2.Text.ToString();
                string email = TextBox3.Text.ToString();
                string office = TextBox4.Text.ToString();


                SqlCommand signup = new SqlCommand("Procedures_AdvisorRegistration", conn);
                signup.CommandType = CommandType.StoredProcedure;
                signup.Parameters.Add(new SqlParameter("@advisor_name", advisorname));
                signup.Parameters.Add(new SqlParameter("@password", password));
                signup.Parameters.Add(new SqlParameter("@email", email));
                signup.Parameters.Add(new SqlParameter("@office", office));


                SqlParameter YS = signup.Parameters.Add("@Advisor_id", SqlDbType.Int);
                YS.Direction = ParameterDirection.Output;

                conn.Open();
                signup.ExecuteNonQuery();
                conn.Close();

                idB.Text = "Your ID : " + YS.Value.ToString();
                signupB.Visible = false;
                idB.Visible = true;
                logB.Visible = true;




            }

        }

        protected void logB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}