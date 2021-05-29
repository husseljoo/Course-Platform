<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackCourse.aspx.cs" Inherits="GUCera_Web.FeedbackCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Comment:"></asp:Label>
        </div>
        <asp:TextBox ID="txt_comment" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="CourseID:"></asp:Label>
        </p>
        <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add Feedback" onclick ="AddFeedback"/>
        </p>
    </form>
</body>
</html>
