<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.Master" AutoEventWireup="true"   CodeBehind="EditTest.aspx.cs" Inherits="Sakei.EditTest" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label  class="label_title">新增題目</label><br />
    
      <label class="label_input">道具等級 </label>
        <asp:DropDownList ID="intLevel" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">N1</asp:ListItem>
            <asp:ListItem Value="2">N2</asp:ListItem>
            <asp:ListItem Value="3">N3</asp:ListItem>
            <asp:ListItem Value="4">N4</asp:ListItem>
            <asp:ListItem Value="5">N5</asp:ListItem>
    </asp:DropDownList><br />
    <label class="label_input">題目類型</label>&nbsp; <br />
      <label class="label_input">題目內容 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtTextContent"  placeholder="請輸入內容" ></asp:TextBox><br />
    <label class="label_input">選項A </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="TextBox1"  placeholder="請輸入內容" ></asp:TextBox><br />
     <label class="label_input">選項B </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="TextBox2"  placeholder="請輸入內容" ></asp:TextBox><br />
     <label class="label_input">選項C </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="TextBox3"  placeholder="請輸入內容" ></asp:TextBox><br />
     <label class="label_input">選項D </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="TextBox4"  placeholder="請輸入內容" ></asp:TextBox><br />
    <label class="label_input">題目狀態 </label><br />
        <asp:DropDownList ID="intEnable" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">停用</asp:ListItem>
            <asp:ListItem Value="1">啟用</asp:ListItem>
            
    </asp:DropDownList><br />  

        <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
      
      <asp:Button runat="server" CssClass="wweebtn" ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />

    <asp:Literal ID="ltl1" runat="server"></asp:Literal>
   
     

</asp:Content>
