$(document).ready(function () {

    $("#home").load("/html/home.html");
    $("#autore").load("/html/autore.html");
    $("#album").load("/html/album.html");
    $("#nuovoautore").load("/html/nuovoautore.html");
    $("#nuovoalbum").load("/html/nuovoalbum.html");

    $(".bottonemenu").click(function () {
        console.log("Hai cliccato il bottone" + $(this).attr("divDaAprire"));

        var paginaDaVedere = $(this).attr("divDaAprire").toLowerCase();

        $(".pagina").hide(250);

        $("#" + paginaDaVedere).show(250);
    });
});