using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Entity.Response;
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
            GetLineListByEmpIdResponse res = new GetLineListByEmpIdResponse();
            var result = _repository.GetLineListByEmpId(empId);
            res.LineList = new List<Line>();
            res.StateCode = 200;
            res.ResultMsg = "no data";
            if (result != null){
                res.LineList = result.ToList();            
                res.ResultMsg = "success";                
            }
            return JsonConvert.SerializeObject(res);
        }

        [HttpPost("AddLine")]
        public string AddLine([FromBody] Line line)
        {
            AddLineResponse res = new AddLineResponse();
            res.Line = _repository.Add(line);
            res.StateCode = 200;
            res.ResultMsg = "success";
            return JsonConvert.SerializeObject(res);
        }
    }
}
