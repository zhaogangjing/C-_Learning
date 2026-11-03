using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S7_Database
{
    public partial class FrmPara : Form
    {
        public FrmPara(string pathFromFrmMain,PlcInfo plcInfoFromFrmMain, PlcInfoService plcInfoServiceFromFrmMain)  
        {
            InitializeComponent();
            iniInfo();
            this.path= pathFromFrmMain;
            this.plcInfo=plcInfoFromFrmMain;
            this.plcInfoService= plcInfoServiceFromFrmMain;

           if(plcInfo!=null) 
            {
                this.txt_IP.Text = plcInfo.IpAddress;
                this.cmb_CpuType.Text=plcInfo.CpuType.ToString();
                this.txt_Rack.Text=plcInfo.Rack.ToString();
                this.txt_Slot.Text=plcInfo.Slot.ToString();                                                //FrmPara窗体加载时，若plcInfo为空,则控件使用默认值，若plcInfo不为空，则将plcInfo中的值赋给控件,
            }                              
        }
        #region 私有字段
        private string path;
        private PlcInfo plcInfo;
        private PlcInfoService plcInfoService;
        #endregion
        #region 如果plcInfo为空，则先New一个，再封装后通过ini封装库写入ini文件
        private void btn_SetOk_Click(object sender, EventArgs e)
        {
            if (this.plcInfo == null)
            {
                this.plcInfo = new PlcInfo();             
            }
            plcInfo.IpAddress = this.txt_IP.Text;
            plcInfo.CpuType = (CpuType)Enum.Parse(typeof(CpuType), this.cmb_CpuType.Text, true);
            plcInfo.Rack = Convert.ToInt16(this.txt_Rack.Text.Trim());
            plcInfo.Slot = Convert.ToInt16(this.txt_Slot.Text.Trim());
            try
            {
                bool result = plcInfoService.SetPlcInfo(this.plcInfo, this.path);
                if (result)
                {
                    MessageBox.Show("Successfull to save PlcInfo" , " Information!");
                }
                this.DialogResult= DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save PlcInfo" +ex.Message,"Information!");
            }
        }                                                                                                                                                    //把控件的值封装到plcInfo对象中，并通过ini封装库写入ini文件
        #endregion
        #region 取消设置
        private void btn_SetCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
        #region 参数设置窗体关闭
        private void btn_FrmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 如果从路径返回空的 plcInfo时，使用默认值
        private void iniInfo()
        {
            this.txt_IP.Text = "192.168.100.100";
           //this.cmb_CpuType.Items.AddRange(Enum.GetNames(typeof(CpuType)));
           this.cmb_CpuType.DataSource=Enum.GetNames(typeof(CpuType));
            this.txt_Rack.Text = "0";
            this.txt_Slot.Text = "0";
        }
        #endregion
    }
}
