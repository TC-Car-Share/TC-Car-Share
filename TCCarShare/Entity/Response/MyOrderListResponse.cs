using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Response
{
    public class MyOrderListResponse : CommonBaseInfo
    {
        public List<OrderDetail> list { get; set; } = new List<OrderDetail>();
    }
    public class OrderDetail
    {
        public string id { get; set; } = string.Empty;
        public string driverId { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string startPoint { get; set; } = string.Empty;
        public string endPoint { get; set; } = string.Empty;
        public string passengerNum { get; set; } = string.Empty;
        public string startDateTime { get; set; } = string.Empty;
        public string sex { get; set; } = string.Empty;
        public string isSingle { get; set; } = string.Empty;
        public string carBrand { get; set; } = string.Empty;
        public string orderNum { get; set; } = string.Empty;
        public string rate { get; set; } = string.Empty;
        public string orderAmount { get; set; } = string.Empty;
        public string passengerName { get; set; } = string.Empty;
        public string passengerEmployRole { get; set; } = string.Empty;
        public string driverName { get; set; } = string.Empty;
        public string driverEmployRole { get; set; } = string.Empty;

    }
}