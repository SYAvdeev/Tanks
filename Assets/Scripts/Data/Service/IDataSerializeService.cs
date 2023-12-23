namespace Data.Service
{
    public interface IDataSerializeService
    {
        string Serialize<T>(T data);
        T Deserialize<T>(string serializedData);
    }
}