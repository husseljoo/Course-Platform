<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="GUCera_Web.StudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to Student Page</div>
        <asp:Button ID="MobileAdd" runat="server" Text="Add Telephone number" onclick="AddTelephone"/>
            <p>
                <asp:Button ID="viewProfile" runat="server" Text="View My Profile" onclick="viewProfileInfo"/>
        <br />
        <br />
        <asp:Button ID="availableCourses" runat="server" Text="ViewAvailableCourses" onclick="dispAvailableCourses"/>
        <br />
        <br />
        <asp:Button ID="CreditCardAdd" runat="server" Text="Add Credit Card" onclick="AddCreditCard"/>
        <br />
        <br />
        <asp:Button ID="PromocodeView" runat="server" Text="View Promocodes" OnClick="ViewPromocodes" />
        </p>
        <p>
        <br />
            <asp:Button ID="ViewAssign" runat="server" Text="View & Submit Assignments and View Grades" onclick="ViewAssignments"/>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Add Feedback to Course" onclick ="FeedbackCourse"/>
        <p>
            <asp:Button ID="Button2" runat="server" Text="View all earned certificates" onclick="ViewAllCert"/>
        </p>
    </form>
</body>
</html>
