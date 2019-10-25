using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class EditCarInfoRequest 
    {
        /// <summary>
        /// 车辆Id
        /// </summary>
        public string id { get; set; }
        
        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNo { get; set; }

        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string carColor { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        public string carType { get; set; }

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public string carBrand { get; set; }

        /// <summary>
        /// 车辆座位数
        /// </summary>
        public string carSeatNum { get; set; }

        /// <summary>
        /// 驾驶证照片
        /// </summary>
        public string carLicenseImg { get; set; }

        /// <summary>
        /// 车主ID
        /// </summary>
        public string carMasterId { get; set; }
    }
}
