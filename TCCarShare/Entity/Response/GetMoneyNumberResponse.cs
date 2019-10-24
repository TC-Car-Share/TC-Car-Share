using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Response
{
    /// <summary>
    /// 获取路线金额返回实体
    /// </summary>
    public class GetMoneyNumberResponse: CommonBaseInfo
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
    }
}
