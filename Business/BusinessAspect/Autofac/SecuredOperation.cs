using System;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspect.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;  //HTTP'ye her istek yapana ayrı context olçuşturması için

        public SecuredOperation(string roles)
        {   //Business'deki roller attribute olarak geldiği için ve de virgiül ile ayrıldığı için 
            //benim verdiğim string'i virgül ile ayır ve de yukarıye göre array haline getir diyorum
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(MessagesAuth.AuthorizationDenied);
        }
    }
}
