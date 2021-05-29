<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPromocode.aspx.cs" Inherits="GUCera_Web.ViewPromocode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        List of Promocodes Issued to you:
    </div>
    <form id="form1" runat="server">
        <asp:GridView ID="ViewPromocodes" runat="server">
        </asp:GridView>
         <p>
              <asp:Button ID="BackButton" runat="server" Text="Home Page" onclick="GoBack"/>
         </p>
    </form>
</body>
</html>
