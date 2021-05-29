<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueCertificate.aspx.cs" Inherits="GUCera_Web.IssueCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" Text="Course ID"></asp:Label>
        </div>
    	<asp:TextBox ID="txt_courseID" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label2" runat="server" Text="Student ID"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_studentID" runat="server"></asp:TextBox>
    	<p>
			<asp:Label ID="Label3" runat="server" Text="Issue Date"></asp:Label>
		</p>
    	<asp:TextBox ID="txt_issueDate" runat="server" TextMode="Date"></asp:TextBox>
    	<p>
			<asp:Button ID="Button1" runat="server" Text="Issue Certiticate" OnClick="issueCertificate" />
		</p>
    	<p>
			<asp:Button ID="Button2" runat="server" Text="Home Page" OnClick="GoBack" />
		</p>
    </form>
</body>
</html>
