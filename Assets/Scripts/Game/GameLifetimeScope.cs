using Tanks.Game.LevelObjects.Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tanks.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private LevelSpawnView _levelSpawnView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureLevelSpawn(builder);
            ConfigureGameplay(builder);
        }

        private void ConfigureLevelSpawn(IContainerBuilder builder)
        {
            builder.Register<LevelSpawnData>(Lifetime.Scoped).AsSelf();
            builder.RegisterInstance(_levelSpawnView);
            builder.Register<LevelSpawnModel>(Lifetime.Scoped).As<ILevelSpawnModel>();
            builder.Register<LevelSpawnService>(Lifetime.Scoped).As<ILevelSpawnService>();
            builder.Register<LevelSpawnController>(Lifetime.Scoped).As<ILevelSpawnController>();
        }

        private void ConfigureGameplay(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayService>();
        }
    }
}
