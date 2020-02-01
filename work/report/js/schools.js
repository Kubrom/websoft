/**
 * @author Kubrom Mulugheta
 */
"use strict";
function addKommun() {
  //ProxyUrl used to avoid CORS
  const proxyUrl = "https://cors-anywhere.herokuapp.com/";
  const url = "https://api.scb.se/UF0109/v2/skolenhetsregister/sv/kommun";
  var xmlhttp = new XMLHttpRequest();
  xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
      var response = this.responseText;

      var json = JSON.parse(response);
      var jsonKommuner = json.Kommuner;
      var kommunCount = jsonKommuner.length;
      daySelect = document.getElementById("kommunForm");
      for (var i = 0; i < kommunCount; i++) {
        daySelect.options[i] = new Option(
          jsonKommuner[i].Namn + " " + jsonKommuner[i].Kommunkod,
          jsonKommuner[i].Kommunkod
        );
      }
    }
  };
  xmlhttp.open("GET", proxyUrl + url, true);
  xmlhttp.send();
}

function showSchools(KommunkodValue) {
  //ProxyUrl used to avoid CORS
  const proxyUrl = "https://cors-anywhere.herokuapp.com/";
  const url =
    "https://api.scb.se/UF0109/v2/skolenhetsregister/sv/kommun/" +
    KommunkodValue;

  var xmlhttp = new XMLHttpRequest();
  xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
      var response = this.responseText;
      var json = JSON.parse(response);
      var jsonSchool = json.Skolenheter;
      var schoolCount = jsonSchool.length;
      var table =
        "<tr><th>Kommunkod</th><th>PeOrgNr</th><th>Skolenhetskod</th><th>Skolenhetsnamn</th></tr>";
      var i;
      for (i = 0; i < schoolCount; i++) {
        table +=
          "<tr><td>" +
          jsonSchool[i].Kommunkod +
          "</td><td>" +
          jsonSchool[i].PeOrgNr +
          "</td><td>" +
          jsonSchool[i].Skolenhetskod +
          "</td><td>" +
          jsonSchool[i].Skolenhetsnamn;
        ("</td></tr>");
      }

      document.getElementById("demo").innerHTML = table;
    }
  };
  xmlhttp.open("GET", proxyUrl + url, true);
  xmlhttp.send();
}
