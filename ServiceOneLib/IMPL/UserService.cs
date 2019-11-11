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
    public class UserService : BaseService, IUserService 
    {
        public UserService(ISqlDataContext _dataContext) : base()
        {
            dataContext = _dataContext;
        }

        public async Task<User> GetUser(string UserId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "UserId", UserId } };

            return await dataContext.SelectSingleAsync<User>(StoredProcedure.GetUser, parameters);
        }
    }
}
