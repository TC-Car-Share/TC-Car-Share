using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TC.ZBY.FrameworkCore.Utility;
using TCCarShare.Data;
using TCCarShare.Entity.Request;
using TCCarShare.Models;
using TCCarShare.Services;
using Microsoft.EntityFrameworkCore;
using TCCarShare.Entity.Response;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderServices _services;
        private readonly DataContext _context;

        public OrderController(OrderServices services, DataContext context)
        {
            _services = services;
            _context = context;
        }

        [HttpPost("AddOrder")]
        public ActionResult<string> AddOrder(AddOrderRequest request)
        {
            var resp = new CommonBaseInfo();
            #region 参数验证
            #endregion
            var startLocation = request.startLat.ToString() + "," + request.startLon.ToString();
            var endLocation = request.endLat.ToString() + "," + request.endLon.ToString();
            var driveInfo = new MapServices().GetDrivingInfo(new GetDrivingInfoResquest {
                FromLocation = startLocation,
                ToLocation = endLocation
            });
            Order order = new Order
            {
                passengerId = request.passengerId.PackInt(),
                startLon = Convert.ToDouble(request.startLon),
                startLat = Convert.ToDouble(request.startLat),
                endLon = Convert.ToDouble(request.endLon),
                endLat = Convert.ToDouble(request.endLat),
                startPoint = request.startPoint,
                endPoint = request.endPoint,
                status = 0,
                createTime = DateTime.Now,
                passengerNum = request.passengerNum.PackInt(),
                startDateTime = request.startDateTime.PackDateTime(),
                orderAmount = driveInfo.result.routes.FirstOrDefault().taxi_fare.fare
            };

            _services.Add(order);
            resp.ResultMsg = "发布成功";
            resp.StateCode = 200;
            return JsonConvert.SerializeObject(resp);
        }

        [HttpPost("EditOrderStatus")]
        public ActionResult<string> EditOrderStatus(EditOrderRequest request)
        {
            var resp = new CommonBaseInfo();
            #region 参数验证
            #endregion
            
            var order = _context.Order.Where(m=>m.id = request.id.PackInt())
            {
                id = request.id.PackInt(),
                driverId = request.driverId.PackInt(),
                status = request.status.PackInt()
            };

            var entry = _context.Entry(order);
            entry.State = EntityState.Unchanged;
            if (order.driverId > 0)
            {
                if(new OrderServices().GetAllPassengerNum(order.driverId) + )
                entry.Property("driverId").IsModified = true;
            }
            entry.Property("status").IsModified = true;
            var result = _context.SaveChanges() > 0;
            if (result)
            {
                resp.ResultMsg = "修改成功";
                resp.StateCode = 200;
            }
            else
            {
                resp.ResultMsg = "修改失败";
                resp.StateCode = 400;
            }
            return JsonConvert.SerializeObject(resp);
        }

        [HttpPost("MyOrderList")]
        public ActionResult<MyOrderListResponse> MyOrderList(MyOrderListRequest request)
        {
            var resp = new MyOrderListResponse();
            #region 参数验证
            #endregion
            var passengerId = request.passengerId.PackInt();
            List<Order> orders = _context.Order.Where(m => m.passengerId == passengerId).ToList();
            foreach (var item in orders)
            {
                var orderDetail = new OrderDetail();
                if (item.driverId > 0)
                {
                    Employee employee = _context.Employee.Find(item.driverId);
                    if (employee != null)
                    {
                        orderDetail.sex = employee.sex.ToString();
                        orderDetail.orderNum = new Random(1).Next(5, 30).ToString();
                        orderDetail.rate = (new Random().NextDouble() * 5).ToString();
                    }
                    Car car = _context.Car.Where(m => m.carMasterId == item.driverId).FirstOrDefault();
                    if (car != null)
                    {
                        orderDetail.carBrand = car.carBrand;
                    }
                }
                orderDetail.status = item.status.ToString();
                orderDetail.startDateTime = item.startDateTime.ToString();
                orderDetail.startPoint = item.startPoint;
                orderDetail.passengerNum = item.passengerNum.ToString();
                orderDetail.orderAmount = item.orderAmount.ToString();
                resp.list.Add(orderDetail);
            }
            return resp;
        }
    }
}