using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class AddOrderRequest
    {
        public string passengerId { get; set; }
        /// <summary>
        /// 始发地经度
        /// </summary>
        public string startLon { get; set; }
        /// <summary>
        /// 始发地纬度
        /// </summary>
        public string startLat { get; set; }
        public string endLon { get; set; }
        public string endLat { get; set; }
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public string passengerNum { get; set; }
        public string startDateTime { get; set; }
        public string sex { get; set; } = "-1";
        
    }
}