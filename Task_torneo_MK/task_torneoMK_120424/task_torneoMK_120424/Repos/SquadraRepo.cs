using task_torneoMK_120424.Models;

namespace task_torneoMK_120424.Repos
{
    public class SquadraRepo : IRepo<Squadra>
    {
        // INJECTION context nella repo
        private readonly TorneoContext _context;
        public SquadraRepo(TorneoContext context)
        {
            _context = context;
        }
        public bool Create(Squadra entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Squadra? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadre.ToList();
        }

        public bool Update(Squadra entity)
        {
            throw new NotImplementedException();
        }
    }
}
