using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.ViewModels
{
    public class WaitingOrder
    {
        public Order info { get; set; } = new Order();

        public ExtensionInfo extension { get; set; } = new ExtensionInfo();
    }

    public class ExtensionInfo
    {
        /// <summary>
        /// 0-研发,1-运营，2-产品，3-商务，4-客服，5-设计
        /// </summary>
        public int empStation { get; set; }
        public string isSingle { get; set; }

        public string passengerName { get; set; }

        public string phoneNumber { get; set; }
    }
}
