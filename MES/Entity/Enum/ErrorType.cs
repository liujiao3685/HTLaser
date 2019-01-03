using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Entity
{
    public enum ErrorType
    {
        /// <summary>
        /// LWM报警
        /// </summary>
        LWMError = 101,

        /// <summary>
        /// CCD报警
        /// </summary>
        CCDError = 102,

        /// <summary>
        /// 视觉报警
        /// </summary>
        VisionError = 103,

        /// <summary>
        /// 扫描枪报警
        /// </summary>
        ScanError = 104,

        /// <summary>
        /// 激光设备异常
        /// </summary>
        LaserDevice = 105,

        /// <summary>
        /// 转盘报警
        /// </summary>
        ZhuanPanError= 106,

        /// <summary>
        /// 机器人报警   
        /// </summary>
        RobotError = 107,


    }
}
