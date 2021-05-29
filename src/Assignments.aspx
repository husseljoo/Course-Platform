<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignments.aspx.cs" Inherits="GUCera_Web.Assignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please enter course id:"></asp:Label>
            <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="View" runat="server" Text="View Assignments of above course" onclick ="getAssign"/>
        <asp:Button ID="Grade" runat="server" Text="View Grades of Submitted Assignments of above course" onclick ="WantToViewGrade"/>
        <p>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Put assignment number to want"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txt_assignnum" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Put assignment type you want"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txt_type" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Submit" runat="server" Text="Submit the assignment" onclick ="SubmitAssign"/>
            <asp:Button ID="ViewGrades" runat="server" Text="View Grade" onclick ="ViewAssignGrade"/>
        </p>
    </form>
</body>
</html>
