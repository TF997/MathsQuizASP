<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MathsQuizASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maths Quiz</title>
    <link href='https://fonts.googleapis.com/css?family=Aleo' rel='stylesheet'/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" type="text/css" href="main.css" media="screen"/>
</head>
<body>
    <form class="mainForm" id="form1" runat="server" method="get" autocomplete="off">
            <p runat="server" id="questionText" style="display:inline">placeholder</p>
            <p><input id="answerBox" type="text" name="answer" placeholder="Answer" />
            <button class="btn btn-default" type="submit">
                <i class="fa fa-arrow-circle-right"></i>
            </button>
            </p>
            <p runat="server" id="answer">Input Your Answer!</p>
            <p id ="timer"></p>
    </form>
<script src="timer.js"></script>

</body>
</html>