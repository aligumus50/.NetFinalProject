using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //EfEntityRepositoryBase<Product,NorthwindContext>: Bu ifade IProductDal ın kızdığı, implemente et dediği operasyonlar bunda mevcut.
    //Bende ondan inherit ediliyorum.

    //Sen aynı zamanda IProductDal'sın (kim olduğunu unutma :) ) - Veri tabanına ait özel operasyonlar olabilir.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

        //yorum satırı
        #region
        /*
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
                //context.Set<Product>().ToList() 
                //Dbsetteki Product a yerleş. Veritabanındaki tabloyu listeye döndür.
                //Kısaca select * from product

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
        }*/
        #endregion
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //context tablomuza karşılık geliyor.
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto //Hangi kolonları istediğimiz. Sonucu bu kolonlara uydurarak ver.
                             {
                                 ProductId = p.ProductId, ProductName = p.ProductName,
                                 CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock
                             };

                return result.ToList(); //dönen result sonucu Iqueryable dir.

            }
        }
    }
}
