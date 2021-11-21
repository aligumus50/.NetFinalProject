using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using kısaca işi bitince belleği temizlemesi için kullandık.
            using (NorthwindContext context = new NorthwindContext())
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

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                /*context.Set<Product>().ToList() 
                //Dbsetteki Product a yerleş. Veritabanındaki tabloyu listeye döndür.
                //Kısaca select * from product*/

                return filter == null
                  ? context.Set<Product>().ToList()
                  : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
