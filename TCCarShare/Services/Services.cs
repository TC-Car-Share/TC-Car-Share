using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Services
{
    public interface IServices<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T newModel);
    }
}
