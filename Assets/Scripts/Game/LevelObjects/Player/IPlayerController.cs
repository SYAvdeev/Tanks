using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IPlayerController : IDisposable
    {
        void Initialize();
        UniTask InstantiateWeaponViews();
    }
}