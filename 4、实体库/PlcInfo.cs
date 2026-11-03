using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7_Database
{
    public class PlcInfo
    {
        public string IpAddress { get; set; }
        public CpuType CpuType { get; set; }
        public short Rack { get; set; } 
        public short Slot { get; set; } 
    }
}
