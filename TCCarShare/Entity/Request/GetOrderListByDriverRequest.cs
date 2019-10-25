using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Entity.Request
{
    /// <summary>
    /// 司机获取订单列表请求实体
    /// </summary>
    public class GetOrderListByDriverRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 出发地经纬度
        /// </summary>
        public string FromLat { get; set; }

        /// <summary>
        /// 出发地经纬度
        /// </summary>
        public string FromLng { get; set; }

        /// <summary>
        /// 目的地经纬度
        /// </summary>
        public string ToLat { get; set; }

        /// <summary>
        /// 目的地经纬度
        /// </summary>
        public string ToLng { get; set; }

        /// <summary>
        /// 是否单身0 ：否 1：是
        /// </summary>
        public int IsSingle { get; set; }

        /// <summary>
        /// 性别 0：男 1：女
        /// </summary>
        public int SexType { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
    }
}
