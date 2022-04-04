<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="ExamReview.aspx.cs" Inherits="Sakei.AfterLogin.ExamReview" %>

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

<%--左側占比3--%>
<asp:Content ID="Content2" ContentPlaceHolderID="CP2" runat="server">

    <uc1:ucLevelChange runat="server" ID="ucLevelChange" />

</asp:Content>

<%--右側占比9--%>
<asp:Content ID="Content3" ContentPlaceHolderID="CP3" runat="server">

    <%--清單顯示題目--%>
    <div class="accordion accordion-flush" id="divTestLest">
        <asp:Repeater ID="rptTestList" runat="server">
            <ItemTemplate>

                <div class="accordion-item">
                    <%--簡略題目內容--%>
                    <h2 class="accordion-header bg-warning" id="test-title">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divTestContent<%# Eval("TestID") %>" aria-expanded="false" aria-controls="flush-collapseOne">

                            <span class="spTitle"><%# Eval("TestContentShort") %></span>
                            <span class="spSubTitle"><%# Eval("TypeContext") %></span><br />
                        </button>
                    </h2>
                    <%--完整題目內容--%>
                    <div id="divTestContent<%# Eval("TestID") %>" class="accordion-collapse collapse" aria-labelledby="test-title" data-bs-parent="#divTestLest">
                        <div class="accordion-body">
                            <%--問題內容--%>
                            <div>
                                <%# Eval("TestContent") %>
                            </div>
                            <%--選項內容--%>
                            <ul class="nav justify-content-center">
                                <li class="nav-item">
                                    <p class="nav-link disabled">A.<%# Eval("OptionsA") %></p>
                                </li>
                                <li class="nav-item">
                                    <p class="nav-link disabled">B.<%# Eval("OptionsB") %></p>
                                </li>
                                <li class="nav-item">
                                    <p class="nav-link disabled">C.<%# Eval("OptionsC") %></p>
                                </li>
                                <li class="nav-item">
                                    <p class="nav-link disabled">D.<%# Eval("OptionsD") %></p>
                                </li>
                            </ul>
                            <ul class="nav justify-content-end">
                                <li class="nav-item">
                                    <p>正確答案為 : <%# Eval("TestAnswer") %></p>
                                </li>
                                <li class="nav-item">
                                    <p>您的答案為 : <%# Eval("UserAnswer") %></p>
                                </li>
                            </ul>
                            <%--筆記留言板按鈕--%>
                            <div class="btn-group" role="group" aria-label="Basic outlined example">
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divNoteWindow" onclick="btnNote_Click('<%# Eval("TestID") %>','<%#Eval("TestContent") %>','<%# Eval("UserAnswer") %>')">
                                    筆記
                                </button>
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divMsgBordWindow" onclick="btnMsgBoard_Click('<%# Eval("TestID") %>','<%#Eval("TestContent") %>')">留言板</button>
                            </div>

                        </div>
                    </div>
                </div>


            </ItemTemplate>
        </asp:Repeater>

    </div>

    <%--空畫面，當使用者未做過任何題目時顯示--%>
    <asp:PlaceHolder ID="plcEmpty" runat="server" Visible="false">
        <p>尚未作答</p>
    </asp:PlaceHolder>

    <%--切換頁數--%>
    <uc1:ucPageChange runat="server" ID="ucPageChange" />

    <%--筆記視窗--%>
    <div class="modal" id="divNoteWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header" id="divNoteTitle">
                </div>
                <div class="modal-body" id="divNote">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                    <button type="button" class="btn btn-warning" id="btnNoteSave">儲存</button>
                </div>

            </div>
        </div>
    </div>

    <%--留言視窗--%>
    <div class="modal" id="divMsgBordWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                <div class="modal-header" id="divMsgTitle">
                </div>
                <div class="modal-body" id="divMsgBoard">
                </div>
                <div class="modal-footer" id="divMsgFooter">
                    <div id="divMsgWriteContent">
                    </div>
                    <button type="button" class="btn btn-warning" id="btnMsgWrite">留言</button>
                </div>

                
            </div>
        </div>
    </div>

    <script>

        var testID = "";
        var userAnswer = "";
        var userID = "<%=this.UserID%>";

        //筆記
        function BulidNote(testID, testContent) {
            var postData = {
                "userID": userID,
                "testID": testID
            }
            $.ajax({
                url: "../API/ExamReviewHandler.ashx?Action=Note",
                method: "POST",
                data: postData,
                dataType: "JSON",
                success: function (objData) {

                    var noteTitle = `<h6> Q : <span id="noteTestContent">${testContent}</span></h6>`
                    var noteContent = ` <textarea id="Note" rows="10" cols="50" style="resize: none;" placeholder="記錄自己的想法吧!">${objData.UserNote}</textarea>`;

                    $("#divNote").empty();
                    $("#divNote").append(noteContent);

                    $("#divNoteTitle").empty();
                    $("#divNoteTitle").append(noteTitle);

                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });

        };

        function btnNote_Click(id, testContent, userAns) {
            testID = id;
            userAnswer = userAns;
            BulidNote(testID, testContent);

        }
        $("#btnNoteSave").click(function () {
            var noteContent = document.getElementById("Note").value;
            var testContent = document.getElementById("noteTestContent").innerText;
            var postData = {
                "userID": userID,
                "testID": testID,
                "UserNote": noteContent,
                "UserAnswer": userAnswer
            };
            $.ajax({
                url: "../API/ExamReviewHandler.ashx?Action=NoteWrite",
                method: "POST",
                data: postData,
                success: function () {
                    alert("筆記已儲存");
                    BulidNote(testID, testContent);

                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        });

        //留言板
        function BulidMsgBoard(testID, testContent) {
            $.ajax({
                url: "../API/ExamReviewHandler.ashx?Action=MsgBoard",
                method: "POST",
                data: { "testID": testID },
                dataType: "JSON",
                success: function (objDataList) {

                    var msgTitle =
                        `<h5> Q : <span id="msgTestContent">${testContent}</span></h5>`;
                    var msgContent = "";
                    for (var item of objDataList) {
                        var msgDate = new Date(item.CreateDate);
                        msgDate = msgDate.toLocaleString();
                        msgContent +=
                            `
                            <div class="card mb-3" style="max-width: 540px;">
                              <div class="row g-0">
                                <div class="col-md-4">
                                  <img src="${item.Character}" class="img-fluid rounded-start" alt="失蹤的鮭魚...">
                                </div>
                                <div class="col-md-8">
                                  <div class="card-body">
                                    <h5 class="card-title">${item.UserName}<span style="font-size:8pt;">( N${item.UserLevel} )</span></h5>
                                    <p class="card-text">${item.MessageContent}</p>
                                    <p class="card-text"><small class="text-muted">${msgDate}</small></p>
                                  </div>
                                </div>
                              </div>
                            </div>
                             `;
                    }

                    var msgWrite =
                        `<textarea id="txtMsgBoard" rows="4" cols="50" style="resize: none;" placeholder="留言分享自己的看法吧!"></textarea>`;

                    $("#divMsgBoard").empty();
                    $("#divMsgBoard").append(`<ul class="list - group list - group - flush">` + msgContent + "</ul >");

                    $("#divMsgTitle").empty();
                    $("#divMsgTitle").append(msgTitle);

                    $("#divMsgWriteContent").empty();
                    $("#divMsgWriteContent").append(msgWrite);

                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });

        }

        function btnMsgBoard_Click(id, testContent) {
            testID = id;
            BulidMsgBoard(testID, testContent);


        }

        $("#btnMsgWrite").click(function () {
            var msgWriteContent = document.getElementById("txtMsgBoard").value;
            var testContent = document.getElementById("msgTestContent").innerText;
            var postData = {
                "userID": userID,
                "testID": testID,
                "msg": msgWriteContent
            };
            $.ajax({
                url: "../API/ExamReviewHandler.ashx?Action=MsgWrite",
                method: "POST",
                data: postData,
                success: function (txtMsg) {
                    BulidMsgBoard(testID, testContent);

                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        });
    </script>
</asp:Content>