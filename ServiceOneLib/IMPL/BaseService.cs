using ServiceOneLib.Database.Interface;

namespace ServiceOneLib.IMPL
{
    public class BaseService
    {
        protected ISqlDataContext dataContext = default;
    }
}
