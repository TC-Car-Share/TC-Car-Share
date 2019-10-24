using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCCarShare.Data;
using TCCarShare.Entity.Request;
using TCCarShare.Models;
using TCCarShare.Models.Request;
using TCCarShare.Services;

namespace TCCarShare.Controllers
{
    public partial class CarController: Controller
    {
        /// <summary>
        /// 关键词输入提示
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetSuggestionList")]
        public string GetSuggestionList([FromBody]GetSuggestionListRequest request)
        {
            var result = new MapServices(_context).GetSuggestionList(request);
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
            var result = new MapServices(_context).GetAddressBylnglat(request);
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
            var result = new MapServices(_context).GetMoneyNumber(request);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 司机选单列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetOrderListByDriver")]
        public string GetOrderListByDriver([FromBody]GetOrderListByDriverRequest request)
        {
            var result = new MapServices(_context).GetOrderListByDriver(request);
            return JsonConvert.SerializeObject(result);
        }
    }
}