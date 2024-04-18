using task_torneoMK_120424.DTO;
using task_torneoMK_120424.Models;
using task_torneoMK_120424.Repos;

namespace task_torneoMK_120424.Services
{
    public class SquadraService : IService<Squadra>
    {
        //INJECTION repo nel service
        private readonly IRepo<Squadra> _repository;
        public SquadraService(IRepo<Squadra> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Squadra> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<SquadraDto> RestituisciTutti() 
        {
            List<SquadraDto> elenco = this.PrendiliTutti().Select(s => new SquadraDto()
            {
                Cod = s.Codice,
                Nom = s.Nome,
                Cre = s.CreditoIniz
            }).ToList();

            return elenco;
        }


    }
}
