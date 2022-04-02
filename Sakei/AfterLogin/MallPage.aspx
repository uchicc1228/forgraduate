<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="MallPage.aspx.cs" Inherits="Sakei.MallPage" %>

<%@ Register Src="~/ShareControls/ucLevelChange.ascx" TagPrefix="uc1" TagName="ucLevelChange" %>
<%@ Register Src="~/ShareControls/ucPageChange.ascx" TagPrefix="uc1" TagName="ucPageChange" %>



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

        .items {
            margin-top: 30px;
            margin: 5px;
            width: 200px;
            height: 200px;
            float: left;
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

    <div class="Level">
        <asp:Button ID="btnLV1" runat="server" Text="等級一" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV2" runat="server" Text="等級二" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV3" runat="server" Text="等級三" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV4" runat="server" Text="等級四" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV5" runat="server" Text="等級五" CssClass="btnLevel" OnClick="btnLV_Click" /><br />
        <asp:Button ID="btnLV" runat="server" Text="全部" CssClass="btnLevel" OnClick="btnLV_Click" />
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">

    <h1>
        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
    </h1>
    <div class="picItems">
        <asp:Repeater ID="rptItems" runat="server" OnItemCommand="rptItems_ItemCommand">
            <ItemTemplate>
                <div class="items">
                    <image src="<%#Eval("Content") %>"></image>
                    <asp:Button runat="server" Text="購買" CommandName="BuyButton" CommandArgument='<%# Eval("ID") +","+ Eval("StyleContent") %>' OnClick="Buy_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script>function getData() {
            console.log("換衣服");
            $.ajax({
                url: "../API/MallHandler.ashx?Action=Mall",
                dataType: "json",
                success: function (jsonObj) {
                    // 成功。JSON物件處理作業



                },
                error: function (xhr, ajaxOptions, thrownError) {
                    // 錯誤。錯誤訊息處理
                    alert(xhr.status);
                    alert(thrownError);
                }
            });

        }
    </script>

</asp:Content>
