using Task_ASP_EF_ferramenta.Models;

namespace Task_ASP_EF_ferramenta.Repositories
{
    public class ProdottoRepo : IRepo<Prodotto>
    {

        private static ProdottoRepo? _instance;
        public static ProdottoRepo getInstance()
        {
            if (_instance == null)
                _instance = new ProdottoRepo();
            return _instance;
        }

        private ProdottoRepo() { }

        public bool Delete(int id)
        {
            bool risultato = false;
            using (TaskFerramenta030424Context ctx = new TaskFerramenta030424Context())
            {
                try
                {
                    Prodotto prod = ctx.Prodottos.Single(p => p.ProdottoId == id);
                    ctx.Remove(prod);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto> ();
            
            using(TaskFerramenta030424Context ctx = new TaskFerramenta030424Context())
            {
                elenco = ctx.Prodottos.ToList();
            }
            return elenco;
        }

        public Prodotto? GetById(int id)
        {
            Prodotto? prod = null;

            using(TaskFerramenta030424Context ctx = new TaskFerramenta030424Context())
            {
                prod = ctx.Prodottos.FirstOrDefault(p => p.ProdottoId == id);
            }
            return prod;
        }

        public bool Insert(Prodotto t)
        {
            bool risultato = false;

            using(TaskFerramenta030424Context ctx = new TaskFerramenta030424Context ())
            {
                try
                {
                    ctx.Prodottos.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

            }
            return risultato;

        }

        public bool Update(Prodotto t)
        {
            bool risultato = false;

            using (TaskFerramenta030424Context ctx = new TaskFerramenta030424Context())
            {
                try
                {
                    Prodotto temp = ctx.Prodottos.Single(p => p.Codice == t.Codice);

                    //t.ProdottoId = temp.ProdottoId;
                    //t.Codice = temp.Codice;
                    //t.Nome = t.Nome is not null ? temp.Nome : t.Nome;
                    //t.Descrizione = t.Descrizione is not null ? temp.Descrizione : t.Descrizione;
                    //t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    //t.Quantita = t.Quantita is null ? temp.Quantita : t.Quantita;
                    //t.Categoria = t.Categoria is not null ? t.Categoria : temp.Categoria;
                    //t.DataCreazione = temp.DataCreazione;

                    t.ProdottoId = temp.ProdottoId;
                    t.Codice = temp.Codice;
                    t.Nome = t.Nome is not null ? t.Nome : temp.Nome;
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : temp.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    t.Quantita = t.Quantita is null ? temp.Quantita : t.Quantita;
                    t.Categoria = t.Categoria is not null ? t.Categoria : temp.Categoria;
                    t.DataCreazione = temp.DataCreazione;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                return risultato;
        }

        public Prodotto? GetByCodice(string codice)
        {
            Prodotto? prod = null;

            using (TaskFerramenta030424Context ctx = new TaskFerramenta030424Context())
            {
                prod = ctx.Prodottos.FirstOrDefault(p => p.Codice == codice);
            }
            return prod;
        }
    }
}
