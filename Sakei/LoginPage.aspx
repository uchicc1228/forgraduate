<%@ Page Title="登入頁面" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SaKei.LoginPage" %>

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
            float: right;
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
            padding: 20px;
        }




        img {
            display: block;
            margin: 0 auto;
            width: 50%;
            padding-top: 20%;
        }


        .divbtn {
            padding-right: 33px;
            border: 0px;
        }
    </style>
</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">


    <img src="Images/page.jpg" style="margin: auto;" />



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:PlaceHolder runat="server" ID="plcLogin">
        <label class="label_title"><b>會員登入</b></label><br />
        <label class="label_input">帳號</label>
        <asp:TextBox CssClass="text_field" ID="txtAccount" runat="server" placeholder="【帳號】："> </asp:TextBox><br />
        <label class="label_input">密碼</label>
        <asp:TextBox ID="txtPassword" CssClass="text_field" runat="server" TextMode="Password" placeholder="【密碼】："> </asp:TextBox><br />


        <div class="divbtn">
            <asp:Button ID="btnLogin" CssClass="wweebtn" runat="server" Text="登入" OnClick="btnLogin_Click " />
            <%-- <asp:Button ID="btnLogout" CssClass="wweebtn" runat="server" Text="登出" OnClick="btnLogout_Click" />--%>
            <asp:Button ID="forgotpwd" CssClass="wweebtn" runat="server" Text="忘記密碼" OnClick="forgotpwd_Click" /><br />
            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
        </div>

    </asp:PlaceHolder>
</asp:Content>

