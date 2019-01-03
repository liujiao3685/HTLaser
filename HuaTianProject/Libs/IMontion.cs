using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaTianProject.Libs
{
    public interface IMontion : IIO
    {
        bool StartMonitorThread();

        bool WaitForAxisMoveDone(ushort axis, int milliseconds);

        void StopAxisMotion(ushort axis);

        bool WaitForAllAxisMotionDone();
    }
}
