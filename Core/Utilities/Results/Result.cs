using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Getterlar readonlydir ve constructor da set edilebilir.
        //Setter koymadık çünkü kodlayıcı kafasına göre kodlayabilir. Bu şekilde sınırlama getirdik.

        //Result new lendiğinde çalışacak blok.

        //Tek parametre gelirse sadece 15. satır çalışır. İki parametre gelirse 15. satır yanında 24. satır da çalışır. : this()
        public Result(bool success, string message) : this(success) //Result ın tek parametreli olan constructor una succesi yolla.
        {

            Message = message;
            //Success = success; //Bu kodu yazarsak kod tekrarı yapmış oluruz. Hemde 13. satır çalışırsa 24. satırda çalışmış olur.

        }

        //İşlem sonucunda mesaj bilgisi vermesin istiyorsak. overload yaptık.
        public Result(bool success)
        {

            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
