using task_torneoMK_120424.Models;

namespace task_torneoMK_120424.Repos
{
    public class UtenteRepo : IRepo<Utente>
    {

        // INJECTION del context dentro alla REPO
        private readonly TorneoContext _context;

        public UtenteRepo(TorneoContext context)
        {
            _context = context;
        }

        public bool Create(Utente entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Utente? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utenti.ToList();
        }

        public bool Update(Utente entity)
        {
            throw new NotImplementedException();
        }
    }
}
