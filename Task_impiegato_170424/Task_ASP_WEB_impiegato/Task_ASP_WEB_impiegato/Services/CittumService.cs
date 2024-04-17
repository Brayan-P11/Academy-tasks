using Task_ASP_WEB_impiegato.Models;
using Task_ASP_WEB_impiegato.Repositories;

namespace Task_ASP_WEB_impiegato.Services
{
    public class CittumService
    {
        private readonly CittumRepository _repository;
        public CittumService(CittumRepository repository)
        {
            _repository = repository;
        }

        public List<Cittum> ElencoTutteCitta()
        {
            return _repository.GetAll();
        }

        public bool InserisciCitta(Cittum cit)
        {
            return _repository.Insert(cit);
        }

        public Cittum? RicercaCittaPerID(int varID)
        {
            return _repository.GetById(varID);
        }

        public bool EliminaCittaPerID(int varID)
        {
            Cittum? citTemp = _repository.GetById(varID);
            if (citTemp == null)
                return false;

            return _repository.Delete(citTemp.CittaId);
        }

        public bool ModificaCitta(Cittum vecchio, Cittum nuovo)
        {
            vecchio.Nome = nuovo.Nome;
            return _repository.Update(vecchio);
        }
    }
}
