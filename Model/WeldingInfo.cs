namespace Model
{
    public class WeldingInfo
    {
        public double WeldXPos { set; get; }

        public double WeldYPos { set; get; }

        public double WeldZPos { set; get; }

        public double WeldRPos { set; get; }

        public double AvgPower { set; get; }

        public double AvgPressure { set; get; }

        public double AvgFlow { set; get; }

        public double FlowUp { set; get; }

        public double FlowDown { set; get; }

        public int AvgSpeed { set; get; }

        public double WeldTime { set; get; }

        public string CurrentBarCode { set; get; }

        public double Coaxiality { set; get; }

        public double CoaxialityUp { set; get; }

        public double CoaxialityDown { set; get; }

        public int SurfaceType { set; get; }

        public string SurfaceInfo { set; get; }

        public int LwmResult { set; get; }

        public bool LwmCheck { set; get; }

        public bool VisionCheck { set; get; }

        public bool QCResult { set; get; }

        public double WeldDepth { set; get; }


    }
}
