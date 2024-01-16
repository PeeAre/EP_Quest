function scrollToElement(containerId, elementId) {
    let container = document.getElementById(containerId);
    let element = document.getElementById(elementId);

    if (container && element) {
        container.scrollTo({ behavior: "smooth", top: element.offsetTop });
    }
}