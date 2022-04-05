<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLevelChange.ascx.cs" Inherits="Sakei.ShareControls.ucLevelChange" %>

<style>
    .btnLevel {
            font-size: 14px;
            font-family: 宋體;
            width: 120px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: black;
            background-color: rgb(243, 229, 207);
            border-radius: 3px;
            border: 1px solid black;
            position: relative;
            left: 70px;
            margin: 5px;
        }
</style>

<div class="Level" align="center">
    <asp:Button ID="btnLV1" runat="server" Text="等級一" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
    <asp:Button ID="btnLV2" runat="server" Text="等級二" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
    <asp:Button ID="btnLV3" runat="server" Text="等級三" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
    <asp:Button ID="btnLV4" runat="server" Text="等級四" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
    <asp:Button ID="btnLV5" runat="server" Text="等級五" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
    <asp:Button ID="btnLV" runat="server" Text="全部" CssClass="btnLevel" OnClick="btnLV_Click" />
</div>
