const stampaTabella = () => {           // OK
    $.ajax(
        {
            url: "https://localhost:7106/api/prodotti",
            type: "GET",
            success: function(risultato){
                let contenuto = "";

                for(let [idx, item] of risultato.entries()){
                    contenuto += `
                        <tr>
                            <!-- <td>${item.codice}</td> -->
                            <td>${item.nome}</td>
                            <td>${item.descrizione}</td>
                            <td>${item.prezzo}</td>
                            <td>${item.categoria}</td>
                            <td
                                
                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                    <button type="button" class="btn btn-group-sm btn-outline-dark" onclick="decrementa('${item.quantita}')">-</button>
                                    <div style="padding: 5px 10px 0 10px;">${item.quantita}</div>
                                    <button type="button" class="btn btn-group-sm btn-outline-dark" onclick="aumenta('${item.quantita}')">+</button>
                                </div>
                            </td>
                            <td>
                                <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                                    <i class="fa-solid fa-pencil"></i>
                                </button>
                                <button class="btn btn-danger" onclick="elimina('${item.codice}')">
                                    <i class="fa-solid fa-trash"></i>
                                </button>
                            </td>
                        </tr>
                    `;
                }

                $("#corpo-tabella").html(contenuto);
            }, 
            error: function(errore){
                alert("ERRORE");
                console.log(errore)
            }
        }
    );
}

const elimina = (codice) => {           // OK
    
    $.ajax(
        {
            url: "https://localhost:7106/api/prodotti/codice/" + codice,
            type: "POST",
            success: function(){
                alert("Stappooooo");
                stampaTabella();
            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
        }
    )

}

const salvaElemento = () => {           // OK
    let nomeTemp = $("#input-nome").val();
    let descTemp = $("#input-descrizione").val();
    let prezTemp = $("#input-prezzo").val();
    let quanTemp = $("#input-quantita").val();
    let cateTemp = $("#input-categoria").val();

    $.ajax(
        {
            url: "https://localhost:7106/api/prodotti",
            type: "POST",
            data: JSON.stringify({
                nome : nomeTemp,
                descrizione : descTemp,
                prezzo : prezTemp,
                quantita : quanTemp,
                categoria : cateTemp

            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){
                
                alert("Stappooooo");
                stampaTabella();
                $("#modaleInserimento1").modal("hide");  // nascondere il modale

            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
            
        
        }
    )
}

// in fase di lavorazione

// const aumenta = () => {
//     let quanTemp = item.quantita;
//     $.ajax(
//         {
//             url: "https://localhost:7106/api/prodotti",
//             type: "POST",
//             data: JSON.stringify({
//                 nome

//         // if(quanTemp > 0){
//         //     quanTemp += 1;
//         // }
//         // else{
//         //     quanTemp = 0;
//         }

//         }
//     )
    

// }


$(document).ready(              // OK
    function(){

        stampaTabella();

        $(".salva").on("click", () => {
            salvaElemento();
        })

    }
);