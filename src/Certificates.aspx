<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificates.aspx.cs" Inherits="GUCera_Web.Certificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter course id:"></asp:Label>
        </div>
        <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="View Certificate" onclick="View"/>
        <p>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </p>
    </form>
</body>
</html>
