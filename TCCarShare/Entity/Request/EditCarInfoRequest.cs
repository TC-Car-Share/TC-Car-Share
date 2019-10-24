using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCarShare.Models;

namespace TCCarShare.Entity.Request
{
    public class EditCarInfoRequest 
    {
        public string id { get; set; }
        public string carNo { get; set; }
        public string carColor { get; set; }
        public string carType { get; set; }
        public string carBrand { get; set; }
        public string carSeatNum { get; set; }
        public string carLicenseImg { get; set; }
        public string carMasterId { get; set; }
    }
}
