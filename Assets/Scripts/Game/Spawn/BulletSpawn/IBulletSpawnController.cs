using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public interface IBulletSpawnController : IDisposable
    {
        UniTask Initialize();
    }
}