using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.IServices;

namespace TCCarShare.IService
{
    public interface ILineService<T> : IServices<T> where T : class
    {
        IEnumerable<T> GetLineListByEmpId(int empId);

        bool DeleteLineByEmpId(int empId);
    }
}
