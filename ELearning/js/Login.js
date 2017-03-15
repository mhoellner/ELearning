
function login() {
  var url = "/umbraco/api/login/login?name=" + document.getElementById('username').value + "&password=" + document.getElementById('password').value;
    var request = new XMLHttpRequest();

    request.open("GET", url);
    request.addEventListener('load', function (event) {
        if (request.status >= 200 && request.status < 300) {
            var username = request.responseText;
            username = username.replace('"', '');
            username = username.replace('"', '');
            if (username != "Username or password is wrong.") {

                //Wenn Login erfolgreich war
              document.cookie = 'elearningName=' + username + '; Path=/;';
                document.getElementById('username').value = "";
                document.getElementById('password').value = "";
                LoginAktualisieren();
            } else 
            {

                //Name und/oderPasswort war falsch
                document.getElementById('password').value = "";
                alert("Ihr Benutzername oder Ihr Passwort ist nicht gültig. Versuchen sie es erneut.");
            }

        } else {
        }
    });
    request.send();
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function LoginAktualisieren() {
  var username = getCookie("elearningName");
  if (username != "") {
        var logged = document.getElementById('logged');
        logged.style.display = 'block';
        document.getElementById('bodyLogged').style.display = 'block';
        document.getElementById('bodyUnlogged').style.display = 'none';
        document.getElementById('nameLogged').innerText = username;

        var unlogged = document.getElementById('unlogged');
        unlogged.style.display = "none";

  } else {
        var logged = document.getElementById('logged');
        logged.style.display = 'none';
        document.getElementById('bodyLogged').style.display = 'none';
        document.getElementById('bodyUnlogged').style.display = 'block';
        document.getElementById('nameLogged').innerText = "";

        var unlogged = document.getElementById('unlogged');
        unlogged.style.display = "block";
    }
}


function Logout() {
  document.cookie ='elearningName=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    var logged = document.getElementById('logged');
    logged.style.display = 'none';
  document.getElementById('bodyLogged').style.display = 'none';
  document.getElementById('bodyUnlogged').style.display = 'block';
    document.getElementById('nameLogged').innerText = "";

    var unlogged = document.getElementById('unlogged');
    unlogged.style.display = "block";
}

LoginAktualisieren();