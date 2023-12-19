using Domain.Logic;
using Domain.Models;
using Services.Factory.ViewModel;

namespace Features
{
    public class Feature : IFeature
    {
        public string ID { get; }
        public IModel Model { get; }
        public ILogicCollection LogicCollection { get; }
        public ViewModelsCollection ViewModels { get; set; }
        public ViewLogicCollection ViewsLogic { get; set; }
        public FeatureViewRoot ViewRoot { get; set; }

        public Feature(string id, IModel model)
        {
            ID = id;
            Model = model;
            LogicCollection = new LogicCollection();
        }
    }
}