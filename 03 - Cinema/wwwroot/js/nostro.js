$(document).ready(function () {

    $("#home").load("/html/home.html");
    $("#film").load("/html/film.html");
    $("#utente").load("/html/utente.html");
    $("#prenotazioni").load("/html/prenotazioni.html");
    $("#nuovofilm").load("/html/nuovofilm.html");
    $("#nuovoutente").load("/html/nuovoutente.html");

    $(".bottonemenu").click(function () {
        console.log("Hai cliccato il bottone" + $(this).attr("divDaAprire"));

        var paginaDaVedere = $(this).attr("divDaAprire").toLowerCase();

        $(".pagina").hide(250);

        $("#" + paginaDaVedere).show(250);
    });
});