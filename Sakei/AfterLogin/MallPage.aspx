<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="MallPage.aspx.cs" Inherits="Sakei.MallPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .picCharacter {
            position: relative;
            left: 45px;
            border: solid 1px black;
            padding: 5px;
            margin: 5px;
        }
        #Level {
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CP2" runat="server">

    <asp:Image ID="picCharacter" runat="server" ImageUrl="~/Images/下載.jpg" Width="200px" Height="250px" CssClass="picCharacter" />

    <div>
        <label class="lblfield">名稱</label>
        <asp:Label runat="server" ID="lblName" />
        <br />

        <label class="lblfield">積分</label>
        <asp:Label runat="server" ID="lblRank" />100/500
        <br />

        <label class="lblfield">等級</label>
        <asp:Label runat="server" ID="lblLevel" />N1
        <br />

        <label class="lblfield">金幣</label>
        <asp:Label runat="server" ID="lblMoney" />100$
        <br />
    </div>

    <div class="Level" align="center">
        <asp:Button ID="btnLV1" runat="server" Text="等級一" /><br />
        <asp:Button ID="btnLV2" runat="server" Text="等級二" /><br />
        <asp:Button ID="btnLV3" runat="server" Text="等級三" /><br />
        <asp:Button ID="btnLV4" runat="server" Text="等級四" /><br />
        <asp:Button ID="btnLV5" runat="server" Text="等級五" />
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">
    <td id="main" valign="top">
        <table width="800">
            <tr>
                <td align="center" valign="bottom">
                    <img src="images/PIC1.jpg" width="260">
                    裝備一</td>
                <td align="center" valign="bottom">
                    <img src="images/PIC2.jpg" width="260">
                    裝備二</td>
                <td align="center" valign="bottom">
                    <img src="images/PIC8.jpg" width="260">
                    裝備三</td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <img src="images/PIC5.jpg" width="260">
                    裝備四</td>
                <td align="center" valign="bottom">
                    <img src="images/PIC6.jpg" width="260">
                    裝備五</td>
                <td align="center" valign="bottom">
                    <img src="images/PIC7.jpg" width="260">
                    裝備六</td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <img src="images/PIC4.jpg" width="260">
                    裝備七</td>
                <td align="center" valign="bottom">
                    <img src="images/PIC3.jpg" width="260">
                    裝備八</td>
                <td align="center" valign="bottom">
                    <img src="images/PIC9.jpg" width="260">
                    裝備九</td>
            </tr>
        </table>
    </td>
</asp:Content>
