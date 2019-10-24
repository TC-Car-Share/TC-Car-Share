using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Entity.Response
{
    /// <summary>
    /// 路线规划服务
    /// </summary>
    public class GetDrivingInfoResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 状态说明
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 搜索结果
        /// </summary>
        public DrivingResult result { get; set; }
    }

    /// <summary>
    /// 搜索结果
    /// </summary>
    public class DrivingResult
    {
        /// <summary>
        /// 路线方案
        /// </summary>
        public List<Routes> routes { get; set; }
    }

    /// <summary>
    /// 路线方案
    /// </summary>
    public class Routes
    {
        /// <summary>
        /// 方案总距离
        /// </summary>
        public decimal distance { get; set; }

        /// <summary>
        /// 打车费用
        /// </summary>
        public TaxiFare taxi_fare { get; set; }

        /// <summary>
        /// 方案路线坐标点串（该点串经过压缩，解压请参考：polyline 坐标解压）
        /// </summary>
        public List<decimal> polyline { get; set; }
    }

    /// <summary>
    /// 打车费用
    /// </summary>
    public class TaxiFare
    {
        /// <summary>
        /// 打车费用
        /// </summary>
        public decimal fare { get; set; }
    }
}
