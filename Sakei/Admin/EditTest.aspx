<%@ Page Title="" Language="C#"   AutoEventWireup="true"  MasterPageFile="~/Admin/Admin.Master"  CodeBehind="EditTest.aspx.cs" Inherits="Sakei.Admin.EditTest" %>

<%--<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

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
                      <asp:TextBox runat="server" ID="TextBox1" Text='<%# Eval("Answer") %>'></asp:TextBox>
                    <asp:Literal runat="server" ID="ltlMobile" />
                    <asp:Button runat="server" Text="刪除" CommandName="DeleteButton" CommandArgument='<%# Eval("ID") %>' />
                    <asp:Button runat="server" Text="編輯" CommandName="EditButton" CommandArgument='<%# Eval("ID") %>' />
                </div>
            </ItemTemplate>
            
           
        </asp:Repeater>
</asp:Content>--%>
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
    <label class="label_input">題目類型</label>
    <asp:DropDownList ID="intType" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">讀音單字</asp:ListItem>
            <asp:ListItem Value="2">填入括號</asp:ListItem>
            <asp:ListItem Value="3">相近意思</asp:ListItem>
            <asp:ListItem Value="4">使用方法</asp:ListItem>
            <asp:ListItem Value="5">填入星號</asp:ListItem>
    </asp:DropDownList><br />
      <label class="label_input">題目內容 </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtContent"  placeholder="請輸入內容" ></asp:TextBox><br />
    <label class="label_input">選項A </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtOptionsA"  placeholder="請輸入內容" ></asp:TextBox><br />
     <label class="label_input">選項B </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtOptionsB"  placeholder="請輸入內容" ></asp:TextBox><br />
     <label class="label_input">選項C </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtOptionsC"  placeholder="請輸入內容" ></asp:TextBox><br />
     <label class="label_input">選項D </label>
    <asp:TextBox runat="server" CssClass="text_field" ID="txtOptionsD"  placeholder="請輸入內容" ></asp:TextBox><br />
      <label class="label_input">答案選項 </label>
    <asp:DropDownList ID="Answewr" runat="server" AutoPostBack="True">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>

            </asp:DropDownList><br />  

    <label class="label_input">題目狀態 </label><br />
        <asp:DropDownList ID="intEnable" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">停用</asp:ListItem>
            <asp:ListItem Value="1">啟用</asp:ListItem>
            
    </asp:DropDownList><br />  

        <asp:Literal runat="server" ID="ltlmsg"></asp:Literal>
      
      <asp:Button runat="server" CssClass="wweebtn" ID="btnConfirm" Text="確定" OnClick="btnConfirm_Click" />

    <asp:Literal ID="ltl1" runat="server"></asp:Literal><br /> 
   
     <a   href="#"   onclick="javascript:history.back();">返回前一頁</a>
     

</asp:Content>







<%@ Register Src="~/ShareControls/ucLevelChange.ascx" TagPrefix="uc1" TagName="ucLevelChange" %>
<%@ Register Src="~/ShareControls/ucPageChange.ascx" TagPrefix="uc1" TagName="ucPageChange" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divTestLest, #extraWindow, #extraWindow div {
            border: 0px;
        }

        .accordion-item div {
            border: 0px;
        }
        .spSubTitle{
            font-size:8pt;
            width:30%;
        }
        .spTitle{
            width:70%;
        }
    </style>
</asp:Content>



  