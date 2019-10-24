using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Entity.Request
{
    /// <summary>
    /// 计算金额接口请求实体
    /// </summary>
    public class GetMoneyNumberResquest
    {
        /// <summary>
        /// 起点经纬度
        /// </summary>
        public string FromLocation { get; set; }

        /// <summary>
        /// 目的地经纬度
        /// </summary>
        public string ToLocation { get; set; }
    }
}
