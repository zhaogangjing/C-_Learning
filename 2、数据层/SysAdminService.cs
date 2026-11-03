using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using thinger.CommonControlLib;
//ExecuteReader()：查多行多列 → 返回 DataReader
//ExecuteNonQuery()：增删改 Insert/Update/Delete → 返回受影响行数
//ExecuteScalar()：查单行单列 → 返回 object

namespace S7_Database
{
    /// <summary>
    /// 用户管理服务类
    /// </summary>
    public class SysAdminService
    {
        #region  登录验证 成功返回整个集合 不成功返回空
        //登录窗体按下登陆按钮，封装好当前界面用户名和密码实体库，执行此方法，实体库的用户名和密码传入sql参数
        public SysAdmin AdminLogin(SysAdmin admin)
        {
            //【1】封装sql语句
            string sql = "select LoginId, RoleName, LoginName,LoginPwd from SysAdmin where LoginName=@LoginName and LoginPwd=@LoginPwd";  //*  注意此处的and   除了条件外 其它需要的列也要加到SQL语句

            //【2】封装sqlPara
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName",admin.LoginName),             //把参数变为具体的数值
                new SqlParameter("@LoginPwd",admin.LoginPwd),
            };             // Watch out 分号和上面的逗号

            //【3】提交查询
            SqlDataReader reader=SqlHelper.ExecuteReader(sql,sqlParameters) ;

            //【4】如果成功，则封装另2个属性       if success,reader.Read() become 1           
            if (reader.Read()) {
                admin.LoginId = Convert.ToInt32(reader["LoginId"]);
                admin.RoleName = reader["RoleName"].ToString();
            }
            else
            {
                admin = null;
            }
            reader.Close();
            return admin;
        }
        #endregion

        #region 获取数据库所有用户信息，用户登陆窗体用户名绑定,还用于用户管理窗体datagridView数据绑定
        //获取数据库所有用户信息，用户登陆窗体用户名绑定
        public List<SysAdmin>  GetAdmin()      
        {
            string sql = "select LoginId, LoginName, LoginPwd, RoleName from SysAdmin";
            SqlDataReader reader=SqlHelper.ExecuteReader(sql);
            List<SysAdmin> sysAdmins = new List<SysAdmin>();
            while (reader.Read())
            {
                sysAdmins.Add(new SysAdmin() { LoginId = Convert.ToInt32(reader["LoginId"]), LoginName = reader["LoginName"].ToString(), LoginPwd = reader["LoginPwd"].ToString(), RoleName = reader["RoleName"].ToString() });            
            }
            reader.Close();
            return sysAdmins;
        }
        #endregion
        #region 增删改
        //添加用户
        public int InsertUsers(SysAdmin admin)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Insert into SysAdmin(LoginName,LoginPwd,RoleName) ");
            stringBuilder.Append("values(@LoginName, @LoginPwd,@RoleName)");
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
            new SqlParameter("@LoginName",admin.LoginName),
            new SqlParameter("@LoginPwd",admin.LoginPwd),
            new SqlParameter("@RoleName",admin.RoleName),
            };
            return SqlHelper.ExecuteNonQuery(stringBuilder.ToString(), sqlParameter);
        }
       
        //修改用户
        public int UpdateUser(SysAdmin admin)
        {
            StringBuilder stringBuilder=new StringBuilder();
            stringBuilder.Append("Update SysAdmin set LoginName=@LoginName,LoginPwd=@LoginPwd,RoleName=@Rolename where LoginId=@LoginId");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName",admin.LoginName),
                new SqlParameter("@LoginPwd",admin.LoginPwd),
                new SqlParameter("@RoleName",admin.RoleName),
                new SqlParameter("@LoginId",admin.LoginId),
            };
            return SqlHelper.ExecuteNonQuery(stringBuilder.ToString(), sqlParameters);
        }
        //删除用户
        public int DeleteUser(int loginId)
        {          
            string sql="Delete from SysAdmin where LoginId=@LoginId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
            };
            return SqlHelper.ExecuteNonQuery(sql,sqlParameters);
        }
        #endregion

    }
}
