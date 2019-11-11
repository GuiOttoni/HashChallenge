using Sone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.Services.Interface
{
    public interface IProductService
    {
        Task<Product> GetProduct(string ProductId);

    }
}
