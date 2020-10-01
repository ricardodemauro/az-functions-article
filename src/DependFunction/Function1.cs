using System;
using DependFunction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DependFunction
{
    public class Function1
    {
        private readonly IRandomNumber _randomService;

        public Function1(IRandomNumber randomService)
        {
            _randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
        }

        [FunctionName("Function1")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var result = new { random = _randomService.GetRandom() };

            return new OkObjectResult(result);
        }
    }
}
