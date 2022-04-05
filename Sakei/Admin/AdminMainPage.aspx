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
            <asp:Label ID="lblAdminName" runat="server" Text="使用者a"></asp:Label> <br />
            <asp:Label ID="lblAdminWelcome" runat="server" Text="歡迎，您的身分為:"></asp:Label>
            <asp:Label ID="lblAdminLevel" runat="server" Text=""></asp:Label>

        </div>
        <asp:Label ID="lblEditAdmin" runat="server" Text="變更使用者"></asp:Label>
        <br />
        <asp:Button ID="btnAdmin" runat="server" Text="進入" OnClick="btnAdmin_Click" />
        <br />
        <asp:Label ID="lblEditTest" runat="server" Text="變更題庫"></asp:Label>
        <br />
        <asp:Button ID="btnTest" runat="server" Text="進入" OnClick="btnTest_Click" />
        <br />
        <asp:Label ID="lblEditItem" runat="server" Text="變更商品"></asp:Label>
        <br />
        <asp:Button ID="btnItem" runat="server" Text="進入" OnClick="btnItem_Click" />
    </form>
</body>
</html>
