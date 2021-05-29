<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseInfoExtended.aspx.cs" Inherits="GUCera_Web.CourseInfoExtended" %>

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
         <p>
            <asp:Button ID="label_enroll" runat="server" Text="Enroll" onclick="EnrollInCourse"/>
        </p>
        <p>
        <asp:Button ID="BackButtonAv" runat="server" Text="Available Courses" onclick="GoBackAvailableCourses"/>
        </p>
        <asp:Button ID="BackButton" runat="server" Text="Home Page" onclick="GoBackHomepage"/>

       </form>
</body>
</html>
