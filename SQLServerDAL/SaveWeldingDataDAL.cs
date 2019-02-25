using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerDAL
{
    public class SaveWeldingDataDAL : ISaveWeldingData
    {
        public ServiceResult SaveWeldingDataL(double WeldPower, int WeldSpeed, double Flow, double FlowUp, double FlowDown, double Pressure,
            double WeldDepth, double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality, double CoaxUp, double CoaxDown,
            string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            ServiceResult result = new ServiceResult();

            string sqlUpdate = "UPDATE Product SET WeldPower=@WeldPower,WeldSpeed=@WeldSpeed,Flow=@Flow,FlowUp=@FlowUp,FlowDown=@flowDown," +
                "Pressure=@Pressure,WeldDepth=@WeldDepth,WeldTime=@WeldTime,XPos=@XPos,YPos=@YPos,ZPos=@ZPos,RPos=@RPos,Coaxiality=@Coaxiality,CoaxUp=@CoaxUp," +
                "CoaxDown=@CoaxDown,Surface=@Surface,LwmCheck=@LwmCheck,QCResult=@QCResult WHERE PNo=@PNo";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter {ParameterName = "@WeldPower", SqlDbType = SqlDbType.Decimal, SqlValue = WeldPower},
                new SqlParameter {ParameterName = "@WeldSpeed", SqlDbType = SqlDbType.Int, SqlValue = WeldSpeed},
                new SqlParameter {ParameterName = "@Pressure", SqlDbType = SqlDbType.Decimal, SqlValue = Pressure},
                new SqlParameter {ParameterName = "@WeldDepth", SqlDbType = SqlDbType.Decimal, SqlValue = WeldDepth},

                new SqlParameter {ParameterName = "@Flow", SqlDbType = SqlDbType.Decimal, SqlValue = Flow},
                new SqlParameter {ParameterName = "@FlowUp", SqlDbType = SqlDbType.Decimal, SqlValue = FlowUp},
                new SqlParameter {ParameterName = "@FlowDown", SqlDbType = SqlDbType.Decimal, SqlValue = FlowDown},

                new SqlParameter {ParameterName = "@Coaxiality", SqlDbType = SqlDbType.Decimal, SqlValue = Coaxiality},
                new SqlParameter {ParameterName = "@CoaxUp", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxUp},
                new SqlParameter {ParameterName = "@CoaxDown", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxDown},

                new SqlParameter {ParameterName = "@XPos", SqlDbType = SqlDbType.Decimal, SqlValue = XPos},
                new SqlParameter {ParameterName = "@YPos", SqlDbType = SqlDbType.Decimal, SqlValue = YPos},
                new SqlParameter {ParameterName = "@ZPos", SqlDbType = SqlDbType.Decimal, SqlValue = ZPos},
                new SqlParameter {ParameterName = "@RPos", SqlDbType = SqlDbType.Decimal, SqlValue = RPos},

                new SqlParameter {ParameterName = "@WeldTime", SqlDbType = SqlDbType.Decimal, SqlValue = WeldTime},
                new SqlParameter {ParameterName = "@Surface", SqlDbType = SqlDbType.NVarChar, SqlValue = Surface},
                new SqlParameter {ParameterName = "@LwmCheck", SqlDbType = SqlDbType.NVarChar, SqlValue = LwmCheck==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@QCResult", SqlDbType = SqlDbType.NVarChar, SqlValue = QCResult==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@PNo", SqlDbType = SqlDbType.NVarChar, SqlValue = PNo}
            };

            try
            {
                if (SqlHelper.IsConnection(SqlHelper.SQLServerConnectionString))
                {
                    int count = SqlHelper.ExecuteNonQuery(sqlUpdate, CommandType.Text);
                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Msg = "更新成功";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Msg = String.Format("更新失败：count={0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("异常：{0}", ex.Message);
            }

            return result;
        }

        public ServiceResult SaveWeldingDataL(double WeldPower, int WeldSpeed, double Flow, double Pressure, double WeldDepth, double WeldTime, double XPos,
            double YPos, double ZPos, double RPos, double Coaxiality, string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            ServiceResult result = new ServiceResult();

            string sqlUpdate = "UPDATE Product SET WeldPower=@WeldPower,WeldSpeed=@WeldSpeed,Flow=@Flow," +
                "Pressure=@Pressure,WeldDepth=@WeldDepth,WeldTime=@WeldTime,XPos=@XPos,YPos=@YPos,ZPos=@ZPos,RPos=@RPos,Coaxiality=@Coaxiality," +
                "Surface=@Surface,LwmCheck=@LwmCheck,QCResult=@QCResult WHERE PNo=@PNo";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter {ParameterName = "@WeldPower", SqlDbType = SqlDbType.Decimal, SqlValue = WeldPower},
                new SqlParameter {ParameterName = "@WeldSpeed", SqlDbType = SqlDbType.Int, SqlValue = WeldSpeed},
                new SqlParameter {ParameterName = "@Pressure", SqlDbType = SqlDbType.Decimal, SqlValue = Pressure},
                new SqlParameter {ParameterName = "@WeldDepth", SqlDbType = SqlDbType.Decimal, SqlValue = WeldDepth},

                new SqlParameter {ParameterName = "@Flow", SqlDbType = SqlDbType.Decimal, SqlValue = Flow},

                new SqlParameter {ParameterName = "@Coaxiality", SqlDbType = SqlDbType.Decimal, SqlValue = Coaxiality},

                new SqlParameter {ParameterName = "@XPos", SqlDbType = SqlDbType.Decimal, SqlValue = XPos},
                new SqlParameter {ParameterName = "@YPos", SqlDbType = SqlDbType.Decimal, SqlValue = YPos},
                new SqlParameter {ParameterName = "@ZPos", SqlDbType = SqlDbType.Decimal, SqlValue = ZPos},
                new SqlParameter {ParameterName = "@RPos", SqlDbType = SqlDbType.Decimal, SqlValue = RPos},

                new SqlParameter {ParameterName = "@WeldTime", SqlDbType = SqlDbType.Decimal, SqlValue = WeldTime},
                new SqlParameter {ParameterName = "@Surface", SqlDbType = SqlDbType.NVarChar, SqlValue = Surface},
                new SqlParameter {ParameterName = "@LwmCheck", SqlDbType = SqlDbType.NVarChar, SqlValue = LwmCheck==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@QCResult", SqlDbType = SqlDbType.NVarChar, SqlValue = QCResult==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@PNo", SqlDbType = SqlDbType.NVarChar, SqlValue = PNo}
            };

            try
            {
                if (SqlHelper.IsConnection(SqlHelper.SQLServerConnectionString))
                {
                    int count = SqlHelper.ExecuteNonQuery(sqlUpdate, CommandType.Text);
                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Msg = "更新成功";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Msg = String.Format("更新失败：count={0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("异常：{0}", ex.Message);
            }

            return result;
        }

        public ServiceResult SaveWeldingDataS(double WeldPower, int WeldSpeed, double Flow, double FlowUp, double FlowDown, double Pressure,
            double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality, double CoaxUp, double CoaxDown,
            string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            ServiceResult result = new ServiceResult();

            string sqlUpdate = "UPDATE Product SET WeldPower=@WeldPower,WeldSpeed=@WeldSpeed,Flow=@Flow,FlowUp=@FlowUp,FlowDown=@flowDown," +
                "Pressure=@Pressure,WeldTime=@WeldTime,XPos=@XPos,YPos=@YPos,ZPos=@ZPos,RPos=@RPos,Coaxiality=@Coaxiality,CoaxUp=@CoaxUp," +
                "CoaxDown=@CoaxDown,Surface=@Surface,LwmCheck=@LwmCheck,QCResult=@QCResult WHERE PNo=@PNo";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter {ParameterName = "@WeldPower", SqlDbType = SqlDbType.Decimal, SqlValue = WeldPower},
                new SqlParameter {ParameterName = "@WeldSpeed", SqlDbType = SqlDbType.Int, SqlValue = WeldSpeed},
                new SqlParameter {ParameterName = "@Pressure", SqlDbType = SqlDbType.Decimal, SqlValue = Pressure},

                new SqlParameter {ParameterName = "@Flow", SqlDbType = SqlDbType.Decimal, SqlValue = Flow},
                new SqlParameter {ParameterName = "@FlowUp", SqlDbType = SqlDbType.Decimal, SqlValue = FlowUp},
                new SqlParameter {ParameterName = "@FlowDown", SqlDbType = SqlDbType.Decimal, SqlValue = FlowDown},

                new SqlParameter {ParameterName = "@Coaxiality", SqlDbType = SqlDbType.Decimal, SqlValue = Coaxiality},
                new SqlParameter {ParameterName = "@CoaxUp", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxUp},
                new SqlParameter {ParameterName = "@CoaxDown", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxDown},

                new SqlParameter {ParameterName = "@XPos", SqlDbType = SqlDbType.Decimal, SqlValue = XPos},
                new SqlParameter {ParameterName = "@YPos", SqlDbType = SqlDbType.Decimal, SqlValue = YPos},
                new SqlParameter {ParameterName = "@ZPos", SqlDbType = SqlDbType.Decimal, SqlValue = ZPos},
                new SqlParameter {ParameterName = "@RPos", SqlDbType = SqlDbType.Decimal, SqlValue = RPos},

                new SqlParameter {ParameterName = "@WeldTime", SqlDbType = SqlDbType.Decimal, SqlValue = WeldTime},
                new SqlParameter {ParameterName = "@Surface", SqlDbType = SqlDbType.NVarChar, SqlValue = Surface},
                new SqlParameter {ParameterName = "@LwmCheck", SqlDbType = SqlDbType.NVarChar, SqlValue = LwmCheck==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@QCResult", SqlDbType = SqlDbType.NVarChar, SqlValue = QCResult==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@PNo", SqlDbType = SqlDbType.NVarChar, SqlValue = PNo}
            };

            try
            {
                if (SqlHelper.IsConnection(SqlHelper.SQLServerConnectionString))
                {
                    int count = SqlHelper.ExecuteNonQuery(sqlUpdate, CommandType.Text);
                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Msg = "更新成功";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Msg = String.Format("更新失败：count={0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("异常：{0}", ex.Message);
            }

            return result;
        }

        public ServiceResult SaveWeldingDataS(double WeldPower, int WeldSpeed, double Flow, double Pressure, double WeldTime, double XPos, double YPos, 
            double ZPos, double RPos, double Coaxiality, string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            ServiceResult result = new ServiceResult();

            string sqlUpdate = "UPDATE Product SET WeldPower=@WeldPower,WeldSpeed=@WeldSpeed,Flow=@Flow," +
                "Pressure=@Pressure,WeldTime=@WeldTime,XPos=@XPos,YPos=@YPos,ZPos=@ZPos,RPos=@RPos,Coaxiality=@Coaxiality," +
                "Surface=@Surface,LwmCheck=@LwmCheck,QCResult=@QCResult WHERE PNo=@PNo";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter {ParameterName = "@WeldPower", SqlDbType = SqlDbType.Decimal, SqlValue = WeldPower},
                new SqlParameter {ParameterName = "@WeldSpeed", SqlDbType = SqlDbType.Int, SqlValue = WeldSpeed},
                new SqlParameter {ParameterName = "@Pressure", SqlDbType = SqlDbType.Decimal, SqlValue = Pressure},

                new SqlParameter {ParameterName = "@Flow", SqlDbType = SqlDbType.Decimal, SqlValue = Flow},

                new SqlParameter {ParameterName = "@Coaxiality", SqlDbType = SqlDbType.Decimal, SqlValue = Coaxiality},

                new SqlParameter {ParameterName = "@XPos", SqlDbType = SqlDbType.Decimal, SqlValue = XPos},
                new SqlParameter {ParameterName = "@YPos", SqlDbType = SqlDbType.Decimal, SqlValue = YPos},
                new SqlParameter {ParameterName = "@ZPos", SqlDbType = SqlDbType.Decimal, SqlValue = ZPos},
                new SqlParameter {ParameterName = "@RPos", SqlDbType = SqlDbType.Decimal, SqlValue = RPos},

                new SqlParameter {ParameterName = "@WeldTime", SqlDbType = SqlDbType.Decimal, SqlValue = WeldTime},
                new SqlParameter {ParameterName = "@Surface", SqlDbType = SqlDbType.NVarChar, SqlValue = Surface},
                new SqlParameter {ParameterName = "@LwmCheck", SqlDbType = SqlDbType.NVarChar, SqlValue = LwmCheck==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@QCResult", SqlDbType = SqlDbType.NVarChar, SqlValue = QCResult==true ? "OK":"NG"},
                new SqlParameter {ParameterName = "@PNo", SqlDbType = SqlDbType.NVarChar, SqlValue = PNo}
            };

            try
            {
                if (SqlHelper.IsConnection(SqlHelper.SQLServerConnectionString))
                {
                    int count = SqlHelper.ExecuteNonQuery(sqlUpdate, CommandType.Text);
                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Msg = "更新成功";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Msg = String.Format("更新失败：count={0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("异常：{0}", ex.Message);
            }

            return result;
        }
    }
}
