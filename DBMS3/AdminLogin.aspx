<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="DBMS3.AdminLogin" %>

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
        Admin Login<br />
        <br />
        <br />
        Please Login<br />
        Username<br />
        <asp:TextBox ID="UserNameAdmin" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="PassWordAdmin" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Adminlogin" Text="Login" /> 
        <br />
        <br />
        <asp:Label ID="ErrorMessageAdmin" runat="server" Text="Invalid ID/Password" ForeColor="Red" Visible="false"></asp:Label>
    </div>
</form>
</body>
</html>
