using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_negozio_270324.DAL
{
    interface IDAL<T>
    {
        List<T> GetAll();
        bool Insert(T t);
        bool Update(T t);
        bool DeleteById(int id);
        T GetById(int id);




    }
}
