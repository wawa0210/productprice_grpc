using Eshop.ProductPrice;
using Grpc.Core;
using System;
using System.Threading;

namespace Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            var channel = new Channel("localhost:5003", ChannelCredentials.Insecure);

            var client = new IProductPrice.IProductPriceClient(channel);
            while (true)
            {
                var reply = client.GetProducepriceAsync(new RequestProduct { ProductId = 100 }).GetAwaiter().GetResult();
                Console.WriteLine("Greeting: " + reply.Price);
                Thread.Sleep(100);
            }
        }
    }
}
