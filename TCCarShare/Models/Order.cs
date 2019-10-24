using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Models
{
    public class Order
    {
        public int id { get; set; }
        public int passengerId { get; set; }
        public int driverId { get; set; }
        public double startLon { get; set; }
        public double startLat { get; set; }
        public double endLon { get; set; }
        public double endLat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        public DateTime createTime { get; set; }
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public int passengerNum { get; set; }
        public DateTime startDateTime { get; set; }
        public decimal orderAmount { get; set; }
        public decimal similarity { get; set; }
    }
}
