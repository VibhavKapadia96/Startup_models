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

    $('#myBtn').on('click', function () {
              document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    });

    var mybutton = document.getElementById("myBtn");

    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

    //// When the user clicks on the button, scroll to the top of the document
    //function gotop() {
    //    document.body.scrollTop = 0;
    //    document.documentElement.scrollTop = 0;
    //}
}
