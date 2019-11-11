using ServiceOneLib.Database.Interface;
using ServiceOneLib.Services.Interface;
using ServiceOneLib.Util;
using Sone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.Services
{
    public class ProductService : BaseService,IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dataContext"></param>
        public ProductService(ISqlDataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Product> GetProduct(string ProductId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>(){ { "ProductId", ProductId } };

            return await dataContext.SelectSingleAsync<Product>(StoredProcedure.GetProduct, parameters); ;
        }


    }
}
