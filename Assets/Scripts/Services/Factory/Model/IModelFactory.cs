using Data.Models;
using Domain.Models;
using ReactiveTypes;

namespace Services.Factory
{
    public interface IModelFactory
    {
        IModel CreateModel(IModelData modelData);
        IReactivePropertyReadonlyUntyped CreateModelProperty(ModelPropertyData modelPropertyData);
        IReactiveListReadOnlyUntyped CreateModelList(ModelListData modelListData);
    }
}