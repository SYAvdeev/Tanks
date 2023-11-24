using Data.Models;
using Domain.Models;

namespace Services
{
    public interface IModelFactoryService
    {
        IModel CreateModel(IModelData modelData);
        IModelProperty CreateModelProperty(ModelPropertyData modelPropertyData);
    }
}