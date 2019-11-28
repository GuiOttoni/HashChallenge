using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sone;

namespace ServiceOneApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET api/<controller>/5
        [HttpGet("{productid}/{userid}")]
        public async Task<ActionResult<Product>> Get(string productid, string userid)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var httpClient = new HttpClient(httpHandler);
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });

            var client = new ServiceOne.ServiceOneClient(channel);

            var reply = (await Task.Run(() => { return client.ProductDiscount(new ProductRequest { ProductId = productid, UserId = userid }); }));

            return Ok(reply);
        }


    }
}
