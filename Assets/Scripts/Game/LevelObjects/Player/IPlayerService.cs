using System;

namespace Tanks.Game.Player
{
    public interface IPlayerService : IDisposable
    {
        IPlayerModel Model { get; }
        void Initialize();
        void Update(float deltaTime);
        void NextWeapon();
        void PreviousWeapon();
    }
}