<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTelephone.aspx.cs" Inherits="GUCera_Web.AddTelephone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Add new telephone number:"></asp:Label>
        </div>
        <asp:TextBox ID="txt_mobilenumber" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Add" runat="server" Text="Add" onclick="AddNumber"/>
        </p>
        <asp:Button ID="BackButton" runat="server" Text="Home Page" onclick="GoBack"/>
    </form>
</body>
</html>
