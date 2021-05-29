<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorPage.aspx.cs" Inherits="GUCera_Web.InstructorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to Instructor page</div>
        <asp:Button ID="MobileAdd" runat="server" Text="Add Telephone number" onclick="AddTelephone"/>
		<p>
		<asp:Button ID="CourseAdd" runat="server" Text="Add new course" onclick="AddCourse"/>
		
    	</p>
		<asp:Button ID="Button1" runat="server" Text="Define assignment to course" OnClick="DefineAssignment" />
		
    	<p>
			<asp:Button ID="Button2" runat="server" Text="View Assignments" OnClick="ViewAssignment" />
		</p>
		
    	<asp:Button ID="Button3" runat="server" Text="Grade Assignment" OnClick="GradeAssignment" />
		
    	<p>
			<asp:Button ID="Button4" runat="server" Text="View feedbacks on course" OnClick="ViewFeedback" />
		</p>
		
    	<asp:Button ID="Button5" runat="server" Text="Issue Certificate" OnClick="IssueCertificate" />
		
    </form>
</body>
</html>
