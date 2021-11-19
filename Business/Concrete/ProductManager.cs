using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
       IProductDal _productDal;

        //ProductManager newlendiğinde bana bir product dal referansı ver(inMemory olabilir, EF olabilir, NHibernate de olabilir.)
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //varsa iş kodları yazılır burada.
            //if ler yazılır.

            //iş kodlarını geçtikten sonra veri erişimi çağırmamız gerek.

            return _productDal.GetAll();
        }
    }
}
