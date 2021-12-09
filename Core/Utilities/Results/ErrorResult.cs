using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message) //base e (Result a) 2 parametreliye gönderir.
        {
        }

        public ErrorResult() : base(false) //base e (Result a) tek parametreliye gönderir.
        {
        }
    }
}
