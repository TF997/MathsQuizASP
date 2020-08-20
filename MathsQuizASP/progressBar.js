var width = sessionStorage.getItem("width") || 0;

var bar = setInterval(function () {
    var barProgress = parseInt(document.getElementById("counter").innerHTML);
    var barTotal = parseInt(document.getElementById("total").innerHTML);
    var bar = document.getElementById("InnerBar");
    width = (barProgress / barTotal) * 100
    if (width > 100) {
        width = 100;
        document.getElementById("ProgressBar").hidden = "true"
        document.getElementById("timer").hidden = "true"
    }
    bar.style.width = width + "%";
    sessionStorage.setItem("width", width);
}, 1000);