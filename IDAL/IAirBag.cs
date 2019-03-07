using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAirBag
    {
        ServiceResult IsExist(string barcode);

        int GetCountByCondition(string sqlCondition);

        int GetTotalCount();

        int GetOKCount();

        int GetNgCount();

        ServiceResult UpdateManaulCheck(string BarCode, string NewResult, string Reason, string Operator);

    }
}
