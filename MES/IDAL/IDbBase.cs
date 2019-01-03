using System.Data;

namespace MES.IDAL
{
    public interface IDbBase
    {
        string ConnectDbString { set; get; }

        DataTable Select(string sql);

        int Modify(string sql);

        void Open();

        void Close();

    }
}
