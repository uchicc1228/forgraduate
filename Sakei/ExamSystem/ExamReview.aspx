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
                                    <p>您的答案為 : <%# Eval("TestAnswer") %></p>
                                </li>
                            </ul>
                            <%--筆記留言板按鈕--%>
                            <div class="btn-group" role="group" aria-label="Basic outlined example">
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divNoteWindow" onclick="btnNote_Click('<%# Eval("TestID") %>')">
                                    筆記
                                </button>
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divMsgBordWindow" onclick="btnMsgBoard_Click('<%# Eval("TestID") %>')">留言板</button>
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
    <%--<uc1:ucNoteAndMsgWindow runat="server" ID="ucNoteAndMsgWindow" />--%>

    <div class="modal" id="divNoteWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
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
    <script>

        function BulidNote(objData) {
            var rowsText = "";
            if (objData) {
                rowsText =
                    `
                       <textarea name="Note" rows="10" cols="50">${objData.UserNote}</textarea>
                           
                    `;
            }
            alert("bulid");
            $("#divNote").empty();
            $("#divNote").append(rowsText);

        };

        function btnNote_Click(testID) {
            alert("btnNote");
            var postData = {
                "userID":'<%=this.UserID%>',
                "testID": testID
            }
            $.ajax({
                url: "../API/ExamReviewHandler.ashx",
                method: "POST",
                data: postData,
                dataType: "JSON",
                success: function (objData) {
                    alert("sucess");
                    BulidNote(objData);
                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });

        }

        function btnMsgBoard_Click(testID) {
           <%-- var ucExtraWindowID = "<%= this.ucNoteAndMsgWindow.ClientID %>";
            alert(ucExtraWindowID);
            document.getElementById(ucExtraWindowID).setAttribute("testID", testID)--%>

        }
    </script>
</asp:Content>
