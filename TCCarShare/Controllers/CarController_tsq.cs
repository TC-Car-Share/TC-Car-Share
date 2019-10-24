using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCCarShare.Entity.Request;
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

        /// <summary>
        /// 逆地址解析
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetAddressBylnglat")]
        public string GetAddressBylnglat([FromBody]GeocoderRequest request)
        {
            var result = new MapServices().GetAddressBylnglat(request);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取路线金额
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetMoneyNumber")]
        public string GetMoneyNumber([FromBody]GetMoneyNumberResquest request)
        {
            var result = new MapServices().GetMoneyNumber(request);
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost("GetlatlngInfoList")]
        public string GetlatlngInfoList()
        {
            var aaa = new List<double>() {                
    31.252097,
    120.730546,
    159,
    -89,
    0,
    0,
    324,
    903};
            var result = new MapServices().GetCanTakeitResult(aaa);
            return JsonConvert.SerializeObject(result);
        }
    }
}