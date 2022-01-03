using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //Bu tip toollar static yapılır. Tek bi instance oluşturulur ve uygulama belleği sadece onu kullanır.
    public static class ValidationTool
    {
        //static bir sınıfın metotlarıda statik olmalı. Javada böyle değil.
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator(); Bu işi IValidator yapıyor artık. onunda validate metotu var.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
