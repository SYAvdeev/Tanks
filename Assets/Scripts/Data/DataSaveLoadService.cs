using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Service;

namespace Data
{
    public class DataSaveLoadService : IDataSaveLoadService
    {
        private readonly IDataReadWriteService _dataReadWriteService;
        private readonly IList<IDataset> _unitsOfWork;

        public DataSaveLoadService(IDataReadWriteService dataReadWriteService, IList<IDataset> unitsOfWork)
        {
            _dataReadWriteService = dataReadWriteService;
            _unitsOfWork = unitsOfWork;
        }

        public void Add(IDataset dataset)
        {
            _unitsOfWork.Add(dataset);
        }

        public async Task LoadAll()
        {
            for (int i = 0; i < _unitsOfWork.Count; i++)
            {
                await Load(_unitsOfWork[i]);
            }
        }

        public async Task SaveAll()
        {
            for (int i = 0; i < _unitsOfWork.Count; i++)
            {
                if (_unitsOfWork[i].IsDirty)
                {
                    
                }
            }
        }

        private async Task Save(IDataset dataset)
        {
            await _dataReadWriteService.TryRead(dataset.Name, dataset.)
        }
        
        private async Task Load(IDataset dataset)
        {
            await _dataReadWriteService.TryLoad<>(dataset.Name, dataset.)
        }
    }
}