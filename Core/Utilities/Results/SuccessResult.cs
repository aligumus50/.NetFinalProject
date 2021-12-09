using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //base e (Result a) 2 parametreliye gönderir.
        {
        }

        public SuccessResult() : base(true) //base e (Result a) tek parametreliye gönderir.
        {
        }
    }
}
