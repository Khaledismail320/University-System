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

namespace DBMS3
{
    public partial class StudentHome : System.Web.UI.Page
    {
        string SelectedChoice = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Action_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SelectedChoice = ActionList.SelectedValue;
            MainPanel.Visible = true;
            ErrorMessage.Visible = false;


            if (SelectedChoice == "View Graduation Plane")
            {
                Session["SelectedChoice"] = "View Graduation Plane";
                P1.Visible = true;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                








            }
            else if (SelectedChoice == "View the upcoming not paid installment")
            {
                Session["SelectedChoice"] = "View the upcoming not paid installment";
                P1.Visible = false;
                P2.Visible = true;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                


            }
            else if (SelectedChoice == "View all courses along with exams details")
            {
                Session["SelectedChoice"] = "View all courses along with exams details";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = true;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                
            }
            else if (SelectedChoice == "Register for first makeup exam")
            {

                Session["SelectedChoice"] = "Register for first makeup exam";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = true;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                

            }
            else if (SelectedChoice == "Register for second makeup exam")
            {

                Session["SelectedChoice"] = "Register for second makeup exam";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = true;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
               



            }
            else if (SelectedChoice == "View all courses along with corresponding slots details and instructors")
            {
                Session["SelectedChoice"] = "View all courses along with corresponding slots details and instructors";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = true;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                

            }
            else if (SelectedChoice == "View the slots of a certain course with their instructor")
            {
                Session["SelectedChoice"] = "View the slots of a certain course with their instructor";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = true;
                P8.Visible = false;
                P9.Visible = false;
                

            }
            else if (SelectedChoice == "Choose the instructor for a certain course")
            {
                Session["SelectedChoice"] = "Choose the instructor for a certain course";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = true;
                P9.Visible = false;
                

            }
            else if (SelectedChoice == "View all details of all courses with their prerequisites")
            {
                Session["SelectedChoice"] = "View all details of all courses with their prerequisites";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = true;
                

            }
          
        }




