using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HuaTianProject.Core
{
    public class CPKHelper
    {
        //标准偏差公式：S = Sqrt[(∑(xi-x拨)^2) /（N-1）]公式中∑代表总和，x拨代表x的均值，^2代表二次方，Sqrt代表平方根。

        public CPKHelper()
        {

        }

        public void Test()
        {
            float[] k = { 0.03F, 0.06F, 0.05F, 0.03F, 0.04F, 0.04F, 0.03F, 0.04F, 0.04F, 0.04F, 0.04F, 0.04F, 0.04F, 0.03F, 0.01F, 0.03F, 0.01F, 0.03F, 0.04F, 0.04F, 0.04F, 0.05F, 0.02F, 0.04F, 0.05F, 0.05F, 0.05F, 0.05F, 0.03F, 0.05F, 0.05F, 0.03F, 0.02F, 0.04F, 0.04F, 0.02F, 0.06F, 0.04F, 0.02F, 0.03F, 0.04F, 0.02F, 0.05F, 0.06F, 0.07F, 0.02F, 0.04F, 0.04F, 0.03F, 0.03F };

            string text = String.Empty;

            float Nomial = 0.05F;
            float UpperLimit = 0.12F;
            float LowerLimit = 0F;
            text = "检测点:" + k.Length.ToString() + "/r/n";
            text += "Nominal:" + Nomial.ToString() + "/r/n";
            text += "UpperLimit:" + UpperLimit.ToString("F2") + "/r/n";
            text += "LowerLimit:" + LowerLimit.ToString("F2") + "/r/n";
            text += "Average:" + ProCPK.Avage(k).ToString("F3") + "/r/n";
            text += "STD:" + ProCPK.SetDev(k).ToString("F3") + "/r/n";
            text += "Cp:" + ProCPK.Cp(UpperLimit, LowerLimit, ProCPK.SetDev(k)).ToString("F3") + "/r/n";
            text += "CpkU:" + ProCPK.CpkU(UpperLimit, ProCPK.Avage(k), ProCPK.SetDev(k)).ToString("F3") + "/r/n";
            text += "CpkL:" + ProCPK.CpkL(LowerLimit, ProCPK.Avage(k), ProCPK.SetDev(k)).ToString("F3") + "/r/n";
            text += "Cpk:" + ProCPK.Cpk(ProCPK.CpkU(UpperLimit, ProCPK.Avage(k), ProCPK.SetDev(k)), ProCPK.CpkL(LowerLimit, ProCPK.Avage(k), ProCPK.SetDev(k))).ToString("F3") + "/r/n";
            text += "Min:" + ProCPK.Min(k).ToString("F3") + "/r/n";
            text += "Max:" + ProCPK.Max(k).ToString("F3") + "/r/n";
        }
    }


    public class ProCPK
    {
        /// <summary>
        /// 计算值偏差
        /// </summary>
        /// <param name="arrData"></param>
        /// <returns></returns>
        public static float SetDev(float[] arrData)
        {
            float xSum = 0f;

            float xAvg = 0f;

            float sSum = 0f;

            float tempDev = 0f;

            int arrNum = arrData.Length;

            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }

            xAvg = xSum / arrNum;

            for (int j = 0; j < arrNum; j++)
            {
                sSum += (arrData[j] - xAvg) * (arrData[j] - xAvg);
            }

            tempDev = Convert.ToSingle(Math.Sqrt(sSum / (arrNum - 1)).ToString());

            return tempDev;
        }

        public static float Cp(float Upper, float Lower, float StDev)
        {
            float tempV = 0f;
            tempV = Upper - Lower;
            return Math.Abs(tempV / (6 * StDev));
        }

        public static float Avage(float[] arrData)
        {
            float tempSum = 0f;

            int length = arrData.Length;

            for (int i = 0; i < length; i++)
            {
                tempSum += arrData[i];
            }

            return tempSum / length;
        }


        public static float Max(float[] arrData)
        {
            float tempMax = 0f;

            int length = arrData.Length;

            for (int i = 0; i < length; i++)
            {
                if (tempMax < arrData[i])
                {
                    tempMax = arrData[i];
                }
            }
            return tempMax;
        }


        public static float Min(float[] arrData)
        {
            float tempMin = 0f;

            int length = arrData.Length;

            for (int i = 0; i < length; i++)
            {
                if (tempMin > arrData[i])
                {
                    tempMin = arrData[i];
                }
            }

            return tempMin;
        }

        public static float CpkU(float Upper, float Avage, float StDev)
        {
            float tempV = 0f;

            tempV = Upper - Avage;

            return tempV / (3 * StDev);
        }

        public static float CpkL(float Lower, float Avage, float StDev)
        {
            float tempV = 0f;

            tempV = Avage - Lower;

            return tempV / (3 * StDev);
        }

        public static float Cpk(float cpkU, float cpkL)
        {
            return Math.Abs(Math.Min(cpkU, cpkL));
        }
    }
}
