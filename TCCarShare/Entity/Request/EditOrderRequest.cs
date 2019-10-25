using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class EditOrderRequest
    {

        /// <summary>
        /// 订单ID
        /// </summary>
        public string id { get; set; }

        public string driverId { get; set; }
        public string status { get; set; }
    }
}