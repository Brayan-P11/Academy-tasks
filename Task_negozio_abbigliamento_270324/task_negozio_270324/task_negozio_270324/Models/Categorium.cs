using System;
using System.Collections.Generic;

namespace task_negozio_270324.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
