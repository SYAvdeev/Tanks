using System;
using System.Collections.Generic;
using Data.Service;

namespace Data.Models
{
    [Serializable]
    public class ModelDataset : IModelDataset
    {
        private List<IModelData> _dataCollection;
        private IDataMapperService _dataMapperService;
        private List<IModelData> _modelsData;

        public string Name { get; }
        public bool IsDirty { get; }
        public IEnumerable<IModelData> DataCollection => _modelsData;

        public void AddModelData(IModelData modelData)
        {
            
        }

        public void RemoveModelData(IModelData modelData)
        {
            
        }
    }
}