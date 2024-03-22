using System;
using System.Collections.Generic;

namespace Task_eventi_220324.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Contatto { get; set; } = null!;

    public string CodiceBiglietto { get; set; } = null!;

    public int EventoRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Evento EventoRifNavigation { get; set; } = null!;
}
