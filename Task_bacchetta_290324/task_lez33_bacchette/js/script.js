// Metodi CRUD PER LE BACCHETTE
const stampa = () => {
    let elencoBacchette = JSON.parse( localStorage.getItem('elenco_bac') );

    let stringaTabella = '';
    for(let [idx, item] of elencoBacchette.entries()){
        stringaTabella += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.materiale}</td>
                <td>${item.nucleo}</td>
                <td>${item.lunghezza}</td>
                <td>${item.resistenza}</td>
                <td>${item.mago}</td>
                <td>${item.casata}</td>
                <td>${item.foto}</td>
                <td class="text-right">
                    <!-- <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button> -->
                    <button class="btn btn-outline-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;

    }

    document.getElementById("corpo-tabella").innerHTML = stringaTabella;

    
    // if(item.casata ="Serpe Verde")
    // nBacchetteS ++;
    // if(item.casata ="Corvo Nero")
    // nBacchetteC ++;
    // if(item.casata ="Tasso Rosso")
    // nBacchetteT ++;

    if(item.casata.value = "GRIF")
    nBacchetteG ++;

    console.log(nBacchetteG);
    
}

const salva = () => {
    let materiale = document.getElementById("input-materiale").value;
    let nucleo = document.getElementById("input-nucleo").value;
    let lunghezza = document.getElementById("input-lunghezza").value;
    let resistenza = document.getElementById("input-resistenza").value;
    let mago = document.getElementById("input-mago").value;
    let casata = document.getElementById("select-casata").value;
    let foto = document.getElementById("input-foto").value;

    let bacchetta = {
        materiale,
        nucleo,
        lunghezza,
        resistenza,
        mago,
        casata,
        foto
    }

    let elencoBacchette = JSON.parse( localStorage.getItem('elenco_bac') ); //Prendo il vecchio elenco decodificato sotto forma di oggetto
    elencoBacchette.push(bacchetta);                                               //Aggiungo l'elemento al vecchio elenco
    localStorage.setItem('elenco_bac', JSON.stringify(elencoBacchette));    //Ricodifico l'elenco (sotto forma di stringa) per poterlo salvare nel Local Storage

    document.getElementById("input-materiale").value = "";
    document.getElementById("input-nucleo").value = "";
    document.getElementById("input-lunghezza").value = "";
    document.getElementById("input-resistenza").value = "";
    document.getElementById("input-mago").value = "";
    document.getElementById("select-casata").value = "";
    document.getElementById("input-foto").value = "";

    stampa();

    // istruzione per nascondere il modale 
    $("#modaleInserimento").modal("hide");
}

const elimina = (indice) => {
    let elencoBacchette = JSON.parse( localStorage.getItem('elenco_bac') );
    elencoBacchette.splice(indice, 1);
    localStorage.setItem('elenco_bac', JSON.stringify(elencoBacchette));

    stampa();
}

const modifica = (indice) => {

    let elencoBacchette = JSON.parse( localStorage.getItem('elenco_bac') );
    console.log(elencoBacchette[indice])

    document.getElementById("update-materiale").value = elencoBacchette[indice].materiale;
    document.getElementById("update-nucleo").value = elencoBacchette[indice].nucleo;
    document.getElementById("update-lunghezza").value = elencoBacchette[indice].lunghezza;
    document.getElementById("update-resistenza").value = elencoBacchette[indice].resistenza;
    document.getElementById("update-mago").value = elencoBacchette[indice].mago;
    document.getElementById("update-casata").value = elencoBacchette[indice].casata;
    document.getElementById("update-foto").value = elencoBacchette[indice].foto;
    

    $("#modaleModifica").data("identificativo", indice)

    $("#modaleModifica").modal("show");
}

const update = () => {
    let materiale = document.getElementById("update-materiale").value;
    let nucleo = document.getElementById("update-nucleo").value;
    let lunghezza = document.getElementById("update-lunghezza").value;
    let resistenza = document.getElementById("update-resistenza").value;
    let mago = document.getElementById("update-mago").value;
    let casata = document.getElementById("update-casata").value;
    let foto = document.getElementById("update-foto").value;
    

    let bacchetta = {
        materiale,
        nucleo,
        lunghezza,
        resistenza,
        mago,
        casata,
        foto
    }

    let indice = $("#modaleModifica").data("identificativo")

    let elencoBacchette = JSON.parse( localStorage.getItem('elenco_bac') );
    elencoBacchette[indice] = bacchetta;
    localStorage.setItem('elenco_bac', JSON.stringify(elencoBacchette));

    $("#modaleModifica").modal("hide");
}


//Creazione elenco se non esiste
let elencoString = localStorage.getItem('elenco_bac');
if(!elencoString)
    localStorage.setItem('elenco_bac', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa(); 


// CASATE
// var nBacchetteG = 0;
// var nBacchetteS;
// var nBacchetteC;
// var nBacchetteT;

// const stampaQuantitaBacchette = () =>{
//     let elencoBacchetteG = JSON.parse( localStorage.getItem('elenco_bac') );
//     if(item.casata ="Griffondoro")
//     nBacchetteG ++;
// }

// const stampaN = () =>{
//     let numeroBacchette = JSON.parse( localStorage.getItem('numero_bacchette') );

//     let stringaTabella = '';
//     let nBacchetteG = 0;
//    for(let[item] of numeroBacchette.entries()){
//     stringaTabella += `
    
//     `;
//    }
//    if(item.casata.value = "GRIF")
//    nBacchetteG ++;


//     document.getElementById("bac-grif").innerHTML = nBacchetteG;
// }

// const stampaN = () =>{
//     let numeroBacchette = JSON.parse( localStorage.getItem('numero_bacchette') );

//     let stringaTabella = '';
//     let nBacchetteG = 0;
//    for(let[item] of numeroBacchette.entries()){
//     stringaTabella += `
    
//     `;
//    }
//    if(item.casata.value = "GRIF")
//    nBacchetteG ++;


//     document.getElementById("bac-grif").innerHTML = nBacchetteG;
// }

let quantitaBacchette = localStorage.getItem('numero_bacchette');
if(!quantitaBacchette)
    localStorage.setItem('numero_bacchette', JSON.stringify([]) );

const aggiungiBacchette = () => {
    let numeroBacchette = JSON.parse( localStorage.getItem('numero_bacchette'));

    let numBacchette = '';
    document.getElementById("update-casata").value = elencoBacchette[indice].casata;
    let casata = document.getElementById("update-casata").value;
    console.log(quantitaBacchette);
}

// <script>
//         let elenco = []
//         function inserisciTesto(){
//             document.getElementById("bac-grif").innerText = "CIAO";
//         }
//     </script>


