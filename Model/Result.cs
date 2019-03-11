using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Result
    {
        public bool IsSuccess { set; get; }

        public string Msg { set; get; }

        public byte[] Content { set; get; }


        public Result(bool isSuccess, string msg, byte[] content)
        {
            IsSuccess = isSuccess;
            Msg = msg;
            Content = content;
        }
    }
}
