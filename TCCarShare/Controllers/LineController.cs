using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.IService;
using TCCarShare.Models;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public class LineController
    {
        private readonly ILineService<Line> _repository;

        public LineController(ILineService<Line> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetLineListByEmpId")]
        public string GetLineListByEmpId(int empId)
        {
            var result = _repository.GetLineListByEmpId(empId);
            if(result != null){
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new List<Line>());
        }

        [HttpPost("AddLine")]
        public string AddLine(Line line)
        {            
            var result = _repository.Add(line);
            return JsonConvert.SerializeObject(result);
        }
    }
}
