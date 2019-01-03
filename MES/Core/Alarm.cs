using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Core
{
    public class Alarm
    {
        private enum AlarmType
        {
            XAxesError = 1,
            YAxesError = 2,
            ZAxesError = 3,
            RAxesError = 4,
            /// <summary>
            /// 焊接马达错误
            /// </summary>
            WeldMotorError = 5,
            /// <summary>
            /// 旋转马达错误
            /// </summary>
            RotaryMotorError = 6,
            /// <summary>
            /// 下料电机错误
            /// </summary>
            BlanderMotorError = 7,
            /// <summary>
            /// 检测电机错误
            /// </summary>
            CheckMotorError = 8,

            /// <summary>
            /// 安全门1打开
            /// </summary>
            SafeDoor1On = 9,
            /// <summary>
            /// 安全门2打开
            /// </summary>
            SafeDoor2On = 10,
            /// <summary>
            /// 安全门3打开
            /// </summary>
            SafeDoor3On = 11,
            /// <summary>
            /// 安全门4打开
            /// </summary>
            SafeDoor4On = 12,
            /// <summary>
            /// 扫码超时
            /// </summary>
            ScanTimeOut = 13,
            /// <summary>
            /// 机器人上料超时
            /// </summary>
            RobotMaterialTimeOut = 14,
            /// <summary>
            /// 机器人焊接上料超时
            /// </summary>
            RobotWeldMaterialTimeOut = 15,
            /// <summary>
            /// OK下料超时
            /// </summary>
            OKDownMaterialTimeOut = 16,
            /// <summary>
            /// NG下料超时
            /// </summary>
            NGDownMaterialTimeOut = 17,
            /// <summary>
            /// 二维码NG品下料超时
            /// </summary>
            BarCodeNGTimeOut = 18,
            /// <summary>
            /// 压料气缸下压异常
            /// </summary>
            DownMotorException = 19,
            /// <summary>
            /// 压料气缸上升异常
            /// </summary>
            UpMotorException = 20,


        }

        public static string SortAlarmL(int type)
        {
            string alarm = string.Empty;

            switch (type)
            {
                case 1:
                    alarm = "X轴错误";
                    break;
                case 2:
                    alarm = "Y轴错误";
                    break;
                case 3:
                    alarm = "Z轴错误";
                    break;
                case 4:
                    alarm = "R轴错误";
                    break;
                case 5:
                    alarm = "焊接马达错误";
                    break;
                case 6:
                    alarm = "旋转马达错误";
                    break;
                case 7:
                    alarm = "下料电机错误";
                    break;
                case 8:
                    alarm = "检测电机错误";
                    break;
                case 9:
                    alarm = "安全门1开";
                    break;
                case 10:
                    alarm = "安全门2开";
                    break;
                case 11:
                    alarm = "安全门3开";
                    break;
                case 12:
                    alarm = "安全门4开";
                    break;
                case 13:
                    alarm = "扫码超时";
                    break;
                case 14:
                    alarm = "机器人上料超时";
                    break;
                case 15:
                    alarm = "机器人焊接上料超时";
                    break;
                case 16:
                    alarm = "OK下料超时";
                    break;
                case 17:
                    alarm = "NG下料超时";
                    break;
                case 18:
                    alarm = "二维码NG品下料超时";
                    break;
                case 19:
                    alarm = "压料气缸下压异常";
                    break;
                case 20:
                    alarm = "压料气缸上升异常";
                    break;
                case 21:
                    alarm = "安全门打开异常";
                    break;
                case 22:
                    alarm = "安全门关闭异常";
                    break;
                case 23:
                    alarm = "抽烟气缸前进异常";
                    break;
                case 24:
                    alarm = "抽烟气缸后退异常";
                    break;
                case 25:
                    alarm = "擦洗气缸下压异常";
                    break;
                case 26:
                    alarm = "擦洗气缸上升异常";
                    break;
                case 27:
                    alarm = "下料气缸前进异常";
                    break;
                case 28:
                    alarm = "大环压紧切换气缸伸出异常";
                    break;
                case 29:
                    alarm = "大环压紧切换气缸缩回异常";
                    break;
                case 30:
                    alarm = "机器人错误";
                    break;
                case 31:
                    alarm = "机器人初始化超时";
                    break;
                case 32:
                    alarm = "3D检测超时";
                    break;
                case 33:
                    alarm = "下料异常";
                    break;
                case 34:
                    alarm = "激光上高压异常";
                    break;
                case 35:
                    alarm = "下料气缸后退异常";
                    break;
                case 36:
                    alarm = "安全门1开启";
                    break;
                case 37:
                    alarm = "安全门2开启";
                    break;
                case 38:
                    alarm = "急停中";
                    break;
                case 39:
                    alarm = "气压报警";
                    break;
                case 40:
                    alarm = "流量报警";
                    break;
                case 41:
                    alarm = "焊接无料报警";
                    break;
                case 42:
                    alarm = "机器人没抓住料报警";
                    break;
                case 43:
                    alarm = "圆盘1号工位放料报警";
                    break;
                case 44:
                    alarm = "圆盘5号工位取料报警";
                    break;
                case 45:
                    alarm = "保护气流量异常";
                    break;
                case 46:
                    alarm = "压紧气压异常";
                    break;
                case 47:
                    alarm = "横吹压力报警";
                    break;
                case 49:
                    alarm = "机器人传感器异常";
                    break;

                default:
                    alarm = "未知异常";
                    break;
            }

            return alarm;
        }

        public static string SortAlarmS(int type)
        {
            string alarm = string.Empty;

            switch (type)
            {
                case 1:
                    alarm = "X轴错误";
                    break;
                case 2:
                    alarm = "Y轴错误";
                    break;
                case 3:
                    alarm = "Z轴错误";
                    break;
                case 4:
                    alarm = "R轴错误";
                    break;
                case 5:
                    alarm = "焊接马达错误";
                    break;
                case 6:
                    alarm = "旋转马达错误";
                    break;
                case 7:
                    alarm = "下料电机错误";
                    break;
                case 8:
                    alarm = "检测电机错误";
                    break;
                case 9:
                    alarm = "安全门1开";
                    break;
                case 10:
                    alarm = "安全门2开";
                    break;
                case 11:
                    alarm = "安全门3开";
                    break;
                case 12:
                    alarm = "安全门4开";
                    break;
                case 13:
                    alarm = "扫码超时";
                    break;
                case 14:
                    alarm = "机器人上料超时";
                    break;
                case 15:
                    alarm = "机器人焊接上料超时";
                    break;
                case 16:
                    alarm = "OK下料超时";
                    break;
                case 17:
                    alarm = "NG下料超时";
                    break;
                case 18:
                    alarm = "二维码NG品下料超时";
                    break;
                case 19:
                    alarm = "拍照后PC未给回馈=2";
                    break;
                case 20:
                    alarm = "报警备用3";
                    break;
                case 21:
                    alarm = "安全门打开异常";
                    break;
                case 22:
                    alarm = "安全门关闭异常";
                    break;
                case 23:
                    alarm = "抽烟气缸前进异常";
                    break;
                case 24:
                    alarm = "抽烟气缸后退异常";
                    break;
                case 25:
                    alarm = "擦洗气缸下压异常";
                    break;
                case 26:
                    alarm = "擦洗气缸上升异常";
                    break;
                case 27:
                    alarm = "下料气缸前进异常";
                    break;
                case 28:
                    alarm = "报警备用1";
                    break;
                case 29:
                    alarm = "机器人错误";
                    break;
                case 30:
                    alarm = "报警备用2";
                    break;
                case 31:
                    alarm = "机器人初始化超时";
                    break;
                case 32:
                    alarm = "3D检测超时";
                    break;
                case 33:
                    alarm = "下料异常";
                    break;
                case 34:
                    alarm = "下料气缸后退异常";
                    break;
                case 35:
                    alarm = "安全门1开启";
                    break;
                case 36:
                    alarm = "安全门2开启";
                    break;
                case 37:
                    alarm = "急停中";
                    break;
                case 38:
                    alarm = "激光上高压异常";
                    break;
                case 39:
                    alarm = "气压报警";
                    break;
                case 40:
                    alarm = "流量报警";
                    break;
                case 41:
                    alarm = "焊接无料报警";
                    break;
                case 42:
                    alarm = "机器人没抓住料报警";
                    break;
                case 43:
                    alarm = "圆盘1号工位放料报警";
                    break;
                case 44:
                    alarm = "圆盘5号工位取料报警";
                    break;
                case 45:
                    alarm = "保护气流量异常";
                    break;
                case 46:
                    alarm = "压紧气压异常";
                    break;
                case 47:
                    alarm = "横吹压力报警";
                    break;
                case 48:
                    alarm = "报警备用4";
                    break;
                case 49:
                    alarm = "机器人传感器异常";
                    break;

                default:
                    alarm = "未知异常";
                    break;
            }

            return alarm;
        }


    }
}
