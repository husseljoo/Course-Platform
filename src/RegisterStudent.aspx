<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="GUCera_Web.RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="firstname" runat="server" Text="First name:"></asp:Label>
        </div>
        <asp:TextBox ID="txt_firstname" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lastname" runat="server" Text="Last name"></asp:Label>
        </p>
        <asp:TextBox ID="txt_lastname" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
        </p>
        <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Address" runat="server" Text="Address"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label>
        </p>
        <p>
            <asp:RadioButton ID="Male" runat="server" GroupName="gender" Text="Male" />
            <asp:RadioButton ID="Female" runat="server" GroupName="gender" Text="Female" />
        </p>
        <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
        <p>
        <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Register" runat="server" Text="Register" onclick="Registering"/>
        <p>
            <asp:Button ID="LoginPage" runat="server" Text="Go To Login Page" onclick="ReturnToLogin"/>
        </p>
    </form>
</body>
</html>
