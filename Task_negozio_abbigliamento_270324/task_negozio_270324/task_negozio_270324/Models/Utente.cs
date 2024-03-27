using System;
using System.Collections.Generic;

namespace task_negozio_270324.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();
}
