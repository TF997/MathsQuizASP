var countDownDate = sessionStorage.getItem("countDownDate") || new Date().getTime() + 5 * 60000;

var countdown = setInterval(function () {

    var now = new Date().getTime();

    var timeRemaining = countDownDate - now;

    var minutes = Math.floor((timeRemaining % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((timeRemaining % (1000 * 60)) / 1000);

    document.getElementById("timer").innerHTML = minutes + "m " + seconds + "s ";

    if (timeRemaining < 0) {
        clearInterval(countdown);
        document.getElementById("timer").innerHTML = "Times up!";
        document.getElementById("answerBox").disabled = true;
    }
    sessionStorage.setItem("countDownDate", countDownDate);
}, 1000);
