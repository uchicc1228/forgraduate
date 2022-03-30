﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="MallPage.aspx.cs" Inherits="Sakei.MallPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .picCharacter {
            position: relative;
            left: 45px;
            border: solid 1px black;
            padding: 5px;
            margin: 5px;
        }

        .info {
            position: relative;
            left: 45px;
            margin: 5px;
            border: 1px;
        }


        .lblfield {
            font-size: 14px;
            font-family: 宋體;
            width: 70px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: black;
            border: 1px solid black;
            margin: 5px;
            border: 0px;
        }

        .btnInfoCh {
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

        .divPWDChanger {
            position: relative;
            left: 250px;
            top: 160px;
            width: 380px;
            border: 0px;
        }

        .btnyes {
            font-size: 14px;
            width: 120px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: black;
            background-color: rgb(243, 229, 207);
            border-radius: 3px;
            border: 1px solid black;
            position: relative;
            left: 220px;
            margin: 5px;
        }

        .text_field {
            width: 278px;
            height: 28px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            border: 0;
            margin: 5px
        }

        .items {
            float: left;
            width: 200px;
            height: 400px;
            background-color: black;
        }

        h1 {
            text-align: center;
            font-family: 宋體;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CP2" runat="server">

    <asp:Image ID="picCharacter" runat="server" Width="200px" Height="250px" CssClass="picCharacter" />

    <div class="info">
        <label class="lblfield">名稱</label>
        <asp:Label runat="server" ID="lblName" />
        <br />

        <label class="lblfield">積分</label>
        <asp:Label runat="server" ID="lblRank" />
        pt
        <br />

        <label class="lblfield">等級</label>
        <asp:Label runat="server" ID="lblLevel" />
        lv
        <br />

        <label class="lblfield">金幣</label>
        $
        <asp:Label runat="server" ID="lblMoney" />
        <br />

    </div>

    <div class="Level" align="center">
        <asp:Button ID="btnLV1" runat="server" Text="等級一" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV2" runat="server" Text="等級二" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV3" runat="server" Text="等級三" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV4" runat="server" Text="等級四" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV5" runat="server" Text="等級五" OnClick="btnLV_Click" /><br />
        <asp:Button ID="Button1" runat="server" Text="全部" OnClick="btnLV_Click" />
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">
    <asp:Repeater ID="rptItems" runat="server">
        <ItemTemplate>
            <div class="items">
                <%# Eval("Content") %>
            </div>
        </ItemTemplate>
    </asp:Repeater>








    <table width="800">
        <tr>
            <td align="center" valign="bottom"><a>
                <a href="https://www.glaciel.jp/">
                    <img src="images/GB.jpg" width="100"></a>
                <p align="center" valign="bottom">GLACIEL</p>
            </td>
            <td align="center" valign="bottom">
                <img src="JPTShirt.png" width="260">
                裝備二</td>
            <td align="center" valign="bottom">
                <img src="~/Images/StyleDefault.png" width="260">
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

</asp:Content>
