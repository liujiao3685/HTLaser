using IDAL;
using Model;

namespace BLL
{
    public partial class FailSafe
    {
        public IFailSafe idal = DALFactory.DALAccess.CreateFailSafe();

        public ServiceResult CheckLarge(string BarCode)
        {
            return idal.CheckLarge(BarCode);
        }

        public ServiceResult CheckSmall(string BarCode)
        {
            return idal.CheckSmall(BarCode);
        }

    }
}
