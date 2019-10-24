using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Models.Response
{
    /// <summary>
    /// 关键词输入提示返回实体
    /// </summary>
    public class Suggestion
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
        public List<SuggestionDate> data { get; set; } = new List<SuggestionDate>();
    }

    /// <summary>
    /// 关键词输入提示返回实体
    /// </summary>
    public class SuggestionDate
    {
        /// <summary>
        /// 提示文字
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// POI类型，值说明：0:普通POI / 1:公交车站 / 2:地铁站 / 3:公交线路 / 4:行政区划
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 返回定位坐标到各POI的距离
        /// </summary>
        public decimal _distance { get; set; }

        /// <summary>
        /// 经纬度坐标
        /// </summary>
        public SuggestionLocationBaseInfo location { get; set; }
    }

    /// <summary>
    /// 经纬度坐标
    /// </summary>
    public class SuggestionLocationBaseInfo
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

    /// <summary>
    /// 关键词输入提示返回实体
    /// </summary>
    public class GetSuggestionListResponse : CommonBaseInfo
    {
        /// <summary>
        /// 关键词输入提示返回实体
        /// </summary>
        public List<SuggestionList> List { get; set; } = new List<SuggestionList>();
    }

    /// <summary>
    /// 关键词输入提示返回实体
    /// </summary>
    public class SuggestionList
    {
        /// <summary>
        /// 提示文字
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// POI类型，值说明：0:普通POI / 1:公交车站 / 2:地铁站 / 3:公交线路 / 4:行政区划
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 返回定位坐标到各POI的距离
        /// </summary>
        public decimal Distance { get; set; }

        /// <summary>
        /// 经纬度坐标
        /// </summary>
        public LocationBaseInfo Location { get; set; }
    }

    /// <summary>
    /// 经纬度坐标
    /// </summary>
    public class LocationBaseInfo
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }
    }
}
