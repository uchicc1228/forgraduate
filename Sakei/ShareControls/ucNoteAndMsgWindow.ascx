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

   

    

</div>
