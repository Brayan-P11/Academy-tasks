using System;
using System.Collections.Generic;

namespace task_negozio_270324.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public int? ProdottoRif { get; set; }

    public int QuantitaFinale { get; set; }

    public decimal PrezzoPieno { get; set; }

    public decimal? PrezzoOfferta { get; set; }

    public DateOnly? InizioOfferta { get; set; }

    public DateOnly? FineOfferta { get; set; }

    public virtual Prodotto? ProdottoRifNavigation { get; set; }
}
