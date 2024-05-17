<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="DBMS3.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button3" runat="server" Text="Go to page 1" Width="278px" OnClick="PageChange" />
            <br />
            <br />
        </div>
        <asp:DropDownList ID="ActionList" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="345px">
            <asp:ListItem>View Graduation Plane</asp:ListItem>
            <asp:ListItem>View the upcoming not paid installment</asp:ListItem>
            <asp:ListItem>View all courses along with exams details</asp:ListItem>
            <asp:ListItem>Register for first makeup exam</asp:ListItem>
            <asp:ListItem>Register for second makeup exam</asp:ListItem>
            <asp:ListItem>View all courses along with corresponding slots details and instructors</asp:ListItem>
            <asp:ListItem>View the slots of a certain course with their instructor</asp:ListItem>
            <asp:ListItem>Choose the instructor for a certain course</asp:ListItem>
            <asp:ListItem>View all details of all courses with their prerequisites</asp:ListItem>
        </asp:DropDownList>
       <br />
            <asp:Button ID="Button1" runat="server" Height="33px" Text="Select Action" Width="143px" OnClick="Action_Click" />
       <br />
         <br />
            
        
        <asp:Panel ID="MainPanel" runat="server" Visible="false">

            <asp:Panel ID="P1" runat="server" Visible="false"><!-- view graduation plane -->
               
                 <br />
                <asp:GridView ID="GraduationPlane" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                 <br/>
               
                </asp:Panel>

             <asp:Panel ID="P2" runat="server" Visible="false"><!-- view Installment -->
                
                  <br />
                 <asp:GridView ID="Installment" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
    
                 </asp:Panel>

            <asp:Panel ID="P3" runat="server" Visible="false"><!-- view CourseExam -->
                 <br />
              
                <asp:GridView ID="CourseExam" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                 <br/>
    
                </asp:Panel>

             <asp:Panel ID="P4" runat="server" Visible="false"><!-- RegisterFirst -->
                
                 <br />
                  <asp:Label ID="Label4" runat="server" Text="Enter Your Course ID:  "></asp:Label>
                     <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                 <br />
                  <asp:Label ID="Label5" runat="server" Text="Enter Your Current Semester Code:  "></asp:Label>
                     <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                  <br />
                 <asp:GridView ID="RegisterFirst" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
    
                 </asp:Panel>

             <asp:Panel ID="P5" runat="server" Visible="false"><!-- RegisterSecond -->
                 
                 <br />
                  <asp:Label ID="Label7" runat="server" Text="Enter Your Course ID:  "></asp:Label>
                     <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                 <br />
                  <asp:Label ID="Label8" runat="server" Text="Enter Your Current Semester Code:  "></asp:Label>
                     <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                  <br />
                 <asp:GridView ID="RegisterSecond" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
    
                 </asp:Panel>

             <asp:Panel ID="P6" runat="server" Visible="false"><!-- view CourseSlotDetails -->
                  <br />
                 <asp:GridView ID="CourseSlotDetails" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
    
                 </asp:Panel>

            <asp:Panel ID="P7" runat="server" Visible="false"><!-- view SlotCourseInstructor-->
                <asp:Label ID="Label9" runat="server" Text="Enter Your Instructor ID:  "></asp:Label>
                 <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <br />
                 <asp:Label ID="Label10" runat="server" Text="Enter Your Course ID:  "></asp:Label>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                <br />
                 <br />
                <asp:GridView ID="SlotCourseInstructor" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                 <br/>
                </asp:Panel>

             <asp:Panel ID="P8" runat="server" Visible="false"><!-- ChooseInstructor -->
                 
                 <br />
                  <asp:Label ID="Label14" runat="server" Text="Enter Your Instructor ID:  "></asp:Label>
                  <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                 <br />
                  <asp:Label ID="Label12" runat="server" Text="Enter Your Course ID:  "></asp:Label>
                     <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                 <br />
                  <asp:Label ID="Label13" runat="server" Text="Enter Your Current Semester Code:  "></asp:Label>
                     <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                  <br />
                 <asp:GridView ID="ChooseInstructor" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
    
                 </asp:Panel>


             <asp:Panel ID="P9" runat="server" Visible="false"><!-- view CoursePrerequisites -->
                  <br />
                 <asp:GridView ID="CoursePrerequisites" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
    
                 </asp:Panel>

             <br />
             <br />
             <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="FormSubmit" />
             <br />



        </asp:Panel>
         <br />
         <br />
         <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
         <br />
         <br />
         <br />
         <br />
    </form>
</body>
</html>
