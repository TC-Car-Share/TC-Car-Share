using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Models.Request
{
    /// <summary>
    /// 关键词输入提示请求实体
    /// </summary>
    public class GetSuggestionListRequest
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 用户定位坐标 例如：39.11457,116.55332
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 限制城市范围
        /// </summary>
        public string Region { get; set; } = "苏州市";
    }
}
