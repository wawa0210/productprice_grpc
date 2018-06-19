using Eshop.ProductPrice;
using Grpc.Core;
using System;
using System.Threading;
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
                Ports = { new ServerPort("0.0.0.0", port, ServerCredentials.Insecure) }
            };
            server.Start();

            Task.Run(() =>
            {
                ClientImpl();
            });

            while (true)
            {
                Console.WriteLine("hello the world!");
                Thread.Sleep(100);
            }


        }

        static async void ClientImpl()
        {
        }
    }
}
