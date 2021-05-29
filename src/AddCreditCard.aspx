<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCreditCard.aspx.cs" Inherits="GUCera_Web.AddCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
          Add your Credit Card Information:
       </div>
        
        <p>
            <asp:Label ID="Cardnumber" runat="server" Text="CreditCard number:"></asp:Label>
        </p>
        <asp:TextBox ID="txt_Cardnumber" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="HolderName" runat="server" Text="Cardholder name:"></asp:Label>
        </p>
        <asp:TextBox ID="txt_HolderName" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="ExpiryDate" runat="server" Text="Expiry Date: Format[YYYY-MM-DD]"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txt_ExpiryDate" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="cvv" runat="server" Text="CVV:"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txt_cvv" runat="server"></asp:TextBox>
        </p>
          <p>
            <asp:Button ID="Add" runat="server" Text="Add" onclick="CreditCardAdd"/>
        </p>
         <asp:Button ID="BackButton" runat="server" Text="Home Page" onclick="GoBack"/>
        
    </form>
</body>
</html>
