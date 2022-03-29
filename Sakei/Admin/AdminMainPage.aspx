<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMainPage.aspx.cs" Inherits="Sakei.AdminMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAdminName" runat="server" Text="Label"></asp:Label>  
            <asp:Label ID="lblAdminWelcome" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Label ID="lblEditAdmin" runat="server" Text="變更使用者"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="變更題庫"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="變更商品"></asp:Label>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Button" />
    </form>
</body>
</html>
