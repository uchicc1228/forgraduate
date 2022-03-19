<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="testtest.aspx.cs" Inherits="Sakei.testtest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Literal runat="server" id="ltl"></asp:Literal>
    <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click"  Text="登入"/>
    <asp:Button runat="server" ID="btnLogout" OnClick="btnLogout_Click"  Text="登出"/>
</asp:Content>
