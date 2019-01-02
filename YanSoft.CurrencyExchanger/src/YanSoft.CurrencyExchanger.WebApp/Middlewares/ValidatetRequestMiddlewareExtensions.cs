using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace YanSoft.CurrencyExchanger.WebApp.Middlewares
{
    public static class ValidatetRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidateRequest(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidateRequestMiddleware>();
        }
    }
}
