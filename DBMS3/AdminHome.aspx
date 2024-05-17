<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="DBMS3.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
        <div>
        </div>
            <asp:DropDownList ID="AdminTasks" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Admintask">
                <asp:ListItem>Choose An Admin Task</asp:ListItem>
                <asp:ListItem>List all advisors in the system</asp:ListItem>
                <asp:ListItem>List all students with their corresponding advisors in the system</asp:ListItem>
                <asp:ListItem>List all pending requests</asp:ListItem>
                <asp:ListItem>Add a new semester</asp:ListItem>
                <asp:ListItem>Add a new course</asp:ListItem>
                <asp:ListItem>Link instructor to a course in a specific slot</asp:ListItem>
                <asp:ListItem>Link a student to an advisor</asp:ListItem>
                <asp:ListItem>Link a student to a course with a specific instructor</asp:ListItem>
                <asp:ListItem>View all details of instructors along with their assigned courses</asp:ListItem>


                <asp:ListItem Text="Delete a course along with its related slots" Value="DeleteCourse" />
                <asp:ListItem Text="Delete a slot of a certain course if the course isn’t offered in the current semester" Value="DeleteSlot" />
                <asp:ListItem Text="Add makeup exam for a certain course" Value="AddMakeupExam" />
                <asp:ListItem Text="View details for all payments along with their corresponding students" Value="ViewPayments" />
                <asp:ListItem Text="Issue installments as per the number of installments for a certain payment" Value="IssueInstallments" />
                <asp:ListItem Text="Update a student status based on his/her financial status" Value="UpdateStudentStatus" />
                <asp:ListItem Text="Fetch all details of active students" Value="FetchActiveStudents" />
                <asp:ListItem Text="View all graduation plans along with their initiated advisors" Value="ViewGraduationPlans" />
                <asp:ListItem Text="View all students transcript details" Value="ViewTranscript" />
                <asp:ListItem Text="Fetch all semesters along with their offered courses." Value="FetchOfferedCourses" />
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Select action" OnClick="Button3_Click" />
            
            <br />
            <br />
            <asp:Panel ID="MainPanel" runat="server" Visible="false">
                 <asp:Button ID="Button10" runat="server" Text="Submit" OnClick="submit" />
                 <asp:Panel ID="P1" runat="server" Visible="false"><!-- List all advisors in the system -->
                     
                     <asp:GridView ID="listalladvisors" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
               
                </asp:Panel>

                 <asp:Panel ID="P2" runat="server" Visible="false"><!-- List all students with their corresponding advisors in the system -->
                     
                     <asp:GridView ID="Liststudentswithadvisors" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>

                 <asp:Panel ID="P3" runat="server" Visible="false"><!-- List all pending requests -->
                     <br />
              
                     <asp:GridView ID="Listpendingrequests" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>

                 <asp:Panel ID="P4" runat="server" Visible="false"><!-- Add a new semester -->
                     <asp:Label ID="Label10" runat="server" Text="Enter start date:  "></asp:Label>
                     <asp:TextBox ID="TextBox1" Type="Date" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label11" runat="server" Text="Enter end date:  "></asp:Label>
                     <asp:TextBox ID="TextBox2" Type="Date" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label12" runat="server" Text="Enter semester code:  "></asp:Label>
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                     <br />
                     <asp:GridView ID="Addsemester" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>

                 <asp:Panel ID="P5" runat="server" Visible="false"><!-- Add a new course -->
                     <asp:Label ID="Label13" runat="server" Text="Enter major:  "></asp:Label>
                     <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label14" runat="server" Text="Enter semester:  "></asp:Label>
                     <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label15" runat="server" Text="Enter credit hours:  "></asp:Label>
                     <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label8" runat="server" Text="Enter course name:  "></asp:Label>
                     <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label9" runat="server" Text="Enter offered:  "></asp:Label>
                     <asp:TextBox ID="TextBox8" Type="Bit" runat="server"></asp:TextBox>
                     <br />
                     <asp:GridView ID="Addcourse" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>

                 <asp:Panel ID="P6" runat="server" Visible="false"><!-- Link instructor to a course in a specific slot -->
                     <asp:Label ID="Label22" runat="server" Text="Enter InstructorId:  "></asp:Label>
                     <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label23" runat="server" Text="Enter courseId:  "></asp:Label>
                     <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label24" runat="server" Text="Enter slotID:  "></asp:Label>
                     <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                     <br />
                     <asp:GridView ID="linkinstructortocourseinslot" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>

                 <asp:Panel ID="P7" runat="server" Visible="false"><!-- Link a student to an advisor-->
                     <asp:Label ID="Label16" runat="server" Text="Enter studentID:  "></asp:Label>
                     <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label17" runat="server" Text="Enter advisorID:  "></asp:Label>
                     <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                     <br />
                     <br />
                     <asp:GridView ID="linkstudenttoadvisor" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>

                     <br/>
                 </asp:Panel>

                 <asp:Panel ID="P8" runat="server" Visible="false"><!-- Link a student to a course with a specific instructor -->
                     <asp:Label ID="Label18" runat="server" Text="Enter Instructor ID:  "></asp:Label>
                     <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label19" runat="server" Text="Enter student ID:  "></asp:Label>
                     <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label20" runat="server" Text="Enter course ID:  "></asp:Label>
                     <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label21" runat="server" Text="Enter semester code:  "></asp:Label>
                     <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                     <br />
                     <asp:GridView ID="Linkstudenttocoursewithinstructor" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>


                 <asp:Panel ID="P9" runat="server" Visible="false"><!-- View all details of instructors along with their assigned courses -->
                     <br />
                     
                     <asp:GridView ID="viewcoursesofinstructor" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                     <br/>
    
                 </asp:Panel>
            </asp:Panel>
        <br />
         <br />
         <asp:Label ID="ErrorMessage1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
         <br />
         <br />
         <br />
         <br />
            
    </form>
     <form id="Task_DeleteCourse" runat="server" visible="false">
             <asp:Label ID="SuccessMessageLabel" runat="server" Text="" ForeColor="Green"></asp:Label>

   <br />
            <asp:Label ID="Label1" runat="server" Text="Please Enter the Course ID"></asp:Label>
               <br />
            <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
