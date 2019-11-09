using ServiceOneLib.IMPL.Interface;
using Sone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.IMPL
{
    public class ProductService : IProductService
    {
        public async Task<Product> GetProduct(string ProductId, string UserId)
        {
            //TODO: Get the product from database with ProductId and UserId
            //TODO: Apply the rules of discount
            return default;
        }
    }
}
