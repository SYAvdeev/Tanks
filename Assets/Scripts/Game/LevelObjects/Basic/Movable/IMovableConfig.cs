namespace Tanks.Game.LevelObjects.Basic
{
    public interface IMovableConfig
    {
        float Velocity { get; }
        bool IsRestricted { get; }
    }
}