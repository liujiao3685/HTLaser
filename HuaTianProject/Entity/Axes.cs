using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaTianProject.Entity
{
    public class Axes
    {
        public enum AxisType
        {
            /// <summary>
            /// X轴
            /// </summary>
            [Description("X轴")]
            X = 0,

            /// <summary>
            /// Y轴
            /// </summary>
            [Description("Y轴")]
            Y = 1,

            /// <summary>
            /// Z轴
            /// </summary>
            [Description("Z轴")]
            Z = 2,

            /// <summary>
            /// W轴
            /// </summary>
            [Description("W轴")]
            W = 3
        }

        public int X { set; get; }

        public int Y { set; get; }

        public int Z { set; get; }

        public int W { set; get; }

    }
}
