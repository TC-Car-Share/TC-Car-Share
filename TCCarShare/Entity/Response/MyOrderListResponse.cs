using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Response
{
    public class MyOrderListResponse : CommonBaseInfo
    {
        public List<OrderDetail> list { get; set; }
    }
    public class OrderDetail
    {
        public string id { get; set; }
        public string driverId { get; set; }
        public string status { get; set; }
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public string passengerNum { get; set; }
        public string startDateTime { get; set; }
        public string sex { get; set; }
        public string isSingle { get; set; }
        public string carBrand { get; set; }
        public string orderNum { get; set; }
        public string rate { get; set; }
        public string orderAmount { get; set; }
    }
}