using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCarShare.Models;
using TCCarShare.Services;
using Newtonsoft.Json;
using TCCarShare.IServices;

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
            var result = _repository.GetById(id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("SwitchRole")]
        public string SwitchRole(int id,int role)
        {
            var result = _repository.SwithRole(id, role);
            return JsonConvert.SerializeObject(result);
        }
    }
}
