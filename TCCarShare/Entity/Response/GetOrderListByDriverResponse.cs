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
        public List<OrderListByDriver> OrderList { get; set; } = new List<OrderListByDriver>();
    }

    /// <summary>
    /// 司机获取订单列表返回实体
    /// </summary>
    public class OrderListByDriver
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 0-研发,1-运营，2-产品，3-商务，4-客服，5-设计
        /// </summary>
        public string EmpStation { get; set; }

        /// <summary>
        /// 是否单身0 ：否 1：是
        /// </summary>
        public int IsSingle { get; set; }

        /// <summary>
        /// 性别 0：男 1：女
        /// </summary>
        public int SexType { get; set; }

        /// <summary>
        /// 出发日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int PeopleCount { get; set; }

        /// <summary>
        /// 金钱
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 出发地址
        /// </summary>
        public string FromPlace { get; set; }

        /// <summary>
        /// 到达地址
        /// </summary>
        public string ToPlace { get; set; }

        /// <summary>
        /// 相似度
        /// </summary>
        public decimal Percent { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
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
