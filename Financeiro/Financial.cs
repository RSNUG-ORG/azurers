using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Financeiro
{
    public static class Financial
    {
        [FunctionName("InterestFee")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");            

            decimal financingValue = decimal.Parse(req.Query["financingvalue"]);
            decimal quote = decimal.Parse(req.Query["quote"]);
            int paymentDeadline = int.Parse(req.Query["paymentdeadline"]);
            
            var taxas = new Taxas();
            var taxaJuros = taxas.CalcularTaxaJuros(financingValue, quote, paymentDeadline);            
            
            return new OkObjectResult(taxaJuros);
        }
    }
}
