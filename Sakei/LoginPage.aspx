<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SaKei.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:PlaceHolder runat="server" ID="plcLogin">Account:
    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
     Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
     <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" />
      <asp:Button ID="forgotpwd" runat="server" Text="忘記密碼" OnClick="forgotpwd_Click" /><br />
     <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
    </asp:PlaceHolder>



    <asp:PlaceHolder runat="server" ID="plcUserInfo">
        <asp:Literal ID="ltlAccount" runat="server"></asp:Literal><br />
        請前往 <a href="/BackAdmin/Index.aspx">後台 </a>
    </asp:PlaceHolder>


</asp:Content>
