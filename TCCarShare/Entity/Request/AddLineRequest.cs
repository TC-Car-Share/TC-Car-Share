using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Entity.Request
{
    public class AddLineRequest
    {
        /// <summary>
        /// 起始经纬度
        /// </summary>
        public string origin { get; set; }

        /// <summary>
        /// 目的地经纬度
        /// </summary>
        public string destination { get; set; }

        /// <summary>
        /// 起始地名称
        /// </summary>

        public string startPoint { get; set; }
        
        /// <summary>
        /// 目的地名称
        /// </summary>
        public string endPoint { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
        public string workTime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        public string overTime { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        public int empId { get; set; }

    }
}
