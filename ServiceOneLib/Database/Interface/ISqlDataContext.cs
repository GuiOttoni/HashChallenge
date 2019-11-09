using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneLib.Database.Interface
{
    public interface ISqlDataContext
    {
        string ConnectionString { get; }
        Task<IEnumerable<T>> SelectListAsync<T>(string procedure, Dictionary<string, object> parameters = null);
        Task<T> SelectSingleAsync<T>(string procedure, Dictionary<string, object> parameters = null);
    }
}
