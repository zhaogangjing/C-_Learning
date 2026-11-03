using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using thinger.CommonControlLib;
using thinger.DataConvertLib;
using S7.Net;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;

namespace S7_Database
{
    /// <summary>
    /// PLC数据采集与控制类
    /// </summary>
    public class PLCDataService
    {
        private S7NetLib s7Net = null;
        public void Connect(PlcInfo plcInfo)
        {
            try
            {
                this.s7Net = new S7NetLib(plcInfo.CpuType, plcInfo.IpAddress, plcInfo.Rack, plcInfo.Slot);
                this.s7Net.OpenPLC();
            }
            catch (Exception ex)
            {

                throw new Exception("PLC连接失败！原因：" + ex.Message);
            }

        }
        public void Disconnect()
        {
            if (this.s7Net != null)
            {
                this.s7Net.ClosePLC();
                this.s7Net = null;                                   //根据需要添加（可防止在系统断开连接的时候，用户还能操作设备）
            }
        }
        #region  批量获取DB块数组，并通过thinger.convert库文件进行转换
        public PLCData GetPlcData()
        {
            int length = 36;
            try
            {
                byte[] data = this.s7Net.ReadDataFromPLC(S7.Net.DataType.DataBlock, 1, 0, length);
                if (data != null && data.Length == length)
                {
                    PLCData plcData = new PLCData();
                    //获取位状态信息
                    plcData.FeedPumpState = BitLib.GetBitFromByteArray(data, 0, 0);    //查找字节数组中第0个字节的第0位
                    plcData.AddPumpState = BitLib.GetBitFromByteArray(data, 0, 1);
                    plcData.AirPumpState = BitLib.GetBitFromByteArray(data, 0, 2);
                    plcData.CiclePumpState = BitLib.GetBitFromByteArray(data, 0, 3);
                    plcData.OutValveState = BitLib.GetBitFromByteArray(data, 0, 4);
                    plcData.SystemState = BitLib.GetBitFromByteArray(data, 0, 6);
                    //获取字节状态信息
                    plcData.PressureIn = FloatLib.GetFloatFromByteArray(data, 2);        //data字节数组中第2个字节开始的4个字节转换为float类型，西门子默认大端序ABCD，所有最后一个参数省略
                    plcData.PressureOut = FloatLib.GetFloatFromByteArray(data,6);
                    plcData.TempIn = FloatLib.GetFloatFromByteArray(data, 10);
                    plcData.TempOut = FloatLib.GetFloatFromByteArray(data, 14);
                    plcData.PressureBoiler = FloatLib.GetFloatFromByteArray(data, 18);
                    plcData.LevelBoiler = FloatLib.GetFloatFromByteArray(data, 22);
                    plcData.TempBoiler = FloatLib.GetFloatFromByteArray(data, 26);
                    plcData.LevelTank = FloatLib.GetFloatFromByteArray(data, 30);
                    return plcData;
                }
                else
                {
                    throw new Exception("数据读取不正确！");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("数据读取失败！原因：" + ex.Message);
            }
        }
        #endregion
        #region 各种泵&阀门启停控制
        public void FeedPumpControl(bool state)
        {
            if (s7Net != null)
            {
                string address = string.Empty;
                address = state ? "DB1.DBX34.0" : "DB1.DBX34.1";
                this.s7Net.WriteDataToPLC(address, 1);
                Thread.Sleep(100);
                this.s7Net.WriteDataToPLC(address, 0);
            }
            else
            {
                throw new Exception("PLC未连接！");
            }
        }
        public void AddPumpControl(bool state)
        {
            if (s7Net != null)
            {
                string address = string.Empty;
                if (state)
                {
                    address = "DB1.DBX34.2";
                }
                else
                {
                    address = "DB1.DBX34.3";
                }
                this.s7Net.WriteDataToPLC(address, 1);
                Thread.Sleep(100);
                this.s7Net.WriteDataToPLC(address, 0);
            }
            else
            {
                throw new Exception("PLC未连接！");
            }
        }
        public void AirPumpControl(bool state)
        {
            if (s7Net != null)
            {
                string address = string.Empty;
                address = state ? "DB1.DBX34.4" : "DB1.DBX34.5";
                this.s7Net.WriteDataToPLC(address, 1);
                Thread.Sleep(100);
                this.s7Net.WriteDataToPLC(address, 0);
            }
            else
            {
                throw new Exception("PLC未连接！");
            }
        }
        public void CirclePumpControl(bool state)
        {
            if (s7Net != null)
            {
                string address = string.Empty;
                address = state ? "DB1.DBX34.6" : "DB1.DBX34.7";
                this.s7Net.WriteDataToPLC(address, 1);
                Thread.Sleep(100);
                this.s7Net.WriteDataToPLC(address, 0);
            }
            else
            {
                throw new Exception("PLC未连接！");
            }
        }
        public void OutTapControl(bool state)
        {
            if (s7Net != null)
            {
                string address = string.Empty;
                address = state ? "DB1.DBX35.0" : "DB1.DBX35.1";
                this.s7Net.WriteDataToPLC(address, 1);
                Thread.Sleep(100);
                this.s7Net.WriteDataToPLC(address, 0);
            }
            else
            {
                throw new Exception("PLC未连接！");
            }
        }
        
        #endregion
    }
}
