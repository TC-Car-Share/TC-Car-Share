using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCCarShare.Models;

namespace TCCarShare.Controllers
{
    public partial class CarController : Controller
    {
        [HttpPost("GetCarInfoList")]
        public string GetCarInfoList()
        {
            var result = new Car { id = 1, carNo = "3123213" };
            return JsonConvert.SerializeObject(result);
            
        }
    }
}