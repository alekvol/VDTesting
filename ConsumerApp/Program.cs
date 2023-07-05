using Confluent.Kafka;

namespace ConsumerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var config = new ConsumerConfig
            {
                GroupId = "test-consumers",
                BootstrapServers = "kafka:9092"
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("registrations");
                while (true)
                {
                    var bookingDetails = consumer.Consume();
                    Console.WriteLine(bookingDetails.Message.Value);
                }
            }
        }
    }
}