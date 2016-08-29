function onButtonClick(event, args) {
    var currentWindow = window,
        browser = currentWindow.navigator.appCodeName,
        isBrowserMozilla = browser == "Mozilla";
    if (isBrowserMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}