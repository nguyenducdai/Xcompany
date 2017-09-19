(function($){
    "use strict";
    jQuery(document).on('ready', function(){
        // Home Slider
          $('#home-slider').sliderPro({
            width: 1920,
            height: 600,
            visibleSize: '100%',
            forceSize: 'fullWidth',
            arrows: true,
            buttons: false,
              autoplay: true,
            autoplayDelay: 7500,
            autoplayOnHover: 'none',
            waitForLayers: true,
            autoScaleLayers: false,
          });
        
        //Testimonials Slides
        $(".testimonial-slides").owlCarousel({
            items: 1,
            nav: true,
            dots: false,
            autoplay: false,
            loop: true,
            navText: ["<i class='fa  fa-angle-double-left'></i>", "<i class='fa fa-angle-double-right'></i>"],
        });
        
        // Project Slides
        $(".project-slides").owlCarousel({
            items: 1,
            nav: true,
            dots: false,
            autoplay: false,
            loop: true,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        });
        
        // Client Slides
        $(".client-slides").owlCarousel({
            dots: false,
            autoplay: true,
            loop: true,
            margin:30,
            nav:false,
            responsive:{
                0:{
                    items:1
                },
                600:{
                    items:3
                },
                1000:{
                    items:6
                }
            }
        });
     
        //Wow Js
        new WOW().init();
        
        //Back To Top
        $(".gototop").gototop({
            position : 0,
            duration : 1250,
            visibleAt : 1000,
            classname : "isvisible"
        });
        
        
        /*----------------------------
		Isotop Js
        ------------------------------ */
        var $grid = $('.portfolio-items').isotope({
            itemSelector: '.grid-item',
            percentPosition: true,
            masonry: {
                // use outer width of grid-sizer for columnWidth
                columnWidth: '.grid-item'
            }
        });   
        // filter items on button click
        $('.portfolio-menu').on( 'click', 'button', function() {
        var filterValue = $(this).attr('data-filter');
        $grid.isotope({ 
            filter: filterValue });
        });
         $('.portfolio-menu button').on('click', function(event) {
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        event.preventDefault();
        });
        
        // This will create gallery from all elements that have class "gallery-item"
        $(".lightbox").magnificPopup({
          type: 'image',
          gallery:{
            enabled:true,
          }
        });
        // This will create a single gallery from all elements that have class "gallery-item"
        $(".lightbox-gallery, .lightbox-image").magnificPopup({
          type: 'image',
        });
       
        // This will create a single gallery from all elements that have class "gallery-item"
          $(".popup-youtube, .popup-vimeo, .popup-gmaps").magnificPopup({
          type: 'iframe',
          mainClass: 'mfp-fade',
          removalDelay: 160,
          preloader: false,
          fixedContentPos: false
        });
    });
    
    //Navbar Shirnk
    jQuery(window).on('scroll',function() {
      if ($(document).scrollTop() > 50) {
        $('nav').addClass('shrink');
      } else {
        $('nav').removeClass('shrink');
      }
    });
    //Preloader
    jQuery(window).on('load',function(){
        jQuery(".site-preloader-wrap").fadeOut(500);
    });
	
	//Input Field Space Validatiton
	jQuery(function() {
	  jQuery('body').on('keydown', '#contact_name, #contact_email, #contact_subject, #contact_phone, #contact_message', function(e) {
			console.log(this.value);
			 if (e.which === 32 &&  e.target.selectionStart === 0) {
			   return false;
			}  
		});
	});
	
	/* ======== Send Mail ============*/
	$('#contatc_form').submit(function(event) {
	    event.preventDefault();
	    var name = $('#contact_name').val();
	    var email = $('#contact_email').val();
	    var sub = $('#contact_subject').val();
	    var phone = $('#contact_phone').val();
	    var message = $('#contact_message').val();
		var recaptcha = $("#g-recaptcha-response").val();
		
	    if(name == "" || email == "" || message == "" || name == " " || message == " " || recaptcha == " " || sub == " " || phone ==" "){
	    	jQuery('#contact_send_status').removeClass('message_send');
		   	jQuery('#contact_send_status').addClass('message_notsend');
			jQuery('#contact_send_status').text('Please fill all fields with correct data.');
	    }else{
		    var formData = $('#contatc_form').serialize();
		    $.ajax({
			    type: 'POST',
			    url: $('#contatc_form').attr('action'),
			    data: formData,
				success:function(data){  
					jQuery('form[name="myform"]')[0].reset();
				},
			})
			.done(function(response) {
				$('#contact_send_status').removeClass('message_notsend');
			   	$('#contact_send_status').addClass('message_send');
			   	$('#contact_send_status').html("<div class='alert alert-success' role='alert'>Your email successfully Sent ! Thank you.</div>");
				$("#contact_send_status").fadeOut(3000);				
			})
			.fail(function(data) {
				jQuery('#contact_send_status').removeClass('message_send');
			   	jQuery('#contact_send_status').addClass('message_notsend');
				jQuery('#contact_send_status').html("<div class='alert alert-danger' role='alert'>Something wrong please try again!</div>");
			});
		}
	});
	
    
}(jQuery));

