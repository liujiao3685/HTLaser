using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Lwm
{
    public class LwmData
    {
        public LwmData()
        {
            Comment = new char[80];
            LwmDataTime = new Int16[6];
        }

        /// <summary>
        /// 报文ID
        /// </summary>
        public int TelegramId { set; get; }

        /// <summary>
        /// 状态
        /// 0=>no error 
        /// </summary>
        public int Statue { set; get; }

        /// <summary>
        /// 数据长度
        /// </summary>
        public int Length { set; get; }

        /// <summary>
        /// 程序号
        /// 0 - 255; –1 
        /// </summary>
        public int ProgramNo { set; get; }

        /// <summary>
        /// ID number of the configuration
        /// Value >0 
        /// </summary>
        public int ConfigId { set; get; }

        /// <summary>
        /// Configuration version
        /// Value>0
        /// </summary>
        public int ConfigVersion { set; get; }

        /// <summary>
        /// 0=> OK, > 0 => NOK 
        /// </summary>
        public int TotalResult { set; get; }

        /// <summary>
        /// More detailed result information
        /// >=0
        /// </summary>
        public int MoreResult { set; get; }

        /// <summary>
        /// 0:on 1:off
        /// </summary>
        public int ErrorSignOutput { set; get; }

        /// <summary>
        /// Measurement ID
        /// Value>0
        /// </summary>
        public int MeasurementID { set; get; }

        /// <summary>
        /// 0-78
        /// </summary>
        public int CommentLength { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public char[] Comment { set; get; }

        /// <summary>
        /// Date, time (YYYY, MM, DD, hh, mm, ss)
        /// </summary>
        public Int16[] LwmDataTime { set; get; }

        /// <summary>
        /// 区间
        /// 0 - 100
        /// </summary>
        public int Area { set; get; }

        /// <summary>
        /// 区间结果
        /// </summary>
        public uint AreaResult { set; get; }

        /// <summary>
        /// 区间编号
        /// 0 - 100
        /// </summary>
        public int AreaNumber { set; get; }

    }

    public class LwmAreaData
    {
        /// <summary>
        /// 区间编号
        /// </summary>
        public int AreaNumber { set; get; }

        /// <summary>
        /// 区间结果
        /// Area result per sensor
        /// </summary>
        public int AreaResult { set; get; }

        /// <summary>
        /// Max. limit top
        /// >=0
        /// </summary>
        public float MaxLimitTop { set; get; }

        /// <summary>
        /// Max. limit bottom
        /// >=0
        /// </summary>
        public float MaxLimitBottom { set; get; }

        /// <summary>
        /// >=0
        /// </summary>
        public float MaxAreaTop { set; get; }

        /// <summary>
        /// >=0
        /// </summary>
        public float MaxAreaButtom { set; get; }

        /// <summary>
        /// 部分
        /// >=0
        /// </summary>
        public float Integral { set; get; }

        public float ErrorFrequencyTop { set; get; }

        public float ErrorFrequencyButtom { set; get; }

        /// <summary>
        /// >=0
        /// </summary>
        public float SquareDeviationValue { set; get; }

        /// <summary>
        /// 0: OK, 1: NOK, –1: OFF
        /// </summary>
        public int IntegraError { set; get; }

        /// <summary>
        /// 0: OK, 1: NOK, –1: OFF
        /// </summary>
        public int ErrorFrequencyTopError { set; get; }

        /// <summary>
        /// 0: OK, 1: NOK, –1: OFF
        /// </summary>
        public int ErrorFrequencyButtonError { set; get; }

        /// <summary>
        ///  Square deviation from mean value error
        ///  0: OK, 1: NOK, –1: OFF
        /// </summary>
        public int SquareDeviationValueError { set; get; }

        /// <summary>
        /// >=0, –1: OFF 
        /// </summary>
        public int AmplitudeErrorsNum { set; get; }

        /// <summary>
        /// >=0, –1: OFF 
        /// </summary>
        public int AreaErrorsNum { set; get; }

    }

}
