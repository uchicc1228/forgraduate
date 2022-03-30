<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="ExamReview.aspx.cs" Inherits="Sakei.ExamSystem.ExamReview" %>

<%@ Register Src="~/ShareControls/ucNoteAndMsgWindow.ascx" TagPrefix="uc1" TagName="ucNoteAndMsgWindow" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divTestLest, #extraWindow, #extraWindow div {
            border: 0px;
        }

        .accordion-item div {
            border: 0px;
        }
    </style>
</asp:Content>

<%--左側占比3--%>
<asp:Content ID="Content2" ContentPlaceHolderID="CP2" runat="server">
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
                            <div runat="server" class="spTestListTitle">
                                <%# Eval("TestContentShort") %>
                            </div>

                            <div runat="server" class="spTypeContext" style="display: none;">
                                <%# Eval("TypeContext") %>
                            </div>

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
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divNoteWindow" onclick="btnNote_Click('<%# Eval("TestID") %>','<%#Eval("TestContent") %>')">
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
                    <asp:Button ID="btnSave" runat="server" Text="儲存" />
                </div>

            </div>
        </div>
    </div>

    <%--留言視窗--%>
    <div class="modal" id="divMsgBordWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                <div class="modal-header" id="divMsgTitle">
                </div>
                <div class="modal-body" id="msgBoard">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-bs-dismiss="modal">留言</button>
                </div>


            </div>
        </div>
    </div>

    <script>

        function BulidNote(objData, testContent) {
            var noteTitle = `<h6> Q : ${testContent}</h6>`
            var noteContent = ` <textarea name="Note" rows="10" cols="50">${objData.UserNote}</textarea>`;

            $("#divNote").empty();
            $("#divNote").append(noteContent);

            $("#divNoteTitle").empty();
            $("#divNoteTitle").append(noteTitle);
        };

        function btnNote_Click(testID, testContent) {
            var postData = {
                "userID":'<%=this.UserID%>',
                "testID": testID
            }
            $.ajax({
                url: "../API/ExamReviewHandler.ashx?Action=Note",
                method: "POST",
                data: postData,
                dataType: "JSON",
                success: function (objData) {
                    BulidNote(objData, testContent);
                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });

        }

        function BulidMsgBoard(objDataList, testContent) {
            var msgTitle =
                `<h5> Q : ${testContent}</h5>
                `;
            var msgContent = "";
            for (var item of objDataList) {
                var msgDate = new Date(item.CreateDate);
                msgDate = msgDate.toLocaleString();
                msgContent +=
                    `
                    <div class="card">
                      <div class="card-header">
                        ${item.UserName}(Lv.N${item.UserLevel})
                      </div>
                      <div class="card-body">
                        <blockquote class="blockquote mb-0">
                          <p>${item.MessageContent}</p>
                          <footer class="blockquote-footer">${msgDate}</cite></footer>
                        </blockquote>
                      </div>
                    </div>
                    `;
            }
            $("#msgBoard").empty();
            $("#msgBoard").append(`<ul class="list - group list - group - flush">` + msgContent + "</ul >");

            $("#divMsgTitle").empty();
            $("#divMsgTitle").append(msgTitle);
        }

        function btnMsgBoard_Click(testID, testContent) {
            $.ajax({
                url: "../API/ExamReviewHandler.ashx?Action=MsgBoard",
                method: "POST",
                data: { "testID": testID },
                dataType: "JSON",
                success: function (objDataList) {
                    BulidMsgBoard(objDataList, testContent);
                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        }
    </script>
</asp:Content>
