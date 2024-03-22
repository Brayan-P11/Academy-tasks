using Task_eventi_220324.Models;

namespace Task_eventi_220324.DAL
{
    internal class EventoDAL : IDAL<Evento>
    {

        private static EventoDAL? istanza;

        public static EventoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new EventoDAL();

            return istanza;
        }

        private EventoDAL() { }

        public bool Delete(Evento t)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Evento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Evento t)
        {
            bool risultato = false;
            using (var ev = new TaskEvento220324Context())
            {

            }
        }

        public bool Update(Evento t)
        {
            throw new NotImplementedException();
        }
    }



        
    }
}
