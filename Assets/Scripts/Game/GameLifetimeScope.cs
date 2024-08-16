using Tanks.Gameplay;
using Tanks.LevelObjects.Level.Spawn;
using VContainer;
using VContainer.Unity;

namespace Tanks.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureLevelSpawn(builder);
            ConfigureGameplay(builder);
        }

        private void ConfigureLevelSpawn(IContainerBuilder builder)
        {
            builder.Register<LevelSpawnData>(Lifetime.Scoped).AsSelf();
            builder.Register<LevelSpawnModel>(Lifetime.Scoped).As<ILevelSpawnService>();
            builder.Register<LevelSpawnService>(Lifetime.Scoped).As<ILevelSpawnService>();
            builder.Register<LevelSpawnController>(Lifetime.Scoped).As<ILevelSpawnController>();
        }

        private void ConfigureGameplay(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayService>().AsImplementedInterfaces();
        }
    }
}