        protected void FormSubmit(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (Session["SelectedChoice"].ToString() == "View Graduation Plane")
            {
               
                    ErrorMessage.Visible = false;
                    int studentid = int.Parse(Session["ID"].ToString());
                    conn.Open();

                    SqlCommand viewGP = new SqlCommand("SELECT * FROM FN_StudentViewGP(@student_ID)", conn);
                    viewGP.Parameters.AddWithValue("@student_ID", studentid);
                    SqlDataAdapter adapter = new SqlDataAdapter(viewGP);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the GridView
                    GraduationPlane.DataSource = dataTable;
                    GraduationPlane.DataBind();
                    GraduationPlane.Visible = true;
                

            }
            else if (Session["SelectedChoice"].ToString() == "View the upcoming not paid installment")
            {
                
                    ErrorMessage.Visible = false;
                    int studentid = int.Parse(Session["ID"].ToString());

                    SqlCommand Inst = new SqlCommand("FN_StudentUpcoming_installment", conn);
                    Inst.CommandType = CommandType.StoredProcedure;
                    Inst.Parameters.Add(new SqlParameter("@student_ID", studentid));



                    SqlParameter installdeadline = Inst.Parameters.Add("@installdeadline", SqlDbType.Date);
                    installdeadline.Direction = ParameterDirection.ReturnValue;
                    conn.Open();
                    Inst.ExecuteNonQuery();
                    //PUT LABEL
                    Response.Write(((DateTime)(installdeadline.Value)).Date);
                    conn.Close();

                

            }
            else if (Session["SelectedChoice"].ToString() == "View all courses along with exams details")
            {
               
                
                    ErrorMessage.Visible = false;
                    conn.Open();

                    SqlCommand CourseExamDet = new SqlCommand("SELECT * FROM Courses_MakeupExams", conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(CourseExamDet);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the GridView
                    CourseExam.DataSource = dataTable;
                    CourseExam.DataBind();
                    CourseExam.Visible = true;
                
            }
            else if (Session["SelectedChoice"].ToString() == "Register for first makeup exam")
            {
                if (TextBox5.Text.Length == 0 || TextBox4.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    string semcode = TextBox5.Text.ToString();
                    int courseid = int.Parse(TextBox4.Text);
                    int studentid = int.Parse(Session["ID"].ToString());


                    SqlCommand checkStatus = new SqlCommand("FME", conn);
                    checkStatus.CommandType = CommandType.StoredProcedure;
                    checkStatus.Parameters.Add(new SqlParameter("@StudentID", studentid));
                    checkStatus.Parameters.Add(new SqlParameter("@courseID", courseid));
                    checkStatus.Parameters.Add(new SqlParameter("@studentCurr_sem", semcode));


                    SqlParameter D = checkStatus.Parameters.Add("@OUT", SqlDbType.Int);
                    D.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkStatus.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(D.Value.ToString() + " CHECK ELIGIBLE <br />");









                    

                    if (D.Value.ToString()=="0")
                    {
                        ErrorMessage.Text = "You're not eligible for the first makeup";
                        ErrorMessage.Visible=true;

                    }
                    else
                    {
                        ErrorMessage.Visible = false;



                        SqlCommand RegFirst = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn);
                        RegFirst.CommandType = CommandType.StoredProcedure;
                        RegFirst.Parameters.Add(new SqlParameter("@StudentID", studentid));
                        RegFirst.Parameters.Add(new SqlParameter("@courseID", courseid));
                        RegFirst.Parameters.Add(new SqlParameter("@studentCurr_sem", semcode));

                        conn.Open();
                        RegFirst.ExecuteNonQuery();
                        conn.Close();

                        ErrorMessage.Text = "You've successfully registered for the first makeup";
                        ErrorMessage.Visible = true;
                    }
                }

            }
            else if (Session["SelectedChoice"].ToString() == "Register for second makeup exam")
            {
                if ( TextBox7.Text.Length == 0 || TextBox8.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {

                    string semcode = TextBox8.Text.ToString();
                    int courseid = int.Parse(TextBox7.Text);
                    int studentid = int.Parse(Session["ID"].ToString());


                    
                    SqlCommand checkE = new SqlCommand("FN_StudentCheckSMEligibility", conn);
                    checkE.CommandType = CommandType.StoredProcedure;
                    checkE.Parameters.Add(new SqlParameter("@StudentID", studentid));
                    checkE.Parameters.Add(new SqlParameter("@courseID", courseid));



                    SqlParameter E = checkE.Parameters.Add("@eligable", SqlDbType.Bit);
                    E.Direction = ParameterDirection.ReturnValue;
                    conn.Open();
                    checkE.ExecuteNonQuery();
                    conn.Close();



                    //Response.Write(E.Value.ToString() + " CHECK ELIGIBLE <br />");



                    Boolean dont = true;


                    if (E.Value.ToString() == "False")
                    {
                        ErrorMessage.Text = "You're not eligible for the seconed makeup";
                        ErrorMessage.Visible = true;

                    }
                    else
                    {
                        ErrorMessage.Visible = false;



                        SqlCommand RegSecond = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn);
                        RegSecond.CommandType = CommandType.StoredProcedure;
                        RegSecond.Parameters.Add(new SqlParameter("@StudentID", studentid));
                        RegSecond.Parameters.Add(new SqlParameter("@courseID", courseid));
                        RegSecond.Parameters.Add(new SqlParameter("@studentCurr_sem", semcode));


                        conn.Open();
                        RegSecond.ExecuteNonQuery();
                        conn.Close();
                        ErrorMessage.Text = "You've successfully registered for the seconed makeup";
                        ErrorMessage.Visible = true;

                    }

                }

            }
            else if (Session["SelectedChoice"].ToString() == "View all courses along with corresponding slots details and instructors")
            {
                conn.Open();

                SqlCommand CourseSlotInstructor = new SqlCommand("SELECT * FROM  Courses_Slots_Instructor", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(CourseSlotInstructor);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the results of the stored procedure
                adapter.Fill(dataTable);

                // Bind the DataTable to the GridView
                CourseSlotDetails.DataSource = dataTable;
                CourseSlotDetails.DataBind();
                CourseSlotDetails.Visible = true;



            }
            else if (Session["SelectedChoice"].ToString() == "View the slots of a certain course with their instructor")
            {
                if (TextBox9.Text.Length == 0 || TextBox10.Text.Length == 0 )
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    ErrorMessage.Visible = false;
                    int courseid = int.Parse(TextBox10.Text);
                    int instructorid = int.Parse(TextBox9.Text);
                    conn.Open();

                    SqlCommand SlotCourse = new SqlCommand("SELECT * FROM FN_StudentViewSlot(@CourseID,@InstructorID)", conn);
                    SlotCourse.Parameters.AddWithValue("@CourseID", courseid);
                    SlotCourse.Parameters.AddWithValue("@InstructorID", instructorid);
                    SqlDataAdapter adapter = new SqlDataAdapter(SlotCourse);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the GridView
                    SlotCourseInstructor.DataSource = dataTable;
                    SlotCourseInstructor.DataBind();
                    SlotCourseInstructor.Visible = true;
                }

            }
            else if (Session["SelectedChoice"].ToString() == "Choose the instructor for a certain course")
            {
                if (TextBox14.Text.Length == 0  || TextBox12.Text.Length == 0 || TextBox13.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    ErrorMessage.Visible = false;
                    string semcode = TextBox13.Text.ToString();
                    int courseid = int.Parse(TextBox12.Text);
                    int studentid = int.Parse(Session["ID"].ToString());
                    int instructorid = int.Parse(TextBox14.Text);

                    SqlCommand InstructorChoose = new SqlCommand("Procedures_ChooseInstructor", conn);
                    InstructorChoose.CommandType = CommandType.StoredProcedure;
                    InstructorChoose.Parameters.Add(new SqlParameter("@StudentID", studentid));
                    InstructorChoose.Parameters.Add(new SqlParameter("@instrucorID", instructorid));
                    InstructorChoose.Parameters.Add(new SqlParameter("@CourseID", courseid));
                    InstructorChoose.Parameters.Add(new SqlParameter("@current_semester_code", semcode));

                    conn.Open();
                    InstructorChoose.ExecuteNonQuery();
                    conn.Close();
                }

            }
            else if (Session["SelectedChoice"].ToString() == "View all details of all courses with their prerequisites")
            {
                conn.Open();

                SqlCommand Prerequisites = new SqlCommand("SELECT * FROM view_Course_prerequisites", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(Prerequisites);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the results of the stored procedure
                adapter.Fill(dataTable);

                // Bind the DataTable to the GridView
                CoursePrerequisites.DataSource = dataTable;
                CoursePrerequisites.DataBind();
                CoursePrerequisites.Visible = true;


            }

        }

        protected void PageChange(object sender, EventArgs e)
        {
            Response.Redirect("~/Student_page.aspx");
        }
    }
}









