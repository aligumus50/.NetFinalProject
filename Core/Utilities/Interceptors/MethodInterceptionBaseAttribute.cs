using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //classlara ve metotlara uygulanabilir.
    //Birden fazla kullanılabilir.(veritabanına logla, dosyaya logla)
    //inherit edilenede uygula.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Hangi attribute önce çalışsın. Önce loglama sonra authorization gibi.

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
