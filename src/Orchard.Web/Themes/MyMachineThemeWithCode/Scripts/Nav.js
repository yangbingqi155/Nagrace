$(function () {
    $(".navbar-nav>li>a").hover(function () { $(this).parent().find(".menu_icon_down").show(); }, function () { $(this).parent().find(".menu_icon_down").hide(); });
    $("#nav_products").find(".item").each(function (i,d) {
        $(d).hover(function () {
            if ($(this).hasClass("default")) {
                $(this).removeClass("default")
            }
        }, function () {
            if (!$(this).hasClass("default")) {
                $(this).addClass("default")
            }
        });
    });
    $("#nav_products").hover(function () {
        $("#nav_products").stop(true, false, true).slideDown('medium');
    }, function () {
        $("#nav_products").stop(true, false, true).slideUp('medium');
    });
    $("#layout-navigation ul li").each(function (i, d) {
        if ($(d).find("a").text() == "Products" || $(d).find("a").text() == "产品") {
            $(d).hover(function () {
                $("#nav_products").stop(true, false, true).slideDown('medium');
            }, function () {
                $("#nav_products").stop(true, false, true).slideUp('medium');
            });
        }
    });
});