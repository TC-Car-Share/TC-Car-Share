using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Services;

namespace TCCarShare.IServices
{
    public interface IEmployeeService<T> : IServices<T> where T : class
    {
        bool SwithRole(int id, int role);
    }
}