var oneTime = setInterval(pageLoad, 0.1);
function pageLoad() {
    feather.replace();
    $(".btn").on("click", function (e) {
        e.preventDefault()
        e.stopImmediatePropagation()
        $(this).closest("li").toggleClass('active')
        $(this).children('.fa').toggleClass('fa-caret-right fa-caret-down');

    });
    $('.nav ul li a').each(function () {
        if ($(this).hasClass('active') && $(this).parents('li').hasClass('active') == false) {
            $(this).parents("li").toggleClass('active');
            $(this).parents("li").each(function () {
                if ($(this).hasClass('active')) {
                    $(this).children("a").children(".btn").children(".fa").toggleClass('fa-caret-right fa-caret-down');
                }
            });
            return false;
        }

    });

    $('.list-group-item').on('click', function () {
        $('.fas', this)
            .toggleClass('fa-angle-right')
            .toggleClass('fa-angle-down');
    });
}
