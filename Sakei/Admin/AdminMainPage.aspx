<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin/Admin.Master"  CodeBehind="AdminMainPage.aspx.cs" Inherits="Sakei.AdminMainPage" %>
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


    <img src="..\Images/page.jpg" style="margin: auto;" />



</asp:Content>
     <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   
    <asp:PlaceHolder runat="server" ID="plcLogin">
         <asp:Label ID="lblAdminName" runat="server" Text="使用者a"></asp:Label> <br />
            <asp:Label ID="lblAdminWelcome" runat="server" Text="歡迎，您的身分為:"></asp:Label>
            <asp:Label ID="lblAdminLevel" runat="server" Text=""></asp:Label> <br />
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
       


    </asp:PlaceHolder>
       





</asp:Content>



