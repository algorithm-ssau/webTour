var images = ["Исаакиевский собор.jpg", "Петропавловский собор.jpg", "Эрмитаж.jpg"];
var slideIndex = 0;
const leftArrow = document.querySelector("left");
const rightArrow = document.querySelector("right");
var obj = document.getElementById("gallery_img");
//const slides = document.querySelectorAll(".slide");
//leftArrow.addEventListener("click",()=>showSlides(slideIndex-=1));
//rightArrow.addEventListener("click",()=>showSlides(slideIndex+=1));
function showSlides(n) {
    if (n > images.length - 1) slideIndex = 0;
    if (n < 0) slideIndex = images.length - 1;
    //obj.src = images[slideIndex];
    //images.forEach((index)=>images[index].style.display="none");
    //images[slideIndex-1].style.display="flex";
    loadSlide();
}

function loadSlide() {
    var obj = document.getElementById("gallery_img");
    obj.src = "images\\" + images[slideIndex];
    images.forEach((index) => images[index].style.display = "none");
    images[slideIndex].style.display = "block";
}

function imgHrefTransition(n) {
    location.href = images[n].slice(0,-4) + '.html'
}
