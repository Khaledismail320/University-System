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

    public partial class AdvisorHome : System.Web.UI.Page
    {

        string SelectedChoice = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label l = new Label();
                l.Text = "";
                Action.Controls.Add(l);
                ErrorMessage.Text = string.Empty;

            }
        }



        protected void SelectListChoose(object sender, EventArgs e)
        {




        }

        protected void SelectButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            Action.Controls.Clear();
            SelectedChoice = SelectList.SelectedValue;
            Label l = new Label();
            l.Text = SelectedChoice;
            Action.Controls.Add(l);

            mainP.Visible = true;
            Button1.Visible = true;
            SuccessMessage.Visible = false;
            ReqMsg.Visible = false;

            //Response.Write(Session["ID"].ToString());

            //don't forget to reset visibility for all other panels
            if (SelectedChoice == "View advising Students")
            {
                Session["SelectedChoice"] = "View advising Students";


                //to view table on select action
                int advisorid = int.Parse(Session["ID"].ToString());

                ErrorMessage.Visible = false;
                conn.Open();
                SqlCommand cmd = new SqlCommand("ViewAdvStudents", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@advisorID", advisorid));

                SqlDataAdapter viewStudents = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                viewStudents.Fill(datatable);
                allStudents.DataSource = datatable;
                allStudents.DataBind();

                allStudents.Visible = true;
                


                //update the visibility of panels
                P1.Visible = true;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;
                Button1.Visible = false;









            }
            else if (SelectedChoice == "Insert GP for Student")
            {
                //Semester code varchar(40), 
                //expected_graduation_date date, sem_credit_hours int,
                //advisor id int, student id int
                Session["SelectedChoice"] = "Insert GP for Student";
                P1.Visible = false;
                P2.Visible = true;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;


            }
            else if (SelectedChoice == "Insert course into GP")
            {
                Session["SelectedChoice"] = "Insert course into GP";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = true;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;
            }
            else if (SelectedChoice == "Update expected grad date")
            {

                Session["SelectedChoice"] = "Update expected grad date";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = true;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;

            }
            else if (SelectedChoice == "Delete course from GP")
            {

                Session["SelectedChoice"] = "Delete course from GP";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = true;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;

                

            }
            else if (SelectedChoice == "View students from major")
            {
                Session["SelectedChoice"] = "View students from major";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = true;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;
                SMtable.Visible = true;

            }
            else if (SelectedChoice == "View all Requests")
            {
                Session["SelectedChoice"] = "View all Requests";


                //to view on select action
                ErrorMessage.Visible = false;

                int advisorId = int.Parse(Session["ID"].ToString());
                conn.Open();



                SqlCommand viewReqs = new SqlCommand("SELECT * FROM FN_Advisors_Requests(@advisor_id)", conn);
                viewReqs.Parameters.AddWithValue("@advisor_id", advisorId);



                SqlDataAdapter adapter = new SqlDataAdapter(viewReqs);
                DataTable dataTable = new DataTable();


                adapter.Fill(dataTable);


                AllReqTable.DataSource = dataTable;
                AllReqTable.DataBind();
                AllReqTable.Visible = true;





                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = true;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = false;
                Button1.Visible = false;

                AllReqTable.Visible = true;

            }
            else if (SelectedChoice == "View all pending Requests")
            {
                Session["SelectedChoice"] = "View all pending Requests";


                //view on select action
                ErrorMessage.Visible = false;
                int advisorId = int.Parse(Session["ID"].ToString());
                conn.Open();

                SqlCommand viewpendingReqs = new SqlCommand("Procedures_AdvisorViewPendingRequests", conn);


                viewpendingReqs.CommandType = CommandType.StoredProcedure;

                // Assuming advisorId is an integer, parse it accordingly

                viewpendingReqs.Parameters.AddWithValue("@Advisor_ID", advisorId);

                // Create a SqlDataAdapter to fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(viewpendingReqs);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the results of the stored procedure
                adapter.Fill(dataTable);

                // Bind the DataTable to the GridView
                pendingTable.DataSource = dataTable;
                pendingTable.DataBind();
                pendingTable.Visible = true;




                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = true;
                P9.Visible = false;
                P10.Visible = false;
                Button1.Visible = false;
                pendingTable.Visible = true;

            }
            else if (SelectedChoice == "Approve/reject extra credit hours request")
            {
                Session["SelectedChoice"] = "Approve/reject extra credit hours request";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = true;
                P10.Visible = false;

            }
            else if (SelectedChoice == "Approve/reject extra courses request")
            {
                Session["SelectedChoice"] = "Approve/reject extra courses request";
                P1.Visible = false;
                P2.Visible = false;
                P3.Visible = false;
                P4.Visible = false;
                P5.Visible = false;
                P6.Visible = false;
                P7.Visible = false;
                P8.Visible = false;
                P9.Visible = false;
                P10.Visible = true;

            }







        }

        protected void FormSubmit(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            //System.Diagnostics.Debug.WriteLine();
            //System.Diagnostics.Debug.WriteLine(advisor_Id);
            //System.Diagnostics.Debug.WriteLine(advisor_Id);
            //System.Diagnostics.Debug.WriteLine(advisor_Id);
            SuccessMessage.Visible = false;
            
            ReqMsg.Visible = false;

            if (Session["SelectedChoice"].ToString() == "View advising Students")
            {


                    
                

            }
            else if (Session["SelectedChoice"].ToString() == "Insert GP for Student")
            {

                
                if (TextBox1.Text.Length == 0 || TextBox2.Text.Length == 0 || semcredithours.Text.Length == 0 ||  studentid.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {

                    ErrorMessage.Visible = false;
                    string semcode = TextBox1.Text.ToString();
                    DateTime expgrad = DateTime.Parse(TextBox2.Text.ToString());
                    
                    int semcredithour = int.Parse(semcredithours.Text);
                    int advisor = int.Parse(Session["ID"].ToString());
                    int student = int.Parse(studentid.Text);


                   




                    SqlCommand checkSt = new SqlCommand("YourStudent", conn);
                    checkSt.CommandType = CommandType.StoredProcedure;
                    checkSt.Parameters.Add(new SqlParameter("@studentID", student));
                    checkSt.Parameters.Add(new SqlParameter("@advisorID", advisor));
                    checkSt.Parameters.Add(new SqlParameter("@semcode", semcode));
                    checkSt.Parameters.Add(new SqlParameter("@chr", semcredithour));
                    checkSt.Parameters.Add(new SqlParameter("@EXP", expgrad));

                    SqlParameter YS = checkSt.Parameters.Add("@OUT", SqlDbType.Int);
                    YS.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkSt.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(YS.Value.ToString() + " your student <br />");
                    //Response.Write(success.Value);




                    SqlCommand checkCan = new SqlCommand("canHaveGP", conn);
                    checkCan.CommandType = CommandType.StoredProcedure;
                    checkCan.Parameters.Add(new SqlParameter("@studentID", student));
                    SqlParameter Can = checkCan.Parameters.Add("@OUT", SqlDbType.Int);
                    Can.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkCan.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(Can.Value.ToString() + " can have <br />");

                    Boolean dont = true;
                    //C.Value.ToString() == "1"
                    Boolean error = false;

                    if (YS.Value.ToString() == "0")
                    {
                        ErrorMessage.Text = "this is not your student";
                        ErrorMessage.Visible = true;

                    }
                    else if (YS.Value.ToString() == "2")
                    {
                        ErrorMessage.Text = "A plan already exists in the system with these details";
                        ErrorMessage.Visible = true;

                    }
                    else if (Can.Value.ToString() == "0")
                    {
                        ErrorMessage.Text = "student's acquired hours are less than 157";
                        ErrorMessage.Visible = true;

                    }
                    else
                    {

                        SqlCommand insertGP = new SqlCommand("Procedures_AdvisorCreateGP", conn);
                        insertGP.CommandType = CommandType.StoredProcedure;
                        insertGP.Parameters.Add(new SqlParameter("@Semester_code", semcode));
                        insertGP.Parameters.Add(new SqlParameter("@expected_graduation_date", expgrad));
                        insertGP.Parameters.Add(new SqlParameter("@sem_credit_hours", semcredithour));
                        insertGP.Parameters.Add(new SqlParameter("@advisor_id", advisor));
                        insertGP.Parameters.Add(new SqlParameter("@student_id", student));

                        

                        try
                        {
                            conn.Open();
                            insertGP.ExecuteNonQuery();
                            conn.Close();
                        }catch (Exception ex)
                        {

                            ErrorMessage.Text = ex.Message.ToString();
                            error = true;

                        }
                        if (!error)
                            SuccessMessage.Visible = true;
                    }

                }
            }
            else if (Session["SelectedChoice"].ToString() == "Insert course into GP")
            {

                if (TextBox3.Text.Length == 0 || TextBox4.Text.Length == 0 || TextBox7.Text.Length == 0) {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    ErrorMessage.Visible = false;

                    string semcode = TextBox3.Text.ToString();
                    string course = TextBox4.Text.ToString();
                    int studentid = int.Parse(TextBox7.Text);

                    //Check that the GP exists first
                    SqlCommand checkGP = new SqlCommand("HasGP", conn);
                    checkGP.CommandType=CommandType.StoredProcedure;
                    checkGP.Parameters.Add(new SqlParameter("@studentID",studentid)) ;
                    checkGP.Parameters.Add(new SqlParameter("@semcode", semcode));

                    SqlParameter GP = checkGP.Parameters.Add("@OUT", SqlDbType.Int);
                    GP.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkGP.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(GP.Value.ToString() + "<br />");
                    //Response.Write(success.Value);




                    SqlCommand checkC = new SqlCommand("CourseExists", conn);
                    checkC.CommandType = CommandType.StoredProcedure;
                    checkC.Parameters.Add(new SqlParameter("@coursename", course));
                    SqlParameter C = checkC.Parameters.Add("@OUT", SqlDbType.Int);
                    C.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkC.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(C.Value.ToString()+ "<br />");
                    
                    Boolean dont = true;
                    //C.Value.ToString() == "1"
                    //Response.Write(semcode);
                    //Response.Write(course);
                    //Response.Write(studentid);

                    if (GP.Value.ToString() == "0")
                    {
                        ErrorMessage.Text = "Graduation plan doesn't exist";
                        ErrorMessage.Visible = true;

                    }else if (C.Value.ToString() == "0")
                    {
                        ErrorMessage.Text = "Course you're trying to enter doesn't exist";
                        ErrorMessage.Visible = true;

                    }else
                    {
                       

                        SqlCommand insertcourseGP = new SqlCommand("Procedures_AdvisorAddCourseGP", conn);
                        insertcourseGP.CommandType = CommandType.StoredProcedure;
                        insertcourseGP.Parameters.Add(new SqlParameter("@student_id", studentid));
                        insertcourseGP.Parameters.Add(new SqlParameter("@Semester_code", semcode));
                        insertcourseGP.Parameters.Add(new SqlParameter("@course_name", course));

                        Boolean error=false;


                        try
                        {
                            conn.Open();
                            insertcourseGP.ExecuteNonQuery();
                            conn.Close();
                        }catch (Exception ex) {
                            if (ex.Message.ToString().Contains("Violation of PRIMARY KEY constraint 'PK__GradPlan__CE1B721E04CFE053'. Cannot insert duplicate key in object 'dbo.GradPlan_Course'. The duplicate key value is (1, 1, w20)"))
                            {
                                ErrorMessage.Text = "Course already exists in plan";
                                ErrorMessage.Visible = true;
                            }
                            else
                            {
                                ErrorMessage.Text = "Plan doesn't exist";
                                ErrorMessage.Visible = true;
                            }
                            error = true;   
                        
                        }

                        if(!error)
                            SuccessMessage.Visible = true;
                    }
                }
            }
            else if (Session["SelectedChoice"].ToString() == "Update expected grad date")
            {

                if (TextBox8.Text.Length == 0 || TextBox5.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    int studentid = int.Parse(TextBox8.Text);
                    string expgrad = TextBox5.Text.ToString();


                    SqlCommand checkGP = new SqlCommand("HasGPtoUpdate", conn);
                    checkGP.CommandType = CommandType.StoredProcedure;
                    checkGP.Parameters.Add(new SqlParameter("@studentID", studentid));


                    SqlParameter GP = checkGP.Parameters.Add("@OUT", SqlDbType.Int);
                    GP.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkGP.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(GP.Value.ToString() + "<br />");

                    Boolean dont=true;
                    Boolean error=false;

                    if (GP.Value.ToString() == "0")
                    {
                        ErrorMessage.Text = "Graduation plan doesn't exist";
                        ErrorMessage.Visible = true;

                    }
                    else { 
                    ErrorMessage.Visible = false;

                    SqlCommand updateGP = new SqlCommand("Procedures_AdvisorUpdateGP", conn);

                    updateGP.CommandType = CommandType.StoredProcedure;
                    updateGP.Parameters.Add(new SqlParameter("@expected_grad_date", expgrad));
                    updateGP.Parameters.Add(new SqlParameter("@studentID", studentid));

                        try
                        {
                            conn.Open();
                            updateGP.ExecuteNonQuery();
                            conn.Close();
                            SuccessMessage.Visible = true;
                        }catch (Exception ex)
                        {
                            ErrorMessage.Text = ex.ToString();
                            error = true;
                        }


                        if (!error)
                            SuccessMessage.Visible = true;
                    }
                }

            }
            else if (Session["SelectedChoice"].ToString() == "Delete course from GP")
            {

                if (TextBox6.Text.Length == 0 || TextBox11.Text.Length == 0 || TextBox12.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    string semcode = TextBox6.Text.ToString();
                    int course = int.Parse(TextBox11.Text);
                    int studentid = int.Parse(TextBox12.Text);


                    SqlCommand checkDelete = new SqlCommand("CanDeleteGPCourse", conn);
                    checkDelete.CommandType = CommandType.StoredProcedure;
                    checkDelete.Parameters.Add(new SqlParameter("@studentID", studentid));
                    checkDelete.Parameters.Add(new SqlParameter("@sem_code", semcode));
                    checkDelete.Parameters.Add(new SqlParameter("@courseID", course));

                    SqlParameter D = checkDelete.Parameters.Add("@OUT", SqlDbType.Int);
                    D.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkDelete.ExecuteNonQuery();
                    conn.Close();

                    //Response.Write(D.Value.ToString() + "<br />");


                    Boolean dont = true;
                    Boolean error = false;

                    if (D.Value.ToString() == "0" )
                    {
                        ErrorMessage.Text = "Graduation plan doesn't exist";
                        ErrorMessage.Visible = true;
                        //Response.Write(D.Value.ToString() + " 1 <br />");
                    }
                    else if (D.Value.ToString() == "2")
                    {
                        ErrorMessage.Text = "Course you're trying to delete isn't in graduation plan";
                        ErrorMessage.Visible = true;
                        //Response.Write(D.Value.ToString() + " 2 <br />");
                    }
                    else
                    {
                        //Response.Write(D.Value.ToString() + " 3  <br />");

                        ErrorMessage.Visible = false;
                        

                        SqlCommand deletecourseGP = new SqlCommand("Procedures_AdvisorDeleteFromGP", conn);
                        deletecourseGP.CommandType = CommandType.StoredProcedure;
                        deletecourseGP.Parameters.Add(new SqlParameter("@studentID", studentid));
                        deletecourseGP.Parameters.Add(new SqlParameter("@sem_code", semcode));
                        deletecourseGP.Parameters.Add(new SqlParameter("@courseID", course));

                        try
                        {
                            conn.Open();
                            deletecourseGP.ExecuteNonQuery();
                            conn.Close();
                        }catch (Exception ex)
                        {
                            ErrorMessage.Text = ex.ToString(); 
                            ErrorMessage.Visible = true;
                            error=true;
                        }
                        if (!error)
                            SuccessMessage.Visible = true;
                    }
                }





            }
            else if (Session["SelectedChoice"].ToString() == "View students from major")
            {
                if (TextBox9.Text.Length == 0 )
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    ErrorMessage.Visible = false;


                    //BEGIN

                    string major = TextBox9.Text;

                    int advisorId = int.Parse(Session["ID"].ToString());



                    conn.Open();

                    SqlCommand viewSM = new SqlCommand("Procedures_AdvisorViewAssignedStudents", conn);


                    viewSM.CommandType = CommandType.StoredProcedure;

                    // Assuming advisorId is an integer, parse it accordingly

                    
                    viewSM.Parameters.AddWithValue("@AdvisorID", advisorId);
                    viewSM.Parameters.AddWithValue("@major", major);

                    // Create a SqlDataAdapter to fill the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(viewSM);
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the stored procedure
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the GridView
                    SMtable.DataSource = dataTable;
                    SMtable.DataBind();
                    SMtable.Visible = true;
                }
            }
            else if (Session["SelectedChoice"].ToString() == "View all Requests")
            {
                
                    
                
            }
            else if (Session["SelectedChoice"].ToString() == "View all pending Requests")
            {

               
                    




                
            }
            else if (Session["SelectedChoice"].ToString() == "Approve/reject extra credit hours request")
            {

                if (TextBox15.Text.Length == 0 || TextBox16.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    int reqId = int.Parse(TextBox15.Text);
                    string semCode = TextBox16.Text;
                    int advisorID = int.Parse(Session["ID"].ToString());

                    string type = "credit";
                    

                    
                    
                    
                    Boolean error = false;


                   //test
                     
                        ErrorMessage.Visible = false;



                        SqlCommand arcredit = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", conn);
                        arcredit.CommandType = CommandType.StoredProcedure;
                        arcredit.Parameters.Add(new SqlParameter("@requestID", reqId));
                        arcredit.Parameters.Add(new SqlParameter("@current_sem_code", semCode));

                        try
                        {
                            conn.Open();
                            arcredit.ExecuteNonQuery();
                            conn.Close();
                        }catch (Exception ex)
                        {
                            ErrorMessage.Text= ex.Message;
                            error=true;

                        }
                        if (!error)
                        {
                            SqlCommand getStatus = new SqlCommand("getReqStatus", conn);
                            getStatus.CommandType = CommandType.StoredProcedure;
                            getStatus.Parameters.Add(new SqlParameter("@reqId", reqId));

                            SqlParameter gS = getStatus.Parameters.Add("@OUT", SqlDbType.Int);
                            gS.Direction = ParameterDirection.Output;

                            conn.Open();
                            getStatus.ExecuteNonQuery();
                            conn.Close();

                           // Response.Write(gS.Value.ToString() + " GET STATUS <br />");

                            if (gS.Value.ToString() == "1")
                            {
                                ReqMsg.Text = "Request approved";
                                ReqMsg.ForeColor = System.Drawing.Color.Green;
                                ReqMsg.Visible= true;

                            }
                            else
                            {
                                ReqMsg.Text = "Request rejected";
                                ReqMsg.ForeColor = System.Drawing.Color.Red;
                                ReqMsg.Visible = true;

                            }




                        





                    }

                }

            }
            else if (Session["SelectedChoice"].ToString() == "Approve/reject extra courses request")
            {

                if (TextBox17.Text.Length == 0 || TextBox18.Text.Length == 0)
                {
                    ErrorMessage.Text = "Please fill all fields";
                    ErrorMessage.Visible = true;

                }
                else
                {


                    int reqId = int.Parse(TextBox17.Text);
                    string semCode = TextBox18.Text;
                    int advisorID = int.Parse(Session["ID"].ToString());


                    

                    
                    
                        ErrorMessage.Visible = false;

                        Boolean error = false;
                    

                        SqlCommand arcourse = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn);
                        arcourse.CommandType = CommandType.StoredProcedure;
                        arcourse.Parameters.Add(new SqlParameter("@requestID", reqId)); 
                        arcourse.Parameters.Add(new SqlParameter("@current_semester_code", semCode));

                        try
                        {
                            conn.Open();
                            arcourse.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage.Text = ex.Message;
                            error = true;

                        }
                        if (!error)
                        {
                            SqlCommand getStatus = new SqlCommand("getReqStatus", conn);
                            getStatus.CommandType = CommandType.StoredProcedure;
                            getStatus.Parameters.Add(new SqlParameter("@reqId", reqId));

                            SqlParameter gS = getStatus.Parameters.Add("@OUT", SqlDbType.Int);
                            gS.Direction = ParameterDirection.Output;

                            conn.Open();
                            getStatus.ExecuteNonQuery();
                            conn.Close();

                            //Response.Write(gS.Value.ToString() + " GET STATUS <br />");

                            if (gS.Value.ToString() == "1")
                            {
                                ReqMsg.Text = "Request approved";
                                ReqMsg.ForeColor = System.Drawing.Color.Green;
                                ReqMsg.Visible = true;

                            }
                            else
                            {
                                ReqMsg.Text = "Request rejected";
                                ReqMsg.ForeColor = System.Drawing.Color.Red;
                                ReqMsg.Visible = true;

                            }




                        





                    }

                }

            }



            
        }

       

    }
    }
