using Eshop.ProductPrice;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        const int port = 5003;

        static void Main(string[] args)
        {
            var server = new Grpc.Core.Server
            {
                Services = { IProductPrice.BindService(new ProductPriceImpl()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };
            server.Start();

            Task.Run(() =>
            {
                ClientImpl();
            });

            Console.WriteLine("hello the world!");

            Console.ReadLine();
        }

        static async void ClientImpl()
        {
        }
    }
}
