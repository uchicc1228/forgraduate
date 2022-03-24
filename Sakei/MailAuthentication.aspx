<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="MailAuthentication.aspx.cs" Inherits="Sakei.MailAuthentication" %>
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
            left: 100px;
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
            border: 1px solid black;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
        }

        .text_field {
            width: 278px;
            height: 28px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
             border: 1px solid black;
        }

        .label_title {
            position: inherit;
            left: 120px;
            font-size: 20px;
            font-family: 宋體;
            text-align: center;
            color: black;
            padding:20px;

        }

        

        
        img {
            display: block;
            margin: 0 auto;
            width: 50%;
            padding-top: 20%;
        }
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <label  class="label_title">驗證頁面</label><br />

    <label class="label_input">輸入新密碼</label>
    <asp:TextBox CssClass="text_field" runat="server" ID="txtpw1"></asp:TextBox> <br />

     <label class="label_input">再輸入一次</label>
    <asp:TextBox CssClass="text_field" runat="server" ID="txtpw2"></asp:TextBox> <br />
    <asp:Button   CssClass="wweebtn" runat="server" ID="btnyes" TEXT="確定" OnClick="btnyes_Click" />

</asp:Content>
