using Grpc.Core;
using ServiceOneLib.IMPL.Interface;
using Sone;
using System.Threading.Tasks;

namespace ServiceOneServer.IMPL
{
    public class ServiceOneImpl : ServiceOne.ServiceOneBase
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        public ServiceOneImpl()
        {
        }

        public ServiceOneImpl(IProductService _productService, IUserService _userService) : base()
        {
            userService = _userService;
            productService = _productService;
        }

        // Server side handler of the SayHello RPC
        public override async Task<Product> ProductDiscount(ProductRequest request, ServerCallContext context)
        {
            User _user = await userService.GetUser(request.UserId);
            Product _product = await productService.GetProduct(request.ProductId);
            
            //SET PRODUCT DISCOUNT

            return await Task.FromResult(new Product
            {
                Id = request.ProductId,
                Title = "teste"
            });
        }

    }
}
