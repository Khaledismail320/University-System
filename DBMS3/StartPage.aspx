<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="DBMS3.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Choose yout Role<br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Admin" OnClick="AdminClick" />
&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Advisor" OnClick="AdvisorClick" />
&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Student" OnClick="StudentClick" />
        </div>
    </form>
</body>
</html>
