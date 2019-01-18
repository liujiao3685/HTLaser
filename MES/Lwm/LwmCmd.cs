using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Lwm
{
    public struct FunctionCmd
    {
        /// <summary>
        /// Close TCP/IP connection (socket)
        /// </summary>
        public int CloseTcp => 0x00000007;

        /// <summary>
        /// Request configuration as binary file
        /// </summary>
        public int RequestConfig => 0x00100000;

        /// <summary>
        /// Send component part number
        /// </summary>
        public int SendComponent => 0x00110000;

        /// <summary>
        /// Enable/configure result transfer 
        /// </summary>
        public int EnableResult => 0x00120000;

        /// <summary>
        /// Last measurement result: total result and areas 
        /// </summary>
        public int LastMeasurementAreas => 0x00120100;

        /// <summary>
        /// Last measurement result: total result with values 
        /// </summary>
        public int LastMeasurementValues => 0x00120300;


    }

    public class LwmCmd
    {
    }
}
