using System;
using System.Collections.Generic;

namespace Task_eventi_220324.Models;

public partial class Evento
{

    /// <summary>
    /// Classe Evento
    /// </summary>
    
    public int EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public int Capacita { get; set; }

    public DateTime DataOra { get; set; }

    public string Luogo { get; set; } = null!;

    public virtual ICollection<Partecipante> Partecipantes { get; set; } = new List<Partecipante>();

    public virtual ICollection<Risorsa> Risorsas { get; set; } = new List<Risorsa>();
    
}
