using System;

namespace Tanks.Game.Player
{
    public interface IPlayerService : IDisposable
    {
        void Initialize();
        void Update(float deltaTime);
        void NextWeapon();
        void PreviousWeapon();
    }
}