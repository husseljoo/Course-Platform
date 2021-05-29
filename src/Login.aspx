<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID:</div>
        <asp:TextBox ID="txt_id" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Password:"></asp:Label>
        </p>
        <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btn_login" runat="server" Text="Login" onclick="login"/>
        </p>
        <asp:Button ID="StudentReg" runat="server" Text="Register as Student   "  onclick="RegisterStudent"/>
        <p>
            <asp:Button ID="InstructReg" runat="server" Text="Register as Instructor" onclick="RegisterInstructor"/>
        </p>
    </form>
    </body>
</html>
