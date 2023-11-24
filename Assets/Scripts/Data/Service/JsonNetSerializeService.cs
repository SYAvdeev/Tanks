using Newtonsoft.Json;

namespace Data.Service
{
    public class JsonNetSerializeService : IDataSerializeService
    {
        public string Serialize(object data) => JsonConvert.SerializeObject(data);
        public T Deserialize<T>(string serializedData) => JsonConvert.DeserializeObject<T>(serializedData);
    }
}