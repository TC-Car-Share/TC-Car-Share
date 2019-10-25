using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class AddOrderRequest
    {
        /// <summary>
        /// 乘客ID
        /// </summary>
        public string passengerId { get; set; }
        /// <summary>
        /// 始发地经度
        /// </summary>
        public string startLon { get; set; }
        /// <summary>
        /// 始发地纬度
        /// </summary>
        public string startLat { get; set; }

        /// <summary>
        /// 目的地经度
        /// </summary>
        public string endLon { get; set; }
        
        /// <summary>
        /// 目的地纬度
        /// </summary>
        public string endLat { get; set; }

        /// <summary>
        /// 始发地
        /// </summary>
        public string startPoint { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        public string endPoint { get; set; }

        /// <summary>
        /// 乘客人数
        /// </summary>
        public string passengerNum { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public string startDateTime { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; } = "-1";
        
    }
}