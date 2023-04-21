using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using Confluent.Kafka;
using E_Commerce.API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            await SendEvent(request, CancellationToken.None);
            return Ok();
        }

        [HttpGet]
        public async Task SendEvent(ProductRequest product, CancellationToken cancellationToken)
        {
            Console.WriteLine("dwadw");

            await Task.CompletedTask;

            Debug.WriteLine("SendEvent Finished");
        }


        //[HttpPost]
        //[Consumes(MediaTypeNames.Application.Json)]
        //public async Task<IActionResult> Post([FromBody] TopicContract contract)
        //{
        //    try
        //    {
        //        var config = new ProducerConfig
        //        {
        //            BootstrapServers = contract.BootstrapServer,
        //            ClientId = Dns.GetHostName()
        //        };

        //        using var producer = new ProducerBuilder<Null, string>(config).Build();
        //        var result = await producer.ProduceAsync(contract.Topic, new Message<Null, string>
        //        {
        //            Value = contract.Message
        //        });

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put([FromBody] TopicContract contract)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = contract.BootstrapServer,
                GroupId = $"{contract.Topic}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            CancellationTokenSource cts = new CancellationTokenSource();
            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe(contract.Topic);

            try
            {
                var cr = consumer.Consume(cts.Token);

                consumer.Close();
                return Ok(cr.Message.Value);
            }
            catch (Exception ex)
            {
                consumer.Close();
                return BadRequest(ex.Message);
            }
        }
    }
}
