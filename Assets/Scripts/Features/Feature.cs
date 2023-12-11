using System.Collections.Generic;
using Domain.Features;
using Domain.Logic;
using Domain.Models;

namespace Features
{
    public class Feature : IFeature
    {
        public string ID { get; }
        public IModel Model { get; }
        public ILogicCollection LogicCollection { get; }
        private IEnumerable<BaseViewModel> _viewModels;

        public Feature(string id, IModel model, IEnumerable<BaseViewModel> viewModels, ILogicCollection logicCollection)
        {
            ID = id;
            Model = model;
            _viewModels = viewModels;
            LogicCollection = logicCollection;
        }
    }
}