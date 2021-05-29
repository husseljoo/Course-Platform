<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailableCourses.aspx.cs" Inherits="GUCera_Web.AvailableCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p></p>
        <div>
             <asp:GridView ID="GridViewCourses" runat="server" > </asp:GridView>
        </div>
        <p></p>

		<div>
            <asp:Label ID="cid_label" runat="server" Text="Enter CID of the Course you want to view more info about: (If there are any available)"></asp:Label>
        </div>
        <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
         <p>
            <asp:Button ID="Enter_cid" runat="server" Text="View" onclick="viewCourseInfo"/>
        </p>
         <asp:Button ID="BackButton" runat="server" Text="Home Page" onclick="GoBack"/>
    </form>
</body>
</html>
