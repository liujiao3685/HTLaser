using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IFailSafe
    {
        ServiceResult CheckSmall(string barcode);

        ServiceResult CheckLarge(string barcode);

    }
}
