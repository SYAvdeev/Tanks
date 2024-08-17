using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Bullet
{
    public interface IBulletModel
    {
        IMovableModel Movable { get; }
        IDamagerModel Damager { get; }
        ISpawnableModel Spawnable { get; }
        IBulletConfig Config { get; }
    }
}