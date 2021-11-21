using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //T çalışacağımız tiptir.

    //Herkes istediği T yi yazamasın diye generic constraint(kısıt) kullanıyoruz.

    //class: referans tip olabilir.

    //Herhangi bi referans tipte yazılabilir bunun içinde IEntity kullandık.

    //Hem referans tip olacak hem de ya IEntity ya da IEntity yi implemente eden bir nesne.

    //new() newlenebilir olmalı. IEntity i devre dışı bırakmak içinde new kullandık. IEntity interface newlenemez.

    //Sistemimiz gerçekten veri tabanı nesneleriyle çalışan repository oldu.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Filtreleme yapabilmek için expression kullandık.
        //Kategoriye göre getir, ürün bilgisine göre getir, fiyatına göre getir gibi ayrı ayrı metot yazmak yerine bu yapıyı kullandık.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //Yukarıda kurulan yapıdan dolayı aşağıdaki metota gerek yok.
        //List<T> GetAllByCategory(int categoryId);
    }
}
