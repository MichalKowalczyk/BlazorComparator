
var jsButton = document.getElementById("jsButton");
var timerSpan = document.getElementById("jsTimer");
var canvas = document.getElementById("myCanvas");

jsButton.addEventListener("click", function (e) {

    jsButton.setAttribute("disabled", "true");
    var t0 = performance.now();
    draw();
    timerSpan.innerHTML = Math.round((performance.now() - t0)) + "ms";
}, false);


function draw() {
    var ctx = canvas.getContext("2d");
    var height = 400;
    var width = 400;

    var c = new Complex(-0.1, 0.65);
    var copy = null;
    var divider = 2;
    var pixelSize = 2; // resolution

    for (var h = -(height / divider); h < (height / divider); h = h + pixelSize) {
        for (var w = -(width / divider); w < (width / divider); w = w + pixelSize) {
            var zNum = new Complex(w / (width / divider), h / (height / divider));
            var i = 0;
            copy = zNum;
            do {
                i++;
                zNum = zNum.kwadrat().add(c);
            } while (zNum.modul2() < 2 && i < 30);
            var argument = i;
            do {
                i++;
                zNum = zNum.kwadrat().add(c);
            } while (zNum.modul2() < 2 && i < argument * 100);

            if (argument < 30) {
                ctx.fillStyle = "hsl(" + argument * 12 + ",100%,50%)";
                ctx.fillRect((copy.getX() + 1) * (width / divider), (copy.getY() + 1) * (height / divider), pixelSize, pixelSize);
            }
            if (i > 30) {
                ctx.fillStyle = "hsl(" + (i / 6) % 360 + ",100%,50%)";
                ctx.fillRect((copy.getX() + 1) * (width / divider), (copy.getY() + 1) * (height / divider), pixelSize, pixelSize);
            }
        }
    }
}

