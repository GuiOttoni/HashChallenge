using Grpc.Core;
using Sone;
using System.Threading.Tasks;

namespace ServiceOneServer.IMPL
{
    public class ServiceOneImpl : ServiceOne.ServiceOneBase
    {

        // Server side handler of the SayHello RPC
        public override Task<Product> ProductDiscount(ProductRequest request, ServerCallContext context)
        {
            //GET PRODUCT FROM DATABASE
            //SET PRODUCT DISCOUNT

            return Task.FromResult(new Product
            {
                IdProduto = request.IdProduto,
                Title = "teste"
            });
        }

    }
}
