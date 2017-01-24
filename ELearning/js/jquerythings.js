jQuery(document)
    .ready(function ($) {
      $('.navbar .dropdown')
          .hover(function () {
            $(this)
                .addClass('extra-nav-class')
                .find('.dropdown-menu')
                .first()
                .stop(true, true)
                .delay(250)
                .slideDown();
          },
              function () {
                var na = $(this);
                na.find('.dropdown-menu')
                    .first()
                    .stop(true, true)
                    .delay(100)
                    .slideUp('fast', function () { na.removeClass('extra-nav-class') });
              });

    });

jQuery(document)
    .ready(function () {
      var offset = 220;
      var duration = 500;
      window.jQuery(window)
          .scroll(function () {
            if (window.jQuery(this).scrollTop() > offset) {
              window.jQuery('.back-to-top').fadeIn(duration);
            } else {
              window.jQuery('.back-to-top').fadeOut(duration);
            }
          });

      window.jQuery('.back-to-top')
          .click(function (event) {
            event.preventDefault();
            window.jQuery('html, body').animate({ scrollTop: 0 }, duration);
            return false;
          });
    });


jQuery(document)
    .ready(function () {
      window.jQuery('.slider1')
          .bxSlider({
            pager: false,
            nextSelector: '#slider-next',
            prevSelector: '#slider-prev',
            nextText: '>',
            prevText: '<',
            slideWidth: 240,
            minSlides: 1,
            maxSlides: 6,
            moveSlides: 1,
            slideMargin: 10
          });
    });