using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.IServices;
using TCCarShare.Models;

namespace TCCarShare.Services
{
    public class CarServices : IServices<Car>
    {
        private readonly DataContext _context;

        public CarServices(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Car.ToList();
        }

        public Car GetById(int id)
        {
            return _context.Car.Find(id);
        }

        public Car Add(Car newModel)
        {
            _context.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }
    }
}
