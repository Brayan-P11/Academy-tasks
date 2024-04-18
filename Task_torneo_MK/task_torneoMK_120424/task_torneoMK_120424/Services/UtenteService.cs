using task_torneoMK_120424.DTO;
using task_torneoMK_120424.Models;
using task_torneoMK_120424.Repos;

namespace task_torneoMK_120424.Services
{
    public class UtenteService : IService<Utente>
    {
        // INJECTION 1
        private readonly IRepo<Utente> _repository;
        public UtenteService(IRepo<Utente> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Utente> PrendiliTutti()
        {
            return _repository.GetAll();
        }
        // END

        public List<UtenteDto> RestituisciTutti()
        {
            List<UtenteDto> elenco = this.PrendiliTutti().Select(u => new UtenteDto()
            {
                Cod = u.Codice,
                Nom = u.Nome,
            }).ToList();

            return elenco;
        }




        

    }
}
