<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentReg.aspx.cs" Inherits="DBMS3.StudentReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="go back to login" OnClick="logB_Click"  />
            <br />
            <br />
            <br />


            Enter your first name:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your last name:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your password:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your email:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your faculty:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your major:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter your Semester:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signupB" runat="server" Text="SignUp" onClick="SignUp"/>
            <br />
            <br />
            <asp:Label ID="idB" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="logB" runat="server" Text="proceed to login" Visible="false" OnClick="logB_Click" />


        </div>
    </form>
</body>
</html>
