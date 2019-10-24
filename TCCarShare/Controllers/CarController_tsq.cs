using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCCarShare.Models;
using TCCarShare.Models.Request;
using TCCarShare.Services;

namespace TCCarShare.Controllers
{
    public partial class CarController
    {
        /// <summary>
        /// 关键词输入提示
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetSuggestionList")]
        public string GetSuggestionList([FromBody]GetSuggestionListRequest request)
        {
            var result = new MapServices().GetSuggestionList(request);
            return JsonConvert.SerializeObject(result);
        }


    }
}