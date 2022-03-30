<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNoteAndMsgWindow.ascx.cs" Inherits="Sakei.ShareControls.ucNoteAndMsgWindow" %>

<style>
    #divNoteWindow, #divMsgBordWindow, #divNoteWindow div, #divMsgBordWindow div {
        border: 0px;
    }
</style>
<div id="<%=this.ClientID %>">

    <%--筆記視窗--%>
    <div class="modal" id="divNoteWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">

                    <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <textarea name="Note" rows="10" cols="50"></textarea>
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

                <div class="modal-header">

                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                </div>
                <div class="modal-body">

                    <div class="card" style="width: 18rem;">
                        <ul class="list-group list-group-flush">

                            <asp:Repeater ID="rptMessageContent" runat="server">
                                <ItemTemplate>

                                    <li class="list-group-item"><%#Eval("MessageContent") %></li>

                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-bs-dismiss="modal">留言</button>
                </div>


            </div>
        </div>
    </div>

    

</div>
