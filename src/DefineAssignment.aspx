<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineAssignment.aspx.cs" Inherits="GUCera_Web.DefineAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" Text="CourseID"></asp:Label>
        </div>
    	<asp:TextBox ID="txt_courseID" runat="server"></asp:TextBox>
		<p>
			<asp:Label ID="Label2" runat="server" Text="Number"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_type" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label4" runat="server" Text="Full Grade"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_grade" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label5" runat="server" Text="Weight"></asp:Label>
		</p>
    	<p>
			<asp:TextBox ID="txt_weight" runat="server"></asp:TextBox>
		</p>
    	<p>
			<asp:Label ID="Label6" runat="server" Text="Deadline"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_deadline" runat="server" textmode="Date"></asp:TextBox>
    	<p>
			<asp:Label ID="Label7" runat="server" Text="Content"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_content" runat="server"></asp:TextBox>
    	<p>
			<asp:Button ID="Button1" runat="server" Text="Add Assignment" OnClick="AddAssignment" />
		</p>
    	<asp:Button ID="Button2" runat="server" Text="Home Page" OnClick="GoBack" />
    </form>
</body>
</html>
