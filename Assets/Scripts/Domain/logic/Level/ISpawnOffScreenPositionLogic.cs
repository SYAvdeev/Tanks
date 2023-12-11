namespace Domain.Logic.Level
{
    public interface ISpawnOffScreenPositionLogic : ILogic
    {
        (float, float) GetRandomOffScreenSpawnPosition();
    }
}