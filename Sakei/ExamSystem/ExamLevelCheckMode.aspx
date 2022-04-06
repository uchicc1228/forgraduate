<%@ Page Title="" Language="C#" MasterPageFile="~/ExamSystem/ExamSystemMaster.Master" AutoEventWireup="true" CodeBehind="ExamLevelCheckMode.aspx.cs" Inherits="Sakei.ExamSystem.ExamLevelCheckMode" %>

<%@ Register Src="~/ShareControls/ucNoteAndMsgBoard.ascx" TagPrefix="uc1" TagName="ucNoteAndMsgBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>alert('註冊成功!幫您導入初次的等級測試。')</script>
    <link href="../CSS/ExamSystemCSS.css" rel="stylesheet" />

</asp:Content>
<%--考試模式標題--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ExamModeTitle" runat="server">
    等級決定試驗
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--題目--%>
    <div id="divQuestion">
    </div>
    <%--答案選項--%>
    <div id="divOption" class="row align-items-center">
    </div>

    <%--確認、筆記、留言板按鈕--%>
    <div id="divBtnArea">
        <div class=" row align-items-center gap-2">
            <button type="button" id="btnNote" class="col btn btn-secondary btn-lg" data-bs-toggle="modal" data-bs-target="#divNoteWindow" style="visibility: hidden;">筆記</button>
            <button type="button" id="btnSure" class="col btn btn-primary btn-lg">確定</button>
            <button type="button" id="btnMsgBoard" class="col btn btn-secondary btn-lg" data-bs-toggle="modal" data-bs-target="#divMsgBordWindow" style="visibility: hidden;">留言板</button>
        </div>

    </div>

    <%--筆記、留言板視窗--%>
    <uc1:ucNoteAndMsgBoard runat="server" ID="ucNoteAndMsgBoard" />


    <script>
        var userID ='<%=this.UserID%>';
        var userPoint =<%=this.UserData.UserPoints %>;
        var TestCount = 10;
        var TestLevel = 0;
        var userLevel =<%=this.UserData.UserLevel%>;
        var IsChalleng = false;
        var IsTheFirstExam = true;
    </script>

    <script src="../JavaScript/ExamSystem/ExamSystem.js"></script>
</asp:Content>
