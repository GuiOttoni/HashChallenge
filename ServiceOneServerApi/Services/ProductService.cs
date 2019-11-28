using Grpc.Core;
using ServiceOneLib.Impl;
using ServiceOneLib.Services.Interface;
using Sone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOneServerApi.Services
{
    public class ProductService : ServiceOne.ServiceOneBase
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_productService"></param>
        /// <param name="_userService"></param>
        public ProductService(IProductService _productService, IUserService _userService) : base()
        {
            userService = _userService;
            productService = _productService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<Product> ProductDiscount(ProductRequest request, ServerCallContext context)
        {
            User _user = await userService.GetUser(request.UserId);
            Product _product = await productService.GetProduct(request.ProductId);

            DiscountRules.ApplyDiscountRules(_product, _user);

            return await Task.FromResult(_product);
        }
    }
}
