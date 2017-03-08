
function login() {
  var url = "/umbraco/api/login/login?name=" + document.getElementById('username').value + "&password=" + document.getElementById('password').value;
    var request = new XMLHttpRequest();

    request.open("GET", url);
    request.addEventListener('load', function (event) {
        if (request.status >= 200 && request.status < 300) {
            console.log(request.responseText);
        } else {
            console.warn(request.statusText, request.responseText);
        }
    });
    request.send();
}