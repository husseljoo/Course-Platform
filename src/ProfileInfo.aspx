<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileInfo.aspx.cs" Inherits="GUCera_Web.ProfileInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="ViewProfileInfo" runat="server">
        </asp:GridView>
         <p>
              <asp:Button ID="BackButton" runat="server" Text="Home Page" onclick="GoBack"/>
         </p>
    </form>
</body>
</html>
