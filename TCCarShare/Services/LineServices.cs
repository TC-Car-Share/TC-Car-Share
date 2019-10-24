using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.IServices;
using TCCarShare.Models;

namespace TCCarShare.Services
{
    public class LineService : IServices<Line>
    {
        private readonly DataContext _context;

        public LineService(DataContext context)
        {
            _context = context;
        }

        public Line Add(Line newModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAll()
        {
            throw new NotImplementedException();
        }

        public Line GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
