using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Core
{
    public class AnalysisBarCode
    {
        public static ServiceResult BarCode(string station, string barCode)
        {
            ServiceResult result = new ServiceResult();

            if (String.IsNullOrEmpty(barCode))
            {
                result.IsSuccess = false;
                result.Msg = String.Format("条码为空：{0}", barCode);
                return result;
            }

            if (barCode.Contains("ERROR") || barCode.Contains("error"))
            {
                result.IsSuccess = false;
                result.Msg = String.Format("错误条码：{0}", barCode);
                return result;
            }

            FailSafe failSafe = new FailSafe();
            if (station == "S")
            {
                result = failSafe.CheckSmall(barCode);
            }
            else
            {
                result = failSafe.CheckLarge(barCode);
            }

            return result;
        }

    }
}
