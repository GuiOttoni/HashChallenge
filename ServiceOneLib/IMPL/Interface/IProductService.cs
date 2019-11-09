using Sone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.IMPL.Interface
{
    public interface IProductService
    {
        Task<Product> GetProduct(string ProductId, string UserId);
    }
}
