using Data.Models;
using Domain.Models;

namespace Data.Service
{
    public interface IDataMapperService
    {
        void MapModelToData(IModelData modelData, IModel model);
    }
}