<br />
        <asp:TextBox ID="Course_id" runat="server"></asp:TextBox>
          <br />
  <br />
        <asp:Button ID="DeleteCourse" runat="server" Text="Delete" OnClick="DeleteCourse_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DoneDeleteCourse" runat="server" Text="Return back" OnClick="DoneDelete_Click" />
        <br />
        </form>

         <form id="Task_DeleteSlot" runat="server" visible="false">
              <asp:Label ID="SuccessM" runat="server" Text="" ForeColor="Green"></asp:Label>
             <asp:Label ID="ErrorM" runat="server" Text="" ForeColor="Red"></asp:Label>
         <asp:Label ID="Label2" runat="server" Text="Please Enter the semster id "></asp:Label>
          <br />
          <br />
         <asp:TextBox ID="Slot_id" runat="server" ></asp:TextBox>
          <br />
          <br />
         <asp:Button ID="DeleteSlot" runat="server" Text="Delete" OnClick="DeleteSlot_Click" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="DoneDeleteSlot" runat="server" Text="Return back" OnClick="DoneDelete_Click2" />
         <br />
        </form>

       <form id="Task_AddMakeupExam" runat="server" visible="false">
            <asp:Label ID="SuccessM1" runat="server" Text="" ForeColor="Green"></asp:Label>
           <asp:Label ID="ErrorM1" runat="server" Text="" ForeColor="Red"></asp:Label>

       <asp:Label ID="Label3" runat="server" Text="Please Enter the Makeup Type"></asp:Label>
       <asp:TextBox ID="Makeup_Type" runat="server" ></asp:TextBox>
       <br />
       <br />
       <asp:Label ID="Label4" runat="server" Text="Please Enter the Makeup Date"></asp:Label>
       <asp:TextBox ID="Makeup_Date" runat="server" ></asp:TextBox>
       <br />
       <br />
      <asp:Label ID="Label5" runat="server" Text="Please Enter the courseid"></asp:Label>
      <asp:TextBox ID="courseid" runat="server" ></asp:TextBox>
       <br />
      <br />
     <asp:Button ID="Button1" runat="server" Text="Add Makeup" OnClick="AddMakeup_Click" />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button2" runat="server" Text="Return back" OnClick="DoneDelete_Click4" />
      <br />
      </form>

      <form id="Task_ViewPayments" runat="server" visible="false">
      <asp:Button ID="ViewButton1" runat="server" Text="View Payments" OnClick="ViewButton1_Click" />
          <br />
        <br />
      <asp:GridView ID="GridViewpayment" runat="server" Height="327px" Width="653px"></asp:GridView>
      <asp:Button ID="DoneViewPayment" runat="server" Text="Return back" OnClick="DoneDelete_Click3" />
      <br />
       </form>

   <form id="Task_IssueInstallments" runat="server" visible="false">
    <asp:Label ID="SuccessM2" runat="server" Text="" ForeColor="Green"></asp:Label>
      <asp:Label ID="ErrorM2" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Please Enter the Payment ID"></asp:Label>
    <br />
     <br />
    <asp:TextBox ID="PaymentID" runat="server" ></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="DoneIssueInstallment" runat="server" Text="Done" OnClick="InstallmentDone_Click" />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button4" runat="server" Text="Return back" OnClick="DoneDelete_Click5" />
   </form>

    <form id="Task_UpdateStudentStatus" runat="server" visible="false">
         <asp:Label ID="SuccessM3" runat="server" Text="" ForeColor="Green"></asp:Label>
   <asp:Label ID="ErrorM3" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="Please Enter the Student ID"></asp:Label>
   <br />
   <br />
    <asp:TextBox ID="StudentID" runat="server" ></asp:TextBox>
   <br />
  <br />
  <asp:Button ID="UpdateButton" runat="server" Text="Done" OnClick="Update_Click" />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Button ID="Button5" runat="server" Text="Return back" OnClick="DoneDelete_Click6" />
 </form>
        
  <form id="Task_FetchActiveStudents" runat="server" visible="false">
 <asp:Button ID="ActiveStudentsButton" runat="server" Text=" View ActiveStudents" OnClick="ViewActiveStudents_Click" />
     <br />
   <br />
 <asp:GridView ID="GridView2" runat="server" Height="327px" Width="653px"></asp:GridView>
 <asp:Button ID="Button6" runat="server" Text="Return back" OnClick="DoneDelete_Click7" />
 <br/>
  </form>

 <form id="Task_ViewGraduationPlans" runat="server" visible="false">
