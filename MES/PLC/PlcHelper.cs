using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.PLC
{
    public class PlcHelper
    {
        #region 通讯地址相关-单个

        /// <summary>
        /// 产品条码指令
        /// </summary>
        public static readonly string OPC_DB_BarCode = "ns=3;s=\"WeldPara\".\"BarCode\"";

        /// <summary>
        /// CCD通讯指令
        /// 1：开始采集
        /// </summary>
        public static readonly string OPC_DB_CcdOrder = "ns=3;s=\"WeldPara\".\"CCDOrder\"";

        /// <summary>
        /// 视觉采集(焊接)通讯指令
        /// 1：开启，2、关闭
        /// </summary>
        public static readonly string OPC_DB_VisionOrder = "ns=3;s=\"WeldPara\".\"VisionOrder\"";

        /// <summary>
        /// 视觉结果反馈指令
        /// </summary>
        public static readonly string OPC_DB_VisionResult = "ns=3;s=\"WeldPara\".\"VisionResult\"";

        /// <summary>
        /// 在线离线指令
        /// 1：在线，2：离线
        /// </summary>
        public static readonly string OPC_DB_OffLine = "ns=3;s=\"WeldPara\".\"OffLine\"";

        /// <summary>
        /// 扫码指令
        ///  bool  true：开始，false：停止
        /// </summary>
        public static readonly string OPC_DB_StartScan = "ns=3;s=\"WeldPara\".\"StartScan\"";

        /// <summary>
        /// LWM采集指令
        /// </summary>
        public static readonly string OPC_DB_LwmSign = "ns=3;s=\"WeldPara\".\"LwmSign\"";

        /// <summary>
        /// 发送条码给LWM地址
        /// </summary>
        public static readonly string OPC_DB_LwmCode = "ns=3;s=\"WeldPara\".\"LwmCode\"";

        /// <summary>
        /// Lwm发送条码指令
        /// </summary>
        public static readonly string OPC_DB_SendLwmCode = "ns=3;s=\"WeldPara\".\"SendLwmCode\"";

        /// <summary>
        /// LWM结果指令
        /// 1:OK  2:NG
        /// </summary>
        public static readonly string OPC_DB_LwmCheck = "ns=3;s=\"WeldPara\".\"LwmCheck\"";

        /// <summary>
        /// 扫码结果反馈指令
        /// 1：成功，2：失败，3：异常
        /// </summary>
        public static readonly string OPC_DB_ScanCallBack = "ns=3;s=\"WeldPara\".\"ScanCallBack\"";

        /// <summary>
        /// 设备状态指令
        /// 1、运行	 2、暂停  3、报警  4、离线
        /// </summary>
        public static readonly string OPC_DB_Light = "ns=3;s=\"WeldPara\".\"Light\"";

        /// <summary>
        /// 提醒自检指令
        /// </summary>
        public static readonly string OPC_DB_WarnCheck = "ns=3;s=\"WeldPara\".\"WarnCheck\"";


        #endregion 

        #region 通讯地址相关-批量

        /// <summary>
        /// 小环批量采集地址
        /// </summary>
        public static string[] Nodes_S =
        {
            "ns=3;s=\"WeldPara\".\"Xpos\"",
            "ns=3;s=\"WeldPara\".\"Ypos\"",
            "ns=3;s=\"WeldPara\".\"Zpos\"",
            "ns=3;s=\"WeldPara\".\"Wpos\"",
            "ns=3;s=\"WeldPara\".\"AvgPower\"",
            "ns=3;s=\"WeldPara\".\"AvgPressure\"",
            "ns=3;s=\"WeldPara\".\"AvgFlow\"",

            "ns=3;s=\"WeldPara\".\"FlowUp\"",
            "ns=3;s=\"WeldPara\".\"FlowDown\"",

            "ns=3;s=\"WeldPara\".\"WeldSpeed\"",
            "ns=3;s=\"WeldPara\".\"WeldTime\"",
            "ns=3;s=\"WeldPara\".\"BarCodeCircle3\"",
            "ns=3;s=\"WeldPara\".\"Coaxiality\"",
            "ns=3;s=\"WeldPara\".\"Surface\"",
            "ns=3;s=\"WeldPara\".\"LwmCheck\""
        };

        /// <summary>
        /// 大环批量采集地址
        /// </summary>
        public static string[] Nodes_L =
        {
            "ns=3;s=\"WeldPara\".\"Xpos\"",
            "ns=3;s=\"WeldPara\".\"Ypos\"",
            "ns=3;s=\"WeldPara\".\"Zpos\"",
            "ns=3;s=\"WeldPara\".\"Wpos\"",
            "ns=3;s=\"WeldPara\".\"AvgPower\"",
            "ns=3;s=\"WeldPara\".\"AvgPressure\"",
            "ns=3;s=\"WeldPara\".\"AvgFlow\"",

            "ns=3;s=\"WeldPara\".\"FlowUp\"",
            "ns=3;s=\"WeldPara\".\"FlowDown\"",

            "ns=3;s=\"WeldPara\".\"WeldSpeed\"",
            "ns=3;s=\"WeldPara\".\"WeldTime\"",
            "ns=3;s=\"WeldPara\".\"BarCodeWeld\"",
            "ns=3;s=\"WeldPara\".\"LwmCheck\""
        };

        #endregion
    }
}
