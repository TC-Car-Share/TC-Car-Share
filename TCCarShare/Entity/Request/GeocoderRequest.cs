using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Entity.Request
{
    /// <summary>
    /// 逆地址解析请求实体
    /// </summary>
    public class GeocoderRequest
    {
        /// <summary>
        /// 用户定位坐标 例如：39.11457,116.55332
        /// </summary>
        public string Location { get; set; }
    }
}
