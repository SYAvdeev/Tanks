using System.Collections.Generic;
using Domain.LevelObjects;

namespace Domain.UseCase
{
    public interface IGameplayPresenter
    {
        public void StartGame();
        public void OnGameStarted(PlayerModel playerModel, List<EnemyModel> enemies);
        public void OnLose();
        public void OnShoot(BulletModel bulletModel);
        public void OnEnemySpawned(EnemyModel enemyModel);
    }
}