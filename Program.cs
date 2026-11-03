using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S7_Database
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.TopMost = true;  //TopMost 属性用于控制窗体是否始终显示在所有其他非置顶窗体的最上层，是实现 “置顶窗口”（如悬浮窗、工具条、提示窗口）的核心属性
            if (DialogResult.OK == frmLogin.ShowDialog())
            {
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();
            }
        }
        public static SysAdmin CurrentSysAdmin;
    
    }
}
