<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DBMS3.Login" %>

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
            Advisor Login<br />
            <br />
            Please Login<br />
            Username<br />
            <asp:TextBox ID="UserNameA" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="PassWordA" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="login" Text="Login" /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Register" OnClick="RegClick" />
            <br />
            <br />
            <asp:Label ID="ErrorMessageL" runat="server" Text="Invalid ID/Password" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
