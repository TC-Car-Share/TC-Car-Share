using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Models
{
    public class CommonBaseInfo
    {
        /// <summary>
        /// 状态码 200表示成功
        /// </summary>
        public int StateCode { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        public string ResultMsg { get; set; }
    }
}
