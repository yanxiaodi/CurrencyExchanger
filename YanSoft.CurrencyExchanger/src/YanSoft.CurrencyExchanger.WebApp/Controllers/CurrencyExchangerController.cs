using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YanSoft.CurrencyExchanger.WebApp.Models;
using YanSoft.CurrencyExchanger.WebApp.Services;

namespace YanSoft.CurrencyExchanger.WebApp.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyExchangerController : ControllerBase
    {
        private readonly IApiService apiService;
        public CurrencyExchangerController(IApiService apiService)
        {
            this.apiService = apiService;
        }


        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Returns all currencies.</response>
        /// <response code="404">If there is no currency.</response>           
        [Produces("application/json")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<ResponseInfo<List<Currency>>> GetCurrencies()
        {
            List<Currency> response = apiService.GetCurrencies();
            if (response.Any())
            {
                var result = new ResponseInfo<List<Currency>>
                {
                    IsSuccess = true,
                    Result = response.OrderBy(x => x.Code).ToList()
                };
                return result;
            }
            else
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// Gets the latest currency rates.
        /// </summary>
        /// <param name="baseCode">The base code.</param>
        /// <param name="targetCodes">The target codes.</param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ResponseInfo<CurrencyRatesResponse>>> GetLatestRates(string baseCode, string targetCodes)
        {
            if (string.IsNullOrEmpty(baseCode) || string.IsNullOrEmpty(targetCodes))
            {
                return new ResponseInfo<CurrencyRatesResponse>
                {
                    Message = "Unexpected params. 'baseCode' and 'targetCodes' should not be null."
                };
            }
            CurrencyRatesResponse response = await apiService.GetLatestRates(baseCode, targetCodes.Split(','));
            if(response.Rates.Count() == 0)
            {
                return new ResponseInfo<CurrencyRatesResponse>
                {
                    Message = "Service unavailable."
                };
            }
            else
            {
                var result = new ResponseInfo<CurrencyRatesResponse>
                {
                    IsSuccess = true,
                    Result = response
                };
                return result;
            }
        }

        // GET: api/CurrencyExchangerApi
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/CurrencyExchangerApi/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/CurrencyExchangerApi
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/CurrencyExchangerApi/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
