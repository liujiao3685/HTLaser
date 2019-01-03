using System;

namespace MES.Entity
{
    public class Product
    {
        /// <summary>
        /// 设备ID
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string PNo { set; get; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public string PType { set; get; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public string Status { set; get; }

        /// <summary>
        /// 同心度(大环：-0.15~0.2，小环：-0.3~0.3)
        /// </summary>
        public double Coaxiality { set; get; }

        /// <summary>
        /// 表面成型
        /// </summary>
        public string Surface { set; get; }

        /// <summary>
        /// 大环焊缝
        /// </summary>
        public double WeldDepth { set; get; }

        /// <summary>
        /// 焊接功率
        /// </summary>
        public double WeldPower { set; get; }

        /// <summary>
        /// 焊接速率
        /// </summary>
        public int WeldSpeed { set; get; }

        /// <summary>
        /// Lwm检查结果
        /// </summary>
        public string LwmCheck { set; get; }

        /// <summary>
        /// 焊接时间 Float
        /// </summary>
        public int WeldTime { set; get; }

        /// <summary>
        /// 坐标轴
        /// </summary>
        //public string XYZRPos { set; get; }

        /// <summary>
        /// 坐标X
        /// </summary>
        public double XPos { set; get; }

        /// <summary>
        /// 坐标Y
        /// </summary>
        public double YPos { set; get; }

        /// <summary>
        /// 坐标Z
        /// </summary>
        public double ZPos { set; get; }

        /// <summary>
        /// 坐标R
        /// </summary>
        public double RPos { set; get; }

        /// <summary>
        /// 压力值
        /// </summary>
        public double Pressure { set; get; }

        /// <summary>
        /// 流量值
        /// </summary>
        public double Flow { set; get; }

        /// <summary>
        /// 最终检测结果（Pass/Ng）
        /// </summary>
        public string QCResult { set; get; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime StorageTime { set; get; }

        /// <summary>
        /// 人工干预
        /// </summary>
        public string ManualCheck { set; get; }

        public Product()
        {
            Id = 1;
            PNo = "PNO001";
            Surface = "表面平滑";
            WeldPower = 4000;
            WeldSpeed = 40;
            WeldTime = 0;
            LwmCheck = "合格";
            Pressure = 1.0;
            Flow = 1.0;
            QCResult = "Pass";
            ManualCheck = String.Empty;
        }

    }

}