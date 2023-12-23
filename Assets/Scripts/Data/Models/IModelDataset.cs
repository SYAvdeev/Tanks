using System.Collections.Generic;

namespace Data.Models
{
    public interface IModelDataset
    {
        string Name { get; }
        IEnumerable<IModelData> DataCollection { get; }
        bool IsDirty { get; }
        void AddModelData(IModelData modelData);
        void RemoveModelData(IModelData modelData);
    }
}