<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNoteAndMsgBoard.ascx.cs" Inherits="Sakei.ShareControls.ucNoteAndMsgBoard" %>

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

 