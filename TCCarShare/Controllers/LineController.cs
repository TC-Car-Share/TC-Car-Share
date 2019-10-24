using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Entity.Request;
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
            res.StateCode = 200;
            res.ResultMsg = "no data";
            if (result != null && result.Any() == true){
                Line workLine = result.FirstOrDefault(r => r.name == "上班路线");
                Line overLine = result.FirstOrDefault(r => r.name == "下班路线");
                res.empId = empId;
                res.origin = workLine.origin;
                res.destination = workLine.destination;
                res.startPoint = workLine.startPoint;
                res.endPoint = workLine.endPoint;
                res.workTime = workLine.takeTime;
                res.overTime = overLine.takeTime;
                res.LineList = result.ToList();
            }
            return JsonConvert.SerializeObject(res);
        }

        [HttpPost("AddLine")]
        public string AddLine([FromBody] AddLineRequest request)
        {
            
            CommonBaseInfo res = new CommonBaseInfo();
            if (request.empId <= 0)
            {
                res.StateCode = 500;
                res.ResultMsg = "empId必须大于0";
                return JsonConvert.SerializeObject(res);
            }
            _repository.DeleteLineByEmpId(request.empId);
            Line workLine = new Line()
            {
                name = "上班路线",
                empId = request.empId,
                origin = request.origin,
                destination = request.destination,
                publishTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                takeTime = request.workTime,
                startPoint = request.startPoint,
                endPoint = request.endPoint
            };
            Line overLine = new Line()
            {
                name = "下班路线",
                empId = request.empId,
                origin = request.destination,
                destination = request.origin,
                publishTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                takeTime = request.overTime,
                startPoint = request.endPoint,
                endPoint = request.startPoint
            };
         
            _repository.Add(workLine);
            _repository.Add(overLine);
            res.StateCode = 200;
            res.ResultMsg = "success";
            return JsonConvert.SerializeObject(res);
        }
    }
}
