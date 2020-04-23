var images = ["Эрмитаж1.jpg", "Эрмитаж2.jpg", "Эрмитаж3.jpg"];
var slideIndex = 0;
const leftArrow = document.querySelector("left");
const rightArrow = document.querySelector("right");
var iframe;
iframe.src = "https://www.youtube.com/embed/YuM16V68Pps?enablejsapi=1";

function showSlides(n){
    if(n>images.length-1) slideIndex = 0;
    if (n < 0) slideIndex = images.length;
    if (n == images.length-1) loadSlidev();
   
    else loadSlide();
}
function loadSlide() {
    iframe = document.querySelector("#ervideo");
    
    iframe.style.display = "none"

    var obj = document.getElementById("gallery_img");
    obj.src = "images\\"+images[slideIndex];
    images.forEach((index)=>images[index].style.display="none");
    images[slideIndex].style.display="block";
}
function loadSlidev() {
    iframe = document.querySelector("#ervideo");
    iframe.style.display = "block";
    
}