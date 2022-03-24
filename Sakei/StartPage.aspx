<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="Sakei.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        img{
            position:relative;
            left:35%;
            padding-top: 8%;
            width:30%
        }
        .lbn
        {
             position:relative;
            left:35%;
            padding-top: 8%;
            width:30%
            
        }

        .img1{
            position:relative;
            left:45%;
            width: 100px;
            height: 25px;
            border-top: 50px;
            padding-top:0px;
            margin-top: 100px;
        }

        .img2{
            position:relative;
            left:45%;
            width: 100px;
            height: 25px;
           
            margin:0px;
            padding-top:10px;
        }

         .img1:hover {
                color: #003C9D;
                background-color: #fff;
                border: 2px #003C9D solid;
            }
          .img2:hover {
                color: #003C9D;
                background-color: #fff;
                border: 2px #003C9D solid;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <img src="Images/page.jpg" />
            
        </div>
       <div>
        
           <img src="Images/enter.jpg" class="img1"  onclick="window.open('LoginPage.aspx')"/><br />
           <img src="Images/register.jpg" class="img2" onclick="window.open('RegisterPage.aspx')"/>
      </div>
    </form>
</body>
</html>
