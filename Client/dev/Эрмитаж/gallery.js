var images = ["Эрмитаж1.jpg", "Эрмитаж2.jpg", "Эрмитаж3.jpg","video"];
var slideIndex = 0;
const leftArrow = document.querySelector("left");
const rightArrow = document.querySelector("right");
var iframe;

function showSlides(n){
    if(n>images.length-1) slideIndex = 0;
    if (n < 0) slideIndex = images.length-1;
    loadSlide();
}
function loadSlide() {
    if (slideIndex == images.length - 1) {
        loadSlidev();
    }
    else {
        iframe = document.querySelector("#ervideo");

        iframe.style.display = "none"

        var obj = document.getElementById("gallery_img");
        obj.src = "images\\" + images[slideIndex];
        for (var i = 0; i < images.length - 1; i++) {
            images[i].style.display = "none";
        }
        images[slideIndex].style.display = "block";
    }
}
function loadSlidev() {
    iframe = document.querySelector("#ervideo");
    iframe.style.display = "block";
    
}