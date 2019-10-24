using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.Models;

namespace TCCarShare.Services
{
    public class EFCoreServices : IServices<car>
    {
        private readonly DataContext _context;

        public EFCoreServices(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<car> GetAll()
        {
            return _context.Car.ToList();
        }

        public car GetById(int id)
        {
            return _context.Car.Find(id);
        }

        public car Add(car newModel)
        {
            _context.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }
    }
}
