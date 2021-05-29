<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="GUCera_Web.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" Text="Credit Hours"></asp:Label>
        </div>
		<asp:TextBox ID="txt_credit" runat="server"></asp:TextBox>
		
    	<p>
			<asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
		</p>
		
		<asp:TextBox ID="txt_courseName" runat="server"></asp:TextBox>
		
		
    	<p>
			<asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
		</p>
		
		
    	<asp:TextBox ID="txt_price" runat="server"></asp:TextBox>
		
		
    	<p>
			<asp:Button ID="CourseAdd" runat="server" Text="Add Course" OnClick="Add"/>
		</p>
		
		
    	<asp:Button ID="Button1" runat="server" Text="Home Page" OnClick="GoBack" />
		
		
    </form>
</body>
</html>
