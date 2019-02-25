using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ISaveWeldingData
    {
        ServiceResult SaveWeldingDataS(double WeldPower, int WeldSpeed, double Flow, double FlowUp, double FlowDown, double Pressure,
            double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality, double CoaxUp, double CoaxDown,
            string Surface, bool LwmCheck, bool QCResult, string PNo);

        ServiceResult SaveWeldingDataL(double WeldPower, int WeldSpeed, double Flow, double FlowUp, double FlowDown, double Pressure,
            double WeldDepth, double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality, double CoaxUp, double CoaxDown,
            string Surface, bool LwmCheck, bool QCResult, string PNo);

        ServiceResult SaveWeldingDataS(double WeldPower, int WeldSpeed, double Flow, double Pressure,
            double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality,
            string Surface, bool LwmCheck, bool QCResult, string PNo);

        ServiceResult SaveWeldingDataL(double WeldPower, int WeldSpeed, double Flow, double Pressure,
            double WeldDepth, double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality,
            string Surface, bool LwmCheck, bool QCResult, string PNo);

    }
}
