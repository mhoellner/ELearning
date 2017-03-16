
function login() {
  var url = "/umbraco/api/login/login?name=" + document.getElementById('username').value + "&password=" + document.getElementById('password').value;
    var request = new XMLHttpRequest();
    request.open("GET", url);

    //Wenn eine Antwort vom Webservice (Controller kommt)
    request.addEventListener('load', function (event) {
        if (request.status >= 200 && request.status < 300) {
            //Die Anfrage war erfolgreich
            var username = request.responseText;
            username = username.replace('"', '');
            username = username.replace('"', '');
            if (username != "Username or password is wrong.") {
                //Wenn Login erfolgreich war
              document.cookie = 'elearningName=' + username + '; Path=/;';
                document.getElementById('username').value = "";
                document.getElementById('password').value = "";
                LoginAktualisieren();
            }
            else {
                //Name und/oderPasswort war falsch
                document.getElementById('password').value = "";
                alert("Ihr Benutzername oder Ihr Passwort ist nicht gültig. Versuchen sie es erneut.");
            }

        }
        else {
            //Die Antwort des Service, beinhaltet eine Fehlermeldung.
            alert("Ein Fehler ist aufgetreten.");
        }
    });
    //Anfrage senden
    request.send();
}

//Inhalt des Cookies mit dem übergebenen Namen wird zurückgegeben
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

// Funktion macht die Anpassungen der Seite für den eingeloggten/ uneingeloggten Zustand
function LoginAktualisieren() {
  var username = getCookie("elearningName");
  if (username != "") {
      //Wenn ein Nutzer eingeloggt ist
        document.getElementById('logged').style.display = 'block';
        document.getElementById('bodyLogged').style.display = 'block';
        document.getElementById('nameLogged').innerText = username;

        document.getElementById('bodyUnlogged').style.display = 'none';
        document.getElementById('unlogged').style.display = "none";

  }
  else {
      //Wenn ein Nutzer nicht eingeloggt ist
        document.getElementById('logged').style.display = 'none';
        document.getElementById('bodyLogged').style.display = 'none';
        document.getElementById('nameLogged').innerText = "";

        document.getElementById('bodyUnlogged').style.display = 'block';
        document.getElementById('unlogged').style.display = "block";
    }
}


function Logout() {
    //Cookie wird gelöscht
    document.cookie = 'elearningName=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    //Ansicht muss aktualisiert werden.
  LoginAktualisieren();
}

//Beim Laden der Seite, wird die Ansicht aktualisiert.
LoginAktualisieren();