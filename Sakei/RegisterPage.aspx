<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Sakei.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
        .Pager > a {
            margin: 5px;
        }

        .SearchPanel {
            border: 1px solid black;
        }

        .SearchPanel > label {
            font-size: large;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          
         帳號:  <asp:TextBox runat="server" ID="txtAcc" required placeholder="【帳號】輸入８～２０字元" Width="200px"  ></asp:TextBox><br />
         密碼:  <asp:TextBox runat="server" ID="txtPWD" required　placeholder="【密碼】輸入８～２０字元"  Width="200px" ></asp:TextBox><br />      
         信箱:  <asp:TextBox runat="server" ID="txtMail" required Width="200px" ></asp:TextBox   ><br />
                <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
    <asp:Button runat="server" ID="btnConfirm" text="確定並發送驗證信" OnClick="btnConfirm_Click"/>
    <asp:Button runat="server" ID="btnCancel"  Text="取消重填" OnClick="btnCancel_Click"/>
    <asp:Literal ID="ltl1" runat="server"></asp:Literal>

</asp:Content>
