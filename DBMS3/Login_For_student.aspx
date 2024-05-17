<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_For_student.aspx.cs" Inherits="DBMS3.Login_For_student" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button3" runat="server" Text="Back" OnClick="StartPageClick" />
<br />
<br />
            <asp:Label ID="welcomeLabel" runat="server" Text="Welcome to GUC"  Font-Size="Larger" ForeColor="#66ff66" ></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="userNameLabel" runat="server" Text="username :"></asp:Label>
            <br />
            <asp:TextBox ID="id" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
            <br />
            <asp:TextBox ID="password" runat="server" ></asp:TextBox>
            <br />
        <div>
           
            <br />
        </div>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" OnClick="login1" Text="log in" />
            <br/>
            <asp:Button ID="Button2" runat="server" Text="Register" OnClick="RegClick" />
            <br />
            <asp:Label ID="message" runat="server" Text=" " ForeColor="Red"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
