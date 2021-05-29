<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeAssignment.aspx.cs" Inherits="GUCera_Web.GradeAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" Text="Student ID"></asp:Label>
        </div>
    	<asp:TextBox ID="txt_studentID" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label2" runat="server" Text="Course ID"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_courseID" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label3" runat="server" Text="Assignment number"></asp:Label>
		</p>
    	<p>
			<asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
		</p>
    	<asp:Label ID="Label4" runat="server" Text="Type"></asp:Label>
    	<p>
			<asp:TextBox ID="txt_type" runat="server"></asp:TextBox>
		</p>
    	<asp:Label ID="Label5" runat="server" Text="Grade"></asp:Label>
    	<p>
			<asp:TextBox ID="txt_grade" runat="server"></asp:TextBox>
		</p>
    	<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="gradeAssignment" />
    	<p>
			<asp:Button ID="Button2" runat="server" Text="Home Page" onclick="GoBack" />
		</p>
    </form>
</body>
</html>
