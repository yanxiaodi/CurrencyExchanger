using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using YanSoft.CurrencyExchanger.WebApp.Models;
using YanSoft.CurrencyExchanger.WebApp.Utils;

namespace YanSoft.CurrencyExchanger.WebApp.Middlewares
{
    public class ValidateRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidateRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                if (!ValidateVersion(context, out ResponseInfo responseForVersion))
                {
                    await context.Response.WriteAsync(SerializerHelper.ToJson(responseForVersion));
                    return;
                }

                if (!ValidateToken(context, out ResponseInfo responseForToken))
                {
                    await context.Response.WriteAsync(SerializerHelper.ToJson(responseForVersion));
                    return;
                }
            }
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private bool ValidateVersion(HttpContext context, out ResponseInfo response)
        {
            response = new ResponseInfo();
            if (!context.Request.Headers.TryGetValue("version", out StringValues versions))
            {
                response.Message = "Authentication failed.";
                return false;
            }
            if (!int.TryParse(versions.First().ToString(), out int currentVersion))
            {
                response.Message = "Authentication failed.";
                return false;
            }
            if (currentVersion < Constants.MinClientAppVersion)
            {
                response.Message = "Authentication failed.";
                return false;
            }
            return true;
        }

        private bool ValidateToken(HttpContext context, out ResponseInfo response)
        {
            response = new ResponseInfo();
            if (!context.Request.Headers.TryGetValue("token", out StringValues tokens))
            {
                response.Message = "Authentication failed.";
                return false;
            }

            if (!context.Request.Headers.TryGetValue("sk", out StringValues saltKeys))
            {
                response.Message = "Authentication failed.";
                return false;
            }

            var token = tokens.First();
            var intTimestamp = token.Split('|')[0].Substring(7);
            if (!int.TryParse(intTimestamp, out var ts))
            {
                response.Message = "Authentication failed.";
                return false;
            }

            DateTime dtQueryTime = DateTimeHelper.ConvertTimestampToDateTime(ts);
            DateTime dtNow = DateTime.UtcNow;
            TimeSpan timeSpan = dtNow - dtQueryTime;
            if (timeSpan.Seconds > 20)
            {
                response.Message = "Authentication failed.";
                return false;
            }

            var saltKey = saltKeys.First();
            string tokenServer = GetToken(dtQueryTime, saltKey);
            if (token != tokenServer)
            {
                response.Message = "Authentication failed.";
                return false;
            }
            
            return true;
        }

        private string GetToken(DateTime timeNow, string saltKey)
        {
            int timeStamp = DateTimeHelper.ConvertDateTimeToTimestamp(timeNow.ToUniversalTime());
            string key = "*****";
            string value = $"ts={timeStamp.ToString()}&key={key}&sk={saltKey}";
            string signature = SHA1(value);
            signature = signature.Insert(7, timeStamp.ToString() + "|");
            return signature;
        }
        private string SHA1(string source)
        {
            byte[] value = Encoding.UTF8.GetBytes(source);
            var sha1 = new System.Security.Cryptography.SHA1Managed();
            var result = sha1.ComputeHash(value);
            string delimitedHexHash = BitConverter.ToString(result);
            string hexHash = delimitedHexHash.Replace("-", "");
            return hexHash;
        }

    }

}
