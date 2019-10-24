using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCarShare.Models;
using TCCarShare.Services;
using Newtonsoft.Json;
using TCCarShare.IServices;
using TCCarShare.Entity.Response;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public class EmployeeController
    {
        private readonly IEmployeeService<Employee> _repository;

        public EmployeeController(IEmployeeService<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetEmployeeById")]
        public string GetEmployeeById(int id)
        {
            GetEmployeeByIdResponse res = new GetEmployeeByIdResponse();
            res.StateCode = 200;
            res.ResultMsg = "success";
            res.Employee = _repository.GetById(id) ?? new Employee();
            return JsonConvert.SerializeObject(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("SwitchRole")]
        public string SwitchRole(int id,int role)
        {
            CommonBaseInfo res = new CommonBaseInfo();
            res.StateCode = 200;
            res.ResultMsg = "success";
            var result = _repository.SwithRole(id, role);
            if(result == false)
            {
                res.StateCode = 500;
                res.ResultMsg = "error";
            }
            return JsonConvert.SerializeObject(res);
        }
    }
}
