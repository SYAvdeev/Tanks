using Domain.Features;
using Domain.Logic;
using Domain.Models;

namespace Features
{
    public class Feature : IFeature, IViewsContainer
    {
        public string ID { get; }
        public IModel Model { get; }
        public ILogicCollection LogicCollection { get; }
        public ViewModelsCollection ViewModels { get; set; }
        public ViewLogicCollection ViewsLogic { get; set; }

        public Feature(string id, IModel model)
        {
            ID = id;
            Model = model;
            LogicCollection = new LogicCollection();
        }
    }
}