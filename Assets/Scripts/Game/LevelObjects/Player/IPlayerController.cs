using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Game.Player
{
    public interface IPlayerController : IDisposable
    {
        UniTask Initialize();
    }
}