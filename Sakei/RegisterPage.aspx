<%@ Page Title="註冊頁面" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Sakei.RegisterPage" %>

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

         .divbtn{
            padding-right:33px;
            border:0px;
        }


        
    </style>  
     
        
    
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">


   <img src="Images/page.jpg" style="margin: auto;" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <label  class="label_title"><b>註冊會員</b></label><br />
        <label class="label_input">帳號</label>
    <asp:TextBox runat="server"    CssClass="text_field" ID="txtAcc"  placeholder="【帳號】輸入８～２０字元" ></asp:TextBox>

      <label class="label_input">密碼</label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtPWD"  placeholder="【密碼】輸入８～２０字元" ></asp:TextBox>

     <label class="label_input">信箱 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtMail"  placeholder="【信箱】" ></asp:TextBox><br />
   
    


    
         <asp:PlaceHolder  runat="server" ID="plc1">
        <label class="label_input">認證密碼</label>
        <asp:TextBox runat="server" CssClass="text_field" ID="txtcaptcha" required Width="200px"></asp:TextBox><br />
        <asp:Button runat="server" CssClass="wweebtn" ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />
    </asp:PlaceHolder>
 
   

   
         <asp:PlaceHolder runat="server" ID="plc2">
    <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
    <asp:Button runat="server" CssClass="wweebtn" ID="btnSend" Text="發送驗證信" OnClick="btnSend_Click" />
    <asp:Button runat="server" CssClass="wweebtn" ID="btnCancel" Text="取消重填" OnClick="btnCancel_Click" />
    <asp:Literal ID="ltl1" runat="server"></asp:Literal>
    </asp:PlaceHolder>
    
   
    

</asp:Content>
