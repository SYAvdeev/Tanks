using System.Collections.Generic;
using Domain.Features;
using Domain.Models;

namespace Features
{
    public class Feature : IFeature
    {
        public string ID { get; }
        public IModel Model { get; }
        private IEnumerable<BaseViewModel> _viewModels;

        public Feature(string id, IModel model, IEnumerable<BaseViewModel> viewModels)
        {
            ID = id;
            Model = model;
            _viewModels = viewModels;
        }
    }
}