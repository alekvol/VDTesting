using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace ProducerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumansController : ControllerBase
    {
        private ProducerConfig _configuration;
        private readonly IConfiguration _config;
        public HumansController(ProducerConfig configuration, IConfiguration config)
        {
            _configuration = configuration;
            _config = config;
        }
        [HttpPost("sendHuman")]
        public async Task<ActionResult> Get([FromBody] HumanInfo employee)
        {
            string serializedData = JsonConvert.SerializeObject(employee);

            var topic = "registrations";

            using (var producer = new ProducerBuilder<Null, string>(_configuration).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedData });
                producer.Flush(TimeSpan.FromSeconds(10));
                return Ok(true);
            }
        }
    }
}
