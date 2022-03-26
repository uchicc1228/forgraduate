<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true"  CodeBehind="EditItem.aspx.cs" Inherits="Sakei.EditItem" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label  class="label_title">新增題目</label><br />
        <label class="label_input">帳號</label>
    <asp:TextBox runat="server"    CssClass="text_field" ID="txtAcc"  placeholder="【帳號】輸入８～２０字元" ></asp:TextBox><br />

      <label class="label_input">密碼</label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtPWD"  placeholder="【密碼】輸入８～２０字元" ></asp:TextBox><br />
      <label class="label_input">使用者姓名 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtName"  placeholder="【使用者姓名】" ></asp:TextBox><br />
     <label class="label_input">信箱 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtMail"  placeholder="【信箱】" ></asp:TextBox><br />
        
    <label class="label_input">題目等級 </label>
        <asp:DropDownList ID="intLevel" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2">N2</asp:ListItem>
            <asp:ListItem Value="3">N3</asp:ListItem>
            <asp:ListItem Value="4">N4</asp:ListItem>
            <asp:ListItem Value="5">N5</asp:ListItem>
    </asp:DropDownList><br />


    
        <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
        <asp:Button runat="server" CssClass="wweebtn" ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />


      
    <asp:Button runat="server" CssClass="wweebtn" ID="btnCancel" Text="取消重填" OnClick="btnCancel_Click" />
    <asp:Literal ID="ltl1" runat="server"></asp:Literal>
   
    

</asp:Content>
