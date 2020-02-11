// http://api.scb.se/UF0109/v2/

(function() {
  var municipality = document.getElementById("municipality");
  var schoolTable = document.getElementById("schoolTable");

  fetch("data/kommunKoder.json")
    .then(res => {
      return res.json();
    })
    .then(jsonObj => {
      console.log(jsonObj);

      for (var i = 0; i < jsonObj.Kommun.length; i++) {
        var opt = document.createElement("option");
        var kommun = jsonObj.Kommun[i];
        opt.appendChild(document.createTextNode(kommun.Namn));
        opt.value = kommun.Kommunkod;
        kommunNr = kommun.Kommunkod;
        municipality.appendChild(opt);
      }

      municipality.addEventListener("change", function() {
        var kommunNr = municipality.options[municipality.selectedIndex].value;
        fetch("data/" + kommunNr + ".json")
          .then(res => {
            return res.json();
          })
          .then(jsonObj => {
            //  console.log(jsonObj)

            var rowCount = schoolTable.rows.length;
            for (var x = rowCount - 1; x >= 0; x--) {
              schoolTable.deleteRow(x);
            }

            var row = schoolTable.insertRow(0);
            var cell = row.insertCell(0);
            var cell1 = row.insertCell(1);
            var cell2 = row.insertCell(2);
            var cell3 = row.insertCell(3);
            cell.innerHTML = "<strong>School Code</strong>";
            cell1.innerHTML = "<strong>School Name</strong>";
            cell2.innerHTML = "<strong>Municipality Code</strong>";
            cell3.innerHTML = "<strong>Organization Number</strong>";

            for (var i = 0; jsonObj.Skolenheter.length; i++) {
              var school = jsonObj.Skolenheter[i];
              row = schoolTable.insertRow(i + 1);
              cell = row.insertCell(0);
              cell1 = row.insertCell(1);
              cell2 = row.insertCell(2);
              cell3 = row.insertCell(3);

              cell.innerHTML = school.Skolenhetskod;
              cell1.innerHTML = school.Skolenhetsnamn;
              cell2.innerHTML = school.Kommunkod;
              cell3.innerHTML = school.PeOrgNr;
            }
          });
      });
    });
})();
