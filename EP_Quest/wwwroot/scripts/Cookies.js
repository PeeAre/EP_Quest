function setCookie(name, value, expiration) {
    var date = new Date();
    date.setTime(date.getTime() + (expiration * 24 * 60 * 60 * 1000));
    var expires = "expires=" + date.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}