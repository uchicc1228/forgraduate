<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AfterLogin.Master" AutoEventWireup="true" CodeBehind="ExamReview.aspx.cs" Inherits="Sakei.ExamSystem.ExamReview" %>

<%@ Register Src="~/ShareControls/ucExamReviewExtraWindow.ascx" TagPrefix="uc1" TagName="ucExamReviewExtraWindow" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divTestLest {
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
            <itemtemplate>

                <div class="accordion-item">
                    <%--簡略題目內容--%>
                    <h2 class="accordion-header bg-warning" id="test-title">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divTestContent<%# Eval("TestID") %>" aria-expanded="false" aria-controls="flush-collapseOne">

                            <div runat="server" id="spTestListTitle">
                                <%# Eval("TestContentShort") %>
                            </div>
                            <div runat="server" id="spTypeContext">
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
                            <%--筆記留言板按鈕--%>
                            <div class="btn-group" role="group" aria-label="Basic outlined example">
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divNoteWindow" onclick="">筆記</button>
                                <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#divMsgBordWindow" onclick="">留言板</button>
                            </div>

                        </div>
                    </div>
                </div>


            </itemtemplate>
        </asp:Repeater>

    </div>



    <%--空畫面，當使用者未做過任何題目時顯示--%>
    <asp:PlaceHolder ID="plcEmpty" runat="server" Visible="false">
        <p>尚未作答</p>
    </asp:PlaceHolder>
    
    <uc1:ucExamReviewExtraWindow runat="server" ID="ucExamReviewExtraWindow" />

</asp:Content>
