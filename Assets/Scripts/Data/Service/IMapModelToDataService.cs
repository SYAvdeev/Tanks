using Data.Models;
using Domain.Models;

namespace Data.Service
{
    public interface IMapModelToDataService
    {
        void Map(IModelData modelData, IModel model);
    }
}