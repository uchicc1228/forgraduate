<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNote.ascx.cs" Inherits="Sakei.ShareControls.ucNote" %>

<style>
    #divNoteWindow, #divNoteWindow div{
        border: 0px;
    }
</style>

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