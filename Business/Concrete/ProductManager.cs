using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

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
        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business code
            //Eğer böyleyse, şöyleyse gibi işlem kodları burada yazılır.


            //Core katmanına taşıdık. Değişen sadece Product ve ProductValidator.
            #region
            /*var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }*/
            #endregion

            //Bu bir iş kuralı değil validationdur. Burada olmaz. fluent apiye taşıdık.
            #region
            /*if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }*/
            #endregion

            //Tek satırda olsa burası yine çorbaya dönecek. :) O yüzden bunu yapma. Sadece iş kuralı.
            //ValidationTool.Validate(new ProductValidator(), product);
            //Ek olarak Loglama yapılacak.
            //Ek olarak cache remobe yapılacak.
            //Ek olarak performance testi
            //Ek olarak Transaction
            //Ek olarak Yetkilendirme


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //varsa iş kodları yazılır burada.
            //if ler yazılır.

            //iş kodlarını geçtikten sonra veri erişimi çağırmamız gerek.

            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanenceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintanenceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
