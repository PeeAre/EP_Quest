function bookInit() {
    $(document).ready(() => {
        $("#flipbook").turn({
            duration: 1800,
            autoCenter: true
        });
        disableTurn();
    });
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

function previousPage() {
    $("#flipbook").turn("previous");
}

function zoomBook() {
    $("#flipbook").turn("zoom", 2);
}