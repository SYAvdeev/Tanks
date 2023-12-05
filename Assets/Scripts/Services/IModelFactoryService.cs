using Data.Models;
using Domain.Models;

namespace Services
{
    public interface ModelFactoryService
    {
        IModel CreateModel(IModelData modelData);
        IModelProperty CreateModelProperty(ModelPropertyData modelPropertyData);
    }
}