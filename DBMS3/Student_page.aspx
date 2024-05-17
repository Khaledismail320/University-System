<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_page.aspx.cs" Inherits="DBMS3.student_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Go to page 2" Width="202px" OnClick="PageChange" />
            <br />
            <br />
            <br />
            <asp:Label ID="for_courseandch" runat="server" Text="fill the info and after filling choose what the request you want ?"></asp:Label>
            <br />
            <asp:Label ID="forcourseid1" runat="server" Text="put what id of the course you want it(if you want to choose course request) :"></asp:Label>
            <asp:TextBox ID="courseID1" runat="server"></asp:TextBox>
            <br/>
            <asp:Label ID="forCH" runat="server" Text="put what id of the credit you want it(if you want to choose credit request) :"></asp:Label>
            <asp:TextBox ID="CHrequest" runat="server"></asp:TextBox>
            <br/>
            <asp:Label ID="labeltype1" runat="server" Text="Type:"></asp:Label>
            <asp:TextBox ID="type1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="labelcomment1" runat="server" Text="do you have any comment:"></asp:Label>
            <asp:TextBox ID="comment1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="courserequest" runat="server" OnClick="course_request" Text="course request" />
            <asp:Button ID="credithourrequest" runat="server" OnClick="credit_hour_request" Text="credit hour request" />
            <br/>
            <br />
            <br />
            <asp:Label ID="semcodelabel" runat="server" Text="put the semester code for courses you want ans choose what type courses you want:"></asp:Label>
            <asp:TextBox ID="semcode" runat="server" ></asp:TextBox>
            <asp:Button ID="o" runat="server" OnClick="optional_courses" Text=" optional courses " />
            <asp:Button ID="a" runat="server" OnClick="avaiable_courses" Text="available courses" />
            <asp:Button ID="r" runat="server" OnClick="required_course"  Text="required courses" />
            <asp:Button ID="m" runat="server" OnClick="missing_course" Text=" missing courses" />
            <br/>
            <br/>
            <asp:Button ID="mobile" runat="server" OnClick="mobile1" Text="add phon number" />
            <BR />
            <asp:TextBox ID="phone_num" runat="server"></asp:TextBox>
            <br />
            <asp:GridView ID="tables" runat="server" AutoGenerateColumns="true" >
            </asp:GridView>
            
        </div>
    </form>
</body>
</html>