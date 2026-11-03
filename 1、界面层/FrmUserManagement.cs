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
    public partial class FrmUserManagement: Form
    {
        public FrmUserManagement()
        {
            InitializeComponent();
            this.dgv_UserInfo.AutoGenerateColumns = false;
            this.Load += new System.EventHandler(this.FrmUserManagement_Load);
        }
        private SysAdminService sysAdminService=new SysAdminService();
        List<SysAdmin> sysAdmins;
        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            this.cmb_Authority.Items.AddRange(Enum.GetNames(typeof(RoleName)));   
            this.cmb_Authority.SelectedIndex = 0;
            refreshUserInfo();
            if (sysAdmins.Count > 0)
            {
                updateUserInfo(sysAdmins.First());
            }
        }
        private void refreshUserInfo()
        {           
            sysAdmins = sysAdminService.GetAdmin();
            this.dgv_UserInfo.DataSource = null;
            this.dgv_UserInfo.DataSource = sysAdmins;
        }
        private void updateUserInfo(SysAdmin admin)
        {
            if(sysAdmins.Count != 0)
            {
                this.txt_UserName.Text = admin.LoginName;
                this.txt_Password.Text = admin.LoginPwd;
                this.cmb_Authority.Text = admin.RoleName;
            }
        }
        private void dgv_UserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                updateUserInfo(sysAdmins[e.RowIndex]);
            }
        }
        private void dgv_UserInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(this.dgv_UserInfo, e);   
        }
        #region 用户增删改
        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            //【1】判断用户名和密码是否为空
            if(string.IsNullOrEmpty(this.txt_UserName.Text.Trim()) && this.txt_Password.Text.Trim().Length==0)
            {
                MessageBox.Show("用户名或密码为空");
                return;              
            }
            //【2】判断用户名是否重名
            if(sysAdmins.Where(c=>c.LoginName== this.txt_UserName.Text.Trim()).ToList().Count > 0)
            {
                MessageBox.Show("用户已存在!");
                return;
            }
            //【3】封装用户
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.txt_UserName.Text.Trim(),
                LoginPwd = this.txt_Password.Text.Trim(),
                RoleName = this.cmb_Authority.Text
            };
            //【4】添加用户
            if (sysAdminService.InsertUsers(sysAdmin) == 1)
            {
                refreshUserInfo();
            }
            else
            {
                MessageBox.Show("添加用户失败");
            }
        }
        private void btn_ModifyUser_Click(object sender, EventArgs e)
        {
            //【1】判断用户名和密码是否为空
            if(string.IsNullOrEmpty(this.txt_UserName.Text.Trim()) || this.txt_Password.Text == null)
            {
                MessageBox.Show("用户名或密码为空");
                return;
            }
            //【2】判断选中的用户名与this.txtName是否一致, 再判断this.txtName是否已存在在数据库
            if (sysAdmins[this.dgv_UserInfo.SelectedRows[0].Index].LoginName !=this.txt_UserName.Text.Trim())
            {
                if(sysAdmins.Where(c=>c.LoginName== this.txt_UserName.Text.Trim()).ToList().Count > 0)
                {
                    MessageBox.Show("用户名数据库已存在!", "姓名检索");        
                    return;
                }
            }
            //【3】封装用户
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = sysAdmins[this.dgv_UserInfo.SelectedRows[0].Index].LoginId,
                LoginName = this.txt_UserName.Text.Trim(),
                LoginPwd = this.txt_Password.Text.Trim(),
                RoleName = this.cmb_Authority.Text
            };
            //【4】修改用户
            if (sysAdminService.UpdateUser(sysAdmin) == 1)
            {
                refreshUserInfo();
            }
            else
            {
                MessageBox.Show("修改用户失败");
            }
        }
        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {
            int loginId = sysAdmins[this.dgv_UserInfo.SelectedRows[0].Index].LoginId;//表格允许多选行
            if (sysAdminService.DeleteUser(loginId) == 1)
            {
                refreshUserInfo();
            }
            else
            {
                MessageBox.Show("删除用户失败");
            }
        }
        #endregion
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
