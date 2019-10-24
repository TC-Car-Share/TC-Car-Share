using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCarShare.Models;
using TCCarShare.Services;
using Newtonsoft.Json;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public class EmployeeController
    {
        private readonly IServices<Employee> _repository;

        public EmployeeController(IServices<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetEmployeeById")]
        public string GetEmployeeById(int id)
        {
            var result = _repository.GetById(id);
            return JsonConvert.SerializeObject(result);

        }
    }
}
