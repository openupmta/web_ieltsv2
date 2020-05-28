$('.menu-mobile-button').click(function(event) {
	if($('section.menu-mobile').attr('class')=="menu-mobile menu-mobile-active"){
		$('section.menu-mobile').removeClass('menu-mobile-active');
		$('.menu-mobile-box').removeClass('menu-mobile-box-active');
		$(this).removeClass('menu-mobile-button-active');
		$('nav.nav-horizontal').removeClass('nav-horizontal-active-3');
		 $('section.banner-slider').removeClass('section.banner-slider-active-1');
        $('.nav-horizontal-sublogo').removeClass('nav-horizontal-sublogo-active-1');
        $('.nav-horizontal-logo').removeClass('nav-horizontal-logo-active-1');
        $('.nav-horizontal-container').removeClass('nav-horizontal-container-active-1');
        $('.nav-horizontal-content').removeClass('nav-horizontal-content-active-1');
	}else{
		$(this).addClass('menu-mobile-button-active');
		$('.menu-mobile-box').addClass('menu-mobile-box-active');
		$('section.menu-mobile').addClass('menu-mobile-active');
		$('nav.nav-horizontal').addClass('nav-horizontal-active-3');
		 $('section.banner-slider').addClass('section.banner-slider-active-1');
        $('.nav-horizontal-sublogo').addClass('nav-horizontal-sublogo-active-1');
        $('.nav-horizontal-logo').addClass('nav-horizontal-logo-active-1');
        $('.nav-horizontal-container').addClass('nav-horizontal-container-active-1');
        $('.nav-horizontal-content').addClass('nav-horizontal-content-active-1');
	}
});
$('.menu-mobile-bg').click(function(event) {
	$('section.menu-mobile').removeClass('menu-mobile-active');
	$('.menu-mobile-box').removeClass('menu-mobile-box-active');
	$('.menu-mobile-button').removeClass('menu-mobile-button-active');
	$('nav.nav-horizontal').removeClass('nav-horizontal-active-3');
	$('section.banner-slider').removeClass('section.banner-slider-active-1');
        $('.nav-horizontal-sublogo').removeClass('nav-horizontal-sublogo-active-1');
        $('.nav-horizontal-logo').removeClass('nav-horizontal-logo-active-1');
        $('.nav-horizontal-container').removeClass('nav-horizontal-container-active-1');
        $('.nav-horizontal-content').removeClass('nav-horizontal-content-active-1');
});