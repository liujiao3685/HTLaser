using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderMachine.Serial
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        public byte[] Content { get; set; }

        public string ErrMsg { get; set; }

        public Result(bool issuccess, string msg, byte[] content)
        {
            IsSuccess = issuccess;
            ErrMsg = msg;
            Content = content;
        }
    }
}
