using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S7_Database
{
    public partial class FrmUserManagerment : Form
    {
        public FrmUserManagerment()
        {
            InitializeComponent();
            this.dGV_History.AutoGenerateColumns = false;
            this.dTP1.Value = DateTime.Now.AddHours(-2.0);
            this.dTP2.Value = DateTime.Now;
        }
        private PlcDataFrmSqlService plcDataFrmSqlService=new PlcDataFrmSqlService();
        


        private void btn_Query_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = this.dTP2.Value - this.dTP1.Value;
            if (timeSpan.TotalSeconds < 0)
            {
                MessageBox.Show("查询开始时间不能晚于结束时间", "数据查询");
            }
            try
            {
                DataTable dataTable = plcDataFrmSqlService.GetPlcDataByTime(this.dTP1.Value, this.dTP2.Value);
                if(dataTable.Rows.Count > 0)
                {
                    this.dGV_History.DataSource = null;
                    this.dGV_History.DataSource=dataTable;
                }
                else
                {
                    MessageBox.Show("此时间段未查询到数据", "数据查询");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
