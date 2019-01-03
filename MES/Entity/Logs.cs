using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Entity
{
    public class Logs
    {
        public int ID { set; get; }

        public int LogID { set; get; }

        public string LogContent { set; get; }

        public string LogResult { set; get; }

        public DateTime HappenTime { set; get; }

        public DateTime DealTime { set; get; }

    }
}
