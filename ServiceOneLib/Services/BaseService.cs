using ServiceOneLib.Database.Interface;

namespace ServiceOneLib.Services
{
    public class BaseService
    {
        protected ISqlDataContext dataContext = default;
    }
}
