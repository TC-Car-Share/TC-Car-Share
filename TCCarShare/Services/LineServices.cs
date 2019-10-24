using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Data;
using TCCarShare.IService;
using TCCarShare.IServices;
using TCCarShare.Models;

namespace TCCarShare.Services
{
    public class LineService : ILineService<Line>
    {
        private readonly DataContext _context;

        public LineService(DataContext context)
        {
            _context = context;
        }

        public Line Add(Line newModel)
        {
            _context.Line.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public bool DeleteLineByEmpId(int empId)
        {
            var list = _context.Line.Where(p => p.empId == empId);
            if(list != null)
            {
                _context.RemoveRange(list);              
            }          
            return _context.SaveChanges() > 0;

        }

        public IEnumerable<Line> GetAll()
        {
            throw new NotImplementedException();
        }

        public Line GetById(int id)
        {
            return _context.Line.Find(id);
        }

        public IEnumerable<Line> GetLineListByEmpId(int empId)
        {
            return _context.Line.Where(l => l.empId == empId);
        }

    }
}
