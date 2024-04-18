using Microsoft.EntityFrameworkCore;
using task_torneoMK_120424.Models;

namespace task_torneoMK_120424.Repos
{
    public class PersonaggioRepo : IRepo<Personaggio>
    {
        private readonly TorneoContext _context;
        public PersonaggioRepo(TorneoContext context)
        {
            _context = context;
        }
        public bool Create(Personaggio entity)
        {
            try
            {
                _context.Personaggi.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                Personaggio? temp = Get(id);
                if (temp != null)
                {
                    _context.Personaggi.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public Personaggio? Get(int id)
        {
            return _context.Personaggi.Find(id);
        }

        public IEnumerable<Personaggio> GetAll()
        { // INCLUDE includi i dati della tabella collegata
          //return _context.Personaggi.Include(p => p.SquadraRifNavigation).ToList();

            return _context.Personaggi.ToList();
        }

        public bool Update(Personaggio entity)
        {
            try
            {
                _context.Personaggi.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }
    }
}
