using Sone;
using System.Threading.Tasks;

namespace ServiceOneLib.IMPL.Interface
{
    public interface IUserService
    {
        Task<User> GetUser(string UserId);
    }
}
