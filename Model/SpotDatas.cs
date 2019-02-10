using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SpotDatas
    {
        public int Id { set; get; }

        public string EmpNo { set; get; }

        public float WeldPower { set; get; }

        public float WeldSpeed { set; get; }

        public float WeldPressure { set; get; }

        public float WeldFlow { set; get; }

        public float WeldXPos { set; get; }

        public float WeldYPos { set; get; }

        public float WeldZPos { set; get; }

        public float WeldRPos { set; get; }

        public DateTime SpotTime { set; get; }

        public string SpotResult { set; get; }

        public string FailReason { set; get; }

    }
}
