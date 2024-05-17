using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBMS3
{
    public partial class StudentReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignUp(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            


            string fname = TextBox1.Text.ToString();
            string lname= TextBox5.Text.ToString();
            string password = TextBox2.Text.ToString();
            string email = TextBox3.Text.ToString();
            string faculty = TextBox4.Text.ToString();
            string major= TextBox6.Text.ToString();
            int semester = int.Parse(TextBox7.Text.ToString());


            SqlCommand signup = new SqlCommand("Procedures_StudentRegistration", conn);
            signup.CommandType = CommandType.StoredProcedure;
            signup.Parameters.Add(new SqlParameter("@first_name", fname));
            signup.Parameters.Add(new SqlParameter("@last_name", lname));
            signup.Parameters.Add(new SqlParameter("@password", password));
            signup.Parameters.Add(new SqlParameter("@email", email));
            signup.Parameters.Add(new SqlParameter("@faculty", faculty));
            signup.Parameters.Add(new SqlParameter("@major", major));
            signup.Parameters.Add(new SqlParameter("@Semester", semester));



            SqlParameter YS = signup.Parameters.Add("@Student_id", SqlDbType.Int);
            YS.Direction = ParameterDirection.Output;

            conn.Open();
            signup.ExecuteNonQuery();
            conn.Close();

            idB.Text = "Your ID : " + YS.Value.ToString();
            signupB.Visible = false;
            idB.Visible = true;
            logB.Visible = true;






        }

        protected void logB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login_For_student.aspx");
        }
    }
}