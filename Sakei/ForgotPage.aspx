﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPage.aspx.cs" Inherits="Sakei.ForgotPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem runat="server" >忘記帳號</asp:ListItem>
        <asp:ListItem  runat="server">忘記密碼</asp:ListItem>
    </asp:RadioButtonList> <br />--%>
    <asp:PlaceHolder  runat="server" ID="plcForgat_acc">

       使用者帳號：<asp:TextBox ID="txtAcc" runat="server"></asp:TextBox>
        使用者信箱：<asp:TextBox ID="txtMail" runat="server"></asp:TextBox>

    </asp:PlaceHolder>

 




</asp:Content>
