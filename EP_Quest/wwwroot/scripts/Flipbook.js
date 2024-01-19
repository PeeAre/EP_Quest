var lastPage;

function bookInit() {
    $(document).ready(() => {
        $("#flipbook").turn({
            duration: 1200,
            autoCenter: true
        });
        disableTurn();
        lastPage = $("#flipbook").turn("pages");
        $('.book-container').zoom({
            flipbook: $('#flipbook'),
            duration: 1000,
            max: 1.5
        });
        $('.book-container').bind('zoom.tap', zoomTo);
        $("#flipbook").bind("turning", (event, page, corner) => {
            if (page > 1) {
                if (page === 2) {
                    event.preventDefault();

                    switch ($("#flipbook").turn("page")) {
                        case 1:
                            $("#flipbook").turn("page", 3);
                            break;
                        case 3:
                            $("#flipbook").turn("page", 1);
                            break;
                    }
                } else if (page === lastPage) {
                    event.preventDefault();
                }
            }
        });
        window.addEventListener('resize', resize);
        resize();
    });
}

function resize() {
    var width = $('.book-container').width();
    var height = $('.book-container').height();

    if ($(window).width() < 980) {
        lastPage = $("#flipbook").turn("pages") - 1;
        $("#flipbook").turn("display", "single");

    } else {
        lastPage = $("#flipbook").turn("pages");
        $("#flipbook").turn("display", "double");
    }

    $('#flipbook').turn("size", width, height);
}

function zoomTo(event) {
    setTimeout(() => {
        if ($('.book-container').data().regionClicked) {
            $('.book-container').data().regionClicked = false;
        } else {
            if ($('.book-container').zoom('value') === 1) {
                if ($("#flipbook").turn("page") === 3)
                    zoomIn(event);
            } else {
                zoomOut();
            }
        }
    }, 200);
}

function zoomIn(event) {
    $('.book-container').zoom('zoomIn', event);
}

function zoomOut() {
    $('.book-container').zoom('zoomOut');
}

function enableTurn() {
    $("#flipbook").turn("disable", false);
}

function disableTurn() {
    $("#flipbook").turn("disable", true);
}

function nextPage() {
    $("#flipbook").turn("next");
}