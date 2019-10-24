using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;
using TCCarShare.Models.Response;

namespace TCCarShare.Entity.Response
{
    /// <summary>
    /// 逆地址解析返回实体
    /// </summary>
    public class GeocoderResponse: CommonBaseInfo
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Lat { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Lng { get; set; }
    }

    /// <summary>
    /// 逆地址解析
    /// </summary>
    public class Geocoder
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
        /// 响应数据
        /// </summary>
        public GeocoderResult result { get; set; }
    }

    /// <summary>
    /// 逆地址解析响应数据
    /// </summary>
    public class GeocoderResult
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 经纬度坐标
        /// </summary>
        public SuggestionLocationBaseInfo location { get; set; }
    }
}
