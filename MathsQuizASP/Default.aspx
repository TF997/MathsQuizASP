<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MathsQuizASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="get">
        <div>
            <p style="display:inline">QUESTION: </p>
            <p runat="server" id="questionText" style="display:inline">placeholder</p>
            <p>ANSWER: <input type="text" name="answer" /></p>
            <input type="submit" value="Submit"/>
            <p runat="server" id="answer">placeholder</p>
        </div>
    </form>
</body>
</html>
