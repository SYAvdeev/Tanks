namespace Domain.Logic.Level
{
    public interface ISpawnPositionLogic
    {
        (float, float) GetRandomOffScreenSpawnPosition();
    }
}