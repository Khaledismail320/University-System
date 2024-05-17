using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DBMS3
{
    public partial class student_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void credit_hour_request(object sender, EventArgs e)
        {
            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            int credit_hours = int.Parse(CHrequest.Text);
            int StudentID = (int)Session["ID"];
            string type = type1.Text;
            string comment = comment1.Text;

            using (SqlConnection newconn = new SqlConnection(conntstr))
            {
                using (SqlCommand command = new SqlCommand("Procedures_StudentSendingCHRequest", newconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("StudentID", StudentID);
                    command.Parameters.AddWithValue("@credit_hours", @credit_hours);
                    command.Parameters.AddWithValue("type", type);
                    command.Parameters.AddWithValue("comment", comment);

                    newconn.Open();
                    command.ExecuteNonQuery();
                    newconn.Close();

                }


            }


        }
        //##
        protected void mobile1(object sender, EventArgs e)//bt effect f el table tmam 
        {
            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            int phone_number = int.Parse(phone_num.Text);
            int StudentID = (int)Session["ID"];

            using (SqlConnection newconn = new SqlConnection(conntstr))
            {
                using (SqlCommand command = new SqlCommand("Procedures_StudentaddMobile", newconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("StudentID", StudentID);
                    command.Parameters.AddWithValue("mobile_number", phone_number);

                    newconn.Open();
                    command.ExecuteNonQuery();
                    newconn.Close();

                }
            }
        }
        //##
        protected void course_request(object sender, EventArgs e)
        {
            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            int courseID = int.Parse(courseID1.Text);
            int StudentID = (int)Session["ID"];
            string type = type1.Text;
            string comment = comment1.Text;

            using (SqlConnection newconn = new SqlConnection(conntstr))
            {
                using (SqlCommand command = new SqlCommand("Procedures_StudentSendingCourseRequest", newconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("StudentID", StudentID);
                    command.Parameters.AddWithValue("courseID", courseID);
                    command.Parameters.AddWithValue("type", type);
                    command.Parameters.AddWithValue("comment", comment);

                    newconn.Open();
                    command.ExecuteNonQuery();
                    newconn.Close();

                }


            }

        }
        //##
        protected void optional_courses(object sender, EventArgs e)//tmam
        {
            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            SqlConnection newconn = new SqlConnection(conntstr);
            int StudentID = (int)Session["ID"];
            string current_semester_code = semcode.Text;
            SqlCommand optional = new SqlCommand("Procedures_ViewOptionalCourse", newconn);
            optional.CommandType = CommandType.StoredProcedure;
            optional.Parameters.Add(new SqlParameter("@StudentID", StudentID));
            optional.Parameters.Add(new SqlParameter("@current_semester_code", current_semester_code));

            newconn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(optional);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            tables.DataSource = dt;
            tables.DataBind();
            newconn.Close();
            /*SqlDataReader sdr_option = optional.ExecuteReader(CommandBehavior.CloseConnection);

            while (sdr_option.Read())
            {
                String option = sdr_option.GetString(sdr_option.GetOrdinal("Course.name"));
                Label name = new Label();
                name.Text = option;
                form1.Controls.Add(name);
            }
           */

        }
        //##
        protected void avaiable_courses(object sender, EventArgs e)
        {
            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection newconn = new SqlConnection(conntstr);
            string current_semester_code = semcode.Text;
            SqlCommand courses = new SqlCommand("SELECT * FROM FN_SemsterAvailableCourses(@semstercode)", newconn);
            courses.CommandType = CommandType.Text;
            courses.Parameters.Add(new SqlParameter("@semstercode", current_semester_code));
            newconn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(courses);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            tables.DataSource = dt;
            tables.DataBind();
            newconn.Close();
            /*SqlDataReader sdr_available = courses.ExecuteReader(CommandBehavior.CloseConnection);

            while (sdr_available.Read())
            {
                String available = sdr_available.GetString(sdr_available.GetOrdinal("course.name"));
                Label name = new Label();
                name.Text = available;
                form1.Controls.Add(name); 
            } */

        }

        protected void required_course(object sender, EventArgs e)
        {
            /* string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            int StudentID = 1;
            string current_semester_code = "W23";
            using (SqlConnection newconn = new SqlConnection(conntstr))
            {
                using (SqlCommand command = new SqlCommand("Procedures_ViewRequiredCourses", newconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("StudentID", StudentID);
                    command.Parameters.AddWithValue("current_semester_code", current_semester_code);

                    newconn.Open();
                    command.ExecuteNonQuery();
                    newconn.Close();

                }


            }*/

            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection newconn = new SqlConnection(conntstr);
            int id = (int)Session["ID"];
            string current_semester_code = semcode.Text;
            SqlCommand requird = new SqlCommand("Procedures_ViewRequiredCourses", newconn);
            requird.Parameters.Add(new SqlParameter("@StudentID", id));
            requird.Parameters.Add(new SqlParameter("@current_semester_code", current_semester_code));



            requird.CommandType = CommandType.StoredProcedure;

            newconn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(requird);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            tables.DataSource = dt;
            tables.DataBind();
            newconn.Close();


            /*SqlDataReader sdr_req = requird.ExecuteReader(CommandBehavior.CloseConnection);

            while (sdr_req.Read())
              {
                  String req = sdr_req.GetString(sdr_req.GetOrdinal("@student_semester"));
                  Label name = new Label();
                  name.Text = req;
                  form1.Controls.Add(name); 
            }
            */
        }

        protected void missing_course(object sender, EventArgs e)
        {

            string conntstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection newconn = new SqlConnection(conntstr);
            int StudentID = (int)Session["ID"];
            SqlCommand miss_command = new SqlCommand("Procedures_ViewMS", newconn);
            miss_command.Parameters.Add(new SqlParameter("@StudentID", StudentID));
            miss_command.CommandType = CommandType.StoredProcedure;

            newconn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(miss_command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            tables.DataSource = dt;
            tables.DataBind();
            newconn.Close();



            /*using (SqlConnection newconn = new SqlConnection(conntstr))
            {
                using (SqlCommand command = new SqlCommand("Procedures_ViewMS", newconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("StudentID", StudentID);
                    newconn.Open();
                    command.ExecuteNonQuery();
                    newconn.Close();

                }


            }*/
        }

        protected void PageChange(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentHome.aspx");
        }
    }
}