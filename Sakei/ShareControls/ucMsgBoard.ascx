<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMsgBoard.ascx.cs" Inherits="Sakei.ShareControls.ucMsgBoard" %>

<style>
    #divMsgBordWindow, #divMsgBordWindow div {
        border: 0px;
    }
</style>

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