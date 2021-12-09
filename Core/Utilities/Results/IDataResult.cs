using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //T: Hangi tipi döndereceği.
    public interface IDataResult <T> : IResult //Data dışında hem mesaj hem de işlem sonucunu içersin diye implemente ettik.
    {
        T Data { get; }
    }
}
