using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//ExecuteReader()：查多行多列 → 返回 DataReader
//ExecuteNonQuery()：增删改 Insert/Update/Delete → 返回受影响行数
//ExecuteScalar()：查单行单列 → 返回 object
//

namespace S7_Database
{
    public class PlcDataFrmSqlService
    {
     //实时插入数据
     public bool InsertPlcData(PLCData pLCData)
        {
            string sql = "insert into ActualData(InsertTime, PressureIn, PressureOut, "+
                "TempIn, TempOut, PressureBoiler, LevelBoiler, TempBoiler, LevelTank) "+
                "values(@InsertTime, @PressureIn, @PressureOut, @TempIn, @TempOut, @PressureBoiler, @LevelBoiler, @TempBoiler, @LevelTank)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@InsertTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@PressureIn",pLCData.PressureIn),
                new SqlParameter("@PressureOut",pLCData.PressureOut),
                new SqlParameter("@TempIn",pLCData.TempIn),
                new SqlParameter("@TempOut",pLCData.TempOut),
                new SqlParameter("@PressureBoiler",pLCData.PressureBoiler),
                new SqlParameter("@LevelBoiler",pLCData.LevelBoiler),
                new SqlParameter("@TempBoiler",pLCData.TempBoiler),
                new SqlParameter("@LevelTank",pLCData.LevelTank),
            };
            return SqlHelper.ExecuteNonQuery(sql, sp) == 1;
        }

        //根据时间查询PLC数据
        public DataTable GetPlcDataByTime(DateTime start,DateTime end)
        {
            string sql = "select InsertTime, PressureIn, PressureOut, TempIn, TempOut, PressureBoiler, LevelBoiler, TempBoiler, LevelTank from ActualData"+
                " where InsertTime between @start and @end";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@start",start),
                new SqlParameter("@end",end)
            };
            try
            {
                DataSet ds = SqlHelper.GetDataSet(sql, null, sp);
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    throw new Exception ("No Query List!");
                }
            }
            catch (Exception ex)
            {

               throw new Exception("Query peocess Eorror!"+ex.Message);
            }           
        }
    }
}