<asp:Button ID="ViewGraduationPlans" runat="server" Text=" View GraduationPlans" OnClick="ViewGraduationPlans_Click" />
    <br />
  <br />
<asp:GridView ID="GridView3" runat="server" Height="327px" Width="653px"></asp:GridView>
<asp:Button ID="Button7" runat="server" Text="Return back" OnClick="DoneDelete_Click8" />
<br/>
 </form>

 <form id="Task_ViewTranscript" runat="server" visible="false">
<asp:Button ID="ViewTranscript" runat="server" Text="View  Transcript" OnClick="ViewTranscript_Click" />
    <br />
  <br />
<asp:GridView ID="GridView4" runat="server" Height="327px" Width="653px"></asp:GridView>
<asp:Button ID="Button8" runat="server" Text="Return back" OnClick="DoneDelete_Click9" />
<br/>
 </form>


 <form id="Task_FetchOfferedCourses" runat="server" visible="false">
<asp:Button ID="FetchOfferedCoursesButton" runat="server" Text="View Offered Courses" OnClick="FetchOfferedCourses_Click" />
    <br />
  <br />
<asp:GridView ID="GridView5" runat="server" Height="327px" Width="653px"></asp:GridView>
<asp:Button ID="Button9" runat="server" Text="Return back" OnClick="DoneDelete_Click10" />
<br/>

</form>

</body>
</html>
