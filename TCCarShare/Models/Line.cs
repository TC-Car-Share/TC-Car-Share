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

       public string lon { get; set; }

       public string lat { get; set; }

       public string publishTime { get; set; }     

       public int takeNum { get; set; }

       public string takeTime { get; set; }
    }
}
