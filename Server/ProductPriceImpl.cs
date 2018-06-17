using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eshop.ProductPrice;
using Grpc.Core;

namespace Server
{
    public class ProductPriceImpl : IProductPrice.IProductPriceBase
    {
        public override async Task<ReturnProduct> GetProduceprice(RequestProduct request, ServerCallContext context)
        {
            return await Task.FromResult<ReturnProduct>(new ReturnProduct
            {
                ProductId = request.ProductId,
                Price = 500
            });
        }
    }
}
