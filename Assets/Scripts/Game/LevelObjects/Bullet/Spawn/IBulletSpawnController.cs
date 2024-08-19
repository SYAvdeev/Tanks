using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Bullet
{
    public interface IBulletSpawnController : IDisposable
    {
        UniTask Initialize();
    }
}