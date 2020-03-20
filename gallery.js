var imgArray = ["images/Эрмитаж.jpg",
                "images/Петропавловский собор.jpg",
                "images/Исаакиевский собор.jpg"];
window.Number = 0;
var imageCount = imgArray.length;
function image(num) {
    if (num == 1) {
        if (Number < imageCount-1) {
            Number++;
            document.getElementById('images').src = imgArray[Number];
            document.getElementById('num_img').innerHTML+ imageCount;
        }
    }
    else {
        if (Number > 0) {
            Number--;
            document.getElementById('images').src = imgArray[Number];
            document.getElementById('num_img').innerHTML+ imageCount;
        }
    }
}
function btn_show() {
    if (Number != 0)
        document.getElementById('left').style.display = "block";
    if (Number != imageCount-1)
        document.getElementById('right').style.display = "block";
}
function btn_noshow() {
    document.getElementById('left').style.display = "none";
    document.getElementById('right').style.display = "none";
}
document.write('<img id="images" src="'+imgArray[0]+'" position="relative" width="100%">');