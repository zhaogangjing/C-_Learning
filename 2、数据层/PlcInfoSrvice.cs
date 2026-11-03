using S7.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace S7_Database
{
    //从路径文件读取&保存PLC配置信息

    public class PlcInfoService   //封装读取和保存PLC信息的服务类, 读(给我一个路径，把读到的数据映射到实体中)，写(给我一个实体和路径，把实体中的信息一一写到Section key value中)
    {
        /// <summary>
        /// 读取PLC信息
        /// </summary>
        /// <param name="path">读取路径</param>
        /// <returns></returns>
        public PlcInfo GetPlcInfo(string path)
        {
            PlcInfo plcInfo = new PlcInfo();
            if (!File.Exists(path))                     //判断文件是否存在
            {
               return null;
            }
            plcInfo.IpAddress = IniConfigHelper.ReadIniData("PLC Information", "IPAddress", "192.168.0.101",path).ToString();
            plcInfo.CpuType = (CpuType)Enum.Parse(typeof(CpuType), IniConfigHelper.ReadIniData("PLC Information", "CPU Type", "1200",path), true);  //字符串转枚举类型
            plcInfo.Slot = Convert.ToInt16(IniConfigHelper.ReadIniData("PLC Information","Slot", "0",path));
            plcInfo.Rack = Convert.ToInt16(IniConfigHelper.ReadIniData("PLC Information", "Rack", "0", path));                                              //有默认值
            return plcInfo;
        }
        /// <summary>
        /// 保存PLC信息
        /// </summary>
        /// <param name="plcInfo">PLC信息实体</param>
        /// <param name="path">保存路径</param>
        /// <returns></returns>
        public bool SetPlcInfo(PlcInfo plcInfo,string path)
        {
            bool result = true;
            result &= IniConfigHelper.WriteIniData("PLC Information", "IPAddress", plcInfo.IpAddress, path);
            result &= IniConfigHelper.WriteIniData("PLC Information", "CPU Type", plcInfo.CpuType.ToString(), path);
            result &= IniConfigHelper.WriteIniData("PLC Information", "Rack", plcInfo.Rack.ToString(), path);
            result &= IniConfigHelper.WriteIniData("PLC Information", "Slot", plcInfo.Slot.ToString(), path);
            return result;  
        }
    }
}
