using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IPlayerController : IDisposable
    {
        UniTask Initialize();
    }
}