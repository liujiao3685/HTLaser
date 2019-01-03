using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaTianProject.Entity
{
    public class Param
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParamName { set; get; }

        /// <summary>
        /// 参数最大值
        /// </summary>
        public double MaxValue { set; get; }

        /// <summary>
        /// 参数最小值
        /// </summary>
        public double MinValue { set; get; }

        /// <summary>
        /// 设定参数值
        /// </summary>
        public double ParamValue { set; get; }

        /// <summary>
        /// 参数单位
        /// </summary>
        public string ParamUnit { set; get; }

        /// <summary>
        /// 参数备注
        /// </summary>
        public string Remark { set; get; }

        /// <summary>
        /// 参数集合
        /// </summary>
        public List<Param> ListParams { set; get; }

    }
}
