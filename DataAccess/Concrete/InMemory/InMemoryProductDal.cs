﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        List<Product> _products;

        //Bellekte referans aldığında çalışacak olan blok.
        public InMemoryProductDal()
        {
            //oracle,sql server,postgres,mongo dbden geliyormuş gibi simule ediyoruz.
            _products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1},

            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
           //Gönderdiğim ürün id sine sahip olan listedeki ürünü bul.
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

        public void Delete(Product product)
        {
            //productToDelete silinecek ürün.

            Product productToDelete=null;

            //LINQ olmasaydı listeyi tek tek dolaşacaktık.
            /*foreach (var p in _products)
            {
                if (product.ProductId==p.ProductId)
                {
                    //tüm _productsları gezdik ve referansını attık.
                    productToDelete = p;
                }
            }*/

            //LINQ(Language Integrated Query) Dile gömülü sorgu
            //LINQ ile çözüm;

            //SingleOrDefault foreach yap demek - ürünleri tek tek gezmek için (p=> her p için)
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //elindeki şarta uyan elemanları yeni bir liste haline getirip onu dönderir.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
