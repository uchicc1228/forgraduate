<%@ Page Title="" Language="C#" MasterPageFile="~/ExamSystem/ExamSystemMaster.Master" AutoEventWireup="true" CodeBehind="ExamChallengeMode.aspx.cs" Inherits="Sakei.ExamSystem.ExamChallengeMode1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #divQuestion {
            padding: 30px;
            height: 50%;
        }

        #divOption {
            padding: 30px;
            height: 30%;
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
    <div id="divQuestion">

        <h4>----題型----</h4>

        <h2>----題目----</h2>

    </div>
    <div id="divOption" class="row align-items-center">
        <ul class="nav justify-content-center">
            <li class="nav-item">
                <p class="nav-link disabled">A.ans1</p>
            </li>
            <li class="nav-item">
                <p class="nav-link disabled">B.ans2</p>
            </li>
            <li class="nav-item">
                <p class="nav-link disabled">C.ans3</p>
            </li>
            <li class="nav-item">
                <p class="nav-link disabled">D.ans4</p>
            </li>
        </ul>
    </div>

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

            //確定考題等級
            if (userPoint >= 100 && userLevel != 1) {
                TestLevel += userLevel;
                scheddule = -1;
                LevelUpMsg();
            } else {
                TestLevel = userLevel;
                scheddule = 0;
                IsExam = true;
                NextQuestion();
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

                if (IsExam === false && scheddule > 2) {
                    //判斷看完解答&作完所有題目

                } else if (IsExam === false) {
                    //看完解答、升級挑戰提示
                    scheddule += 1;
                    IsExam = true;
                    NextQuestion();

                } else {
                    //做完這一題
                    IsExam = false;
                    BuildAnswer();
                }

            });
            //從解答、升級提示切換為考題
            function NextQuestion() {

                var qusText =
                    `
                                <h4>----題型----</h4>
                                <h2>----題目${scheddule}----</h2>
                            `;
                var optText =
                    `
                                <ul class="nav justify-content-center">
                                    <li class="nav-item">
                                        <p class="nav-link disabled">A.ans1</p>
                                    </li>
                                    <li class="nav-item">
                                        <p class="nav-link disabled">B.ans2</p>
                                    </li>
                                    <li class="nav-item">
                                        <p class="nav-link disabled">C.ans3</p>
                                    </li>
                                    <li class="nav-item">
                                        <p class="nav-link disabled">D.ans4</p>
                                    </li>
                                </ul>
                            `;
                $("#divQuestion").empty();
                $("#divQuestion").append(qusText);

                $("#divOption").empty();
                $("#divOption").append(optText);

                //var postData = {};
                //$.ajax({
                //    url: "../API/",
                //    method: "POST",
                //    data: postData,
                //    dataType: "JSON",
                //    success: function (objData) {

                        
                //    },
                //    error: function (msg) {
                //        console.log(msg);
                //        alert("連線失敗，請聯絡管理員。");
                //    }
                //});
            };
            //從考題切換為解答
            function BuildAnswer() {
                //正確/錯誤
                var ansText = "正確";
                //判斷使用者答案正確與否

                //編輯顯示字串
                var qusText =
                    `
                                <h4>----題型----</h4>
                                <h2>----題目${scheddule}----</h2>
                            `;
                var optText =
                    `
                                <ul class="nav justify-content-center">

                                    <li class="nav-item">
                                        <p class="nav-link disabled">正確答案 : </p>
                                    </li>
                                    <li class="nav-item">
                                        <p class="nav-link disabled">選擇的答案 : </p>
                                    </li>
                                   
                                </ul>
                                
                            `;
                $("#divQuestion").empty();
                $("#divQuestion").append(qusText);

                $("#divOption").empty();
                $("#divOption").append(optText);

            }

        })
    </script>

</asp:Content>
