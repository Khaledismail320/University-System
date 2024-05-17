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
    public partial class AdminHome : System.Web.UI.Page
    {
        string SelectedChoice = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Admintask(object sender, EventArgs e)
        {
            string selectedTask = AdminTasks.SelectedValue;
            switch (selectedTask)
            {
                case "DeleteCourse":
                    form1.Visible = false;
                    Task_DeleteCourse.Visible = true;
                    break;
                case "DeleteSlot":
                    form1.Visible = false;
                    Task_DeleteSlot.Visible = true;
                    break;
                case "AddMakeupExam":
                    form1.Visible = false;
                    Task_AddMakeupExam.Visible = true;
                    break;
                case "ViewPayments":
                    form1.Visible = false;
                    Task_ViewPayments.Visible = true;
                    break;
                case "IssueInstallments":
                    form1.Visible = false;
                    Task_IssueInstallments.Visible = true;
                    break;

                case "UpdateStudentStatus":
                    form1.Visible = false;
                    Task_UpdateStudentStatus.Visible = true;
                    break;
                case "FetchActiveStudents":
                    form1.Visible = false;
                    Task_FetchActiveStudents.Visible = true;
                    break;
                case "ViewGraduationPlans":
                    form1.Visible = false;
                    Task_ViewGraduationPlans.Visible = true;
                    break;
                case "ViewTranscript":
                    form1.Visible = false;
                    Task_ViewTranscript.Visible = true;
                    break;
                case "FetchOfferedCourses":
                    form1.Visible = false;
                    Task_FetchOfferedCourses.Visible = true;
                    break;


            }
        }

        protected void DoneDelete_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_DeleteCourse.Visible = false;
            SuccessMessageLabel.Text = "";
            ErrorMessage.Text = "";
        }

        protected void DeleteCourse_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (error == true)
                SuccessMessageLabel.Text = "";
            ErrorMessage.Text = "";

            try
            {
                string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                if (int.TryParse(Course_id.Text, out int courseID))
                {
                    SqlCommand delete_courseProc = new SqlCommand("Procedures_AdminDeleteCourse", conn);
                    delete_courseProc.CommandType = CommandType.StoredProcedure;
                    delete_courseProc.Parameters.Add(new SqlParameter("@courseID", courseID));

                    conn.Open();
                    delete_courseProc.ExecuteNonQuery();
                    conn.Close();


                    SuccessMessageLabel.Text = "Course deleted successfully!";
                    ErrorMessage.Text = "";
                }
                else
                {

                    throw new ArgumentException("Invalid course ID. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "An error occurred: " + ex.Message;
                SuccessMessageLabel.Text = "";
                error = true;
            }
        }


        protected void DoneDelete_Click2(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_DeleteSlot.Visible = false;
            SuccessM.Text = "";
            ErrorM.Text = "";


        }


        protected void DeleteSlot_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (error == true)
                SuccessM.Text = "";
            ErrorM.Text = "";
            try
            {
                string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                string semester = Slot_id.Text;

                if (!string.IsNullOrWhiteSpace(semester))
                {
                    SqlCommand check = new SqlCommand("Procedures_Check_inSemester", conn);
                    check.CommandType = CommandType.StoredProcedure;

                    check.Parameters.Add(new SqlParameter("@Current_semester", semester));
                    check.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
                    check.Parameters["@count"].Direction = ParameterDirection.Output;

                    conn.Open();
                    check.ExecuteNonQuery();


                    int countofsemster = Convert.ToInt32(check.Parameters["@count"].Value);
                    conn.Close();
                    if (countofsemster > 0)
                    {
                        SqlCommand delete_slotProc = new SqlCommand("Procedures_AdminDeleteSlots", conn);
                        delete_slotProc.CommandType = CommandType.StoredProcedure;
                        delete_slotProc.Parameters.Add(new SqlParameter("@current_semester", semester));
                        conn.Open();
                        delete_slotProc.ExecuteNonQuery();
                        conn.Close();
                        error = true;

                        SuccessM.Text = "slot is deleted";
                        ErrorM.Text = "";
                    }
                    else
                    {
                        SuccessM.Text = "";
                        ErrorM.Text = "SEMSTER is not found Please try again!";
                        error = true;
                    }

                }
                else
                {
                    throw new ArgumentException("Semester cannot be null");
                }
            }
            catch (Exception ex)
            {
                SuccessM.Text = "";
                ErrorM.Text = "SEMSTER is not found Please try again!" + ex.Message; ;
                error = true;

            }
        }




        protected void AddMakeup_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (error == true)
                SuccessM1.Text = "";
            ErrorM1.Text = "";
            try
            {
                string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                string Type = Makeup_Type.Text;
                string Date = Makeup_Date.Text;
                int courseId;

                if (int.TryParse(courseid.Text, out courseId))
                {
                    SqlCommand AdminExam_Proc = new SqlCommand("Procedures_AdminAddExam", conn);
                    AdminExam_Proc.CommandType = CommandType.StoredProcedure;
                    AdminExam_Proc.Parameters.Add(new SqlParameter("@Type", Type));
                    AdminExam_Proc.Parameters.Add(new SqlParameter("@date", Date));
                    AdminExam_Proc.Parameters.Add(new SqlParameter("@courseID", courseId));

                    conn.Open();
                    AdminExam_Proc.ExecuteNonQuery();
                    conn.Close();

                    ErrorM1.Text = "";
                    SuccessM1.Text = "Exam added successfully!";
                }
                else
                {
                    throw new ArgumentException("Invalid course ID. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                ErrorM1.Text = "An error occurred: " + ex.Message;
                SuccessM1.Text = "";
            }
        }

        protected void DoneDelete_Click4(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_AddMakeupExam.Visible = false;
            ErrorM1.Text = "";
            SuccessM1.Text = "";

        }

        protected void ViewButton1_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlDataAdapter ViewPayment = new SqlDataAdapter("SELECT * FROM Student_Payment", conn);
            DataTable datatable = new DataTable();
            ViewPayment.Fill(datatable);
            GridViewpayment.DataSource = datatable;
            GridViewpayment.DataBind();

        }

        protected void DoneDelete_Click3(object sender, EventArgs e)
        {

            form1.Visible = true;
            Task_ViewPayments.Visible = false;
        }

        protected void InstallmentDone_Click(object sender, EventArgs e)
        {

            bool error = false;

            if (error == true)
                SuccessM2.Text = "";
            ErrorM2.Text = "";
            try
            {
                string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                int payment_id;

                if (int.TryParse(PaymentID.Text, out payment_id))
                {
                    SqlCommand issue_installment = new SqlCommand("Procedures_AdminIssueInstallment", conn);
                    issue_installment.CommandType = CommandType.StoredProcedure;
                    issue_installment.Parameters.Add(new SqlParameter("@payment_id", payment_id));

                    conn.Open();
                    issue_installment.ExecuteNonQuery();
                    conn.Close();
                    error = true;

                    ErrorM2.Text = "";
                    SuccessM2.Text = "Installment issued successfully!";
                }
                else
                {
                    throw new ArgumentException("Invalid payment ID. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                error = true;
                ErrorM2.Text = "An error occurred: " + ex.Message;
                SuccessM2.Text = "";
            }
        }


        protected void DoneDelete_Click5(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_IssueInstallments.Visible = false;
            ErrorM2.Text = "";
            SuccessM2.Text = "";

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (error == true)
                SuccessM2.Text = "";
            ErrorM2.Text = "";
            try
            {
                string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(conStr);

                int student_id;

                if (int.TryParse(StudentID.Text, out student_id))
                {
                    SqlCommand update_status = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn);
                    update_status.CommandType = CommandType.StoredProcedure;
                    update_status.Parameters.Add(new SqlParameter("@student_id", student_id));

                    ErrorM3.Text = "";
                    SuccessM3.Text = "Student status updated successfully!";
                }
                else
                {
                    throw new ArgumentException("Invalid student ID. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                ErrorM3.Text = "An error occurred: " + ex.Message;
                SuccessM3.Text = "";
            }
        }


        protected void DoneDelete_Click6(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_UpdateStudentStatus.Visible = false;
            ErrorM3.Text = "";
            SuccessM3.Text = "";

        }



        protected void ViewActiveStudents_Click(object sender, EventArgs e)
        {

            string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlDataAdapter ViewActiveStudents = new SqlDataAdapter("SELECT * FROM view_Students", conn);
            DataTable datatable = new DataTable();
            ViewActiveStudents.Fill(datatable);
            GridView2.DataSource = datatable;
            GridView2.DataBind();


        }

        protected void DoneDelete_Click7(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_FetchActiveStudents.Visible = false;

        }


        protected void ViewGraduationPlans_Click(object sender, EventArgs e)
        {

            string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlDataAdapter View_GraduationPlans = new SqlDataAdapter("SELECT * FROM Advisors_Graduation_Plan", conn);
            DataTable datatable = new DataTable();
            View_GraduationPlans.Fill(datatable);
            GridView3.DataSource = datatable;
            GridView3.DataBind();


        }

        protected void DoneDelete_Click8(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_ViewGraduationPlans.Visible = false;

        }

        protected void ViewTranscript_Click(object sender, EventArgs e)
        {

            string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlDataAdapter View_Transcript = new SqlDataAdapter("SELECT * FROM Students_Courses_transcript", conn);
            DataTable datatable = new DataTable();
            View_Transcript.Fill(datatable);
            GridView4.DataSource = datatable;
            GridView4.DataBind();


        }

        protected void DoneDelete_Click9(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_ViewTranscript.Visible = false;

        }

        protected void FetchOfferedCourses_Click(object sender, EventArgs e)
        {

            string conStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlDataAdapter Fetch_OfferedCourses = new SqlDataAdapter("SELECT * FROM Semster_offered_Courses", conn);
            DataTable datatable = new DataTable();
            Fetch_OfferedCourses.Fill(datatable);
            GridView5.DataSource = datatable;
            GridView5.DataBind();


        }

        protected void DoneDelete_Click10(object sender, EventArgs e)
        {
            form1.Visible = true;
            Task_FetchOfferedCourses.Visible = false;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SelectedChoice = AdminTasks.SelectedValue;
            MainPanel.Visible = true;


            if (SelectedChoice == "List all advisors in the system")
            {
                Session["SelectedChoice"] = "List all advisors in the system";
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
            else if (SelectedChoice == "List all students with their corresponding advisors in the system")
            {
                Session["SelectedChoice"] = "List all students with their corresponding advisors in the system";
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
            else if (SelectedChoice == "List all pending requests")
            {
                Session["SelectedChoice"] = "List all pending requests";
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
            else if (SelectedChoice == "Add a new semester")
            {

                Session["SelectedChoice"] = "Add a new semester";
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
            else if (SelectedChoice == "Add a new course")
            {

                Session["SelectedChoice"] = "Add a new course";
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
            else if (SelectedChoice == "Link instructor to a course in a specific slot")
            {
                Session["SelectedChoice"] = "Link instructor to a course in a specific slot";
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
            else if (SelectedChoice == "Link a student to an advisor")
            {
                Session["SelectedChoice"] = "Link a student to an advisor";
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
            else if (SelectedChoice == "Link a student to a course with a specific instructor")
            {
                Session["SelectedChoice"] = "Link a student to a course with a specific instructor";
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
            else if (SelectedChoice == "View all details of instructors along with their assigned courses")
            {
                Session["SelectedChoice"] = "View all details of instructors along with their assigned courses";
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

        protected void submit(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (Session["SelectedChoice"].ToString() == "List all advisors in the system")
            {
                ErrorMessage1.Visible = false;
                conn.Open();

                SqlCommand listadvisors = new SqlCommand("Exec Procedures_AdminListAdvisors", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(listadvisors);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the results of the stored procedure
                adapter.Fill(dataTable);

                // Bind the DataTable to the GridView
                listalladvisors.DataSource = dataTable;
                listalladvisors.DataBind();
                listalladvisors.Visible = true;
            }
            else
            {
                if (Session["SelectedChoice"].ToString() == "List all students with their corresponding advisors in the system")
                {
                    ErrorMessage1.Visible = false;
                    conn.Open();

                    SqlCommand liststudentwithadvisor = new SqlCommand("Exec AdminListStudentsWithAdvisors", conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(liststudentwithadvisor);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the GridView
                    Liststudentswithadvisors.DataSource = dataTable;
                    Liststudentswithadvisors.DataBind();
                    Liststudentswithadvisors.Visible = true;
                }
                else
                {
                    if (Session["SelectedChoice"].ToString() == "List all pending requests")
                    {
                        ErrorMessage1.Visible = false;
                        conn.Open();

                        SqlCommand listpendingrequests = new SqlCommand("Select * From all_Pending_Requests", conn);

                        SqlDataAdapter adapter = new SqlDataAdapter(listpendingrequests);
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the results of the stored procedure
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the GridView
                        Listpendingrequests.DataSource = dataTable;
                        Listpendingrequests.DataBind();
                        Listpendingrequests.Visible = true;


                    }
                    else
                    {
                        if (Session["SelectedChoice"].ToString() == "Add a new semester")
                        {
                            if (TextBox1.Text.Length == 0 || TextBox2.Text.Length == 0 || TextBox3.Text.Length == 0)
                            {
                                ErrorMessage1.Text = "Please fill all fields";
                                ErrorMessage1.Visible = true;

                            }
                            else
                            {
                                ErrorMessage1.Visible = false;
                                DateTime startdate = DateTime.Parse(TextBox1.Text.ToString());
                                DateTime enddate = DateTime.Parse(TextBox2.Text.ToString());
                                string semestercode = TextBox3.Text.ToString();


                                SqlCommand addsem = new SqlCommand("AdminAddingSemester", conn);
                                addsem.CommandType = CommandType.StoredProcedure;
                                addsem.Parameters.Add(new SqlParameter("@start_date", startdate.Date));
                                addsem.Parameters.Add(new SqlParameter("@end_date", enddate.Date));
                                addsem.Parameters.Add(new SqlParameter("@semester_code", semestercode));

                                conn.Open();
                                addsem.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        else
                        {
                            if (Session["SelectedChoice"].ToString() == "Add a new course")
                            {
                                if (TextBox4.Text.Length == 0 || TextBox5.Text.Length == 0 || TextBox6.Text.Length == 0 || TextBox7.Text.Length == 0 || TextBox8.Text.Length == 0)
                                {
                                    ErrorMessage1.Text = "Please fill all fields";
                                    ErrorMessage1.Visible = true;

                                }
                                else
                                {
                                    ErrorMessage1.Visible = false;
                                    String major = TextBox4.Text.ToString();
                                    int semester = int.Parse(TextBox5.Text);
                                    int credithours = int.Parse(TextBox6.Text);
                                    string coursename = TextBox7.Text.ToString();
                                    int offered = int.Parse(TextBox8.Text);

                                    if (offered == 1)
                                    {
                                        SqlCommand addcourse = new SqlCommand("Procedures_AdminAddingCourse", conn);
                                        addcourse.CommandType = CommandType.StoredProcedure;
                                        addcourse.Parameters.Add(new SqlParameter("@major", major));
                                        addcourse.Parameters.Add(new SqlParameter("@semester", semester));
                                        addcourse.Parameters.Add(new SqlParameter("@credit_hours", credithours));
                                        addcourse.Parameters.Add(new SqlParameter("@name", coursename));
                                        addcourse.Parameters.Add(new SqlParameter("@is_offered", 1));
                                        conn.Open();
                                        addcourse.ExecuteNonQuery();
                                        conn.Close();
                                    }
                                    else
                                    {
                                        if (offered == 0)
                                        {
                                            SqlCommand addcourse = new SqlCommand("Procedures_AdminAddingCourse", conn);
                                            addcourse.CommandType = CommandType.StoredProcedure;
                                            addcourse.Parameters.Add(new SqlParameter("@major", major));
                                            addcourse.Parameters.Add(new SqlParameter("@semester", semester));
                                            addcourse.Parameters.Add(new SqlParameter("@credit_hours", credithours));
                                            addcourse.Parameters.Add(new SqlParameter("@name", coursename));
                                            addcourse.Parameters.Add(new SqlParameter("@is_offered", 0));
                                            conn.Open();
                                            addcourse.ExecuteNonQuery();
                                            conn.Close();
                                        }
                                        else
                                        {
                                            ErrorMessage1.Text = "Offered can only be 1 or 0";
                                            ErrorMessage1.Visible = true;
                                        }
                                    }
                                }


                            }
                            else
                            {
                                if (Session["SelectedChoice"].ToString() == "Link instructor to a course in a specific slot")
                                {
                                    if (TextBox9.Text.Length == 0 || TextBox10.Text.Length == 0 || TextBox11.Text.Length == 0)
                                    {
                                        ErrorMessage1.Text = "Please fill all fields";
                                        ErrorMessage1.Visible = true;

                                    }
                                    else
                                    {
                                        ErrorMessage1.Visible = false;
                                        int InstructorId = int.Parse(TextBox9.Text);
                                        int courseId = int.Parse(TextBox10.Text);
                                        int slotID = int.Parse(TextBox11.Text);


                                        SqlCommand instructortocourse = new SqlCommand("Procedures_AdminLinkInstructor", conn);
                                        instructortocourse.CommandType = CommandType.StoredProcedure;
                                        instructortocourse.Parameters.Add(new SqlParameter("@cours_id", courseId));
                                        instructortocourse.Parameters.Add(new SqlParameter("@instructor_id", InstructorId));
                                        instructortocourse.Parameters.Add(new SqlParameter("@slot_id", slotID));

                                        conn.Open();
                                        instructortocourse.ExecuteNonQuery();
                                        conn.Close();
                                    }
                                }
                                else
                                {
                                    if (Session["SelectedChoice"].ToString() == "Link a student to an advisor")
                                    {
                                        if (TextBox12.Text.Length == 0 || TextBox13.Text.Length == 0)
                                        {
                                            ErrorMessage1.Text = "Please fill all fields";
                                            ErrorMessage1.Visible = true;

                                        }
                                        else
                                        {
                                            ErrorMessage1.Visible = false;
                                            int studentID = int.Parse(TextBox12.Text);
                                            int advisorID = int.Parse(TextBox13.Text);


                                            SqlCommand studenttoadvisor = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);
                                            studenttoadvisor.CommandType = CommandType.StoredProcedure;
                                            studenttoadvisor.Parameters.Add(new SqlParameter("@studentID", studentID));
                                            studenttoadvisor.Parameters.Add(new SqlParameter("@advisorID", advisorID));

                                            conn.Open();
                                            studenttoadvisor.ExecuteNonQuery();
                                            conn.Close();
                                        }
                                    }
                                    else
                                    {
                                        if (Session["SelectedChoice"].ToString() == "Link a student to a course with a specific instructor")
                                        {
                                            if (TextBox14.Text.Length == 0 || TextBox15.Text.Length == 0 || TextBox16.Text.Length == 0 || TextBox17.Text.Length == 0)
                                            {
                                                ErrorMessage1.Text = "Please fill all fields";
                                                ErrorMessage1.Visible = true;

                                            }
                                            else
                                            {
                                                ErrorMessage1.Visible = false;
                                                int InstructorID = int.Parse(TextBox14.Text);
                                                int studentID = int.Parse(TextBox15.Text);
                                                int courseID = int.Parse(TextBox16.Text);
                                                string semestercode = TextBox17.Text.ToString();


                                                SqlCommand studentinstructor = new SqlCommand("Procedures_AdminLinkStudent", conn);
                                                studentinstructor.CommandType = CommandType.StoredProcedure;
                                                studentinstructor.Parameters.Add(new SqlParameter("@cours_id", courseID));
                                                studentinstructor.Parameters.Add(new SqlParameter("@instructor_id", InstructorID));
                                                studentinstructor.Parameters.Add(new SqlParameter("@studentID", studentID));
                                                studentinstructor.Parameters.Add(new SqlParameter("@semester_code", semestercode));

                                                conn.Open();
                                                studentinstructor.ExecuteNonQuery();
                                                conn.Close();
                                            }
                                        }
                                        else
                                        {
                                            if (Session["SelectedChoice"].ToString() == "View all details of instructors along with their assigned courses")
                                            {
                                                ErrorMessage1.Visible = false;
                                                conn.Open();

                                                SqlCommand instructorcourse = new SqlCommand("Select * From Instructors_AssignedCourses", conn);

                                                SqlDataAdapter adapter = new SqlDataAdapter(instructorcourse);
                                                DataTable dataTable = new DataTable();

                                                // Fill the DataTable with the results of the stored procedure
                                                adapter.Fill(dataTable);

                                                // Bind the DataTable to the GridView
                                                viewcoursesofinstructor.DataSource = dataTable;
                                                viewcoursesofinstructor.DataBind();
                                                viewcoursesofinstructor.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }
    }
}