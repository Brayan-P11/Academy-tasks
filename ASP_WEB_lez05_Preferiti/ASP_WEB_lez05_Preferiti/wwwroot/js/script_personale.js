function elimina(varCodice) {
    $.ajax(
        {
            url: "/Film/elimina/" + varCodice,
            type: "DELETE",
            success: function (risultato) {
                alert("STAPPOOOOOO");
                location.reload();
            },
            error: function (errore) {
                alert(errore)
            }
        }
    )
}