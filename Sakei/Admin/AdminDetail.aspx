<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDetail.aspx.cs" Inherits="Sakei.Admin.AdminDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnPreRender="Repeater1_PreRender" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="c1">
                <asp:Literal runat="server" ID="ltl1"></asp:Literal>
                   
                <asp:Literal runat="server" ID="ltlID" Text='<%#Eval("ID") %>'></asp:Literal>
                    
                    <asp:TextBox runat="server" ID="intLevel" Text='<%# Eval("Level") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="intType" Text='<%# Eval("Type") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtContent" Text='<%# Eval("Content") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtOptionA" Text='<%# Eval("OptionA") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtOptionB" Text='<%# Eval("OptionB") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtOptionC" Text='<%# Eval("OptionC") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtOptionD" Text='<%# Eval("OptionD") %>'></asp:TextBox>
                      <asp:TextBox runat="server" ID="txtAnswer" Text='<%# Eval("Answer") %>'></asp:TextBox>
                    <asp:Literal runat="server" ID="ltlMobile" />
                   
                    <asp:Button runat="server" Text="編輯" CommandName="EditButton" CommandArgument='<%# Eval("ID") %>' />
                    <asp:Button runat="server" Text="刪除" CommandName="DeleteButton" CommandArgument='<%# Eval("ID") %>' />
                </div>
            </ItemTemplate>
            
           
        </asp:Repeater>
</asp:Content>
