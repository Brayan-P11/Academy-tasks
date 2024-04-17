using Task_ASP_WEB_impiegato.Models;

namespace Task_ASP_WEB_impiegato.Repositories
{
    public class CittumRepository : IRepository<Cittum>
    {

        private readonly TaskImpiegatoContext _context;
        public CittumRepository (TaskImpiegatoContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                Cittum? citTemp = _context.Cittas.Single(c => c.CittaId == id);
                _context.Cittas.Remove(citTemp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Cittum> GetAll()
        {
            return _context.Cittas.ToList();
        }

        public Cittum? GetById(int id)
        {
            Cittum? citTemp = null;
            try
            {
                citTemp = _context.Cittas.FirstOrDefault(p => p.CittaId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return citTemp;
        }


        public bool Insert(Cittum t)
        {
            try
            {
                _context.Cittas.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return false;
        }

        public bool Update(Cittum t)
        {
            try
            {
                _context.Cittas.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
