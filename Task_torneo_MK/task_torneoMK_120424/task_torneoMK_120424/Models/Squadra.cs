using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace task_torneoMK_120424.Models
{
    [Table("Squadra")]
    public class Squadra
    {
        public int SquadraID { get; set; }
        public string? Codice { get; set; }
        public string? Nome { get; set; }
        public int CreditoIniz { get; set; }
        //public int UtenteRif { get; set; }
        //public Utente? UtenteRN { get; set; }
        //[JsonIgnore]
        //public int PersonaggioRIF { get; set; }
        
        //public IEnumerable<Personaggio>? Personaggios { get; set; }


    }
}
