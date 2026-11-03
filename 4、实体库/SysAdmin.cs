using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7_Database
{
    /// <summary>
    /// 用户信息实体类
    /// </summary>
    public class SysAdmin
    {
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string RoleName { get; set; }
    }
  
}
