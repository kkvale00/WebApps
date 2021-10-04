function validaForm() {

    //Controlleremo uno ad uno i valori inseriti nei vari input
    //Se troviamo qualcosa che non ci va a genio ritorneremo false
    //Se verranno passati tutti i controlli ritorneremo true
    //il nome deve essere di almeno due caratteri
   
    if (document.getElementById("nome").value.length < 2) {
        alert("inserire almeno 2 caratteri ")
        return false;
    }
    //il cognome deve essere di almeno 2 caratteri
    if (document.getElementById("cognome").value.length < 2) {
        alert("inserire almeno 2 caratteri ")
        return false;
    }

    //il reparto deve essere uno tra "Acquisti","Vendite","Segreteria","Amministrazione"
    switch (document.getElementById("reparto").value.toLowerCase()) {
        case "acquisti":
        case "vendite":
        case "segreteria":
        case "amministrazione":
            break;
        default:
            alert("i reparti accentati sono: acquisti,vendite,segreteria,amministrazione")
            return false
    }
    //la residenza deve essere almeno di due caratteri
    if (document.getElementById("residenza").value.length < 2) {
        alert("inserire almeno due caratteri")
        return false;
    }
    //l'anno della dob deve essere almmeno annocorrente - 17
    var annoInserito = parseInt(document.getElementById("dob").value.split("-")[0]);
    var annoCorrente = new Date().getFullYear();

    if (annoCorrente - 17 < annoInserito)
        alert("bro dai torna a giocare coi lego...")
        return false;
    //alla fine un bel
    return true;
}

var reparti = ["Acquisti", "Vendite", "Segreteria", "Amministrazione"];
var ris = "";
for (var i = 0; i < reparti.length; i++)
    ris += "<option value='" + reparti[i] + "'>" + reparti[i] + "</option>";

document.getElementById("reparto").innerHTML = ris;

var pippo = new XMLHttpRequest();

pippo.onload = function () {
    var residenze = console.log(JSON.parse(this.responseText));
}

pippo.open("GET", "https://raw.githubusercontent.com/matteocontrini/comuni-json/master/comuni.json");
pippo.send();


