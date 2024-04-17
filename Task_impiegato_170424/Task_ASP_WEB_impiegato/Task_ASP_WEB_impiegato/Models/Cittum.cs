using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_ASP_WEB_impiegato.Models;
[Table("Citta")]
public partial class Cittum
{
    

    public int CittaId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Impiegato> Impiegatos { get; set; } = new List<Impiegato>();
}
