using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Response
{
    /// <summary>
    /// 司机获取订单列表返回实体
    /// </summary>
    public class GetOrderListByDriverResponse : CommonBaseInfo
    {

    }

    /// <summary>
    /// 司机获取订单列表返回实体
    /// </summary>
    public class OrderListByDriver
    {

    }

    /// <summary>
    /// 距离计算返回实体
    /// </summary>
    public class Distance
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
        public DistanceResult result { get; set; }
    }

    /// <summary>
    /// 搜索结果
    /// </summary>
    public class DistanceResult
    {
        /// <summary>
        /// 结果数组
        /// </summary>
        public List<Elements> elements { get; set; }
    }

    /// <summary>
    /// 结果数组
    /// </summary>
    public class Elements
    {
        /// <summary>
        /// 终点坐标
        /// </summary>
        public ToObject to { get; set; }

        /// <summary>
        /// 距离
        /// </summary>
        public decimal distance { get; set; }
    }

    /// <summary>
    /// 终点坐标
    /// </summary>
    public class ToObject
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double lng { get; set; }
    }
}
