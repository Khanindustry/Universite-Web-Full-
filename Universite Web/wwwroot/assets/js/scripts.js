/*!
    * Start Bootstrap - SB Admin v7.0.4 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2021 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 
window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }
});



$(document).ready(function(){



    //   function myFunction() {
    //         var x = document.getElementById("myDate").value;
    //         document.getElementById("demo").innerHTML = x;
    //  }



    //$(window).on('load', function(){
    //    setTimeout(removeLoader, 100); //wait for page load PLUS two seconds.
    //});

    setTimeout(function () {
        $(".loader-wrapper").remove(); //makes page more lightweight 
    }, 1000);

    //$('#CountryList').on("change", function () {
    //    $.ajax({
    //        type: "Post",
    //        url: "/RegisterSTUDENTs/GetState",
    //        data: { "FacultyId": $("#CountryList").val() },
    //        success: function (response) {
    //            var items = '';

    //            $(response).each(function ( ) {
    //                items += "<option value =" + this.value + ">" + this.text + "</option>";
    //            })
    //            $("#StateList").html(items);
    //        },
    //        failure: function (response) {
    //            alert(response.responseText);
    //        },
    //        error: function (response) {
    //            alert(response.responseText);
    //        }
    //    });
    //})

      function removeLoader(){
          $( ".loader-wrapper" ).fadeOut(200, function() {
            // fadeOut complete. Remove the loading div
            $( ".loader-wrapper" ).remove(); //makes page more lightweight 
        });  
      }

        $('.tesdiqle').click(function() {
            console.log("Clicked");
            // $('.lessons.active').removeClass('active');
            $(".lessons").addClass('active');

            var x=$("#myDate").val();
            let p=$("#demo");
                p.html("Tarix: "+x);
        });


        
  
       
     
});