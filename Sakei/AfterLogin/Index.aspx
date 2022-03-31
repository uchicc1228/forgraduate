<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sakei.AfterLogin.Index" %>

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

        .plcCharacterChanger {
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

    <asp:Button runat="server" ID="btnChCharacter" Text="鮭魚穿新衣" CssClass="btnInfoCh" OnClick="btnChCharacter_Click" />
    <br />
    <asp:Button runat="server" ID="btnInfoCh" Text="變更使用者資料" CssClass="btnInfoCh" OnClick="btnInfoCh_Click" />



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">
</asp:Content>
