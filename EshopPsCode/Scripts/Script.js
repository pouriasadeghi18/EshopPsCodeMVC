jQuery(function ($) {

    $('.form-search span').click(function(){
        $('.form-search form').slideToggle();
    });
    $('.responsive-list').click(function(){
        $('.mega-menu .container > ul').slideToggle();
    });

    $('.thumbnails-image img').click(function(){
      var src = $(this).attr('src');
      $('.large-image img').attr('src', src).fadeOut('fast').fadeIn('fast');
    });

    $("#slider-one").owlCarousel({
       navigation : false, // Show next and prev buttons
       slideSpeed : 300,
       dots: true,
       paginationSpeed : 400,
       singleItem:true,
       items:1,
       autoplay: 500,
       center: true,
       autoplayHoverPause : true,
       loop:true
   });

});
$('.owl-carousel').owlCarousel({
    items:2,

    rtl:true,
    loop:true,

    margin:10,
    nav:true,
    autoplay:true,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:4
        }
    }
});



$('.newprofucts').owlCarousel({
    items:1,

    loop:true,

    margin:10,
    nav:true,
    autoplay:true,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:4
        }
    }
});