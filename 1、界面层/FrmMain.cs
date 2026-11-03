using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.CommonControlLib;

namespace S7_Database
{
    public partial class FrmMain : Form
    {
        #region 无边框拖动 

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion
        private string plcInPath = Application.StartupPath + "\\plc.ini";  //获取当前程序的启动路径，并拼接ini文件名
        private PlcInfoService plcInfoService = new PlcInfoService();
        private PlcInfo plcInfo = new PlcInfo();
        private Timer timer;
        private DateTime lastTime = DateTime.Now;
        private PLCDataService dataService = new PLCDataService();
        private PlcDataFrmSqlService PlcDataFrmSqlService = new PlcDataFrmSqlService();
        public FrmMain()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                PLCData pLCData = dataService.GetPlcData();
                updateUI(pLCData);
                int timeSpan = DateTime.Now.Second - lastTime.Second;
                if (timeSpan == 1 || timeSpan == -59)
                {
                    PlcDataFrmSqlService.InsertPlcData(pLCData);
                    lastTime = DateTime.Now;
                }

            }
            catch (Exception ex)
            {
                this.timer.Enabled = false;
                MessageBox.Show(ex.Message, "Plc 连接中断");
            }

        }
        private void updateUI(PLCData data)
        {
            //更新状态
            this.pump_FeedState.IsRun = data.FeedPumpState;
            this.pump_AddState.IsRun = data.AddPumpState;
            this.pump_AirState.IsRun = data.AirPumpState;
            this.circle_Pump.PumpState = data.CiclePumpState ? 1 : 0;   //必须是布尔类型 bool 或可空布尔类型 bool? true返回1，false返回0
            this.handValue.IsOpen = data.OutValveState;
            this.Led_SystemState.LedState = data.SystemState ? 1 : 0;
            //更新label
            this.lbl_TempIn.Text = data.TempIn.ToString("F1");
            this.lbl_TempOut.Text = data.TempOut.ToString("F1");
            this.lbl_TempBoiler.Text = data.TempBoiler.ToString("F1");
           // this.lbl_PressureIn.Text = data.PressureIn.ToString("f2") + "Bar";
            this.lbl_TempIn1.Text = data.TempIn.ToString("f1") + "℃";
            this.lbl_TempOut1.Text = data.TempOut.ToString("f1") + "℃";
            this.lbl_PressureOut.Text = data.PressureOut.ToString("f2") + "Bar";
            this.lbl_LevelTank.Text = data.LevelTank.ToString("f1") + "%";
            this.lbl_TempBoiler.Text = data.TempBoiler.ToString("f2") + "℃";
            this.lbl_LevelBoiler.Text = data.LevelBoiler.ToString("f2") + "%";
            //this.lbl_PressureBoiler1.Text = data.PressureBoiler.ToString("f2") + "Bar";
            //更新仪表盘
            this.meter_PressureIn.Value = data.PressureIn;
            this.meter_PressureOut.Value = data.PressureOut;
            this.meter_TempIn.Value = data.TempIn;
            this.meter_TempOut.Value = data.TempOut;
            this.meter_BoilerTemp.Value = data.TempBoiler;
            this.meter_TankLevel.Value = data.LevelTank;
            this.meter_BoilerLevel.Value = data.LevelBoiler;
            //更新液位
            this.ct_Boiler.BoilLevel = data.LevelBoiler;
            this.wave_TankLevel.Value = (int)data.LevelTank;
            //
            UpdateFlowBar(data.FeedPumpState);
        }
        private void UpdateFlowBar(bool IsRun)
        {
            this.thingerFlowControl1.PipeLineActive = IsRun;
            this.thingerFlowControl10.PipeLineActive = IsRun;
            this.thingerFlowControl11.PipeLineActive = IsRun;
            this.thingerFlowControl12.PipeLineActive = IsRun;   
            this.thingerFlowControl13.PipeLineActive = IsRun;   
            this.thingerFlowControl2.PipeLineActive = IsRun;
            this.thingerFlowControl3.PipeLineActive = IsRun;
            this.thingerFlowControl4.PipeLineActive = IsRun;
            this.thingerFlowControl5.PipeLineActive = IsRun;
            this.thingerFlowControl6.PipeLineActive = IsRun;
            this.thingerFlowControl7.PipeLineActive = IsRun;
            this.thingerFlowControl8.PipeLineActive = IsRun;
            this.thingerFlowControl9.PipeLineActive = IsRun;

        }
        #region 主窗体泵和阀门的启动与停止
        private void toggle_FeedPump_CheckedChanged(object sender, EventArgs e)
        {
            thingerToggleAdvance toggle=sender as thingerToggleAdvance;
            try
            {
                dataService.FeedPumpControl(toggle.Checked);
            }
            catch (Exception ex)
            {
                toggle.CheckedChanged -= toggle_FeedPump_CheckedChanged;
                try
                {
                    toggle.Checked = !toggle.Checked;
                }
                finally
                {
                    // 无论如何，事件一定重新绑定
                    toggle.CheckedChanged += toggle_FeedPump_CheckedChanged;
                }
                MessageBox.Show("FeedPumpControl" + ex.Message, "Info!");
            }
            
        }

        private void toggle_AddPump_CheckedChanged(object sender, EventArgs e)
        {
            thingerToggleAdvance toggle = sender as thingerToggleAdvance;
            try
            {
                dataService.AddPumpControl(toggle.Checked);
            }
            catch (Exception ex)
            {
                toggle.CheckedChanged -= toggle_AddPump_CheckedChanged;
                toggle.Checked = !toggle.Checked;
                toggle.CheckedChanged += toggle_AddPump_CheckedChanged; ;
                MessageBox.Show("AddPumpControl" + ex.Message, "Info!");
            }
        }

        private void toggle_AirPump_CheckedChanged(object sender, EventArgs e)
        {
            thingerToggleAdvance toggle = sender as thingerToggleAdvance;
            try
            {
                dataService.AirPumpControl(toggle.Checked);
            }
            catch (Exception ex)
            {
                toggle.CheckedChanged -= toggle_AirPump_CheckedChanged;
                toggle.Checked = !toggle.Checked;
                toggle.CheckedChanged += toggle_AirPump_CheckedChanged; ;
                MessageBox.Show("AirPumpControl" + ex.Message, "Info!");
            }
        }

        private void toggle_CirclePump_CheckedChanged(object sender, EventArgs e)
        {
            thingerToggleAdvance toggle = sender as thingerToggleAdvance;
            try
            {
                dataService.CirclePumpControl(toggle.Checked);
            }
            catch (Exception ex)
            {
                toggle.CheckedChanged -= toggle_CirclePump_CheckedChanged;
                toggle.Checked = !toggle.Checked;
                toggle.CheckedChanged += toggle_CirclePump_CheckedChanged; ;
                MessageBox.Show("CirclePumpControl" + ex.Message, "Info!");
            }
        }

        private void handValue_ValueControl(bool value)
        {
            string tip=(value? "close":"open")+"valve";
            if (MessageBox.Show("Are you sure to " + tip + "?", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    dataService.OutTapControl(!value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("OutValveControl" + ex.Message, "Info!");
                }
            }
        }
        #endregion
        private void btn_ParamSet_Click(object sender, EventArgs e)
        {
            FrmPara frmPara= new FrmPara(plcInPath, plcInfo, plcInfoService);   
            frmPara.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)   //窗体加载plc配置信息，供连接PLC使用
        {
            try
            {
                this.plcInfo = this.plcInfoService.GetPlcInfo(plcInPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load PlcInfo from ini file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }

        #region 系统启动与停止按钮
        private void btn_SystemStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataService.Connect(this.plcInfo);
                this.timer.Enabled = true;
                this.btn_SystemStart.Enabled = false;
                this.btn_SystemStop.Enabled = true;
                this.Led_PlcState.LedState = 1;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plc 连接错误" + ex.Message, "PLc connecting");
            }
           
        }

        private void btn_SystemStop_Click(object sender, EventArgs e)
        {
            this.timer.Enabled=false;
            this.btn_SystemStart.Enabled = true;
            this.btn_SystemStop.Enabled = false;
            this.Led_PlcState.LedState = 0;

            
            updateUI(new PLCData());
        }
        #endregion
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the window?！", "Information", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            FrmUserManagerment frmHistory = new FrmUserManagerment();   
            frmHistory.ShowDialog();
        }

        private void btn_UserManage_Click(object sender, EventArgs e)
        {
            if (Program.CurrentSysAdmin.RoleName!= RoleName.管理员.ToString())
            {
                MessageBox.Show("用户权限不足"); return;
            }
            new FrmUserManagement().Show();
        }
    }
}
