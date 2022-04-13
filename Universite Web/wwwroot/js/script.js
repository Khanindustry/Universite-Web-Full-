$(document).ready(function(){


    //$('.nav-link').click(function () {
    //    console.log("Clicked");
    //    $('.nav-link.active').removeClass('active');
    //    $('.nav-link').addClass('active');
    //});

    setTimeout(function () {
        $(".loader-wrapper").remove(); //makes page more lightweight 
    }, 1000);


  
  
    $(function(){
        $('.timer').countTo();
    });



    $('.student-1').owlCarousel({
        loop:true,
        margin:10,
        dots:false,
        nav:false,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:3
            }
        }
    });



    $('.partner-logo').owlCarousel({
        loop:true,
        margin:10,
        dots:false,
        nav:false,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:4
            }
        }
    });

    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:10,
        nav:false,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });

    window.addEventListener("scroll",function(){
        var nav =document.querySelector("nav");
        nav.classList.toggle("fixed-top",window.scrollY>58);
    })
    
    window.addEventListener("scroll",function(){
        var nav =document.getElementsByClassName("down-top")[0];
        nav.classList.toggle("top",window.scrollY>20);
    })

    //$(window).on('load', function(){
    //    setTimeout(removeLoader, 1000); //wait for page load PLUS two seconds.
    //});
    //  function removeLoader(){
    //      $( ".loader-wrapper" ).fadeOut(100, function() {
    //        // fadeOut complete. Remove the loading div
    //        $( ".loader-wrapper" ).remove(); //makes page more lightweight 
    //    });  
    //  }

    

    
    
  });