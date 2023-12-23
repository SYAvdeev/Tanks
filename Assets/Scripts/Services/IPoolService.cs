namespace Services
{
    public interface IPoolService<TObject>
    {
        bool TryGet(string key, out TObject feature);
        void Add(string key, TObject feature);
    }
}