$(function () {
	
  /* ==========================================================================
     * set
   ==========================================================================*/
  //判斷是否存在
  $.fn.exist = function () {
    return this.length > 0;
  };

  /* ==========================================================================
     * header
   ==========================================================================*/
  $(".hamburger").click(function () {
    $(this).toggleClass("is-active");
    $(this).next('.nav').slideToggle(500, 'easeInOutCubic');
  });

  $(window).resize(function () {
    if ($('.min-md-size').exist()) {
      $('#header').find('.nav .child2').mCustomScrollbar({
        theme:"minimal-dark",
        axis: "y"
      });
    } else {
      $('#header').find('.nav .child2').mCustomScrollbar("destroy");
    }
  }).resize();

  //
  $(window).resize(function () {
    if ($('.min-md-size').exist()) {
      $('#header').find('.nav .child2 .sub').mCustomScrollbar({
        theme:"minimal-dark",
        axis: "y"
      });
    } else {
      $('#header').find('.nav .child2 .sub').mCustomScrollbar("destroy");
    }
  }).resize();

  //
  $(window).resize(function () {
    if ($('.max-md-size').exist()) {
      $('#header').find('.nav').mCustomScrollbar({
        theme:"minimal-dark",
        axis: "y"
      });
    } else {
      $('#header').find('.nav').mCustomScrollbar("destroy");
    }
  }).resize();

  //
  function myMenu() {
    if ($('#header .menu > li').length) {
      var activeItem = $('#header .menu > li.is-active'),
          firstItem = $('#header .menu > li:first-child'),
          menuActive = $('#header').find('.menu-active'),
          activeL,
          activeW;      
      if(activeItem.length){
        activeL = activeItem.position().left;
        activeW = activeItem.innerWidth();
      }else{
        activeL = 0;
        activeW = firstItem.innerWidth();
      }
      $('#header .menu > li').each(function () {
        var childList = $(this).find('.child-list');
        menuActive.css({
          left: activeL,
          width: activeW
        });
        $(this).on('mouseenter.menu', function () {
          var el = $(this),
            x = el.position().left,
            w = el.innerWidth(),
            a = el.children('a'),
            tl = new TimelineLite();
          tl.to(menuActive, .1, {
              left: x,
              width: w,
              ease: Sine.easeOut
            })
          el.find('.child-list').stop().slideDown(300, 'easeOutSine');
        });
        $(this).on('mouseleave.menu', function () {
          childList.stop().hide(0);
        });
      });
      $(document).on('mouseleave.menu', function () {
        $('#header .menu > li').each(function () {
          tl = new TimelineLite();
          tl.to(menuActive, .3, {
              left: activeL,
              width: activeW,
              ease: Sine.easeInOut
            });
          $(this).find('.child-list').stop().hide(0);

        });
      });
      $('#header .menu').each(function () {
        $(this).on('mouseleave.menu', function () {
          var tl = new TimelineLite();
          tl.to(menuActive, .3, {
              left: activeL,
              width: activeW,
              ease: Sine.easeInOut
            });
        });
      });
    };
  }

  function mobileMenu(){
   // $('#header .menu > li > a').each(function(){
      $('#header .menu  a').on('click',function(e){
        var parentli = $(this).parent('li');
        var hasChild = parentli.hasClass('has-child');
        var $child = $(this).next('.sub');
        var $siblings = parentli.siblings('.has-child');
        
        if(hasChild == true){

          e.preventDefault();
          parentli.toggleClass('active');

          $child.stop().slideToggle(500,'easeOutCubic');
          $siblings.removeClass('active')
          $siblings.find('.sub').slideUp(0,'easeOutCubic');
        }
      })

      //產品比較表卷軸
      $(".af-scrollbar").mCustomScrollbar({
	    theme: "light-thick",
	    axis: "y"
	  });
  }

  myMenu();

  var h = 0;

  $(window).on('resize', function() {
    var w1024 = Modernizr.mq('(max-width: 1024px)');
      if (w1024 && h == 0) {
          $('#header .menu > li').off('mouseenter.menu mouseleave.menu');
          $('#header .menu').off('mouseleave.menu');
          $(document).off('mouseleave.menu');
          mobileMenu();
          h = h + 1;
          return h;
      } else if (!w1024 && h == 1) {
          $('#header .menu > li > a').off('click');
          myMenu();
          h = 0;
          return h;
      }
  }).trigger('resize');


  /* ==========================================================================
    * magic scroll
  ==========================================================================*/
  
  var controller = new ScrollMagic.Controller();
  var magicFadeIn = document.querySelectorAll(".magic-fadeIn");
  for (var i = 0; i < magicFadeIn.length; i++) {
    new ScrollMagic.Scene({
        triggerElement: magicFadeIn[i],
        offset: -200
      })
      .setTween(magicFadeIn[i], 1, {
        opacity: 1,
        ease: Sine.easeOut
      })
      .addTo(controller);
  };

  var magicFadeInUp = document.querySelectorAll(".magic-fadeInUp");
  for (var i = 0; i < magicFadeInUp.length; i++) {
    new ScrollMagic.Scene({
        triggerElement: magicFadeInUp[i],
        offset: -200
      })
      .setTween(magicFadeInUp[i], .5, {
        transform: "translateY(0)",
        opacity: 1,
        ease: Sine.easeOut
      })
      .addTo(controller);
  };


  /* ==========================================================================
     * 網頁防呆設定[內容不足高度時防破版] , resize
   ==========================================================================*/

  $(window).on('resize', function () {
    var footH = $('#footer').outerHeight();
    $('#main').css({
      paddingBottom: footH
    });
    $('#footer').css({
      marginTop: -footH
    });
  }).trigger('resize');


  /* ==========================================================================
     * header 回到最上面
   ==========================================================================*/

	  $(window).scroll(function() {

	    if ( $(this).scrollTop() > 50){
	      $("#header").addClass("actived");
	    } else {
	      $("#header").removeClass("actived");
	    }

	    //.quickly-gates-01.actived
	    if ( $(this).scrollTop() > 55){
	      $(".quickly-gates-01").addClass("actived");
	    } else {
	      $(".quickly-gates-01").removeClass("actived");
	    }

	  }).scroll();

  /* ==========================================================================
     * 卷軸捲動時防呆
   ==========================================================================*/
  /*smooth scrollbar*/
  
  if (!$('html').hasClass('msie')){ //針對IE設定不使用
	  
	  $(document).on('mousewheel', function (event, delta) {
	    if (!$(event.target).is(':input')) {

	        var that = this,
	            duration = 800,
	            easing = 'easeOutCirc',
	            step = 80,
	            target = $('html, body'),
	            scrollHeight = $(document).height(),
	            scrollTop = that.last !== undefined ? that.last : $(window).scrollTop(),
	            viewportHeight = $(window).height(),
	            multiply = (event.deltaMode === 1) ? step : 1;


	        scrollTop -= delta * multiply * step;
	        scrollTop = Math.min((scrollHeight - viewportHeight), Math.max(0, scrollTop));
	        that.last = scrollTop;

	        target.stop().animate({
	            scrollTop: scrollTop
	        }, {
	            easing: easing,
	            duration: duration,
	            complete: function () {
	                delete that.last;
	            }
	        });

	        event.preventDefault();
	    }
	  });

  };

	$(".scrollbar-y").mCustomScrollbar({
	    theme: "light-thick",
	    axis: "y"
	});


  /* ==========================================================================
     * 圖片,連結禁止拖曳
   ==========================================================================*/

  $("img,a[href]").attr("draggable", "false");

  /* ==========================================================================
     * load完成後 卷軸美化 頁面顯示 捲動特效
   ==========================================================================*/
  $(".scrollbar").mCustomScrollbar({
    theme: "minimal-dark",
    // mouseWheel: { preventDefault: true }
  });
  
  $(".nav-sort .scrollbar-x").mCustomScrollbar({
    theme: "light-thick",
    axis: "x",
    callbacks: {
      onCreate: function () {
        var self = $(this);
        var el = this;
        self.prepend("<a class='nav-prev sprite sprite-banner-arrow-left'></a>");
        self.append("<a class='nav-next sprite sprite-banner-arrow'></a>");
        var $li = self.find('.inBox li');
        var prev = $('.nav-prev'),
          next = $('.nav-next');
        var x = 0;
        prev.addClass('disable');
        prev.click(function () {
          var pct = el.mcs.leftPct;
          if (pct != 0 && x > 0) {
            x--
          } else {
            x = x
          }
          self.mCustomScrollbar("scrollTo", $li.eq(x));
        });
        next.click(function () {
          var pct = el.mcs.leftPct;
          if (pct != 100 && x < $li.length) {
            x++
          } else {
            x = x
          }
          self.mCustomScrollbar("scrollTo", $li.eq(x));
        });
      },
      onScroll: function () {
        var prev = $('.nav-prev'),
          next = $('.nav-next');
        var pct = this.mcs.leftPct;
        if (pct == 0) {
          prev.addClass('disable');
        } else {
          prev.removeClass('disable');
        }
        if (pct == 100) {
          next.addClass('disable');
        } else {
          next.removeClass('disable');
        }

      }
    }
  });

  $('body').addClass("animated fadeIn");


});
