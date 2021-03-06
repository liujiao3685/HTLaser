﻿using DALFactory;
using IDAL;
using Model;
using System;

namespace BLL
{
    public class Welding
    {
        public Action<bool> WeldSuccessCallBack;

        public ISaveWeldingData idal = DALAccess.CreateSaveWeldingData();

        #region 成员方法

        public ServiceResult SaveWeldingDataL(WeldingInfo weldingInfo)
        {
            return idal.SaveWeldingDataL(weldingInfo);
        }
        public ServiceResult SaveWeldingDataS(WeldingInfo weldingInfo)
        {
            return idal.SaveWeldingDataS(weldingInfo);
        }

        public ServiceResult SaveWeldingDataL(double WeldPower, int WeldSpeed, double Flow, double FlowUp, double FlowDown, double Pressure,
           double WeldDepth, double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality, double CoaxUp, double CoaxDown,
           string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            return idal.SaveWeldingDataL(WeldPower, WeldSpeed, Flow, FlowUp, FlowDown, Pressure, WeldDepth, WeldTime, XPos, YPos, ZPos, RPos, Coaxiality,
                CoaxUp, CoaxDown, Surface, LwmCheck, QCResult, PNo);
        }

        public ServiceResult SaveWeldingDataS(double WeldPower, int WeldSpeed, double Flow, double FlowUp, double FlowDown, double Pressure,
         double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality, double CoaxUp, double CoaxDown,
         string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            return idal.SaveWeldingDataS(WeldPower, WeldSpeed, Flow, FlowUp, FlowDown, Pressure, WeldTime, XPos, YPos, ZPos, RPos, Coaxiality,
                CoaxUp, CoaxDown, Surface, LwmCheck, QCResult, PNo);
        }


        public ServiceResult SaveWeldingDataL(double WeldPower, int WeldSpeed, double Flow, double Pressure,
           double WeldDepth, double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality,
           string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            return idal.SaveWeldingDataL(WeldPower, WeldSpeed, Flow, Pressure, WeldDepth, WeldTime, XPos, YPos, ZPos, RPos, Coaxiality,
                Surface, LwmCheck, QCResult, PNo);
        }

        public ServiceResult SaveWeldingDataS(double WeldPower, int WeldSpeed, double Flow, double Pressure,
         double WeldTime, double XPos, double YPos, double ZPos, double RPos, double Coaxiality,
         string Surface, bool LwmCheck, bool QCResult, string PNo)
        {
            return idal.SaveWeldingDataS(WeldPower, WeldSpeed, Flow, Pressure, WeldTime, XPos, YPos, ZPos, RPos, Coaxiality,
                 Surface, LwmCheck, QCResult, PNo);
        }

        #endregion

        public void DoWeldResultCallBack(bool result)
        {
            WeldSuccessCallBack?.Invoke(result);
        }

    }
}
