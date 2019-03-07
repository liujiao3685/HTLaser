using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerDAL
{
    /***
    insert into TABLE
    select 'pid' as [F_Id], [Customer], 'newType' as [ProductCode], 'newType' as [FullName], [FigureNumber], [ClientNumber]
     from TABLE WHERE Model='oldType';
     * */
    public class AirBagDAL : IAirBag
    {
        public int GetCountByCondition(string sqlCondition)
        {
            int count = 0;
            try
            {
                count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sqlCondition);
            }
            catch (Exception ex)
            {
                count = -1;
            }
            return count;
        }

        public int GetNgCount()
        {
            int count = 0;
            try
            {
                string sql = "SELECT COUNT(*) FROM Product WHERE QCResult IS NOT NULL";
                count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                count = -1;
            }
            return count;
        }

        public int GetOKCount()
        {
            int count = 0;
            try
            {
                string sql = "SELECT COUNT(*) FROM Product WHERE QCResult='OK'";
                count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                count = -1;
            }
            return count;
        }

        public int GetTotalCount()
        {
            int count = 0;
            try
            {
                string sql = "SELECT COUNT(*) FROM Product WHERE QCResult IS NOT NULL";
                count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                count = -1;
            }
            return count;
        }

        public ServiceResult IsExist(string barCode)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                string sqlIsExist = "SELECT PNo FROM Product WHERE PNo = @PNo";
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@PNo", System.Data.SqlDbType.NVarChar, 50);
                sqlParameters[0].Value = barCode;

                object value = SqlHelper.ExecuteScalar(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sqlIsExist, sqlParameters);
                if (value != null)
                {
                    sqlIsExist = "INSERT INTO Product(PNo,StorageTime) Values(@PNo,@StorageTime)";
                    SqlParameter[] paramInsert = new SqlParameter[2];
                    paramInsert[0] = new SqlParameter("@PNo", System.Data.SqlDbType.NVarChar, 50);
                    paramInsert[0].Value = barCode;
                    paramInsert[1] = new SqlParameter("@StorageTime", System.Data.SqlDbType.DateTime);
                    paramInsert[1].Value = DateTime.Now;

                    int count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sqlIsExist, paramInsert);

                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Msg = string.Format("条码:{0} - 入库成功", barCode);
                    }
                    else
                    {
                        result.IsSuccess = true;
                        result.Msg = string.Format("条码:{0} - 入库失败，count ：{1}", barCode, count);
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = string.Format("条码:{0} - 已入库", barCode);
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = String.Format("异常：{0}", ex.Message);
            }

            return result;

        }

        public ServiceResult UpdateManaulCheck(string BarCode, string NewResult, string Reason, string Operator)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                //先备份
                string sqlInsert = "UPDATE Product SET QCResult=@QCResult,ManualCheck=@ManualCheck,ManualOperator=@ManualOperator,ManualTime=GETDATE() WHERE PNo=@PNo";
                SqlParameter[] paramInsert = new SqlParameter[4];
                paramInsert[0] = new SqlParameter("@QCResult", System.Data.SqlDbType.NVarChar, 50);
                paramInsert[0].Value = NewResult;
                paramInsert[1] = new SqlParameter("@ManualOperator", System.Data.SqlDbType.NVarChar, 50);
                paramInsert[1].Value = Operator;
                paramInsert[2] = new SqlParameter("@PNo", System.Data.SqlDbType.NVarChar, 50);
                paramInsert[2].Value = BarCode;
                paramInsert[3] = new SqlParameter("@ManualCheck", System.Data.SqlDbType.NVarChar, 50);
                paramInsert[3].Value = Reason;

                int count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sqlInsert, paramInsert);

                if (count > 0)
                {
                    result.IsSuccess = true;
                    result.Msg = "成功！";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = string.Format("失败 - count:{0}", count);
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("异常 - {0}", ex.Message);
            }
            return result;
        }

    }
}
