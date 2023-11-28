using System;

namespace Services
{
    public interface ITickService
    {
        event Action<float> Tick;
    }
}