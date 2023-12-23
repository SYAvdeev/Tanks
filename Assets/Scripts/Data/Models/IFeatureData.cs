namespace Data.Models
{
    public interface IFeatureData
    {
        string ID { get; }
        IModelData ModelData { get; }
    }
}