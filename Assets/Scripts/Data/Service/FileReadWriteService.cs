using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Service
{
    public class FileReadWriteService : IDataReadWriteService
    {
        private readonly string _dataPath;
        private readonly IDataSerializeService _serializeService;

        public FileReadWriteService(string dataPath, IDataSerializeService serializeService)
        {
            _dataPath = dataPath;
            _serializeService = serializeService;
        }

        public void Delete(string name)
        {
            name = Path.Combine(_dataPath, name);
            File.Delete(name);
        }
        
        public async Task<bool> TryWrite(string name, IList<IModelData> data)
        {
            string jsonData = _serializeService.Serialize(data);
            bool success = true;

            await using StreamWriter writer = new StreamWriter(Path.Combine(_dataPath, name), false);
            
            try
            {
                await writer.WriteAsync(jsonData);
                await writer.FlushAsync();
            }
            catch (Exception exception)
            {
                success = false;
            }

            return success;
        }

        public async Task<(bool, IModelData)> TryRead(string name)
        {
            IModelData data = default(IModelData);
            name = Path.Combine(_dataPath, name);

            if (File.Exists(name) == false)
            {
                return (false, null);
            }

            using StreamReader reader = new StreamReader(name, false);
            
            try
            {
                string jsonString = await reader.ReadToEndAsync();
                data = _serializeService.Deserialize<ModelData>(jsonString);
            }
            catch (Exception exception)
            {
                return (false, data);
            }

            return (true, data);
        }
    }
}