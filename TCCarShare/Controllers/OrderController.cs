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
using TCCarShare.IServices;

namespace TCCarShare.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IServices<Order> _services;
        private readonly DataContext _context;

        public OrderController(OrderServices services, DataContext context)
        {
            _services = services;
            _context = context;
        }

        [HttpPost("AddOrder")]
        public ActionResult<string> AddOrder([FromBody]AddOrderRequest request)
        {
            var resp = new CommonBaseInfo();
            #region 参数验证
            #endregion
            var passengerId = request.passengerId.PackInt();
            var count = _context.Order.Where(m => m.startDateTime == request.startDateTime.PackDateTime()).Where(m => m.passengerId == passengerId).ToList().Count;
            if (count > 0)
            {
                resp.ResultMsg = "您已提交过相同订单，请勿重复提交";
                resp.StateCode = 400;
                return JsonConvert.SerializeObject(resp);
            }
            var startLocation = request.startLat.ToString() + "," + request.startLon.ToString();
            var endLocation = request.endLat.ToString() + "," + request.endLon.ToString();
            var driveInfo = new MapServices(_context).GetDrivingInfo(new GetDrivingInfoResquest {
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
                orderAmount = driveInfo.result.routes.FirstOrDefault().taxi_fare.fare,
                distance = driveInfo.result.routes.FirstOrDefault().distance,
                sex = request.sex.PackInt()
            };

            _services.Add(order);
            resp.ResultMsg = "发布成功";
            resp.StateCode = 200;
            return JsonConvert.SerializeObject(resp);
        }

        [HttpPost("EditOrderStatus")]
        public ActionResult<string> EditOrderStatus([FromBody]EditOrderRequest request)
        {
            var resp = new CommonBaseInfo();
            #region 参数验证
            #endregion

            var id = request.id.PackInt();
            var order = _context.Order.Where(m => m.id == id).FirstOrDefault();

            order.id = request.id.PackInt();
            order.status = request.status.PackInt();
            if (request.driverId.PackInt() > 0)
            {
                order.driverId = request.driverId.PackInt();
            }
            var entry = _context.Attach(order);
            entry.State = EntityState.Unchanged;
            if (request.driverId.PackInt() > 0)
            {
                if (new OrderServices(_context).GetAllPassengerNum(order.driverId) + order.passengerNum > 3)
                {
                    resp.ResultMsg = "您超过最大载客数，无法接单";
                    resp.StateCode = 200;
                }
                entry.Property(p=>p.driverId).IsModified = true;
            }
            //取消订单删除车主信息
            if (request.status.PackInt() == 0)
            {
                order.driverId = 0;
                entry.Property(p => p.driverId).IsModified = true;
            }
            entry.Property(p => p.status).IsModified = true;
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
        public ActionResult<MyOrderListResponse> MyOrderList([FromBody]MyOrderListRequest request)
        {
            var resp = new MyOrderListResponse();
            #region 参数验证
            #endregion
            var passengerId = request.passengerId.PackInt();
            var driverId = request.driverId.PackInt();
            List<Order> orders = new List<Order>();
            if (passengerId > 0)
            {
                orders = _context.Order.Where(m => m.passengerId == passengerId).ToList();
            }
            else if (driverId > 0)
            {
                orders = _context.Order.Where(m => m.driverId == driverId).ToList();
            }

            if (orders == null || orders.Count == 0)
            {
                resp.StateCode = 400;
                resp.ResultMsg = "未获取到对应订单信息";
                return resp;
            }

            if (request.status != "-1")
            {
                var status = request.status.PackInt();
                orders = orders.Where(m => m.status == status).ToList();
            }
            foreach (var item in orders)
            {
                var orderDetail = new OrderDetail();
                orderDetail.id = item.id.ToString();
                if (request.driverId.PackInt() > 0) //当前为司机订单
                {
                    Employee employee = _context.Employee.Find(item.passengerId);
                    if (employee != null)
                    {
                        orderDetail.passengerId = item.passengerId.ToString();
                        orderDetail.driverId = driverId.ToString();
                        orderDetail.passengerName = employee.name;
                        orderDetail.passengerEmployRole = employee.empRole.ToString();
                    }
                }
                else
                {
                    orderDetail.passengerId = request.passengerId.ToString();
                    Employee employee = _context.Employee.Find(item.driverId);
                    if (employee != null)
                    {
                        orderDetail.driverId = employee.id.ToString();
                        orderDetail.driverName = employee.name;
                        orderDetail.driverEmployStation = employee.empStation.ToString();
                    }
                }

                if (item.driverId > 0)
                {
                    Employee employee = _context.Employee.Find(item.driverId);
                    if (employee != null)
                    {
                        orderDetail.sex = employee.sex.ToString();
                        orderDetail.orderNum = new Random(1).Next(5, 30).ToString();
                        orderDetail.rate = ( new Random().NextDouble() * 5).ToString("#0.0");
                        
                    }
                    Car car = _context.Car.Where(m => m.carMasterId == item.driverId).FirstOrDefault();
                    if (car != null)
                    {
                        orderDetail.carBrand = car.carBrand;
                    }
                }
                else
                {
                    Employee employee = _context.Employee.Find(item.driverId);
                    if (employee != null)
                    {
                        orderDetail.sex = employee.sex.ToString();
                        orderDetail.orderNum = new Random(1).Next(5, 30).ToString();
                        orderDetail.rate = (new Random().NextDouble() * 5).ToString();
                    }
                }
                orderDetail.status = item.status.ToString();
                orderDetail.startDateTime = item.startDateTime.ToString();
                orderDetail.startPoint = item.startPoint;
                orderDetail.endPoint = item.endPoint;
                orderDetail.passengerNum = item.passengerNum.ToString();
                orderDetail.orderAmount = item.orderAmount.ToString();
                resp.list.Add(orderDetail);
            }
            resp.StateCode = 200;
            resp.ResultMsg = "获取成功";
            return resp;
        }
    }
}