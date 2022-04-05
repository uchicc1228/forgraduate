<%@ Page Title="" Language="C#"   AutoEventWireup="true" CodeBehind ="EditAdmin.aspx.cs" MasterPageFile="~/Admin/Admin.Master" Inherits="Sakei.Admin.EditAdmin" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">


    <img src="..\Images/page.jpg" style="margin: auto;" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <label  class="label_title">新增管理員</label><br />
        <label class="label_input">帳號</label>
    <asp:TextBox runat="server"    CssClass="text_field" ID="txtAcc"  placeholder="【帳號】輸入８～２０字元" ></asp:TextBox><br />

      <label class="label_input">密碼</label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtPWD"  placeholder="【密碼】輸入８～２０字元" ></asp:TextBox><br />
      <label class="label_input">使用者姓名 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtName"  placeholder="【使用者姓名】" ></asp:TextBox><br />
     <label class="label_input">信箱 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtMail"  placeholder="【信箱】" ></asp:TextBox><br />
        
    <label class="label_input">使用者等級 </label>
        <asp:DropDownList ID="intLevel" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">管理員</asp:ListItem>
            <asp:ListItem Value="1">主管</asp:ListItem>
            <asp:ListItem Value="2">員工</asp:ListItem>
    </asp:DropDownList><br />

      <label class="label_input">是否開通 </label>
        <asp:DropDownList ID="intIsEnable" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
            
    </asp:DropDownList><br />
    
        <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
        <asp:Button runat="server" CssClass="wweebtn" ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />


      
    <asp:Button runat="server" CssClass="wweebtn" ID="btnCancel" Text="取消重填" OnClick="btnCancel_Click" />
    <asp:Literal ID="ltl1" runat="server"></asp:Literal>
   <br />
    <a   href="#"   onclick="javascript:history.back();">返回前一頁</a>



    
</asp:Content>






