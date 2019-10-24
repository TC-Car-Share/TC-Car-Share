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
        public string startLon { get; set; }
        public string startLat { get; set; }
        public string endLon { get; set; }
        public string endLat { get; set; }
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public string passengerNum { get; set; }
        public string startDateTime { get; set; }
    }
}