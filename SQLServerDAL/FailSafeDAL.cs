using IDAL;
using Model;
using System;
using System.Data.SqlClient;

namespace SQLServerDAL
{
    public class FailSafeDAL : IFailSafe
    {
        public ServiceResult CheckLarge(string barcode)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                string sqlCheck = "SELECT 结果 From V_ST060 Where 条码=@Barcode";

                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@Barcode", System.Data.SqlDbType.VarChar, 50);
                sqlParameters[0].Value = barcode;

                object value = SqlHelper.ExecuteScalar(SqlHelper.SQLServerConnectionStringTPOS, System.Data.CommandType.Text, sqlCheck, sqlParameters);

                if (Convert.ToBoolean(value))
                {
                    result.IsSuccess = true;
                    result.Msg = String.Format("获取60工位结果：{0}", value);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = String.Format("获取60工位结果：{0}", value);
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = String.Format("异常：{0},条码 - {1}", ex.Message, barcode);
            }


            return result;
        }

        public ServiceResult CheckSmall(string barcode)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                string sqlCheck = "SELECT 结果 From V_ST010 Where 条码=@Barcode";

                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@Barcode", System.Data.SqlDbType.VarChar, 50);
                sqlParameters[0].Value = barcode;

                object value = SqlHelper.ExecuteScalar(SqlHelper.SQLServerConnectionStringTPOS, System.Data.CommandType.Text, sqlCheck, sqlParameters);

                if (Convert.ToBoolean(value))
                {
                    result.IsSuccess = true;
                    result.Msg = String.Format("获取10工位结果：{0}", value);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = String.Format("获取10工位结果：{0}", value);
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = String.Format("异常：{0},条码 - {1}", ex.Message, barcode);
            }

            return result;
        }
    }
}
