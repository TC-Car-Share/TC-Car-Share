using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCCarShare.IServices;
using TCCarShare.Models;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public partial class CarController : Controller
    {
        private readonly IServices<Car> _repository;

        public CarController(IServices<Car> repository)
        {
            _repository = repository;
        }

        [HttpPost("GetCarInfo")]
        public string GetCarInfo()
        {
            var result = _repository.GetById(1);
            return JsonConvert.SerializeObject(result);
        }
    }
}