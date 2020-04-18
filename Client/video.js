var videos = ["1.mkv","2.mkv","3.mkv"];
var slideIndex = 0;
const leftArrow = document.querySelector("left");
const rightArrow = document.querySelector("right");
var obj = document.getElementById("video_mkv");
//const slides = document.querySelectorAll(".slide");
//leftArrow.addEventListener("click",()=>showSlides(slideIndex-=1));
//rightArrow.addEventListener("click",()=>showSlides(slideIndex+=1));
function showSlides(n){
    if(n>videos.length-1) slideIndex = 0;
    if(n<0) slideIndex=videos.length-1;
    //obj.src = videos[slideIndex];
    //videos.forEach((index)=>videos[index].style.display="none");
    //videos[slideIndex-1].style.display="flex";
    loadSlide();
}
function loadSlide(){
    var obj = document.getElementById("video_mkv");
    obj.src = videos[slideIndex];
    videos.forEach((index)=>videos[index].style.display="none");
    videos[slideIndex].style.display="block";
}