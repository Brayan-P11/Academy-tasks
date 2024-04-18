using System.ComponentModel.DataAnnotations.Schema;

namespace task_torneoMK_120424.Models
{
    [Table("Utente")]
    public class Utente
    {
        public int UtenteID { get; set; }
        public string? Codice { get; set; }
        public string? Nome { get; set; }
        //public Squadra? Squadra { get; set; }
        
    }
}
