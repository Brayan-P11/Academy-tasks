using System;
using System.Collections.Generic;

namespace task_negozio_270324.Models;

public partial class OrdineProdotto
{
    public int CodiceId { get; set; }

    public int OrdineRif { get; set; }

    public int ProdottoRif { get; set; }

    public virtual Ordine OrdineRifNavigation { get; set; } = null!;

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;
}
