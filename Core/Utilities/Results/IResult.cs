using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç - işlem sonuçları
    public interface IResult
    {
        //get: sadece okunabilir.
        bool Success { get; } //Yampaya çalışılan işlem başarılı ya da başarısız
        string Message { get; } //İşlem sonucuna göre dönderilecek mesaj
    }
}
