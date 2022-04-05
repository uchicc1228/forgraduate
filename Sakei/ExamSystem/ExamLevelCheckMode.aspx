<%@ Page Title="" Language="C#" MasterPageFile="~/ExamSystem/ExamSystemMaster.Master" AutoEventWireup="true" CodeBehind="ExamLevelCheckMode.aspx.cs" Inherits="Sakei.ExamSystem.ExamLevelCheckMode" %>

<%@ Register Src="~/ShareControls/ucNoteAndMsgBoard.ascx" TagPrefix="uc1" TagName="ucNoteAndMsgBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divQuestion {
            padding: 30px;
            height: 40%;
        }

            #divQuestion > h4 {
                color: #4C6D8E;
            }

            #divQuestion > h2 {
                color: #18454C;
            }

        #divOption {
            padding: 30px;
            height: 40%;
        }

            #divOption p {
                font-size: 24px;
            }

        #divBtnArea {
            height: 20%;
        }

            #divBtnArea > div {
                width: 50%;
                height: 100%;
                margin: auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--題目--%>
    <div id="divQuestion">

        <h4>----題型----</h4>

        <h2>----題目----</h2>

    </div>
    <%--答案選項--%>
    <div id="divOption" class="row align-items-center">
        <ul class="nav justify-content-center">
            <li class="nav-item">
                <label>
                    <input type="radio" name="option" value="A" checked="checked" /><span class="round btnOption">A.ans1</span>
                </label>
            </li>
            <li class="nav-item">
                <label>
                    <input type="radio" name="option" value="B" checked="checked" /><span class="round btnOption">B.ans2</span>
                </label>
            </li>
            <li class="nav-item">
                <label>
                    <input type="radio" name="option" value="C" checked="checked" /><span class="round btnOption">C.ans3</span>
                </label>
            </li>
            <li class="nav-item">
                <label>
                    <input type="radio" name="option" value="D" checked="checked" /><span class="round btnOption">D.ans4</span>
                </label>
            </li>
        </ul>

    </div>
    <style>
        #divOption input[type="radio"] {
            display: none;
        }

        #divOption input:checked + .btnOption {
            background: #0067E2;
            color: #FFE6D2;
            cursor: default;
        }

        #divOption .btnOption {
            display: inline-block;
            margin: 0px 10px;
            padding: 5px 10px;
            background: none;
            border: 0px;
            color: #18454C;
            cursor: pointer;
            font-size: 24px;
        }

            #divOption .btnOption:hover {
                background: #BDDBF4;
                color: #385B77;
            }

        #divOption .round {
            border-radius: 5px;
        }
    </style>

    <%--確認、筆記、留言板按鈕--%>
    <div id="divBtnArea">
        <div class=" row align-items-center gap-2">
            <button type="button" id="btnNote" class="col btn btn-secondary btn-lg" data-bs-toggle="modal" data-bs-target="#divNoteWindow" style="visibility: hidden;">筆記</button>
            <button type="button" id="btnSure" class="col btn btn-primary btn-lg">確定</button>
            <button type="button" id="btnMsgBoard" class="col btn btn-secondary btn-lg" data-bs-toggle="modal" data-bs-target="#divMsgBordWindow" style="visibility: hidden;">留言板</button>
        </div>

    </div>

    <%--筆記、留言板視窗--%>
    <uc1:ucNoteAndMsgBoard runat="server" ID="ucNoteAndMsgBoard" />


    <script>
        var userID ='<%=this.UserID%>';
        var userPoint =<%=this.UserData.UserPoints %>;
        var TestCount = 10;
        var TestLevel = 0;
        var userLevel =<%=this.UserData.UserLevel%>;
        var IsChalleng = false;
    </script>
   
    <script src="../JavaScript/ExamSystem/ExamSystem.js"></script>
</asp:Content>
