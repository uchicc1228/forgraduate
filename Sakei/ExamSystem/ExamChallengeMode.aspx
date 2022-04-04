<%@ Page Title="" Language="C#" MasterPageFile="~/ExamSystem/ExamSystemMaster.Master" AutoEventWireup="true" CodeBehind="ExamChallengeMode.aspx.cs" Inherits="Sakei.ExamSystem.ExamChallengeMode1" %>

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
            font-size:24px;
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
            <button type="button" id="btnNote" class="col btn btn-secondary btn-lg" style="visibility: hidden;">筆記</button>
            <button type="button" id="btnSure" class="col btn btn-primary btn-lg">確定</button>
            <button type="button" id="btnMsgBoard" class="col btn btn-secondary btn-lg" style="visibility: hidden;">留言板</button>
        </div>

    </div>



    <script>
        var userID ='<%=this.UserID%>';
        var userPoint =<%=this.User.UserPoints %>;
        var TestCount = 10;
        var TestLevel = 0;
        var userLevel =<%=this.User.UserLevel%>;
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
                TestLevel += userLevel;
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
               
                if (IsExam === false && scheddule > TestCount - 2) {
                    //判斷看完解答&作完所有題目

                } else if (IsExam === false && scheddule === -1) {
                    scheddule += 1;
                    IsExam = true;
                    StartExam();
                }
                else if (IsExam === false) {
                    //看完解答、升級挑戰提示
                    scheddule += 1;
                    IsExam = true;
                    NextQuestion();
                } else {
                    //做完這一題
                    IsExam = false;
                    userAnswer = $("[name='option']:checked").val();
                    examAnswer = examDataList[scheddule].TestAnswer.trim();
                    if (userAnswer === examAnswer) {
                        right += 1;
                        alert(right);
                    }
                    SaveAnswer();
                }
                

            });

            //正式進入考試畫面，獲取資料
            function StartExam() {
                var postData = {
                    "TestLevel": TestLevel,
                    "TestCount": TestCount,
                    "UserID":userID
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

        })
    </script>
</asp:Content>
