namespace Domain.Services
{
    public interface ILevelService
    {
        (float, float) CurrentSize { get; }
    }
}