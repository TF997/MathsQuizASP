<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MathsQuizASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maths Quiz</title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css" media="screen"/>
</head>
<body>
    <form class="mainForm" id="form1" runat="server" method="get">
            <p runat="server" id="questionText" style="display:inline">placeholder</p>
            <p><input type="text" name="answer" placeholder="Answer" /></p>
            <p><input type="submit" value="Submit"/></p>
            <p runat="server" id="answer">Input Your Answer!</p>
    </form>
</body>
</html>
