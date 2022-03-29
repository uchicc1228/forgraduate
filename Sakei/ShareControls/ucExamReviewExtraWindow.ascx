﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucExamReviewExtraWindow.ascx.cs" Inherits="Sakei.ShareControls.ucExamReviewExtraWindow" %>

<style>
    #divNoteWindow, #divNoteWindow div, #divMsgBordWindow, #divMsgBordWindow div {
        border: 0px;
    }
</style>



<div id="<%= this.ClientID%>">

    <%--筆記視窗--%>
    <div class="modal" id="divNoteWindow" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">

                    <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine"></asp:TextBox>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                    <asp:Button ID="Button1" runat="server" Text="btnSave" />
                </div>

            </div>
        </div>
    </div>

    

</div>
