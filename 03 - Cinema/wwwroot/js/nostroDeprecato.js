//$ : Il dollaro in jQuery è il SELETTORE, serve a selezionare elementi
//(document) : è l'elemento che è stato selezionato
//getReady : la funzione getReady aspetta che il documento sia pronto
//function(){} : è una callback, ovvero una funzione che verrà eseguita solo quando il 
//               getReady sarà terminato (darà l'ok)
//Prendo il mio intero documento HTML, aspetto che sia pronto e poi eseguo tutte le
//operazioni contenute nella function anonima (nella callback)

//jQuery è una libreria javascript che grazie al $ e a delle funzioni ci consente
//una più facile manipolazione del DOM (Document Object Model - la nostra pagina HTML)

$(document).ready(function ()
{
    //tutto il codice di nostro.js sara qui

    $(".bottonemenu").click(function () {
        console.log("Hai cliccato il bottone" + $(this).html() );

        var paginaDaVedere = $(this).html().toLowerCase();

        //nascondo tutte le pagine
        $(".pagina").hide();

        //mostro solo la pagina che voglio vedere
        $("#" + paginaDaVedere).show();
    });

    var elencoFilm = [];

    //Andremo a rie,pire il nostro elenco di film grazie ad una chiamata AJAX
    //la chiamata verra fatta a localohost:/Film/ElencoJSON

    //AJAX serve a fare delle request ASINCRONE
    $.get("/Film/ElencoJSON").then(function (data) {

        elencoFilm = data;

        //Eseguo la stampa dei film nella tabella, la eseguo qui per essere sicuro
        //console.log("Ho richiesto a /Film/ElencoJSON gli oggetti film");
        //console.log(elencoFilm);
        //che venga eseguita DOPO che l'elencoFilm e stato valorizzato

        //dichiaro la prima riga della tabella contenenti cosa sto stampando
        var ris = '<thead> < tr class="w3-light-grey" >' +
            '<th>Titolo</th><th>Genere</th><th>Durata</th> </tr >' +
            '</thead > ';


        for (var i = 0; i < elencoFilm.length; i++)
        {
            ris += "<tr>" +
                   "<td>" + elencoFilm[i].titolo + "</td>" +
                   "<td>" + elencoFilm[i].genere + "</td>" +
                   "<td>" + elencoFilm[i].durata + "</td>" +
                   "</tr>";
        }
        //tr indica l inizio di una nuova riga (table row)
        //td indica singolo dato della riga (table data)

        $("#elencofilm").html(ris);
    });//fine ajax film
    //AJAX sta per Asinchronous Javascript And XML, ? uno strumento che ci consente di
    //effettuare delle request ad un indirizzo particolare, queste request avvengono in
    //background. Quindi il programma prosegue normalmente nel frattempo una piccola porzione
    //di programma ? addetta al recupero dell'elenco degli utenti che possiamo reperire al
    //link /Utente/ElencoJSON

    var elencoutenti = [];
    $.get("/Utente/ElencoJSON").then(function (dati) {

        //Sappiamo che /Utente/ElencoJSON ci restituisce l'elenco dei dipendenti in
        //formato JSON e una volta che ci verr? fornito lo inseriremo nell'elencoUtenti
        //JSON -> Javascript Object Notation -> il formato in cui sono scritti gli oggetti in JS

        elencoutenti = dati;

        var ans = '<thead> < tr class="w3-light-grey" >' +
            '<th>Username</th><th>Nome</th><th>Cognome</th><th>Data di Nascita</th><th>Residenza<th> </tr >' +
            '</thead > ';

        for (var i = 0; i < elencoutenti.length; i++) {

            ans += "<tr>" +
                   "<td>" + elencoutenti[i].username + "</td>" +
                   "<td>" + elencoutenti[i].nome+ "</td>" +
                   "<td>" + elencoutenti[i].cognome+ "</td>" +
                   "<td>" + elencoutenti[i].dob.split('T')[0]+ "</td>" +
                   "<td>" + elencoutenti[i].residenza+ "</td>" +
                   "</tr>";         
        }

        $("#elencoutenti").html(ans);

    });
});