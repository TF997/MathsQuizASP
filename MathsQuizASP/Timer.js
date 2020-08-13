﻿// Set the date we're counting down to
var countDownDate = sessionStorage.getItem("countDownDate") || new Date().getTime() + 5 * 60000;

// Update the count down every 1 second
var countdown = setInterval(function () {

    // Get today's date and time
    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = countDownDate - now;

    // Time calculations for days, hours, minutes and seconds
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // Display the result in the element with id="demo"
    document.getElementById("timer").innerHTML = minutes + "m " + seconds + "s ";

    // If the count down is finished, write some text
    if (distance < 0) {
        clearInterval(countdown);
        document.getElementById("timer").innerHTML = "EXPIRED";
        document.getElementById("answerBox").disabled = true;
    }
    sessionStorage.setItem("countDownDate", countDownDate);
}, 1000);