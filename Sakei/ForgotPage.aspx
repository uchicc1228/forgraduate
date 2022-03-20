<%@ Page Title="忘記密碼" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPage.aspx.cs" Inherits="Sakei.ForgotPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
     <style>
        .wweebtn {
            font-size: 14px;
            font-family: 宋體;
            width: 120px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: white;
            background-color: black;
            border-radius: 6px;
            border: 0;
            position: relative;
            left: 230px;
            margin: 5px;
        }

            .wweebtn:hover {
                color: #003C9D;
                background-color: #fff;
                border: 2px #003C9D solid;
            }

        .label_input {
            font-size: 14px;
            font-family: 宋體;
            width: 70px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: black;
            background-color: white;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
        }

        .text_field {
            width: 278px;
            height: 28px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            border: 0;
        }

        .label_title {
            position: inherit ;
            left: 120px;
            font-size: 20px;
            font-family: 宋體;
            text-align: center;
            color: black;
            padding:20px;

        }

        .Content2{
           background-color:red;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">


    <img src="Images/下載.jpg" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <title>Forget Page</title>
   <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem runat="server" >忘記帳號</asp:ListItem>
        <asp:ListItem  runat="server">忘記密碼</asp:ListItem>
    </asp:RadioButtonList> <br />--%>
    <asp:PlaceHolder  runat="server" ID="plcForgat_acc">

         <label  class="label_title">忘記密碼</label><br />

        <label class="label_input">帳號</label>
        <asp:TextBox ID="txtAcc"  CssClass="text_field" runat="server"></asp:TextBox> <br />


       <label class="label_input">信箱</label>
        <asp:TextBox ID="txtMail"  CssClass="text_field" runat="server"></asp:TextBox>



        <asp:Button ID="btnConfirm"  CssClass="wweebtn" runat="server" Text="寄出認證信" OnClick="btnConfirm_Click" />
         <asp:Label runat="server" ID="lbl"></asp:Label>
    </asp:PlaceHolder>
  
</asp:Content>

