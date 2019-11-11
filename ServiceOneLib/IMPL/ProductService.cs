using ServiceOneLib.Database.Interface;
using ServiceOneLib.IMPL.Interface;
using ServiceOneLib.Util;
using Sone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.IMPL
{
    public class ProductService : BaseService,IProductService
    {
        public ProductService(ISqlDataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public async Task<Product> GetProduct(string ProductId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>(){ { "ProductId", ProductId } };

            return await dataContext.SelectSingleAsync<Product>(StoredProcedure.GetProduct); ;
        }


    }
}
