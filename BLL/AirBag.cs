using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class AirBag
    {
        public IAirBag idal = DALFactory.DALAccess.CreateAirBag();

        public int GetCountByCondition(string sqlCondition)
        {
            return idal.GetCountByCondition(sqlCondition);
        }

        public int GetTotalCount()
        {
            return idal.GetTotalCount();
        }

        public int GetOKCount()
        {
            return idal.GetOKCount();
        }

        public int GetNgCount()
        {
            return idal.GetNgCount();
        }

        public ServiceResult IsExist(string barCode)
        {
            return idal.IsExist(barCode);
        }

        public ServiceResult UpdateManaulCheck(string BarCode, string NewResult, string Reason, string Operator)
        {
            return idal.UpdateManaulCheck(BarCode, NewResult, Reason, Operator);
        }

    }
}
