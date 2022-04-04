<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"   CodeBehind="EditItem.aspx.cs" Inherits="Sakei.Admin.EditItem" %>


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
      
     <label class="label_input">道具狀態 </label>
        <asp:DropDownList ID="intEnable" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">停用</asp:ListItem>
            <asp:ListItem Value="1">啟用</asp:ListItem>
            
    </asp:DropDownList><br />  
   <asp:Label runat="server" ID="picMainlbl" Text="道具圖片(含角色)"></asp:Label>
    
    <asp:FileUpload runat="server" ID="ItemPicUploadMain"  /><br/>
    <asp:Label runat="server" ID="picClotheslbl" Text="道具圖片(不含角色)"></asp:Label>
    <asp:FileUpload runat="server" ID="ItemPicUploadClothes"  /><br/>
   
   
   


    
        <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
      
      <asp:Button runat="server"  ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />

    <asp:Literal ID="ltl1" runat="server"></asp:Literal>
   
     

</asp:Content>
