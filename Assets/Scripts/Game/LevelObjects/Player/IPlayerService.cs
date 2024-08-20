using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IPlayerService : IDisposable
    {
        IPlayerModel Model { get; }
        IDamageableService DamageableService { get; }
        void Initialize();
        void Update(float deltaTime);
    }
}