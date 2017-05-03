function menuSec(id) {
    $("#menu form ul li").each(function () {
        $(this).removeClass("current_page_item");
    });
    $("#menu form ul li:nth-child(" + id + ")").addClass("current_page_item");
}