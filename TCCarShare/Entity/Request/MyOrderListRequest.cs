using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class MyOrderListRequest
    {
        /// <summary>
        /// 乘车人ID
        /// </summary>
        public string passengerId { get; set; }

        /// <summary>
        /// 车主ID
        /// </summary>
        public string driverId { get; set; }

        /// <summary>
        /// 订单状态：-1-全部，0-待接单，1-已接单、2-乘客已确认、3-进行中、4-已完成、5-已点评、6-取消
        /// </summary>

        public string status { get; set; } = "-1";
    }
}