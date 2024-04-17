function elimina(varID) {
    $.ajax(
        {
            url: "/Cittum/elimina/" + varID,
            type: "DELETE",
            success: function (risultato) {
                alert("YEAH! MDF");
                location.reload();
            },
            error: function (errore) {
                alert(errore)
            }
        }
    )
}