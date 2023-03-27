namespace Domain.LevelObjects.Config
{
    public class SpawnModelConfig
    {
        public readonly float PlayerSpawnPositionX;
        public readonly float PlayerSpawnPositionY;
        public readonly float EnemySpawnBorderOffset;
        public readonly int EnemiesCount;

        public SpawnModelConfig(float playerSpawnPositionX, float playerSpawnPositionY, float enemySpawnBorderOffset, int enemiesCount)
        {
            PlayerSpawnPositionX = playerSpawnPositionX;
            PlayerSpawnPositionY = playerSpawnPositionY;
            EnemySpawnBorderOffset = enemySpawnBorderOffset;
            EnemiesCount = enemiesCount;
        }
    }
}