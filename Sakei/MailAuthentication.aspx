<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="MailAuthentication.aspx.cs" Inherits="Sakei.MailAuthentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:Literal runat="server" ID="ltl1"></asp:Literal>

    輸入新密碼：<asp:TextBox runat="server" ID="txtpw1"></asp:TextBox>
    再輸入一次：<asp:TextBox runat="server" ID="txtpw2"></asp:TextBox>
    <asp:Button runat="server" ID="btnyes" TEXT="確定" OnClick="btnyes_Click" />

</asp:Content>
