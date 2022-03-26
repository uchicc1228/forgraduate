<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true"  CodeBehind="EditItem.aspx.cs" Inherits="Sakei.EditItem" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label  class="label_title">新增道具</label><br />
    
    <label class="label_input">道具名稱</label>
    <asp:TextBox runat="server"    CssClass="text_field" ID="txtItemName"  placeholder="道具名稱" ></asp:TextBox><br />
     <label class="label_input">道具等級 </label>
        <asp:DropDownList ID="intLevel" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">N1</asp:ListItem>
            <asp:ListItem Value="2">N2</asp:ListItem>
            <asp:ListItem Value="3">N3</asp:ListItem>
            <asp:ListItem Value="4">N4</asp:ListItem>
            <asp:ListItem Value="5">N5</asp:ListItem>
    </asp:DropDownList><br />
      <label class="label_input">道具價格 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtItemPrice"  placeholder="請輸入數字" ></asp:TextBox><br />
       <label class="label_input">道具圖片 </label>

    <asp:FileUpload runat="server" ID="ItemPicUpload" /><br/>
    <label class="label_input">道具狀態 </label>
        <asp:DropDownList ID="intEnable" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">停用</asp:ListItem>
            <asp:ListItem Value="1">啟用</asp:ListItem>
            
    </asp:DropDownList><br />  
   


    
        <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
      
      <asp:Button runat="server" CssClass="wweebtn" ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />

    <asp:Literal ID="ltl1" runat="server"></asp:Literal>
   
     

</asp:Content>
