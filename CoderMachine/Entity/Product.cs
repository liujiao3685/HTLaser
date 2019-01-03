using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderMachine
{
    public class Product
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public string PID { set; get; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpNo { set; get; }

        /// <summary>
        /// 雷管编号
        /// </summary>
        public string TubeNo { set; get; }

        /// <summary>
        /// 电流值
        /// </summary>
        public double CurrentVal { set; get; }

        /// <summary>
        /// 是否合格
        /// </summary>
        public int Pass { set; get; }

        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime ProductTime { set; get; }

        public override string ToString()
        {
            string id = "ID：" + PID + "\r\n";

            string current = "电流值：" + CurrentVal.ToString() + "\r\n";

            string pass = "是否合格：" + Pass.ToString() + "\r\n";

            return id + current + pass;
        }


    }
}
