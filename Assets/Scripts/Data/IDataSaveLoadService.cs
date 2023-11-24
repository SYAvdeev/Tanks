using System.Threading.Tasks;

namespace Data
{
    public interface IDataSaveLoadService
    {
        void Add(IDataset dataset);
        Task LoadAll();
        Task SaveAll();
    }
}