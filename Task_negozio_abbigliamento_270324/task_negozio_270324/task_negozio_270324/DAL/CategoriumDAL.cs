using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_negozio_270324.Models;

namespace task_negozio_270324.DAL
{
    class CategoriumDAL : IDAL<Categorium>
    {
        private static CategoriumDAL? instance;
        public static CategoriumDAL GetIstance()
        {
            if (instance == null)
                instance = new CategoriumDAL();
            return instance;
        }
        private CategoriumDAL() { }
       
        public bool DeleteById(int id)
        {
            bool risultato = false;
            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    Categorium tmpCat = ctx.Categoria.Single(c => c.CategoriaId == id);
                    ctx.Categoria.Remove(tmpCat);
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

        public List<Categorium> GetAll()
        {
            List<Categorium> elenco = new List<Categorium>();

            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    elenco = ctx.Categoria.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return elenco;
        }

        public Categorium GetById(int id)
        {

            Categorium prodotto = new Categorium();
            using (TaskNegozio270324Context ctx = new TaskNegozio270324Context())
            {
                try
                {
                    prodotto = ctx.Categoria.Single(c => c.CategoriaId == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return prodotto;
        }

        public bool Insert(Categorium t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categorium t)
        {
            throw new NotImplementedException();
        }

        
    }
}
