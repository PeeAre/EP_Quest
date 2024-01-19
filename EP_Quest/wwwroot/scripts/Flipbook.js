function bookInit() {
    $(document).ready(() => {
        $("#flipbook").turn({
            duration: 1800,
            autoCenter: true
        });
        disableTurn();
        $('.book-container').zoom({
            flipbook: $('#flipbook'),
            duration: 1000,
            max: 2
        });
        //$("#flipbook").bind("turning", zoomTo);
        window.addEventListener('resize', resize);
        resize();
    });
}

function resize() {
    var width = $('.book-container').width();
    var height = $('.book-container').height();

    if ($(window).width() < 980)
        $("#flipbook").turn("display", "single");
    else
        $("#flipbook").turn("display", "double");

    $('#flipbook').turn("size", width, height);
    $('#flipbook').turn("resize");
}

function zoomTo(event) {
    setTimeout(() => {
        if ($('.book-container').zoom('value') === 1) {
            zoomIn(event);
        } else {
            zoomOut();
        }
    }, 200);
}

function zoomIn(event) {
    if (event.clientX)
        $('.book-container').zoom('zoomIn', event);
    else
        $('.book-container').zoom('zoomIn', { x: ($('#flipbook').width()), y: 32 });
}

function zoomOut() {
    $('.book-container').zoom('zoomOut');
}

function resizeViewport() {
    var width = $(window).width(),
        height = $(window).height(),
        options = $('#flipbook').turn('options');

    $('.book-container').css({
        width: width,
        height: height
    }).zoom('resize');
}

function enableTurn() {
    //$('.book-container').bind('zoom.tap', zoomTo);
    $("#flipbook").turn("disable", false);
}

function disableTurn() {
    $("#flipbook").turn("disable", true);
}

function nextPage() {
    $("#flipbook").turn("next");
}

function previousPage() {
    $("#flipbook").turn("previous");
}

function zoomBook() {
    $("#flipbook").turn("zoom", 2);
}