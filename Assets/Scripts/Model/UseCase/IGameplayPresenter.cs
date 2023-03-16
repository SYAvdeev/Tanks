using System.Collections.Generic;
using Model.LevelObjects;

namespace Model.UseCase
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