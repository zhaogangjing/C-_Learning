using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace S7_Database
{
    public class S7NetLib        //根据s7netplus封装的对象
    {
       /// <summary>
       /// 【私有字段】：西门子S7协议PLC通讯类对象
       /// </summary>
        private Plc s7NetPlc=null;
        /// <summary>
        /// S7通讯的4个参数共有属性：  CPU类型、IP地址、机架号、插槽号 
        /// </summary>
        public CpuType CPUType { get; set; }
        public string  IPAddress { get; set; }
        public short Rack { get; set; }
        public short Slot { get; set; }

        //构造方法  用于给上面4个属性传递初始值，供Plc类型的 s7NetPlc使用
        public S7NetLib(CpuType type, string ip, short rack, short slot)
        {
            CPUType = type;
            IPAddress = ip;
            Rack = rack;
            Slot = slot;
        }

        //打开PLC  打开前判断通讯对象是否为空   if不为空 则重新实例化 then判断是否连接 if未连接 then重新调用open方法
        public void OpenPLC()
        {
            if (s7NetPlc == null)
            {
                s7NetPlc = new Plc(CPUType, IPAddress, Rack, Slot);
            }
            if (!s7NetPlc.IsConnected)
            {
                s7NetPlc.ReadTimeout = 100;
                s7NetPlc.WriteTimeout = 100;
                s7NetPlc.Open();
            }
        }

        //断开PLC  打开前判断通讯对象是否为空   then判断是否连接   调用close方法
        public void ClosePLC()
        {
            if (s7NetPlc!=null && s7NetPlc.IsConnected)
            {
                s7NetPlc.Close();
            }
        }
        //数据批量读取 
        public byte[] ReadDataFromPLC(DataType dataType,int db,int startByteAdr,int count)
        {
            OpenPLC();
            lock (this) 
            {
                byte[] result = this.s7NetPlc.ReadBytes(dataType, db, startByteAdr, count);
                return result;
            }
        }
        //数据写入（单个变量）
          public void WriteDataToPLC(string varAddress,object varValue)
        {
            OpenPLC();
            lock (this)     //规定加锁 防止并发
            {
                this.s7NetPlc.Write(varAddress, varValue);
            }
        }
    }
}
