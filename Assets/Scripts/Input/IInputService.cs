using System;
using VContainer.Unity;

namespace Tanks.Input
{
    public interface IInputService : ITickable
    {
        bool IsMoveKeyPressed { get; }
        bool IsRotateClockwiseKeyPressed { get; }
        bool IsRotateCounterClockwiseKeyPressed { get; }
        event Action ShootKeyDown;
        event Action NextWeaponKeyDown;
        event Action PreviousWeaponKeyDown;
    }
}