using Sone;
using System.Threading.Tasks;

namespace ServiceOneLib.Services.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<User> GetUser(string UserId);
    }
}
