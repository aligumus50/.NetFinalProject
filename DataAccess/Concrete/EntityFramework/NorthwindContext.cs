using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile projedeki veri tabanı classlarını birbiriyle ilişkilendirmek için.
    //DbContext entity framework ile gelen base bir sınıf.
    public class NorthwindContext:DbContext
    {
        //Bu metot projemizin hangi veritabanı ile ilişkilendireceğimizi belirten kısımdır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sql server kullanacağız.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //Veritabanı bağladık ama hangi nesne hangi nesneye karşılık gelecek onuda burada yapıyoruz.
        //Product classım Products tablosuna karşılık geliyor.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Bundan sonra EF kullanarak kodlarımızı yazabiliriz.
    }
}
