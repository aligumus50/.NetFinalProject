using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //EF olarak bir repository base i oluşturacağız.

    //TEntiy: Bana bi tane çalışacağım tablo ver.
    //TContext: Bana bi tane çalışacağım context ver.

    //Kuracağımız yapı ile yeni bir tablo eklendiğinde ekle,sil,güncelle,filtreleme operasyonlarını tekrar tekrar yazmayacağız.

    //Bu katmana da nuget package den EF sql server i ekliyoruz.
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity> 
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using kısaca işi bitince belleği temizlemesi için kullandık.
            using (TContext context = new TContext())
            {
                //Git veri kaynağından benim gönderdiğim productı bir tane nesneyi eşleştir.
                //veri kaynağı ile ilişkilendirme
                //referansı yakalama tarafı.
                var addedEntity = context.Entry(entity);

                //Ekleme olacağı için herhangi bir eşleşme olmayacağı için ekleme yapar.
                //Onuda burada belirtiyoruz.
                //ilişkilendirme sonrası ne yapacağı.
                addedEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                /*context.Set<Product>().ToList() 
                //Dbsetteki Product a yerleş. Veritabanındaki tabloyu listeye döndür.
                //Kısaca select * from product*/

                return filter == null
                  ? context.Set<TEntity>().ToList()
                  : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
