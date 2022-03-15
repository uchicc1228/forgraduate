<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Sakei.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         帳號:  <asp:TextBox runat="server" ID="txtAcc"></asp:TextBox><br />
         密碼:  <asp:TextBox runat="server" ID="txtPWD"></asp:TextBox><br />
         信箱:  <asp:TextBox runat="server" ID="txtMail"></asp:TextBox><br />
         暱稱:  <asp:TextBox runat="server" ID="txtNickName"></asp:TextBox><br />

    <asp:Button runat="server" ID="btnConfirm" text="確定" OnClick="btnConfirm_Click"/>
    <asp:Button runat="server" ID="btnCancel"  Text="取消重填"/>
    <asp:Literal ID="ltl1" runat="server"></asp:Literal>

</asp:Content>
