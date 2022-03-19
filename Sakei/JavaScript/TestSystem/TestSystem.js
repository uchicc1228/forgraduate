var canves = document.getElementById("cavTest");
var ctx = canves.getContext("2d");

var x = canves.width / 10;
var y = canves.height / 10;

ctx.beginPath();

ctx.font = "24px arial";
ctx.textAlign = "start";
ctx.fillStyle = "#553030";
ctx.fillText('yeee', x, y);

ctx.closePath();