using System;
using System.Collections.Generic;

namespace task_negozio_270324.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public string StatoOrdine { get; set; } = null!;

    public string NomeProdotto { get; set; } = null!;

    public decimal Costo { get; set; }

    public DateOnly DataEmissione { get; set; }

    public int QuantitaOrd { get; set; }

    public int? UtenteRif { get; set; }

    public virtual ICollection<OrdineProdotto> OrdineProdottos { get; set; } = new List<OrdineProdotto>();

    public virtual Utente? UtenteRifNavigation { get; set; }
}
