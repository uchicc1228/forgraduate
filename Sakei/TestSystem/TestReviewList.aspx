<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="TestReviewList.aspx.cs" Inherits="Sakei.TestSystem.TestReviewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--左側占比3--%>
<asp:Content ID="Content2" ContentPlaceHolderID="CP2" runat="server">

</asp:Content>
<%--右側占比9--%>
<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>

        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

