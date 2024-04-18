using System.Runtime.ConstrainedExecution;
using task_torneoMK_120424.DTO;
using task_torneoMK_120424.Models;
using task_torneoMK_120424.Repos;

namespace task_torneoMK_120424.Services
{
    public class PersonaggioService : IService<Personaggio>
    {
        //INJECTION
        private readonly IRepo<Personaggio> _repository;
        public PersonaggioService(IRepo<Personaggio> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Personaggio> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        //Metodo per trasferire i dati in formato DTO
        public List<PersonaggioDto> RestituisciTutti()
        {
            List<PersonaggioDto> elenco = this.PrendiliTutti().Select(p => new PersonaggioDto()
            {
                Cod = p.Codice,
                Nom = p.Nome,
                Cos = p.Costo,
                Cat = p.Categoria,
                //SquadraDtoRifNavigation = ConvertSquadraToDto (p.SquadraRifNavigation)
            }).ToList();
            return elenco;
        }

        public bool InserisciPersonagggio(PersonaggioDto perDto)
        {
            Personaggio per = new Personaggio()
            {
                Codice = Guid.NewGuid().ToString().ToUpper(),
                Nome = perDto.Nom,
                Costo = perDto.Cos,
                Categoria = perDto.Cat
            };

            return _repository.Create(per);
        }

        #region funzioni per squadra

        public SquadraDto ConvertSquadraToDto(Squadra squadra)
        {
            SquadraDto s = new SquadraDto()
            {
                Cod = squadra.Codice,
                Nom = squadra.Nome,
                Cre = squadra.CreditoIniz
                
            };
            return s;
        }

        #endregion
    }
}
