using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.Models;

namespace TCCarShare.Services
{
    public class EFCoreServices : IServices<Car>
    {
        private readonly DataContext _context;

        public EFCoreServices(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Students.ToList();
        }

        public Car GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public Car Add(Car newModel)
        {
            _context.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }
    }
}
