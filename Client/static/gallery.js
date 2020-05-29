var images = ["static/images/Исаакиевский собор.jpg", "static/images//Петропавловский собор.jpg", "static/images//Эрмитаж.jpg"];
var slideIndex = 0;
const leftArrow = document.querySelector("left");
const rightArrow = document.querySelector("right");
var obj = document.getElementById("gallery_img");

function showSlides(n) {
    if (n > images.length - 1) slideIndex = 0;
    if (n < 0) slideIndex = images.length - 1;
    loadSlide();
}
function loadSlide() {
    var obj = document.getElementById("gallery_img");
    obj.src = images[slideIndex];
    images.forEach((index) => images[index].style.display = "none");
    images[slideIndex].style.display = "block";
}

function loadSlides(links) {
    images = links;
    var obj = document.getElementById("gallery_img");
    obj.src = images[slideIndex];
    images.forEach((index) => images[index].style.display = "none");
    images[slideIndex].style.display = "block";
}