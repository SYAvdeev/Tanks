using Tanks.Game.LevelObjects.Camera;
using Tanks.Game.LevelObjects.Player;
using Tanks.Game.Spawn.BulletSpawn;
using Tanks.Game.Spawn.EnemySpawn;
using Tanks.Game.Spawn.LevelSpawn;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tanks.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private LevelSpawnView _levelSpawnView;
        [SerializeField] private BulletSpawnView _bulletSpawnView;
        [SerializeField] private EnemySpawnView _enemySpawnView;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Camera _gameplayCamera;
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureLevelSpawn(builder);
            ConfigureBulletSpawn(builder);
            ConfigureEnemySpawn(builder);
            
            ConfigureCamera(builder);
            ConfigurePlayer(builder);
            ConfigureGameplay(builder);
            builder.RegisterEntryPoint<GameSceneStarter>();
        }

        private void ConfigureLevelSpawn(IContainerBuilder builder)
        {
            builder.Register<LevelSpawnData>(Lifetime.Scoped).AsSelf();
            builder.RegisterInstance(_levelSpawnView);
            builder.Register<LevelSpawnModel>(Lifetime.Scoped).As<ILevelSpawnModel>();
            builder.Register<LevelSpawnService>(Lifetime.Scoped).As<ILevelSpawnService>();
            builder.Register<LevelSpawnController>(Lifetime.Scoped).As<ILevelSpawnController>();
        }

        private void ConfigureBulletSpawn(IContainerBuilder builder)
        {
            builder.RegisterInstance(_bulletSpawnView);
            builder.Register<BulletSpawnModel>(Lifetime.Scoped).As<IBulletSpawnModel>();
            builder.Register<BulletSpawnService>(Lifetime.Scoped).As<IBulletSpawnService>();
            builder.Register<BulletSpawnController>(Lifetime.Scoped).As<IBulletSpawnController>();
        }

        private void ConfigureEnemySpawn(IContainerBuilder builder)
        {
            builder.RegisterInstance(_enemySpawnView);
            builder.Register<EnemySpawnModel>(Lifetime.Scoped).As<IEnemySpawnModel>();
            builder.Register<EnemySpawnService>(Lifetime.Scoped).As<IEnemySpawnService>();
            builder.Register<EnemySpawnController>(Lifetime.Scoped).As<IEnemySpawnController>();
        }

        private void ConfigureCamera(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameplayCamera);
            builder.Register<CameraModel>(Lifetime.Scoped).As<ICameraModel>();
            builder.Register<CameraService>(Lifetime.Scoped).As<ICameraService>();
            builder.Register<CameraController>(Lifetime.Scoped).As<ICameraController>();
        }

        private void ConfigurePlayer(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerView);
            builder.Register<PlayerModel>(Lifetime.Scoped).As<IPlayerModel>();
            builder.Register<PlayerService>(Lifetime.Scoped).As<IPlayerService>();
            builder.Register<PlayerController>(Lifetime.Scoped).As<IPlayerController>();
        }

        private void ConfigureGameplay(IContainerBuilder builder)
        {
            builder.Register<GameplayService>(Lifetime.Scoped).As<IGameplayService>();
        }
    }
}
