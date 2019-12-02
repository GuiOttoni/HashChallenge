using Grpc.Net.Client;
using Sone;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceOneClientConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var httpClient = new HttpClient(httpHandler);
            var channel = GrpcChannel.ForAddress("https://172.18.0.1:5001/", new GrpcChannelOptions { HttpClient = httpClient });

            var client = new ServiceOne.ServiceOneClient(channel);

            while (true)
            {
                Console.WriteLine("product Id");
                var product = "1";//Console.ReadLine();
                Console.WriteLine("user Id");
                var user = "2";//Console.ReadLine();

                var reply = (await Task.Run(() => { return client.ProductDiscount(new ProductRequest { ProductId = product, UserId = user }); }));
                Console.WriteLine("\n Product:");
                Console.WriteLine($"{reply.Id}\n" +
                    $"{reply.Title}\n" +
                    $"{reply.PriceInCents}\n" +
                    $"{reply.Discount.ValueInCents}\n" +
                    $"{reply.Discount.Pct}\n" +
                    $"Final value: {(reply.PriceInCents - reply.Discount.ValueInCents)/10}");

                Console.WriteLine("Continue? S/N");
                var val = Console.ReadLine();
                if (val == "N")
                    break;
            }
        }
    }
}
