using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class WaitingOrderRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; } = -1;
        /// <summary>
        /// 是否单身
        /// </summary>
        public int isSingle { get; set; } = -1;
        /// <summary>
        /// 出发日期
        /// </summary>
        public string startDate { get; set; } = "";

    }
}