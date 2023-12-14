namespace Services.Pool
{
    public interface IPoolService<TObject>
    {
        bool TryGet(string key, out TObject obj);
        void Add(string key, TObject obj);
    }
}