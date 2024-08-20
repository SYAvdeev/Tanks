using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Game
{
    public interface IGameplayService : IDisposable
    {
        UniTask StartGameAsync();
    }
}