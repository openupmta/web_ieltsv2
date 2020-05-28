$(document).keydown(function(event) {
if (event.ctrlKey==true && (event.which == '61' || event.which == '107' || event.which == '173' || event.which == '109'  || event.which == '187'  || event.which == '189'  ) ) {
        event.preventDefault();
     }
    // 107 Num Key  +
    // 109 Num Key  -
    // 173 Min Key  hyphen/underscor Hey
    // 61 Plus key  +/= key
});

$(window).bind('mousewheel DOMMouseScroll', function (event) {
       if (event.ctrlKey == true) {
       event.preventDefault();
       }
});
//scoll menu bar and back to top
var position = $(window).scrollTop(); 
$(window).scroll(function() {
    var scroll = $(window).scrollTop();
    // console.log(scroll);
    if(scroll > position && scroll >100) {
        $('header').addClass('header-hide-effect');
    } else {
        $('header').removeClass('header-hide-effect');
    }
    if (scroll>300) {
		$('section.back-to-top').fadeIn('400');
	}else {
		$('section.back-to-top').fadeOut('400');
	}
    position = scroll;
});
$('.back-to-top-button').click(function(event) {
	$('html, body').animate({scrollTop:0},500); 
});

