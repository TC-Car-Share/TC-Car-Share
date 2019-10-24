using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Models
{
    public class Employee
    {
        public int id { get; set; }

        public string name { get; set; }

        public string number { get; set; }

        public string photo { get; set; }

        public int sex { get; set; }

        public string mobile { get; set; }

        public int driveExp { get; set; }

        public int isSingle { get; set; }

        public string driveLicenseImg { get; set; }

        public string password { get; set; }

        public int empRole { get; set; }
    }
}
