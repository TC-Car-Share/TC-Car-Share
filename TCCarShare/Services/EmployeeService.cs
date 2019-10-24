using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.IServices;
using TCCarShare.Models;

namespace TCCarShare.Services
{
    public class EmployeeService : IEmployeeService<Employee>
    {
           
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public Employee Add(Employee newModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id)
        {
            return _context.Employee.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool SwithRole(int id,int role)
        {
            var model = new Employee() { id = id, empRole = role };
            _context.Employee.Attach(model);
            _context.Entry(model).Property(x => x.empRole).IsModified = true;
            return _context.SaveChanges() > 0;
        }
    }
}
