using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //Controllerda bize yapılabilecek istekler kodlanır.
    //Bizim sistemimizi kullanacak client lerin bize hangi operasyonlar için nasıl istekte bulunabilir. Bunları yazıyoruz.

    [Route("api/[controller]")] //Nasıl istekte bulunacağı. [controller] > controllerin ismidir yani Products.
    [ApiController] //ATTRIBUTE - Javadaki Annotation

    //Bu class bir controllerdir kendini ona göre yapılandır demek kısaca >>> [ApiController]
    //Attribute: class ile ilgili bilgi verme onu imzalama.
    public class ProductsController : ControllerBase //Controller olabilmesi için ControllerBaseden inherit edilmesi gerek.
    {
        //Loosely coupled - Gevşek Bağımlılık
        IProductService _productService;

        //Elimizde ProductService i implemente eden somut bir referans yok.
        //Burada IOC Container -- Inversion Of Controller yapısı kullanılır.
        //Bellekte kutu gibi bir yer ya da liste olarak düşünelim.
        //Bunun içerisine de referanslar koyalım(new ProductManager(), new EFProductDal()). Kim ihtiyaç duyuyorsa onu verelim.
        //IOC Container ile ProductService e ihtiyacı olanları bellekte newleme configürasyonu yaptık Startup.cs içinde.
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //alias verdik.
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
