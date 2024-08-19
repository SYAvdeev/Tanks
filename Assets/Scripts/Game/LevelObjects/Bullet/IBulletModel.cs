using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Bullet
{
    public interface IBulletModel
    {
        IMovableModel Movable { get; }
        IDamagerModel Damager { get; }
        ISpawnableModel Spawnable { get; }
        IBulletConfig Config { get; }
    }
}