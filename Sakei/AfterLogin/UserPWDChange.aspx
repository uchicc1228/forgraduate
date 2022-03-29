<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="UserPWDChange.aspx.cs" Inherits="Sakei.AfterLogin.UserPWDChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CP2" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">

    <asp:PlaceHolder runat="server" ID="plcPWDChanger">
        <h1><b>變更使用者資料</b></h1>
        <div class="divPWDChanger">
            <label class="lblfield">原密碼</label><asp:TextBox runat="server" CssClass="text_field" ID="txtpwdOld"></asp:TextBox><br />
            <label class="lblfield">新密碼</label><asp:TextBox runat="server" CssClass="text_field" ID="txtpwdNew"></asp:TextBox><br />
            <label class="lblfield">再次輸入新密碼</label><asp:TextBox runat="server" CssClass="text_field" ID="txtpwdNewx2"></asp:TextBox><br />
             <asp:Button runat="server" ID="btnPWDyes" Text="確定變更" CssClass="btnyes"  OnClick="btnPWDyes_Click" />
            <hr />
            <label class="lblfield">暱稱　</label> <asp:TextBox runat="server" CssClass="text_field" ID="txtnick"></asp:TextBox><br />            
            <asp:Button runat="server" ID="btnNICKyes" Text="確定變更" CssClass="btnyes" OnClick="btnNICKyes_Click" />
        </div>
    </asp:PlaceHolder>

</asp:Content>
