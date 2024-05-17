<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorHome.aspx.cs" Inherits="DBMS3.AdvisorHome" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="SelectList" runat="server" OnSelectedIndexChanged="SelectListChoose">
                <asp:ListItem>View advising Students</asp:ListItem>
                <asp:ListItem>Insert GP for Student</asp:ListItem>
                <asp:ListItem>Insert course into GP</asp:ListItem>
                <asp:ListItem>Update expected grad date</asp:ListItem>
                <asp:ListItem>Delete course from GP</asp:ListItem>
                <asp:ListItem>View students from major</asp:ListItem>
                <asp:ListItem>View all Requests</asp:ListItem>
                <asp:ListItem>View all pending Requests</asp:ListItem>
                <asp:ListItem>Approve/reject extra credit hours request</asp:ListItem>
                <asp:ListItem>Approve/reject extra courses request</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <asp:Button ID="SelectButton" runat="server" Text="Select Action" OnClick="SelectButton_Click" />
        <br />
        <br />
        <asp:Panel runat="server" ID="mainP" Visible="false"><!-- main panel -->

             <asp:Panel ID="P1" runat="server" Visible="false"><!-- view his students panel -->
                 
                  <br />
                 <asp:GridView ID="allStudents" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                  <br/>
                 <br />
                
                <br />


             </asp:Panel><!-- view his students panel -->



            <asp:Panel ID="P2" runat="server" Visible="false"><!-- insert gp panel -->
                            <asp:Label ID="Label4" runat="server" Text=" Enter Semester Code:  "></asp:Label>
           
                            <asp:TextBox ID="TextBox1" runat="server" Width="196px"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text=" Enter Expected Graduation Date:  "></asp:Label>
           
                            <asp:TextBox ID="TextBox2" Type="date" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Enter Semester Credit Hours:  "></asp:Label>
                            &nbsp;<asp:TextBox ID="semcredithours" runat="server"></asp:TextBox>
                            <br />
                            
                            <asp:Label ID="Label3" runat="server" Text="Enter the Student's ID:  "></asp:Label>
                            <asp:TextBox ID="studentid" runat="server"></asp:TextBox>

                 
                 <br />
                </asp:Panel><!-- insert gp panel -->


            <asp:Panel ID="P3" runat="server" Visible="false"><!-- insert course into gp panel -->
                <asp:Label ID="Label6" runat="server" Text=" Enter Semester Code:  "></asp:Label>
           
                <asp:TextBox ID="TextBox3" runat="server" Width="196px"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text=" Enter course name:  "></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Enter the Student's ID:  "></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>

                 
                 <br />


            </asp:Panel> <!-- insert course into gp panel -->

            <asp:Panel ID="P4" runat="server" Visible="false"><!-- update grad date panel -->
                <asp:Label ID="Label8" runat="server" Text=" Enter Expected Graduation Date :  "></asp:Label>
           
                <asp:TextBox ID="TextBox5" runat="server" Type="date" Width="196px"></asp:TextBox>
            
                <br />
                <asp:Label ID="Label11" runat="server" Text="Enter the Student's ID:  "></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

                 
                 <br />

            </asp:Panel> <!-- update grad date panel -->

            <asp:Panel ID="P5" runat="server" Visible="false"><!-- delete course from gp panel -->
                <asp:Label ID="Label9" runat="server" Text=" Enter Semester Code:  "></asp:Label>
           
                <asp:TextBox ID="TextBox6" runat="server" Width="196px"></asp:TextBox>
                <br />
                <asp:Label ID="Label14" runat="server" Text="Enter course ID:  "></asp:Label>
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label15" runat="server" Text="Enter the Student's ID:  "></asp:Label>
                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>


                 
                 <br />

            </asp:Panel><!-- delete course from gp panel -->

            <asp:Panel ID="P6" runat="server" Visible="false"> <!-- view students from certain major panel -->
                <asp:Label ID="Label12" runat="server" Text="Enter major :  "></asp:Label>
           
                <asp:TextBox ID="TextBox9" runat="server" Width="196px"></asp:TextBox>

                <br />
                
                <br />
                <br />

                 
                 <br />
                
                  <br />
                <asp:GridView ID="SMtable" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
                

                <br/>

            </asp:Panel> <!-- view students from certain major panel -->

            <asp:Panel ID="P7" runat="server" Visible="false" style="margin-top: 0px"><!-- view all requests panel -->

                 
                 <br />
                
                 <br />
                 <asp:GridView ID="AllReqTable" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                 <br/>
                </asp:Panel> <!-- view all requests panel -->


             <asp:Panel ID="P8" runat="server" Visible="false"><!-- view all pending requests panel -->
                 
                    <br />
                    
                    <br />
                    <br />
                    <asp:GridView ID="pendingTable" runat="server" Height="327px" Width="653px" Visible="false"></asp:GridView>
 
                    <br/>


            </asp:Panel> <!-- view all pending requests panel -->

            <asp:Panel ID="P9" runat="server" Visible="false"><!-- a/r credit hours requests panel -->
                <asp:Label ID="Label18" runat="server" Text="Enter Request ID:  "></asp:Label>
                  <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                  <br />
                <asp:Label ID="Label19" runat="server" Text="Enter Current semester code:  "></asp:Label>
                  <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                  <br />



            </asp:Panel> <!-- a/r credit hours requests panel -->


             <asp:Panel ID="P10" runat="server" Visible="false"><!-- a/r course requests panel -->
                 <asp:Label ID="Label20" runat="server" Text="Enter Request ID:  "></asp:Label>
                   <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                   <br />
                 <asp:Label ID="Label21" runat="server" Text="Enter Current semester code:  "></asp:Label>
                   <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                   <br />



             </asp:Panel> <!-- a/r course requests panel -->



            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="FormSubmit" />
            <br />

        

        </asp:Panel> <!-- main panel -->
        <br />
        <br />
        <asp:PlaceHolder ID="Action" runat="server"></asp:PlaceHolder>
        <br />
        <br />
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="SuccessMessage" runat="server" Text="Action done successfully" ForeColor="Green" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="ReqMsg" runat="server" Text="Action done successfully" ForeColor="Green" Visible="false"></asp:Label>
        <br />
        <br />
    </form>
</body>
</html>
