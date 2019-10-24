using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.ViewModels
{
    public class WaitingOrder
    {
        public Order info { get; set; }

        public ExtensionInfo extension { get; set; }
    }

    public class ExtensionInfo
    {
        public string isSingle { get; set; }

        public string passengerName { get; set; }

        public string phoneNumber { get; set; }
    }
}
