namespace Data.Service
{
    public interface IDataSerializeService
    {
        string Serialize(object data);
        T Deserialize<T>(string serializedData);
    }
}