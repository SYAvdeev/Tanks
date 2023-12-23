using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Service
{
    public interface IDataReadWriteService
    {
        Task<bool> TryWrite(string name, IList<IModelData> dataset);
        Task<(bool, IModelData)> TryRead(string name);
        
    }
}