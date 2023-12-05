using Cysharp.Threading.Tasks;

namespace Services
{
    public interface IPrototypeProvider
    {
        UniTask<T> Get<T>(string key);
        void Release(string key);
    }
}