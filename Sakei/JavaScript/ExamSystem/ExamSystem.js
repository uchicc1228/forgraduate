var canves = document.getElementById("cavTest");
var ctxQuestion = canves.getContext("2d");

//進度條座標
var progressBarX = canves.width / 10;
var progressBarY = canves.height / 10;
//問題座標
var questionX = canves.width / 10;
var questionY = canves.height * 2 / 10;
//選項座標
var optionX = questionX;
var optionY = canves.height * 6 / 10;

var progress = 1;

function draw() {
    ctxQuestion.clearRect(0, 0, canves.width, canves.height);
    //題目
    DrawQuestion(progress);
    DrawOptions();

    this.stop();

    progress += 1;

}

//畫出題目
function DrawQuestion(qusNO) {
    ctxQuestion.beginPath();
    //問題
    ctxQuestion.font = "24px arial";
    ctxQuestion.textAlign = "start";
    ctxQuestion.fillStyle = "#553030";
    ctxQuestion.fillText('yeee', questionX, questionY);

    ctxQuestion.closePath();
}

//畫出選項
function DrawOptions() {
    ctxQuestion.beginPath();

    //選項
    ctxQuestion.fillText('A.', answerX, answerY);
    ctxQuestion.fillText('B.', answerX * 3, answerY);
    ctxQuestion.fillText('C.', answerX * 5, answerY);
    ctxQuestion.fillText('D.', answerX * 7, answerY);

    ctxQuestion.closePath();
}

//連接資料
function getData() {

}

setInterval(draw, 10);