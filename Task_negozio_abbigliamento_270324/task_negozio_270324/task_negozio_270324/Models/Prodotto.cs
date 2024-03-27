using System;
using System.Collections.Generic;

namespace task_negozio_270324.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Galleria { get; set; } = null!;

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int? CategoriaRif { get; set; }

    public virtual Categorium? CategoriaRifNavigation { get; set; }

    public virtual ICollection<OrdineProdotto> OrdineProdottos { get; set; } = new List<OrdineProdotto>();

    public virtual ICollection<Variazione> Variaziones { get; set; } = new List<Variazione>();
}
