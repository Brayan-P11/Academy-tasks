using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_negozio_270324.Models;

namespace task_negozio_270324.DAL
{
    class ProdottoDAL : IDAL<Prodotto>
    {
        private static ProdottoDAL? istance;
        public static ProdottoDAL GetIstance()
        {
            if (istance == null)
                istance = new ProdottoDAL();
            return istance;
        }
        private ProdottoDAL() { }
        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    elenco = ctx.Prodottos.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return elenco;
        }

        public bool Insert(Prodotto t)
        {
            bool risulato = false;
            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    ctx.Prodottos.Add(t);
                    ctx.SaveChanges();
                    risulato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risulato;
        }

        public bool DeleteById(int id)
        {
            bool risultato = false;
            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    Prodotto tmpProd = ctx.Prodottos.Single(p => p.ProdottoId == id);
                    ctx.Prodottos.Remove(tmpProd);
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

        public Prodotto GetById(int id)
        {
            Prodotto prodotto = new Prodotto();
            using(TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    prodotto = ctx.Prodottos.Single(p => p.ProdottoId == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return prodotto;
        }

        public bool Update(Prodotto t)
        {
            bool risultato = false;
            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    Prodotto? tmpProd = ctx.Prodottos.FirstOrDefault(p => p.ProdottoId == t.ProdottoId);
                    if (tmpProd is not null)
                    {

                        ctx.Prodottos.Update(tmpProd);
                        ctx.SaveChanges();
                        risultato = true;
                    }
                    //risultato = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }
    }
}
