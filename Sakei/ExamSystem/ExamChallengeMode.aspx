<%@ Page Title="" Language="C#" MasterPageFile="~/ExamSystem/ExamSystemMaster.Master" AutoEventWireup="true" CodeBehind="ExamChallengeMode.aspx.cs" Inherits="Sakei.ExamSystem.ExamChallengeMode1" %>

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
        var IsChalleng = true;
        $(document).ready(function () {
            //正確數
            var right = 0;
            //題目進程
            var scheddule = 0;
            //判斷為考題或解答畫面
            var IsExam = false;
            //題目資料
            var examDataList;
            //使用者答案
            var userAnswer = "";
            //正確答案
            var examAnswer = "";


            //確定考題等級
            if (userPoint >= 100 && userLevel != 1) {
                TestLevel = userLevel - 1;
                scheddule = -1;
                LevelUpMsg();
            } else {
                TestLevel = userLevel;
                scheddule = 0;
                IsExam = true;
                StartExam();
            }


            function LevelUpMsg() {
                var rowsText = ` <div style="height:100%; text-align:center; line-height:300px; font-size:30pt;">
                                    積分已達標準，開始向下一階段的挑戰!
                                 </div>`;
                $("#divQuestion").empty();
                $("#divQuestion").append(rowsText);

                $("#divOption").empty();

            }


            //點擊下一步
            $("#btnSure").click(function () {
                var note = document.getElementById("btnNote");
                var msgBoard = document.getElementById("btnMsgBoard");

                if (scheddule > TestCount - 1) {
                    window.location.href = "../AfterLogin/Index.aspx";
                } else if (IsExam === false && scheddule > TestCount - 2) {
                    //判斷看完解答&作完所有題目
                    Settlement();
                    note.style.visibility = "hidden";
                    msgBoard.style.visibility = "hidden";
                    scheddule += 1;
                } else if (IsExam === false && scheddule === -1) {
                    //升級提示
                    scheddule += 1;
                    IsExam = true;
                    StartExam();
                }
                else if (IsExam === false) {
                    //看完解答、升級挑戰提示
                    scheddule += 1;
                    IsExam = true;
                    NextQuestion();
                    note.style.visibility = "hidden";
                    msgBoard.style.visibility = "hidden";
                } else {
                    //做完這一題
                    IsExam = false;
                    userAnswer = $("[name='option']:checked").val();
                    examAnswer = examDataList[scheddule].TestAnswer.trim();
                    if (userAnswer === examAnswer) {
                        right += 1;
                    }
                    SaveAnswer();
                    note.style.visibility = "visible";
                    msgBoard.style.visibility = "visible";
                }


            });

            //正式進入考試畫面，獲取資料
            function StartExam() {
                var postData = {
                    "TestLevel": TestLevel,
                    "TestCount": TestCount,
                    "UserID": userID,
                    "IsChalleng": IsChalleng
                };
                $.ajax({
                    url: "../API/ExamSystemHandler.ashx?Exam=Start",
                    method: "POST",
                    data: postData,
                    dataType: "JSON",
                    success: function (objDataList) {
                        examDataList = objDataList;
                        NextQuestion();
                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("連線失敗，請聯絡管理員。");
                    }
                });
            }
            //將使用者答案存入資料庫
            function SaveAnswer() {
                var examData = examDataList[scheddule];
                var postData = {
                    "UserID": userID,
                    "TestID": examData.TestID,
                    "UserAnswer": userAnswer,
                    "UserNote": examData.UserNote,
                    "IsNew": ((examData.UserAnswer != null) ? false : true)
                };
                $.ajax({
                    url: "../API/ExamSystemHandler.ashx?Exam=SaveAnswer",
                    method: "POST",
                    data: postData,
                    success: function (objDataList) {
                        BuildAnswer();
                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("連線失敗，請聯絡管理員。");
                    }
                });
            }

            //從解答、升級提示切換為考題
            function NextQuestion() {
                var examData = examDataList[scheddule];
                var qusText =
                    `
                                <h4>${examData.TypeContext}</h4>
                                <h2>${examData.TestContent}</h2>
                            `;
                var optText =
                    `
                                <ul class="nav justify-content-center">
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="A" checked="checked" /><span id="A" class="round btnOption">A.${examData.OptionsA}</span>
                                        </label>
                                    </li>
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="B" checked="checked" /><span id="B" class="round btnOption">B.${examData.OptionsB}</span>
                                        </label>
                                    </li>
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="C" checked="checked" /><span id="C" class="round btnOption">C.${examData.OptionsC}</span>
                                        </label>
                                    </li>
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="D" checked="checked" /><span id="D" class="round btnOption">D.${examData.OptionsD}</span>
                                        </label>
                                    </li>
                                </ul>
                            `;
                $("#divQuestion").empty();
                $("#divQuestion").append(qusText);

                $("#divOption").empty();
                $("#divOption").append(optText);


            };
            //從考題切換為解答
            function BuildAnswer() {
                var examData = examDataList[scheddule];
                //帶入文正解文字資訊
                var examAnswerText = document.getElementById(`${examAnswer}`).textContent;
                var userAnswerText = document.getElementById(`${userAnswer}`).textContent;
                //正確/錯誤
                var ansText = "正確";
                //判斷使用者答案正確與否

                //編輯顯示字串
                var qusText =
                    `
                                <h4>${examData.TypeContext}</h4>
                                <h2>${examData.TestContent}</h2>
                            `;
                var optText =
                    `
                                <ul class="nav justify-content-center">
                                    
                                    <li class="nav-item">
                                        <p class="nav-link disabled">正確答案為 : ${examAnswerText}</p>
                                    </li>
                                    <li class="nav-item">
                                        <p class="nav-link disabled">選擇答案為 : ${userAnswerText}</p>
                                    </li>
                                   
                                </ul>
                                
                            `;
                $("#divQuestion").empty();
                $("#divQuestion").append(qusText);

                $("#divOption").empty();
                $("#divOption").append(optText);

            };

            //成果結算畫面
            function Settlement() {
                var point = right * 2;
                var money = right * 3;

                var postData = {
                    "UserID": userID,
                    "Correct": right,
                    "UserLevel": userLevel,
                    "Point": point,
                    "UserPoints": userPoint,
                    "Money": money
                };
                $.ajax({
                    url: "../API/ExamSystemHandler.ashx?Exam=Settlement",
                    method: "POST",
                    data: postData,
                    success: function (objDataList) {
                        var qusTextInDiv = "";
                        if (userLevel > 1 && userPoint >= 90 && point > 10) {
                            qusTextInDiv = `升級挑戰成功 ! 從今天起就是 N${userLevel - 1} 級的鮭魚了!`;
                        } else if (userLevel > 1 && userPoint >= 90 && point < 10) {
                            qusTextInDiv = `升級挑戰失敗!`;
                        } else {
                            qusTextInDiv = "挑戰結束!";
                        }
                        var qusText =
                            `<div style="height:100%; text-align:center; line-height:300px; font-size:30pt;">
                                ${qusTextInDiv}
                             </div>`;

                        var optText =
                            `<div style="text-align:center;">
                                 <p>答對題數 : ${right} / ${TestCount} 題</p>
                                 <p>獲得積分 : ${point - 10} 分</P>
                                 <p>獲得金幣 : ${money} 個</P>
                              </div>
                             `;

                        $("#divQuestion").empty();
                        $("#divQuestion").append(qusText);

                        $("#divOption").empty();
                        $("#divOption").append(optText);

                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("連線失敗，請聯絡管理員。");
                    }
                });

            }


            //筆記
            function BulidNote(testID, testContent) {
                var postData = {
                    "userID": userID,
                    "testID": testID
                }
                $.ajax({
                    url: "../API/ExamReviewHandler.ashx?Action=Note",
                    method: "POST",
                    data: postData,
                    dataType: "JSON",
                    success: function (objData) {

                        var noteTitle = `<h6> Q : <span id="noteTestContent">${testContent}</span></h6>`
                        var noteContent = ` <textarea id="Note" rows="10" cols="50" style="resize: none;" placeholder="記錄自己的想法吧!">${objData.UserNote}</textarea>`;

                        $("#divNote").empty();
                        $("#divNote").append(noteContent);

                        $("#divNoteTitle").empty();
                        $("#divNoteTitle").append(noteTitle);

                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("通訊失敗，請聯絡管理員。");
                    }
                });

            };

            $("#btnNote").click(function () {
                var testID = examDataList[scheddule].TestID;
                var testContent = examDataList[scheddule].TestContent;
                BulidNote(testID, testContent);

            });
            $("#btnNoteSave").click(function () {
                var noteContent = document.getElementById("Note").value;
                var testContent = document.getElementById("noteTestContent").innerText;
                var postData = {
                    "userID": userID,
                    "testID": examDataList[scheddule].TestID,
                    "UserNote": noteContent,
                    "UserAnswer": userAnswer
                };
                $.ajax({
                    url: "../API/ExamReviewHandler.ashx?Action=NoteWrite",
                    method: "POST",
                    data: postData,
                    success: function () {
                        alert("筆記已儲存");
                        BulidNote(testID, testContent);

                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("通訊失敗，請聯絡管理員。");
                    }
                });
            });

            //留言板
            function BulidMsgBoard(testID, testContent) {
                $.ajax({
                    url: "../API/ExamReviewHandler.ashx?Action=MsgBoard",
                    method: "POST",
                    data: { "testID": testID },
                    dataType: "JSON",
                    success: function (objDataList) {

                        var msgTitle =
                            `<h5> Q : <span id="msgTestContent">${testContent}</span></h5>
                `;
                        var msgContent = "";
                        for (var item of objDataList) {
                            var msgDate = new Date(item.CreateDate);
                            msgDate = msgDate.toLocaleString();
                            msgContent +=
                                `
                    <div class="card">
                      <div class="card-header">
                        <p>${item.UserName}( N${item.UserLevel} )</p>
                      </div>
                      <div class="card-body">
                        <blockquote class="blockquote mb-0">
                          <p>${item.MessageContent}</p>
                          <footer class="blockquote-footer">${msgDate}</cite></footer>
                        </blockquote>
                      </div>
                    </div>
                    `;
                        }

                        var msgWrite =
                            `<textarea id="txtMsgBoard" rows="4" cols="50" style="resize: none;" placeholder="留言分享自己的看法吧!"></textarea>`;

                        $("#divMsgBoard").empty();
                        $("#divMsgBoard").append(`<ul class="list - group list - group - flush">` + msgContent + "</ul >");

                        $("#divMsgTitle").empty();
                        $("#divMsgTitle").append(msgTitle);

                        $("#divMsgWriteContent").empty();
                        $("#divMsgWriteContent").append(msgWrite);

                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("通訊失敗，請聯絡管理員。");
                    }
                });

            }

            $("#btnMsgBoard").click(function () {
                var testID = examDataList[scheddule].TestID;
                var testContent = examDataList[scheddule].TestContent;
                BulidMsgBoard(testID, testContent);
            });

            $("#btnMsgWrite").click(function () {
                var msgWriteContent = document.getElementById("txtMsgBoard").value;
                var testContent = document.getElementById("msgTestContent").innerText;
                var postData = {
                    "userID": userID,
                    "testID": examDataList[scheddule].TestID,
                    "msg": msgWriteContent
                };
                $.ajax({
                    url: "../API/ExamReviewHandler.ashx?Action=MsgWrite",
                    method: "POST",
                    data: postData,
                    success: function (txtMsg) {
                        BulidMsgBoard(testID, testContent);

                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("通訊失敗，請聯絡管理員。");
                    }
                });
            });

        })
    </script>
</asp:Content>
