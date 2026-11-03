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
    public partial class FrmLogin : Form
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
        public FrmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
        }
        private SysAdminService sysAdminService=new SysAdminService();
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            List<SysAdmin> sysAdmins=sysAdminService.GetAdmin();    
            if(sysAdmins.Count > 0)
            {
                foreach (SysAdmin item in sysAdmins)
                {
                    this.cmb_UserName.Items.Add(item.LoginName);  //每次添加 1 项
                }
                this.cmb_UserName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No effective userInfo", "Login Info!");
                return;
            }
           
        }
        #region 登录验证：通过登录界面用户名及密码，去数据库查询有无此人，并返回此人全部信息
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //【1】验证用户名和密码
            if(this.cmb_UserName.Text.Trim().Length== 0)
            {
                MessageBox.Show("Please choose the Username", "Login InFo!");
                return;
            }
            if(this.txt_Password.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please insert the Password", "Login InFo!");
                return;
            }
            //【2】封装sysadmin
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.cmb_UserName.Text.Trim(),
                LoginPwd = this.txt_Password.Text.Trim()
            };
            //【3】验证
            sysAdmin=sysAdminService.AdminLogin(sysAdmin);
            if(sysAdmin == null)
            {
                MessageBox.Show("Login Failed", "Login InFo!");
                return ;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Program.CurrentSysAdmin = sysAdmin;
            }
        }
        #endregion
        private void common_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btn_Login_Click(sender, e);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
