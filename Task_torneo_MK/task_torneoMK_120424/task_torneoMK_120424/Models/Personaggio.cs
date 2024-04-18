using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace task_torneoMK_120424.Models
{
    [Table("Personaggio")]
    public class Personaggio
    {
        public int PersonaggioID { get; set; }
        public string? Codice { get; set; }
        public string? Nome { get; set; }
        public int Costo { get; set; }
        public int Categoria { get; set; }
        //public int SquadraRIF { get; set; }
        //public Squadra? SquadraRifNavigation { get; set; }
    }
}
