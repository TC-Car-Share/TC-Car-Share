using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TCCarShare.IServices;
using TCCarShare.Entity.Request;
using TCCarShare.Entity.Response;
using TCCarShare.Models;
using TCCarShare.Services;
using TC.ZBY.FrameworkCore.Utility;
using TCCarShare.Data;
using TCCarShare.Models.Request;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public partial class CarController : Controller
    {
        private readonly CarServices _repository;
        private readonly DataContext _context;

        public CarController(CarServices repository, DataContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet("GetCarInfoByEmpId")]
        public string GetCarInfoByEmpId(int empId)
        {
            GetCarInfoByEmpIdResponse res = new GetCarInfoByEmpIdResponse();
            res.ResultMsg = "success";
            res.StateCode = 200;
            res.Car = _repository.GetByEmpId(empId) ?? new Car();
            if(res.Car == null || res.Car.id<=0)
            {
                res.ResultMsg = "no data";
                res.StateCode = 200;                
            }
            return JsonConvert.SerializeObject(res);
        }

        [HttpPost("EditCarInfo")]
        public string EditCarInfo([FromBody]EditCarInfoRequest request)
        {
            var result = new CommonBaseInfo();
            if (request.id.PackInt() > 0)
            {
                var model = _repository.GetById(request.id.PackInt());
                if (model == null)
                {
                    result.ResultMsg = "未查询到车辆信息";
                    result.StateCode = 404;
                    return JsonConvert.SerializeObject(result);
                }
                Car newCar = new Car
                {
                    id = Convert.ToInt32(request.id),
                    carBrand = request.carBrand,
                    carColor = request.carColor,
                    carLicenseImg = request.carLicenseImg,
                    carMasterId = request.carMasterId.PackInt(),
                    carNo = request.carNo,
                    carSeatNum = request.carSeatNum.PackInt(),
                    carType = request.carType.PackInt()
                };
                var update = _repository.Edit(newCar);
                if(update)
                {
                    result.ResultMsg = "编辑成功";
                    result.StateCode = 200;
                }
            }
            else
            {
                Car newCar = new Car
                {
                    carBrand = request.carBrand,
                    carColor = request.carColor,
                    carLicenseImg = request.carLicenseImg,
                    carMasterId = request.carMasterId.PackInt(),
                    carNo = request.carNo,
                    carSeatNum = request.carSeatNum.PackInt(),
                    carType = request.carType.PackInt()
                };
                var add = _repository.Add(newCar);
                if (add == null)
                {
                    result.ResultMsg = "新增失败";
                    result.StateCode = 201;
                    return JsonConvert.SerializeObject(result);
                }
                result.ResultMsg = "新增成功";
                result.StateCode = 200;
            }
            return JsonConvert.SerializeObject(result);
        }

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