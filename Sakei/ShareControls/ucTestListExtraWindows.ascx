<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTestListExtraWindows.ascx.cs" Inherits="Sakei.ShareControls.ucTestListExtraWindows" %>

<%--筆記視窗--%>
    <div class="modal" id="divNoteWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <asp:Repeater ID="rptNote" runat="server">
                    <ItemTemplate>
                        <div class="modal-header">
                        </div>
                        <div class="modal-body">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>

    <%--留言視窗--%>
    <div class="modal" id="divMsgBordWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <asp:Repeater ID="rptMsgBoard" runat="server">
                    <ItemTemplate>

                        <div class="modal-header">

                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                        </div>
                        <div class="modal-body">
                            <p>確定要放棄此次測驗並回到主畫面嗎?</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-warning" data-bs-dismiss="modal">留言</button>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>