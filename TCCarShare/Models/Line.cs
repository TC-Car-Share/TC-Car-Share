using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCarShare.Models
{
    public class Line
    {
        public int id { get; set; }

        public string name { get; set; }

        public int empId { get; set; }

       public string origin { get; set; }

       public string destination { get; set; }

       public string publishTime { get; set; }     

       public string takeTime { get; set; }

       public string startPoint { get; set; }

       public string endPoint { get; set; }
    }
}
